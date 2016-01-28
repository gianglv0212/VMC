using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMC.Model;
using VMC.EO;

namespace VMC.Movie
{
    public partial class Add : System.Web.UI.Page
    {
        public DataSet ds;
        public int error = -1;
        public int success = 0;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                setEvent();
                getTag();
                getCateMovie();
                getDevice();
                getDirector();
                getActor();
                getCountry();
            }

        }
        private void setEvent()
        {
            avatar.Attributes.Add("width", "350px");
            avatar.Attributes.Add("height", "285px");
            poster.Attributes.Add("width", "200px");
            poster.Attributes.Add("height", "190px");
            avatarinput.Attributes.Add("onchange", "readURL(this,'avatar','output1');");
            posterinput.Attributes.Add("onchange", "readURL(this,'poster','output2');");
        }
        private void getTag()
        {
            lbTag.DataSource = (new TagModel()).Tag_Select(1);
            lbTag.DataTextField = "name";
            lbTag.DataValueField = "id";
            lbTag.DataBind();
        }
        private void getCountry()
        {
            lbcountry.DataSource = (new MovieModel()).Country_Select();
            lbcountry.DataTextField = "name";
            lbcountry.DataValueField = "id";
            lbcountry.DataBind();
        }
        private void getDevice()
        {
            lbDevice.DataSource = (new DeviceModel()).Device_Select(1);
            lbDevice.DataTextField = "name";
            lbDevice.DataValueField = "id";
            lbDevice.DataBind();
        }
        private void getCateMovie()
        {
            lbCate.DataSource = (new CateModel()).Category_Select("",0);
            lbCate.DataTextField = "name";
            lbCate.DataValueField = "id";
            lbCate.DataBind();
        }
        private void getDirector()
        {
            lbdirector.DataSource = (new DirectorModel()).Director_Select();
            lbdirector.DataTextField = "name";
            lbdirector.DataValueField = "id";
            lbdirector.DataBind();
        }
        private void getActor()
        {
            lbactor.DataSource = (new ActorModel()).Actor_Select();
            lbactor.DataTextField = "name";
            lbactor.DataValueField = "id";
            lbactor.DataBind();
        }
        protected void btnaddvideo_Click(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                error = Validate_Video();
                if (error == 0)
                {
                    Array DataInput = getValueItem();
                    int videoid = Convert.ToInt32((new MovieModel()).Movie_Insert(DataInput));
                    if( videoid > 0)
                    {
                        getValueListBox(lbCate, videoid, 4);
                        getValueListBox(lbTag, videoid, 5);
                        getValueListBox(lbDevice, videoid, 6);
                        getValueListBox(lbactor, videoid, 9);
                        getValueListBox(lbdirector, videoid, 8);
                        getValueListBox(lbcountry, videoid, 7);
                        ResetForm();
                        success = 1;
                    }else
                    {
                        error = 0;
                    }
                    
                }  
            }
        }
        private void getValueListBox(ListBox lb, int videoid, int type)
        {
           
            foreach (int i in lb.GetSelectedIndices())
            {
                VideoModel vm = new VideoModel();
                vm.Video_Insert_Option(videoid, Convert.ToInt32(lb.Items[i].Value), type);
            }

        }
        private Array getValueItem()
        {
            Array files = UploadFile();
            string [] arr = new string[11];
            arr[0] = txtName.Text;
            arr[1] = txtFullName.Text;
            arr[2] = txtDescription.Text;
            arr[3] = txtReleaseYear.Text;
            arr[4] = ddlType.SelectedValue.ToString();
            //arr[5] = (txtOrders.Text != "") ? txtOrders.Text : 0;          
            arr[5] = files.GetValue(0).ToString();
            arr[6] = files.GetValue(1).ToString();
            arr[7] = (status.Checked == true) ? "1" : "0";
            arr[8] = Common.Common.getUserInfo().uid.ToString();
            arr[9] = Common.Common.getUserInfo().uname.ToString();
            return arr;  
        }
        private Array UploadFile()
        {
            string[] arr = new string[2];
            string file1, file2;
            if (Page.IsValid && avatarinput.HasFile)
            {
                file1 = "/Uploads/Movie/IMGS/Avatar/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + avatarinput.FileName;
                string filePath = MapPath(file1);
                avatarinput.SaveAs(filePath);
                arr[0] = file1;
            }
            else arr[0] = "/Uploads/Core/noimg.jpg";
            if (Page.IsValid && posterinput.HasFile)
            {
                file2 = "/Uploads/Movie/IMGS/Poster/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + posterinput.FileName;
                string filePath = MapPath(file2);
                avatarinput.SaveAs(filePath);
                arr[1] = file2;
            } else
                arr[1] = "/Uploads/Core/noimg.jpg";
            return arr;
        }
        private void ResetForm()
        {
            txtName.Text = "";
            txtFullName.Text = "";
            //txtOrders.Text = "";
            txtReleaseYear.Text = "";
            lbCate.SelectedIndex = -1;
            //lbCate.Items.FindByValue("8").Selected = true; lbCate.Items.FindByValue("9").Selected = true;
            //lbCate.Items.FindByValue("10").Selected = true;
            lbDevice.SelectedIndex = -1;
            lbTag.SelectedIndex = -1;
            lblName.Text = "";
            lblCate.Text = "";
            lblFullName.Text = "";
            lblReleaseYear.Text = "";
        }

        private int Validate_Video()
        {
            string res = "";
            int j;
            foreach(int i in lbCate.GetSelectedIndices())
            {
                res += lbCate.Items[i].Value.ToString();
            }
            if (txtName.Text == "" || txtFullName.Text == "" || txtReleaseYear.Text == "" || res == "" || int.TryParse(txtReleaseYear.Text, out j) == false)
            {
                if (txtName.Text == "") lblName.Text = "Tên phim không được để trống";
                if (txtFullName.Text == "") lblFullName.Text = "Tên phim gốc không được để trống";
                if (txtReleaseYear.Text == "" || int.TryParse(txtReleaseYear.Text, out j) == false) lblReleaseYear.Text = "Năm phát hành phải là số";
                if (res == "") lblCate.Text = "Bạn chưa chọn thể loại hoặc thể loại không phù hợp";
                return 1;
            }else  return 0;
        }
    }
}