using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using VMC.Common;

namespace VMC.Model
{
    public class MovieModel : Config
    {
        public int Movie_Insert(Array DataInput)
        {
            SqlCommand cmd = new SqlCommand("Movie_InsertItem");
            cmd.Parameters.Add(new SqlParameter("@name", DataInput.GetValue(0).ToString()));
            cmd.Parameters.Add(new SqlParameter("@fullname", DataInput.GetValue(1).ToString()));
            cmd.Parameters.Add(new SqlParameter("@description", DataInput.GetValue(2).ToString()));
            cmd.Parameters.Add(new SqlParameter("@releaseyear", DataInput.GetValue(3).ToString()));
            cmd.Parameters.Add(new SqlParameter("@videotype", DataInput.GetValue(4).ToString()));
            cmd.Parameters.Add(new SqlParameter("@avatar", DataInput.GetValue(5).ToString()));
            cmd.Parameters.Add(new SqlParameter("@poster", DataInput.GetValue(6).ToString()));
            cmd.Parameters.Add(new SqlParameter("@status", DataInput.GetValue(7).ToString()));
            cmd.Parameters.Add(new SqlParameter("@uid", DataInput.GetValue(8).ToString()));
            cmd.Parameters.Add(new SqlParameter("@uname", DataInput.GetValue(9).ToString()));
            //cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Direction = ParameterDirection.Output;
            SqlParameter param = cmd.Parameters.Add("RetVal", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            ExcuteNonquery(cmd);

            Int32 id = 0;
            Int32.TryParse(Convert.ToString(param.Value), out id);
            return id;
        }
        public Boolean Movie_Update(Array DataInput, Int32 id)
        {
            SqlCommand cmd = new SqlCommand("Movie_UpdateItem");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@name", DataInput.GetValue(0).ToString()));
            cmd.Parameters.Add(new SqlParameter("@fullname", DataInput.GetValue(1).ToString()));
            cmd.Parameters.Add(new SqlParameter("@description", DataInput.GetValue(2).ToString()));
            cmd.Parameters.Add(new SqlParameter("@releaseyear", DataInput.GetValue(3).ToString()));
            cmd.Parameters.Add(new SqlParameter("@videotype", DataInput.GetValue(4).ToString()));
            cmd.Parameters.Add(new SqlParameter("@avatar", DataInput.GetValue(5).ToString()));
            cmd.Parameters.Add(new SqlParameter("@poster", DataInput.GetValue(6).ToString()));
            cmd.Parameters.Add(new SqlParameter("@status", DataInput.GetValue(7).ToString()));

            return ExcuteNonquery(cmd);
        }

        public DataSet Movie_SelectById(Int32 id)
        {
            SqlCommand cmd = new SqlCommand("Movie_SelectById");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            return getDataSet(cmd);
        }
        public DataSet Movie_filter(string status, Int16 videotype, int optionid, Int16 type, string uid, string name)
        {
            SqlCommand cmd = new SqlCommand("Movie_filter");
            cmd.Parameters.Add(new SqlParameter("@status", Common.Common.getDBNull(status, status.GetTypeCode())));
            cmd.Parameters.Add(new SqlParameter("@videotype", Common.Common.getDBNull(videotype, videotype.GetTypeCode())));
            cmd.Parameters.Add(new SqlParameter("@optionid", Common.Common.getDBNull(optionid, optionid.GetTypeCode())));
            cmd.Parameters.Add(new SqlParameter("@type", Common.Common.getDBNull(type, type.GetTypeCode())));
            cmd.Parameters.Add(new SqlParameter("@uid", Common.Common.getDBNull(uid, uid.GetTypeCode())));
            cmd.Parameters.Add(new SqlParameter("@name", Common.Common.getDBNull(name, name.GetTypeCode())));
            return getDataSet(cmd);
        }
        public Boolean Movie_Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("Movie_DeleteItem");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            return ExcuteNonquery(cmd);
        }
        public Boolean Movie_UpdateStatus(Int32 id, Int16 status)
        {
            SqlCommand cmd = new SqlCommand("Movie_UpdateStatus");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@status", status));

            return ExcuteNonquery(cmd);
        }
        public DataSet Country_Select()
        {
            SqlCommand cmd = new SqlCommand("Country_Select");
            return getDataSet(cmd);
        }
    }
}