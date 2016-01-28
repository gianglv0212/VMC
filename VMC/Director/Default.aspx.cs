using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using VMC.Model;

namespace VMC.Director
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/Login");
            }
            BindData();
        }
        private void BindData()
        {
            gvdirector.DataSource = (new DirectorModel()).Director_Select();
            gvdirector.DataBind();

        }
        protected void gvdirector_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvdirector.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void gvdirector_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Image avatar = (Image)e.Row.FindControl("avatar");
            //    if (avatar.ImageUrl == "")
            //        avatar.ImageUrl = "/Uploads/Core/noimg.jpg";
            //}
        }
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            LinkButton lbtnDelete = (LinkButton)sender;
            Int32 id = Convert.ToInt32(lbtnDelete.CommandArgument);
            (new DirectorModel()).Director_Delete(id);
            BindData();
        }

        protected void gvdirector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}