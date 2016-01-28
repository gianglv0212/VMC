using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMC.Model;

namespace VMC.Category
{
    public partial class Video : System.Web.UI.Page
    {
        public string status;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null) Response.Redirect("/Login");
            setAttr();
            if (Request.QueryString["status"] != null)
            {
                status = Request.QueryString["status"].ToString();
                Array myArray = status.Split(',');
                if (myArray.Length == 2)
                {
                    chkchecked(chkon, chkoff);
                    BindData(1);
                }
                else
                {
                    if (status == "0") chkoff.Checked = true;
                    else chkon.Checked = true;
                        BindDataByStatus(1, Convert.ToInt32(status));
                }

            }
            else BindData(1);

            
            
        }
        private void chkchecked(CheckBox chk1, CheckBox chk2)
        {
            chk1.Checked = true;
            chk2.Checked = true;
        }
        private void setAttr()
        {
            txtQuery.Attributes.Add("placeholder", "Từ khóa muốn tìm");
            chkon.InputAttributes.Add("data-switch-no-init", "");
            chkoff.InputAttributes.Add("data-switch-no-init", "");
            chkon.InputAttributes.Add("onclick", "javascript: statusSelect('/Category/Video');");
            chkoff.InputAttributes.Add("onclick", "javascript: statusSelect('/Category/Video');");
            chkon.InputAttributes.Add("value", "1");
            chkoff.InputAttributes.Add("value", "0");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData(1);
        }

        private void BindData(int type)
        {
            grvList.DataSource = (new CateModel()).Category_Select(txtQuery.Text, type);
            grvList.DataBind();
        }
        private void BindDataByStatus(int type, int status)
        {
            grvList.DataSource = (new CateModel()).Category_SelectByStatus(txtQuery.Text, type, status);
            grvList.DataBind();
        }
        protected void grvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                if (lblStatus.Text == "1")
                    lblStatus.Text = "Hoạt động";
                else if (lblStatus.Text == "0")
                    lblStatus.Text = "<span style='color: red;'>Không hoạt động</span>";
            }
        }

        protected void grvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvList.PageIndex = e.NewPageIndex;
            BindData(1);
        }

        protected void grvList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}