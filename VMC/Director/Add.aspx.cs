using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using VMC.Model;
using VMC.EO;

namespace VMC.Director
{
    public partial class Add : System.Web.UI.Page
    {
        public Boolean check;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["uid"] == null)
            //{
            //    Response.Redirect("/Login");
            //}
            avatarinput.Attributes.Add("onchange", "readURL(this,'avatar','output1');");
        }

        protected void btndirector_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string fileName = "";
                if (txtName.Text != "")
                {
                    if (Page.IsValid && avatarinput.HasFile)
                    {
                        fileName = "/Uploads/Director/IMGS/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + avatarinput.FileName;
                        string filePath = MapPath(fileName);
                        avatarinput.SaveAs(filePath);
                    }

                    //bool chkstatus;
                    String name, description, uname, avatar;
                    int type, status, uid;
                    name = txtName.Text;
                    description = txtDescription.Text;
                    uname = Common.Common.getUserInfo().uname.ToString();
                    avatar = (fileName == "") ? "/Uploads/Core/noimg.jpg" : fileName;
                    type = 1;
                    status = 1;
                    uid = Convert.ToInt32(Common.Common.getUserInfo().uid.ToString());
                    if ((new DirectorModel()).Director_Insert(name, description, status, uid, uname, type, avatar))
                        check = true;
                    else
                        check = false;
                }
                else
                {
                    lblName.Text = "Bạn cần nhập nội dung";
                    txtName.Focus();
                }
            }
        }

    }
}