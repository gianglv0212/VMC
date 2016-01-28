using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using VMC.Common;

namespace VMC.Model
{
    public class User : Config
    {
        public DataSet Login(string u, string p)
        {
            DataSet ds;
            Regex R = new Regex(@"^[\w]{1,40}$");
            if (R.Match(u).Success || R.Match(p).Success)
            {

                SqlCommand cmd = new SqlCommand("User_Login");
                cmd.Parameters.Add(new SqlParameter("@username", u));
                cmd.Parameters.Add(new SqlParameter("@pass", p));
                ds = getDataSet(cmd);
                return ds;
                
            }
            else return null;
        }
        public DataSet GetRoles()
        {
            DataSet ds;
            SqlCommand cmd = new SqlCommand("User_Role");
            ds = getDataSet(cmd);
            return ds;
        }
        public DataSet UserList(string FullName)
        {
            DataSet ds;
            SqlCommand cmd = new SqlCommand("User_List");
            cmd.Parameters.Add(new SqlParameter("@fullname", Common.Common.getDBNull(FullName, FullName.GetTypeCode())));
            ds = getDataSet(cmd);
            return ds;
        }
        public Boolean User_Register(string user, string pass, Int32 roleID, string fullname, string email)
        {
            SqlCommand cmd = new SqlCommand("User_Register");
            cmd.Parameters.Add(new SqlParameter("@username", user));
            cmd.Parameters.Add(new SqlParameter("@pass", pass));
            cmd.Parameters.Add(new SqlParameter("@roles", roleID));
            cmd.Parameters.Add(new SqlParameter("@fullname", fullname));
            cmd.Parameters.Add(new SqlParameter("@email", email));
             return ExcuteNonquery(cmd);
        }
        public Boolean User_Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("User_Delete");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            return ExcuteNonquery(cmd);
        }
        public DataSet User_GetById(Int32 id)
        {
            SqlCommand cmd = new SqlCommand("User_GetById");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            return getDataSet(cmd);
        }

        public Boolean User_Update(Int32 id,int roleID, string full, string mail , string avatar)
        {
            SqlCommand cmd = new SqlCommand("User_UpdateItem");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@roles", roleID));
            cmd.Parameters.Add(new SqlParameter("@fullname", full));
            cmd.Parameters.Add(new SqlParameter("@email", mail));
            cmd.Parameters.Add(new SqlParameter("@avatar", avatar));
            return ExcuteNonquery(cmd);
        }

        public Boolean User_Changepass(int id, string pass)
        {
            SqlCommand cmd = new SqlCommand("User_Changepass");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@pass", pass));
            return ExcuteNonquery(cmd);
        }
    }
}