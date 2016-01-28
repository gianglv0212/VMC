using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMC.Common;
using System.Data;
using VMC.Model;


namespace VMC.Publics
{
    public partial class Default : System.Web.UI.Page
    {
        public DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 videoid, itype;
            if (Common.Common.getQueryString("ID") != null)
            {
                videoid = Convert.ToInt32(Common.Common.getQueryString("ID"));
                id.Value = videoid.ToString();
                itype = Convert.ToInt32(Common.Common.getQueryString("type"));
                type.Value = itype.ToString();
                if (!IsPostBack)
                {
                    BindData(videoid, itype);
                }
            }

        }
        private void BindData(int videoid, int type)
        {
            ds = (new FileModel()).File_Select(videoid, type);
            grvFile.DataSource = ds;
            grvFile.DataBind();
        }

        protected void grvFile_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                //HyperLink havideo = (HyperLink)e.Row.FindControl("hplhaphim");
                //HyperLink xuatbanvideo = (HyperLink)e.Row.FindControl("hplxuatban");
                //HiddenField type = (HiddenField)e.Row.FindControl("hdftype");
                ////HyperLink LinkEdit = (HyperLink)e.Row.FindControl("hpledit");

                if (lblStatus.Text.Contains("1"))
                {
                    lblStatus.Text = "Đã xuất bản";
                    //xuatbanvideo.Visible = false;
                }
                else
                {
                    lblStatus.Text = "Đã gỡ bỏ";
                    //havideo.Visible = false;
                }
                //
                //if (type.Value.Contains("0")) LinkEdit.NavigateUrl = "/File/EditFile";
                    
            }
        }

    }
}