using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using VMC.Model;

namespace VMC.Country
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDataDefault();
            }
        }
        private void SetDataDefault()
        {
            Int32 id = Convert.ToInt32(Common.Common.getQueryString("ID"));
            DataSet ds = (new CountryModel()).Country_GetById(id);
            if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                txtDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
                hdfid.Value = id.ToString();
            }
        }
        public void btnCountry_Click(object sender, EventArgs e)
        {
            try
            {

                string name, description, slug;
                Int32 id;
                name = txtName.Text;
                description = txtDescription.Text;
                slug = Common.Common.UTF8toASCII(name);
                id = Convert.ToInt32(hdfid.Value);
                if ((new CountryModel()).Country_Edit(name, description, slug, id))
                    Response.Redirect("/Country?success");
                else
                    lblerror.Text = "Chưa sửa được quốc gia " + name;

            }
            catch (Exception ex)
            {
                lblerror.Text = ex.ToString();
            }
        }
    }
}