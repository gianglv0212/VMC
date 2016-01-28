using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using VMC.Model;
using System.Data;
using VMC.EO;
using VMC.Common;

namespace VMC
{
    public partial class Login : System.Web.UI.Page
    {
        public int failded;
        protected void Page_Load(object sender, EventArgs e)
        {
            failded = 0;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                User us = new User();
                DataSet ds = us.Login(txtuser.Text, Common.Common.MD5Hash(txtpass.Text));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    LoginEO user = new LoginEO();
                    user.uid = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
                    user.fullname = Convert.ToString(ds.Tables[0].Rows[0]["fullname"]);
                    user.roles = Convert.ToString(ds.Tables[0].Rows[0]["roles"]);
                    user.avatar = Convert.ToString(ds.Tables[0].Rows[0]["avatar"]);
                    user.uname = txtuser.Text;
                    Session["uid"] = user;

                    //Session["uname"] = txtuser.Text;
                    //Session["uid"] = ds.Tables[0].Rows[0]["id"];
                    //Session["name"] = ds.Tables[0].Rows[0]["fullname"];
                    //Session["roles"] = ds.Tables[0].Rows[0]["roles"];
                    //Session["avatar"] = ds.Tables[0].Rows[0]["avatar"];
                    Response.Redirect("Default");
                }
                else
                {
                    txtuser.Text = "";
                    txtuser.Focus();
                    failded = 1;
                }
            }
        }
    }
}