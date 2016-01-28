using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace VMC.Model
{
    public class RoleModel : Config
    {
        public DataSet Role_Select()
        {
            SqlCommand cmd = new SqlCommand("Role_Select");
            return getDataSet(cmd);
        }
        public DataSet Role_CheckLink(int roleid, int linkid)
        {
            SqlCommand cmd = new SqlCommand("Role_CheckLink");
            cmd.Parameters.Add(new SqlParameter("@RoleID", roleid));
            cmd.Parameters.Add(new SqlParameter("@linkID", linkid));
            return getDataSet(cmd);
        }
        public DataSet Link_Select()
        {
            SqlCommand cmd = new SqlCommand("Link_Select");
            return getDataSet(cmd);
        }
        public DataSet Link_SelectByPath(string path)
        {
            SqlCommand cmd = new SqlCommand("Link_SelectByPath");
            cmd.Parameters.Add(new SqlParameter("@link", path));
            return getDataSet(cmd);
        }
        public Boolean Role_Update(int id, string name, string desc, int weight)
        {
            SqlCommand cmd = new SqlCommand("Role_UpdateItem");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@description", desc));
            cmd.Parameters.Add(new SqlParameter("@weight", weight));
            return ExcuteNonquery(cmd);
        }
        public DataSet Role_SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Role_SelectById");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            return getDataSet(cmd);
        }
        public Boolean Role_Insert(String name, String description, int weight)
        {
            SqlCommand cmd = new SqlCommand("Role_InsertItem");
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@description", description));
            cmd.Parameters.Add(new SqlParameter("@weight", weight));
            return ExcuteNonquery(cmd);
        }
        public Boolean Role_DeleteLink(Int32 roleid)
        {
            SqlCommand cmd = new SqlCommand("Role_DeleteByRoleID");
            cmd.Parameters.Add(new SqlParameter("@roleid", roleid));
            return ExcuteNonquery(cmd);
        }
        public Boolean Role_AddLink(int roleID, int linkID)
        {
            SqlCommand cmd = new SqlCommand("RolePermission_Add");
            cmd.Parameters.Add(new SqlParameter("@RoleID", roleID));
            cmd.Parameters.Add(new SqlParameter("@linkID", linkID));
            return ExcuteNonquery(cmd);
        }
        public DataSet Role_Link(int RoleID)
        {
            SqlCommand cmd = new SqlCommand("RolePermission_ByRoleID");
            cmd.Parameters.Add(new SqlParameter("@RoleID", RoleID));
            return getDataSet(cmd);
        }
    }
}