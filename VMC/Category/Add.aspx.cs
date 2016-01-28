
using VMC.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web.SessionState;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace VMC.Category
{
    public partial class Add : System.Web.UI.Page
    {
        Boolean check = false;
        int idparent, level_parent;
        String leveltree_parent;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                int cateid = Convert.ToInt32(ddparentid.SelectedValue);
                getParent(cateid);
            }
            else
            {
                avatarinput.Attributes.Add("onchange", "readURL(this,'avatar','output1');");
                ddlCate();
            }
        }
        
        private void getParent(int cateid)
        {
            if (cateid > 0)
            {
                ds = (new CateModel()).Category_SelectById(cateid);
                idparent = cateid;
                level_parent = Convert.ToInt32(ds.Tables[0].Rows[0]["level"].ToString());
                leveltree_parent = ds.Tables[0].Rows[0]["level_tree"].ToString() + "_";
            }
            else
            {
                idparent = 0;
                level_parent = 0;
                leveltree_parent = "";
            }
        }
        private void ddlCate()
        {
            ddparentid.DataSource = (new CateModel()).Category_Select("",1);
            ddparentid.DataTextField = "name";
            ddparentid.DataValueField = "id";
            ddparentid.DataBind();
            ddparentid.Items.Insert(0, new ListItem("-- Chọn danh mục --", "0"));
        }
        protected void btncatevideo_Click(object sender, EventArgs e)
        {
            string fileName = "";
            if (Page.IsValid && avatarinput.HasFile)
            {
                fileName = "/Uploads/Category/IMGS/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + avatarinput.FileName;
                string filePath = MapPath(fileName);
                avatarinput.SaveAs(filePath);
            }
            String name, description, level_tree, uname, avatar;
            int parentid, level, status, uid, type, orders;
            name = txtName.Text;
            description = txtDescription.Text;
            uname = Common.Common.getUserInfo().uname.ToString();
            avatar = (fileName == "") ? "/Uploads/Core/noimg.jpg" : fileName;
            orders = (txtOrder.Text != "") ? Convert.ToInt32(txtOrder.Text) : 0;
            type = 1;
            if (chkstatus.Checked == true) status = 1;
            else status = 0;
            parentid = Convert.ToInt32(ddparentid.SelectedValue);
            level = level_parent + 1;
            level_tree = leveltree_parent;
            uid = Convert.ToInt32(Common.Common.getUserInfo().uid.ToString());
            if (name != "")
            {
                if ((new CateModel()).Category_Insert(name, description, parentid, level, level_tree, status, uid, uname, type, avatar, orders))
                    lblmess.Text = "Thể loại đã được thêm thành công";
                else
                    lblerror.Text = "Thể loại chưa được thêm vui lòng nhập lại";
            }
            else lblerror.Text = "Bạn chưa nhập tên thể loại";
        }
    }
}