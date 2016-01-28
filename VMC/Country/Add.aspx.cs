using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMC.Common;
using VMC.Model;

namespace VMC.Country
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCountry_Click(object sender, EventArgs e)
        {
            try
            {

                string name, description, slug;
                name = txtName.Text;
                description = txtDescription.Text;
                slug = Common.Common.UTF8toASCII(name);
                if ((new CountryModel()).Country_Add(name, description, slug))
                    lblmess.Text = "Thêm mới quốc gia " + name + " thành công";
                else
                    lblerror.Text = "Chưa thêm được quốc gia " + name;
            }
            catch(Exception ex)
            {
                lblerror.Text = ex.ToString();
            }
        }
    }
}