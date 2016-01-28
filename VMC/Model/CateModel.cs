using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;


namespace VMC.Model
{
    public class CateModel : Config
    {
        public Boolean Category_Insert(String name, String description, int parentid, int level, String level_tree, int status, int uid, String uname, int type, String avatar, int orders)
        {
            SqlCommand cmd = new SqlCommand("Cate_InsertItem");
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@description", description));
            cmd.Parameters.Add(new SqlParameter("@parentid", parentid));
            cmd.Parameters.Add(new SqlParameter("@level", level));
            cmd.Parameters.Add(new SqlParameter("@level_tree", level_tree));
            cmd.Parameters.Add(new SqlParameter("@status", status));
            cmd.Parameters.Add(new SqlParameter("@uid", uid));
            cmd.Parameters.Add(new SqlParameter("@uname", uname));
            cmd.Parameters.Add(new SqlParameter("@type", type));
            cmd.Parameters.Add(new SqlParameter("@avatar", avatar));
            cmd.Parameters.Add(new SqlParameter("@orders", orders));
            return ExcuteNonquery(cmd);
        }
        public Boolean Category_Update(int id, String name, String description, int parentid, int level, String level_tree, int status, int uid, String uname, String avatar, int orders)
        {
            SqlCommand cmd = new SqlCommand("Cate_UpdateItem");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@description", description));
            cmd.Parameters.Add(new SqlParameter("@parentid", parentid));
            cmd.Parameters.Add(new SqlParameter("@level", level));
            cmd.Parameters.Add(new SqlParameter("@level_tree", level_tree));
            cmd.Parameters.Add(new SqlParameter("@status", status));
            cmd.Parameters.Add(new SqlParameter("@uid", uid));
            cmd.Parameters.Add(new SqlParameter("@uname", uname));
            cmd.Parameters.Add(new SqlParameter("@avatar", avatar));
            cmd.Parameters.Add(new SqlParameter("@orders", orders));
            return ExcuteNonquery(cmd);
        }
        public DataSet Category_Select(String name, int type)
        {
            SqlCommand cmd = new SqlCommand("Cate_Select");
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@type", type));
            return getDataSet(cmd);
        }
        public DataSet Category_SelectCountVideo(int type)
        {
            SqlCommand cmd = new SqlCommand("Cate_SelectCountVideo");
            cmd.Parameters.Add(new SqlParameter("@type", type));
            return getDataSet(cmd);
        }
        public DataSet Category_SelectByStatus(String name, int type, int status)
        {
            SqlCommand cmd = new SqlCommand("Cate_SelectByStatus");
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@type", type));
            cmd.Parameters.Add(new SqlParameter("@status", status));
            return getDataSet(cmd);
        }
        public DataSet Category_SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Cate_GetById");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            return getDataSet(cmd);
        }
    }
}