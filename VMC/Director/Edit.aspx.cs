using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMC.Model;


namespace VMC.Director
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (!IsPostBack)
                {
                    avatarinput.Attributes.Add("onchange", "readURL(this,'avatar','output1');");
                    int id;
                    DataSet ds;
                    id = Convert.ToInt32(Request.QueryString["ID"]);
                    ds = (new DirectorModel()).Director_SelectById(id);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                        txtDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
                        avatar.ImageUrl = ds.Tables[0].Rows[0]["avatar"].ToString();
                        hdid.Value = id.ToString();
                    }
                }
        }

        protected void btndirector_Click(object sender, EventArgs e)
        {
            string fileName = "";
            if (Page.IsValid && avatarinput.HasFile)
            {
                fileName = "/Uploads/Director/IMGS/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + avatarinput.FileName;
                string filePath = MapPath(fileName);
                avatarinput.SaveAs(filePath);
            }
            Boolean check = false;
            //bool chkstatus;
            String name, description, urlavatar;
            int id;
            name = txtName.Text;
            id = Convert.ToInt32(hdid.Value);
            description = txtDescription.Text;
            urlavatar = (fileName == "") ? avatar.ImageUrl.ToString() : fileName;
            if ((new DirectorModel()).Director_update(name, description, urlavatar, id))
                Response.Redirect("/Director");
        }
    }
}