using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using System.Data;
using VMC.Model;

namespace VMC.Role
{
    public partial class Permission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int id = Convert.ToInt32(RouteData.Values["RoleId"]);
                    BindData(id);
                    getLink(id);
                }
                catch (Exception ex)
                { }
            }
        }
        private void BindData(int id)
        {
            
            hdfid.Value = id.ToString();
                    DataSet ds = (new RoleModel()).Role_SelectById(id);
            if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count> 0)
            {
                txtrole.Text = ds.Tables[0].Rows[0]["name"].ToString();
                txtdescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
                txtweight.Text = ds.Tables[0].Rows[0]["weight"].ToString();
            }         
        }
        private void getLink(int RoleID)
        {
            lbLink.DataSource = (new RoleModel()).Link_Select();
            lbLink.DataTextField = "name";
            lbLink.DataValueField = "id";

            lbLink.DataBind();
            setDefaultListbox(lbLink, RoleID);
        }
        private void setDefaultListbox(ListBox lt, Int32 RoleID)
        {
            DataSet ds = (new RoleModel()).Role_Link(RoleID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    foreach (ListItem item in lt.Items)
                    {
                        if (item.Value.Equals(ds.Tables[0].Rows[i]["linkID"].ToString()))
                            item.Selected = true;
                    }
                }
            }
        }
        protected void btnUpdateRole_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                int id = Convert.ToInt32(hdfid.Value);
                string name = txtrole.Text;
                string desc = txtdescription.Text;
                int weight = (txtweight.Text != null && int.TryParse(txtweight.Text, out i)) ? Convert.ToInt32(txtweight.Text) : 0;
                (new RoleModel()).Role_Update(id, name, desc, weight);

                (new RoleModel()).Role_DeleteLink(id);
                getValueListBox(lbLink, id);
                lblmess.Text = "Thay đổi thành công nội dung và chức năng quyền '" + name +"'";
            }catch(Exception ex)
            {
                lblerror.Text = ex.ToString();
            }
        }
        private void getValueListBox(ListBox lb, int roleID)
        {

            foreach (int i in lb.GetSelectedIndices())
            {
                RoleModel RL = new RoleModel();
                RL.Role_AddLink(roleID, Convert.ToInt32(lb.Items[i].Value));
            }

        }
    }
}