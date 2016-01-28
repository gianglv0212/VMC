using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using VMC.Common;
using VMC.Model;

namespace VMC.Movie
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url;
            if (Common.Common.getQueryString("ID") != null)
                url = "/Publics/Default?type=0&ID=" + Common.Common.getQueryString("ID").ToString();
            else
                url = "/Publics/Default";
            IfUpload.Attributes.Add("src", url);

            if (!IsPostBack)
            {
                setEvent();
                int id;
                id = Convert.ToInt32(Common.Common.getQueryString("ID"));
                DataDefault(id);
                CateDefault(id);
            }
        }
        public void btnupdatevideo_Click(object sender, EventArgs e)
        {
            int error = Validate_Video();
            if (error == 0)
            {
                int videoid = Convert.ToInt32(hdid.Value);
                Array DataInput = getValueItem();
                if ((new MovieModel()).Movie_Update(DataInput, videoid))
                {
                    DeleteOption(videoid, "4,5,6,7,8,9");
                    getValueListBox(lbCate, videoid, 4);
                    getValueListBox(lbTag, videoid, 5);
                    getValueListBox(lbDevice, videoid, 6);
                    getValueListBox(lbactor, videoid, 9);
                    getValueListBox(lbdirector, videoid, 8);
                    getValueListBox(lbcountry, videoid, 7);

                    Response.Redirect("/Movie?success=update");
                }
            }
        }
        private Array getValueItem()
        {
            Array files = UploadFile();
            string[] arr = new string[11];
            arr[0] = txtname.Text;
            arr[1] = txtfullname.Text;
            arr[2] = txtDescription.Text;
            arr[3] = txtreleaseyear.Text;
            arr[4] = ddlType.SelectedValue.ToString();
            arr[5] = (files.GetValue(0).ToString().Equals("")) ? avatar.ImageUrl.ToString() : files.GetValue(0).ToString();
            arr[6] = (files.GetValue(1).ToString().Equals("")) ? avatar.ImageUrl.ToString() : files.GetValue(1).ToString();
            arr[7] = (status.Checked == true) ? "1" : "0";
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
            else arr[0] = "";
            if (Page.IsValid && posterinput.HasFile)
            {
                file2 = "/Uploads/Movie/IMGS/Poster/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + posterinput.FileName;
                string filePath = MapPath(file2);
                avatarinput.SaveAs(filePath);
                arr[1] = file2;
            }
            else
                arr[1] = "";
            return arr;
        }
        private void getValueListBox(ListBox lb, int videoid, int type)
        {

            foreach (int i in lb.GetSelectedIndices())
            {
                VideoModel vm = new VideoModel();
                vm.Video_Insert_Option(videoid, Convert.ToInt32(lb.Items[i].Value), type);
            }

        }
        private void DeleteOption(Int32 id, String sType)
        {

            (new OptionVideoModel()).OptionVideo_Delete(id, sType);
        }
        private void CateDefault(Int32 id)
        {
            getTag(id);
            getDevice(id);
            getCateVideo(id);
            getActor(id);
            getCountry(id);
            getDirector(id);

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
        
        private void setDefaultListbox(ListBox lt, Int32 id, Int16 type)
        {
            DataSet ds = (new OptionVideoModel()).Option_Select(id, type);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    foreach (ListItem item in lt.Items)
                    {
                        if (item.Value.Equals(ds.Tables[0].Rows[i]["optionid"].ToString()))
                            item.Selected = true;
                    }
                }
            }
        }
        private void getTag(Int32 id)
        {
            lbTag.DataSource = (new TagModel()).Tag_Select(1);
            lbTag.DataTextField = "name";
            lbTag.DataValueField = "id";
            lbTag.DataBind();
            setDefaultListbox(lbTag, id, 5);
        }
        private void getDirector(Int32 id)
        {
            lbdirector.DataSource = (new DirectorModel()).Director_Select();
            lbdirector.DataTextField = "name";
            lbdirector.DataValueField = "id";
            lbdirector.DataBind();
            setDefaultListbox(lbdirector, id, 8);
        }
        private void getActor(Int32 id)
        {
            lbactor.DataSource = (new ActorModel()).Actor_Select();
            lbactor.DataTextField = "name";
            lbactor.DataValueField = "id";
            lbactor.DataBind();
            setDefaultListbox(lbactor, id, 9);
        }
        private void getCountry(Int32 id)
        {
            lbcountry.DataSource = (new DeviceModel()).Device_Select(1);
            lbcountry.DataTextField = "name";
            lbcountry.DataValueField = "id";
            lbcountry.DataBind();
            setDefaultListbox(lbcountry, id, 7);
        }
        private void getDevice(Int32 id)
        {
            lbDevice.DataSource = (new DeviceModel()).Device_Select(1);
            lbDevice.DataTextField = "name";
            lbDevice.DataValueField = "id";
            lbDevice.DataBind();
            setDefaultListbox(lbDevice, id, 6);
        }
        private void getCateVideo(Int32 id)
        {
            lbCate.DataSource = (new CateModel()).Category_Select("", 0);
            lbCate.DataTextField = "name";
            lbCate.DataValueField = "id";
            lbCate.DataBind();
            setDefaultListbox(lbCate, id, 4);
        }
        private void DataDefault(Int32 id)
        {
            DataSet ds;
            ds = (new MovieModel()).Movie_SelectById(id);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hdid.Value = id.ToString();
                txtname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                txtfullname.Text = ds.Tables[0].Rows[0]["fullname"].ToString();
                txtDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
                txtreleaseyear.Text = ds.Tables[0].Rows[0]["releaseyear"].ToString();
                ddlType.SelectedValue = ds.Tables[0].Rows[0]["videotype"].ToString();
                avatar.ImageUrl = ds.Tables[0].Rows[0]["avatar"].ToString();
                poster.ImageUrl = ds.Tables[0].Rows[0]["poster"].ToString();
                if (ds.Tables[0].Rows[0]["status"].ToString().Equals("1")) status.Checked = true;
                else status.Checked = false;
            }
        }


        private int Validate_Video()
        {
            string res = "";
            int j;
            foreach (int i in lbCate.GetSelectedIndices())
            {
                res += lbCate.Items[i].Value.ToString();
            }
            if (txtname.Text == "" || txtfullname.Text == "" || txtreleaseyear.Text == "" || res == "" || int.TryParse(txtreleaseyear.Text, out j) == false)
            {
                if (txtname.Text == "") lblname.Text = "Tên phim không được để trống";
                if (txtfullname.Text == "") lblfullname.Text = "Tên phim gốc không được để trống";
                if (txtreleaseyear.Text == "" || int.TryParse(txtreleaseyear.Text, out j) == false) lblreleaseyear.Text = "Năm phát hành phải là số";
                if (res == "") lblCate.Text = "Bạn chưa chọn thể loại hoặc thể loại không phù hợp";
                return 1;
            }
            else return 0;
        }
    }
}