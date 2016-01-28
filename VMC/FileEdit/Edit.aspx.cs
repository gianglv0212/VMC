using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMC.Model;
using System.Data;

namespace VMC.FileEdit
{
    public partial class Edit : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                try
                {
                    BindData();
                }
                catch (Exception ex)
                {
                    lblerror.Text = ex.ToString();
                }
            }
            
        }
        private void BindData()
        {
            Int32 Fileid = Convert.ToInt32(RouteData.Values["FileId"]);
            DataSet ds = (new FileModel()).File_SelectById(Fileid);
            //get data tag
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int idvideo = Convert.ToInt32(ds.Tables[0].Rows[0]["videoid"].ToString());
                string type = ds.Tables[0].Rows[0]["type"].ToString();
                // breadcrumd
                breadcrumb(idvideo, type);
                GetDataTag(Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString()));
                //fill data to form
                DataDefault(ds);

            }

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hdfid.Value);
            string title = txtName.Text;
            string description = txtDescription.Text;
            string strordering = txtOrdering.Text;
            int i;
            int ordering = (int.TryParse(strordering, out i)) ? Convert.ToInt32(strordering) : 1;
            int status = (chkstatus.Checked == true) ? 1 : 0;
            string avatar, poster;
            if (Page.IsValid && avatarinput.HasFile)
            {
                avatar = "/Uploads/File/IMGS/Avatar/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + avatarinput.FileName;
                string filePath = MapPath(avatar);
                avatarinput.SaveAs(filePath);
            }
            else avatar = "/Uploads/Core/noimg.jpg";
            if (Page.IsValid && posterinput.HasFile)
            {
                poster = "/Uploads/File/IMGS/Poster/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + posterinput.FileName;
                string filePath = MapPath(poster);
                avatarinput.SaveAs(filePath);
            }
            else
                poster = "/Uploads/Core/noimg.jpg";

            if ((new FileModel()).File_Update(id, title, description, ordering, status, avatar, poster))
            {
                DeleteOption(id, "10");
                getValueListBox(lbtag, id, 10);
                BindData();
                lblmess.Text = "Sửa tập thành công";
            }
            else
            {
                BindData();
                lblerror.Text = "Tập này chưa được sửa do lỗi vui lòng kiểm tra lại";
            }
        }
        private void getValueListBox(ListBox lb, int fileid, int type)
        {

            foreach (int i in lb.GetSelectedIndices())
            {
                VideoModel vm = new VideoModel();
                vm.Video_Insert_Option(fileid, Convert.ToInt32(lb.Items[i].Value), type);
            }

        }
        private void DeleteOption(Int32 id, String sType)
        {

            (new OptionVideoModel()).OptionVideo_Delete(id, sType);
        }
        private void GetDataTag(int id)
        {
            lbtag.DataSource = (new TagModel()).Tag_Select(1);
            lbtag.DataTextField = "name";
            lbtag.DataValueField = "id";
            lbtag.DataBind();
            setDefaultListbox(lbtag, id, 10);
        }
        private void setDefaultListbox(ListBox lt, Int32 id, Int16 type)
        {
            DataSet ds = (new OptionVideoModel()).Option_Select(id, type);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    foreach (ListItem item in lt.Items)
                    {
                        if (item.Value.Equals(ds.Tables[0].Rows[i]["optionid"].ToString()))
                            item.Selected = true;
                    }
                }
            }
        }
        private void DataDefault(DataSet ds)
        {
            string avt = ds.Tables[0].Rows[0]["avatar"].ToString();
            string pot = ds.Tables[0].Rows[0]["poster"].ToString();

            hdfid.Value = ds.Tables[0].Rows[0]["id"].ToString();
            txtName.Text = ds.Tables[0].Rows[0]["title"].ToString();
            txtOrdering.Text = ds.Tables[0].Rows[0]["ordering"].ToString();
            txtDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
            if(ds.Tables[0].Rows[0]["status"].ToString().Equals("1")) chkstatus.Checked = true;
            else chkstatus.Checked = false;

            avatar.ImageUrl = (avt.Equals("")) ? "/Uploads/Core/noimg.jpg" : avt;
            poster.ImageUrl = (pot.Equals("")) ? "/Uploads/Core/noimg.jpg" : pot;

            avatar.Attributes.Add("width", "350px"); avatar.Attributes.Add("height", "285px");
            poster.Attributes.Add("width", "200px"); poster.Attributes.Add("height", "190px");
        }
        private void breadcrumb(int id, string type)
        {
            if (type.Contains("1"))
            {
                int videoid = Convert.ToInt32(id);
                DataSet dsVideo = (new VideoModel()).Video_SelectById(videoid);
                lbllink1.Text = "Danh sách video";
                hpl1.NavigateUrl = "/Video";
                lbllink2.Text = "Video: " + dsVideo.Tables[0].Rows[0]["name"].ToString();
                hpl2.NavigateUrl = "/Video/Edit?ID=" + dsVideo.Tables[0].Rows[0]["id"].ToString();
            }
            else
            {
                int movieid = Convert.ToInt32(id);
                DataSet dsMovie = (new MovieModel()).Movie_SelectById(movieid);
                lbllink1.Text = "Danh sách phim";
                hpl1.NavigateUrl = "/Movie";
                lbllink2.Text = "Phim: " + dsMovie.Tables[0].Rows[0]["name"].ToString();
                hpl2.NavigateUrl = "/Movie/Edit?ID=" + dsMovie.Tables[0].Rows[0]["id"].ToString();
            }
        }
    }
}