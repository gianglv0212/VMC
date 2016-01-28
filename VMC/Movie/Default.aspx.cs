using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using VMC.Model;
using VMC.EO;

namespace VMC.Movie
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            setAttr();
            ControlSetDefault();
            BindCateData();
            FilterData();
        }
        private void ControlSetDefault()
        {
            int cate = 0;
            int type = 0;
            string status = "";
            if (Common.Common.getQueryString("name") != "")
            {
                txtQuery.Text = Common.Common.getQueryString("name");

            }
            if (Request.QueryString["cate"] != null)
            {
                cate = Convert.ToInt32(Request.QueryString["cate"].ToString());

            }
            if (Request.QueryString["type"] != null)
            {
                type = Convert.ToInt32(Request.QueryString["type"].ToString());
                switch (type)
                {
                    case 0: rdle.Checked = true; break;
                    case 1: rdbo.Checked = true; break;
                    default: rdall.Checked = true; break;
                }
            }
            else rdall.Checked = true;
            if (Request.QueryString["status"] != null)
            {
                status = Request.QueryString["status"].ToString();
                var arr = status.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    if (Convert.ToInt32(arr[i]) == 0) chkunpublish.Checked = true;
                    else if (Convert.ToInt32(arr[i]) == 1) chkpublish.Checked = true;
                    else if (Convert.ToInt32(arr[i]) == 2) chkcreate.Checked = true;
                }
            }

        }
        private void setAttr()
        {
            txtQuery.Attributes.Add("placeholder", "Từ khóa muốn tìm");

            rdall.InputAttributes.Add("data-switch-no-init", "");
            rdall.InputAttributes.Add("onclick", "javascript:vodtypeSelect('/Movie?',2)");
            rdbo.InputAttributes.Add("data-switch-no-init", "");
            rdbo.InputAttributes.Add("onclick", "javascript:vodtypeSelect('/Movie?',1)");
            rdle.InputAttributes.Add("data-switch-no-init", "");
            rdle.InputAttributes.Add("onclick", "javascript:vodtypeSelect('/Movie?',0)");


            chkcreate.InputAttributes.Add("data-switch-no-init", "");
            chkcreate.InputAttributes.Add("value", "2");
            chkcreate.InputAttributes.Add("onclick", "javascript:vodstatusSelect('/Movie?',2)");
            chkpublish.InputAttributes.Add("data-switch-no-init", "");
            chkpublish.InputAttributes.Add("value", "1");
            chkpublish.InputAttributes.Add("onclick", "javascript:vodstatusSelect('/Movie?',1)");
            chkunpublish.InputAttributes.Add("data-switch-no-init", "");
            chkunpublish.InputAttributes.Add("value", "0");
            chkunpublish.InputAttributes.Add("onclick", "javascript:vodstatusSelect('/Movie?',0)");
        }
        private void FilterData()
        {
            string name = "";
            string uid = "";
            Int16 videotype = 0;
            int cate = 0;
            string status = "";
            if (Common.Common.getQueryString("name") != "") name = Common.Common.getQueryString("name").ToString();

            if (Common.Common.getQueryString("type") != "")
            {
                videotype = Convert.ToInt16(Common.Common.getQueryString("type"));
                if (videotype == 2) videotype = 0;
            }

            if (Common.Common.getQueryString("cate") != "") cate = Convert.ToInt32(Common.Common.getQueryString("cate"));
            if (Common.Common.getQueryString("status") != "")
            {
                status = Common.Common.getQueryString("status").ToString();
                if (status.Contains("2"))
                    uid = Common.Common.getUserInfo().uid.ToString();

                if (status.Contains("0") && status.Contains("1"))
                    status = "";
                else if (status.Contains("0") && !status.Contains("1")) status = "0";
                else if (!status.Contains("0") && status.Contains("1")) status = "1";
                else status = "";
            }
            BindDataFilter(status, videotype, cate, 4, uid, name);
        }
        private void BindDataFilter(string status, Int16 videotype, int optionid, Int16 type, string uid, string name)
        {
            grvList.DataSource = (new MovieModel()).Movie_filter(status, videotype, optionid, type, uid, name);
            grvList.DataBind();
        }
        private void BindCateData()
        {
            rptCate.DataSource = (new CateModel()).Category_SelectCountVideo(0);
            rptCate.DataBind();
        }
        protected void grvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                LinkButton hplxoa = (LinkButton)e.Row.FindControl("hplxoa");
                LinkButton hplhavideo = (LinkButton)e.Row.FindControl("hplhavideo");
                LinkButton hplxuatban = (LinkButton)e.Row.FindControl("hplxuatban");

                if (lblStatus.Text.Contains("1"))
                {
                    hplxoa.Visible = true;
                    hplhavideo.Visible = true;
                    hplxuatban.Visible = false;
                    lblStatus.Text = "Đã xuất bản<br>";
                }
                else if (lblStatus.Text == "0")
                {
                    lblStatus.Text = "Đã gỡ bỏ<br>";
                    hplhavideo.Visible = false;
                    hplxuatban.Visible = true;
                }

            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = "/Movie?";
            if (Common.Common.getQueryString("status") != "")
                url += "&status=" + Common.Common.getQueryString("status");
            if (Common.Common.getQueryString("cate") != "")
                url += "&cate=" + Common.Common.getQueryString("cate");
            if (Common.Common.getQueryString("type") != "")
                url += "&type=" + Common.Common.getQueryString("type");
            if (txtQuery.Text != "")
                url += "&name=" + txtQuery.Text;
            Response.Redirect(url);
        }

        protected void grvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblmess.Text = "";
            try
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument) % grvList.PageSize;
                Int32 idvideo = Convert.ToInt32(grvList.DataKeys[rowIndex].Values[0]);
                if (e.CommandName == "cmdXuatBan")
                {
                    (new MovieModel()).Movie_UpdateStatus(idvideo, 1);
                    lblmess.Text = "Phim đã được xuất bản";
                }
                else if (e.CommandName == "cmdHaVideo")
                {
                    (new MovieModel()).Movie_UpdateStatus(idvideo, 0);
                    lblmess.Text = "Phim đã được hạ";
                }
                else if (e.CommandName == "cmdXoa")
                {
                    (new MovieModel()).Movie_Delete(idvideo);
                    (new FileModel()).File_DeleteByVideoId(idvideo, 0);
                    BindCateData();
                    lblmess.Text = "Phim được xóa thành công";
                }
                FilterData();
            }
            catch (Exception ex)
            {
                lblmess.Text = ex.ToString();
            }
        }
        protected void grvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvList.PageIndex = e.NewPageIndex;
            FilterData();
        }
    }
}