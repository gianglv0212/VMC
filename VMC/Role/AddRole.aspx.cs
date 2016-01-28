using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMC.Model;

namespace VMC.Role
{
    public partial class AddRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateRole_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                string name = txtrole.Text;
                string desc = txtdescription.Text;
                int weight = (txtweight.Text != null && int.TryParse(txtweight.Text, out i)) ? Convert.ToInt32(txtweight.Text) : 0;
                if ((new RoleModel()).Role_Insert(name, desc, weight))
                {
                    lblmess.Text = "Khởi tạo nhóm quyền thành công";
                    resetForm();
                }
                else
                    lblerror.Text = "Nhóm quyền chưa được khởi tạo";

            }
            catch (Exception ex)
            {
                lblerror.Text = ex.ToString();
            }
        }
        private void resetForm()
        {
            txtrole.Text = "";
            txtdescription.Text = "";
            txtweight.Text = "";
        }
    }
}