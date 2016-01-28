using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMC.Model;

namespace VMC.Category
{
    public partial class Edit : System.Web.UI.Page
    {
        public DataSet ds;
        public Boolean error = false;
        public int level_parent;
        public string leveltree_parent;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null) Response.Redirect("/Login");
            else
                if (!IsPostBack)
                {
                    int id, type;
                    id = Convert.ToInt32(Request.QueryString["ID"]);
                    type = Convert.ToInt32(Request.QueryString["type"]);
                    ds = (new CateModel()).Category_SelectById(id);
                    txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                    txtDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
                    txtOrder.Text = ds.Tables[0].Rows[0]["orders"].ToString();
                    hdid.Value = id.ToString();
                    avatar.ImageUrl = ds.Tables[0].Rows[0]["avatar"].ToString();
                    ddlCate(type);
                }else
                {
                    int pid = Convert.ToInt32(ddparentid.SelectedValue);
                    if (pid > 0)
                    {
                        DataSet cate = (new CateModel()).Category_SelectById(pid);
                        level_parent = Convert.ToInt32(cate.Tables[0].Rows[0]["level"]);
                        leveltree_parent = cate.Tables[0].Rows[0]["level_tree"].ToString();
                    }else
                    {
                        level_parent = 0;
                        leveltree_parent = "";
                    }
                }
        }
        private void ddlCate(int type)
        {
            ddparentid.DataSource = (new CateModel()).Category_Select("", type);
            ddparentid.DataTextField = "name";
            ddparentid.DataValueField = "id";
            
            ddparentid.DataBind();
            ddparentid.Items.Insert(0, new ListItem("-- Chọn danh mục --", "0"));
            ddparentid.SelectedValue = ds.Tables[0].Rows[0]["parentid"].ToString();
        }
        public void btncate_Click(object sender, EventArgs e)
        {
            string fileName = "";
            if (Page.IsValid && avatarinput.HasFile)
            {
                fileName = "/Uploads/Category/IMGS/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + avatarinput.FileName;
                string filePath = MapPath(fileName);
                avatarinput.SaveAs(filePath);
            }
            Boolean check = false;
            //bool chkstatus;
            String name, description, level_tree, uname, urlavatar;
            int parentid, level, status, uid, orders, id;
            id = Convert.ToInt32(hdid.Value);
            parentid = Convert.ToInt32(ddparentid.SelectedValue);
            name = txtName.Text;

            if (ValidateForm(name, id, parentid) > 0)
            {
                error = true;
            }
            else
            {
                description = txtDescription.Text;
                uname = Common.Common.getUserInfo().uid.ToString();
                urlavatar = (fileName == "") ? avatar.ImageUrl.ToString() : fileName;
                orders = (txtOrder.Text != "") ? Convert.ToInt32(txtOrder.Text) : 0;
                if (chkstatus.Checked == true) status = 1;
                else status = 0;

                level = level_parent + 1;
                if (parentid > 0) level_tree = leveltree_parent + "_" + id;
                else level_tree = id.ToString();
                uid = Convert.ToInt32(Common.Common.getUserInfo().uid.ToString());
                if ((new CateModel()).Category_Update(id, name, description, parentid, level, level_tree, status, uid, uname, urlavatar, orders))
                {
                    if (Convert.ToInt32(Request.QueryString["type"]) == 1) Response.Redirect("/Category/Video?success");
                    else Response.Redirect("/Category/Video?success");
                }
            }
        }

        public int ValidateForm(string name, int id, int parentid)
        {
            if (name == "")
            {
                lblName.Text = "Bạn cần nhập nội dung";
                lblName.Focus();
                return 1;
            }
            else if (id == parentid)
            {
                lblparentid.Text = "Bạn không được chọn trùng thể loại";
                return 1;
            }
            else return 0;
        }
    }
}