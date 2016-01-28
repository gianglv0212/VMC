using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMC.Model;
using System.Data;

namespace VMC.Role
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            grvRole.DataSource = (new RoleModel()).Role_Select();
            grvRole.DataBind();
        }

        protected void grvRole_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}