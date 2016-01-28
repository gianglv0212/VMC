using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMC.Model;
using VMC.Common;
using System.Data;

namespace VMC.Account
{
    public partial class Accountinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Int32 id;
                if (Common.Common.getQueryString("ID").ToString() != "" && Convert.ToInt32(Common.Common.getUserInfo().roles.ToString()) == 1)
                    id = Convert.ToInt32(Common.Common.getQueryString("ID"));
                else id = Convert.ToInt32(Common.Common.getUserInfo().uid.ToString());
                //lblerror.Text = id.ToString();
                SetDataDefault(id);
            }
        }
        private void SetDataDefault(Int32 id)
        {
            DataSet ds = (new User()).User_GetById(id);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hdfid.Value = id.ToString();
                fullname.Text = ds.Tables[0].Rows[0]["fullname"].ToString();
                username.Text = ds.Tables[0].Rows[0]["username"].ToString();
                email.Text = ds.Tables[0].Rows[0]["email"].ToString();
                avatar.ImageUrl = ds.Tables[0].Rows[0]["avatar"].ToString();
                avatar.Attributes.Add("width", "96px");
                DataSet dsRole = (new User()).GetRoles();
                lbRole.DataSource = dsRole;
                lbRole.DataTextField = "name";
                lbRole.DataValueField = "id";
                lbRole.DataBind();
                lbRole.SelectedValue = ds.Tables[0].Rows[0]["roles"].ToString();
                //Common.FillData.FillDataListBox(dsRole, ds, lbRole, "name", "id", "roles");
                if (Common.Common.getUserInfo().roles.ToString() != "1")
                    lbRole.Attributes.Add("disabled", "");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string mail, full,avat;
                Int32 roleID, id;
                mail = email.Text;
                full = fullname.Text;
                roleID = Convert.ToInt32(lbRole.SelectedValue.ToString());
                id = Convert.ToInt32(hdfid.Value);
                avat = User_Upload();
                if ((new User()).User_Update(id, roleID, full, mail, avat))
                {
                    if (Common.Common.getQueryString("ID") != null && Common.Common.getUserInfo().roles.ToString().Equals("1"))
                    {
                        Response.Redirect("Manage?success_up");
                    }
                    else Response.Redirect("/Logout");
                }
                    
                else
                    lblerror.Text = "Vui lòng nhập lại";
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.ToString();
            }
        }
        private string User_Upload()
        {
            string fileName = "";
            if (Page.IsValid && avatarinput.HasFile)
            {
                fileName = "/Uploads/User/IMGS/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + avatarinput.FileName;
                string filePath = MapPath(fileName);
                avatarinput.SaveAs(filePath);
            }
            else fileName = avatar.ImageUrl.ToString();
            return fileName;
        }
        

    }
}