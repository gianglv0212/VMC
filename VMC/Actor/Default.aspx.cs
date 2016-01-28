using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMC.Model;
using System.Data;

namespace VMC.Actor
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null) Response.Redirect("/Login");
            BindData();
        }
        private void BindData()
        {
            gvactor.DataSource = (new ActorModel()).Actor_Select();
            gvactor.DataBind();

        }
        protected void gvactor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvactor.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void gvactor_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gvactor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}