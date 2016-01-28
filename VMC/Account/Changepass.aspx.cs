using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMC.Model;
using VMC.Common;


namespace VMC.Account
{
    public partial class Changepass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Int32 id;
                if (Common.Common.getQueryString("ID").ToString() != "" && Convert.ToInt32(Common.Common.getUserInfo().roles.ToString()) == 1)
                    id = Convert.ToInt32(Common.Common.getQueryString("ID"));
                else id = Convert.ToInt32(Common.Common.getUserInfo().uid.ToString());

                SetDataDefault(id);
            }
        }
        private void SetDataDefault(Int32 id)
        {
            DataSet ds = (new User()).User_GetById(id);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hdfid.Value = id.ToString();
                //txtpasswordold.Text = "123456";

                //txtpassword.Text = ds.Tables[0].Rows[0]["pass"].ToString();
            }
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            try
            {
                string pass;
                Int32 id;
                id = Convert.ToInt32(hdfid.Value);
                if (txtpassword.Text == txtrepassword.Text)
                {
                    pass = Common.Common.MD5Hash(txtpassword.Text);
                    if ((new User()).User_Changepass(id, pass))
                    {
                        if (Common.Common.getUserInfo().roles.ToString() == "1")
                        {
                            Response.Redirect("Manage?success_up");
                        }
                        else Response.Redirect("/Logout");
                    }
                    else
                        lblerror.Text = "Vui lòng nhập lại";
                }else
                {
                    lblerror.Text = "Mật khẩu mới và nhập lại mật khẩu không khớp";
                }
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.ToString();
            }
        }
    }
}