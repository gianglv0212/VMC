using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace VMC.Model
{
    public class ActorModel : Config
    {
        public DataSet Actor_Select()
        {
            SqlCommand cmd = new SqlCommand("Actor_Select");
            //cmd.Parameters.Add(new SqlParameter("@name", name));
            return getDataSet(cmd);
        }
        public Boolean Actor_Insert(String name, String description, int status, int uid, String uname, int type, String avatar)
        {
            //SqlCommand cmd = new SqlCommand("test_InsertItem");
            //cmd.Parameters.Add(new SqlParameter("@id", 1));
            SqlCommand cmd = new SqlCommand("Actor_InsertItem");
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@description", description));
            cmd.Parameters.Add(new SqlParameter("@status", status));
            cmd.Parameters.Add(new SqlParameter("@uid", uid));
            cmd.Parameters.Add(new SqlParameter("@uname", uname));
            cmd.Parameters.Add(new SqlParameter("@type", type));
            cmd.Parameters.Add(new SqlParameter("@avatar", avatar));
            return ExcuteNonquery(cmd);
        }
        public DataSet Actor_SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Actor_SelectById");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            return getDataSet(cmd);
        }

        public Boolean Actor_update(string name, string description, string avatar, int id)
        {
            SqlCommand cmd = new SqlCommand("Actor_UpdateItem");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@description", description));
            cmd.Parameters.Add(new SqlParameter("@avatar", avatar));
            return ExcuteNonquery(cmd);
        }
        public Boolean Actor_Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("Actor_DeleteItem");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            return ExcuteNonquery(cmd);
        }
    }
}