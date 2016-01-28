using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace VMC.Model
{
    public class CountryModel : Config
    {
        public DataSet Country_List()
        {
            SqlCommand cmd = new SqlCommand("Country_Select");
            return getDataSet(cmd);
        }

        public Boolean Country_Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("Country_DeleteItem");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            return ExcuteNonquery(cmd);
        }

        public Boolean Country_Add(string name, string description, string slug)
        {
            SqlCommand cmd = new SqlCommand("Country_InsertItem");
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@description", description));
            cmd.Parameters.Add(new SqlParameter("@slug", slug));
            return ExcuteNonquery(cmd);
        }
        public DataSet Country_GetById(Int32 id)
        {
            SqlCommand cmd = new SqlCommand("Country_SelectById");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            return getDataSet(cmd);
        }
        public Boolean Country_Edit(string name, string description, string slug, Int32 id)
        {
            SqlCommand cmd = new SqlCommand("Country_UpdateItem");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@description", description));
            cmd.Parameters.Add(new SqlParameter("@slug", slug));
            return ExcuteNonquery(cmd);
        }
    }
}