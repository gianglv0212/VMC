using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Data;
using System.Data.SqlClient;
using VMC.Model;
using VMC.Common;


namespace VMC.Account
{
    public partial class Register : Page
    {
        Boolean check;
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
            if(!IsPostBack)  getRole();
        }

        private void getRole()
        {
            ddlRole.DataSource = (new User()).GetRoles();
            ddlRole.DataTextField = "name";
            ddlRole.DataValueField = "id";
            ddlRole.DataBind();
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {

            //FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            //string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            //if (!OpenAuth.IsLocalUrl(continueUrl))
            //{
            //    continueUrl = "~/";
            //}
            //Response.Redirect(continueUrl);
        }
        public void btnCreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                string username, pass, email, fullname;
                Int32 roleID;
                username = UserName.Text;
                pass = Common.Common.MD5Hash(Password.Text);
                email = Email.Text;
                fullname = Full.Text;
                roleID = Convert.ToInt32(ddlRole.SelectedValue);

                if ((new User()).User_Register(username, pass, roleID, fullname, email))
                    lblmess.Text = "Tài khoản đã được tạo thành công" + roleID.ToString();
                else
                    lblerror.Text = "Tài khoản chưa được tạo. Vui lòng nhập lại";
            }
            catch(Exception ex)
            {
                lblerror.Text = ex.ToString();
            }
        }
    }
}