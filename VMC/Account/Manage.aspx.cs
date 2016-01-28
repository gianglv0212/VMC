using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.UI.WebControls;

using Microsoft.AspNet.Membership.OpenAuth;
using VMC.Model;
using System.Data;

namespace VMC.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        protected void Page_Load()
        {

            BindData("");
        }
        private void BindData(string FullName)
        {
            grvUser.DataSource = (new User()).UserList(FullName);
            grvUser.DataBind();
        }
        protected void grvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (Avatar.ImageUrl.ToString().Equals("")) Avatar.ImageUrl = "/Uploads/Core/noimg.jpg";
            }
        }

        protected void grvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblmess.Text = "";
            try
            {
                if(e.CommandName == "cmdDelete")
                {
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    (new User()).User_Delete(id);
                    BindData("");

                }
            }
            catch(Exception ex)
            {
                lblerror.Text = ex.ToString();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string fname = txtQuery.Text;
                BindData(fname.ToString());
            }
            catch(Exception ex)
            {
                lblerror.Text = ex.ToString();
            }
        }

    }
}