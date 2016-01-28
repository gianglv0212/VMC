using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMC.Model;
using System.Data;

namespace VMC.Country
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            gvcountry.DataSource = (new CountryModel()).Country_List();
            gvcountry.DataBind();
        }

        protected void gvcountry_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvcountry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblmess.Text = "";
            try
            {
                if(e.CommandName == "cmdDelete")
                {
                    string name = "";
                    Int32 id = Convert.ToInt32(e.CommandArgument.ToString());
                    if ((new CountryModel()).Country_Delete(id))
                        lblmess.Text = "Quốc gia" + name  + "đã được xóa";
                    else
                        lblerror.Text = "Lỗi chưa xóa được. Vui lòng refresh lại trang.";
                }
                BindData();
            }
            catch(Exception ex)
            {
                lblerror.Text = ex.ToString();
            }
        }

        protected void gvcountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}