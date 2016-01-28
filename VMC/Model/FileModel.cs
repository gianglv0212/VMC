using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace VMC.Model
{
    public class FileModel : Config
    {
        public Boolean File_Insert(string name, string url, Int32 type, Int32 videoid, string title, Int32 ordering, Int32 uid, string uname, Int64 size)
        {
            
            SqlCommand cmd = new SqlCommand("File_InsertItem");
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@url", url));
            cmd.Parameters.Add(new SqlParameter("@type", type));
            cmd.Parameters.Add(new SqlParameter("@videoid", videoid));
            cmd.Parameters.Add(new SqlParameter("@title", title));
            cmd.Parameters.Add(new SqlParameter("@ordering", ordering));
            cmd.Parameters.Add(new SqlParameter("@uid", uid));
            cmd.Parameters.Add(new SqlParameter("@uname", uname));
            cmd.Parameters.Add(new SqlParameter("@size", size));
            return ExcuteNonquery(cmd);
        }
        public Boolean File_Update(int id, string title, string description, int ordering, int status, string avatar, string poster)
        {
            SqlCommand cmd = new SqlCommand("File_UpdateItem");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@title", title));
            cmd.Parameters.Add(new SqlParameter("@description", description));
            cmd.Parameters.Add(new SqlParameter("@ordering", ordering));
            cmd.Parameters.Add(new SqlParameter("@status", status));
            cmd.Parameters.Add(new SqlParameter("@avatar", avatar));
            cmd.Parameters.Add(new SqlParameter("@poster", poster));
            return ExcuteNonquery(cmd);
        }
        public DataSet File_Select(Int32 videoid, Int32 type)
        {
            SqlCommand cmd = new SqlCommand("File_SelectByVideoId");
            cmd.Parameters.Add(new SqlParameter("@videoid", videoid));
            cmd.Parameters.Add(new SqlParameter("@type", type));
            return getDataSet(cmd);
        }
        public DataSet File_SelectById(Int32 id)
        {
            SqlCommand cmd = new SqlCommand("File_SelectById");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            return getDataSet(cmd);
        }
        public Boolean File_DeleteByVideoId(int videoid,int type)
        {
            SqlCommand cmd = new SqlCommand("File_DeleteItemByVideoID");
            cmd.Parameters.Add(new SqlParameter("@videoid", videoid));
            cmd.Parameters.Add(new SqlParameter("@type", type));
            return ExcuteNonquery(cmd);
        }
    }
}