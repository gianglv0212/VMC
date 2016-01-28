using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMC.EO;
using System.Data;
using System.Web.Routing;
using VMC.Model;

namespace VMC
{
    public partial class SiteMaster : MasterPage
    {
        public string success;
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        //public LoginEO objUser
        //{
        //    get { return (LoginEO)ViewState["objUser"]; }
        //    set { ViewState["objUser"] = value; }
        //}

        public LoginEO objUser { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                 objUser = new LoginEO();
                 objUser = (LoginEO)Session["uid"];
                //check role
                int i;
                string path = HttpContext.Current.Request.Url.AbsolutePath;
                string[] arr = path.Split('/');
                if (int.TryParse(arr[arr.Length - 1].ToString(), out i))
                {
                    path = "";
                    for(int j=0; j < arr.Length - 1; j++)
                    {
                        if(j == arr.Length -2)
                            path += arr[j];
                        else
                            path += arr[j] + "/";
                    }
                }
                //get linkid
                
                DataSet dsLink = (new RoleModel()).Link_SelectByPath(path);
                if(dsLink != null && dsLink.Tables.Count > 0 && dsLink.Tables[0].Rows.Count > 0)
                {
                    int linkid = Convert.ToInt32(dsLink.Tables[0].Rows[0]["id"]);
                    DataSet dsPermission = (new RoleModel()).Role_CheckLink(Convert.ToInt32(objUser.roles), linkid);
                    if (dsPermission == null || dsPermission.Tables.Count == 0 || dsPermission.Tables[0].Rows.Count == 0)
                        Response.Redirect("/Login");
                }

    
            }
            else
                Response.Redirect("/Login");
        }
    }
}