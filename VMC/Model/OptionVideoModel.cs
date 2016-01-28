using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using VMC.Common;

namespace VMC.Model
{
    public class OptionVideoModel : Config
    {
        public DataSet Option_Select(Int32 videoid, Int16 type)
        {
            SqlCommand cmd = new SqlCommand("OptionVideo_Select");
            cmd.Parameters.Add(new SqlParameter("@videoid", videoid));
            cmd.Parameters.Add(new SqlParameter("@type", type));
            return getDataSet(cmd);
        }
        public Boolean OptionVideo_Delete(int id, String sType)
        {
            SqlCommand cmd = new SqlCommand("OptionVideo_DeleteItem");
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@type", sType));
            return ExcuteNonquery(cmd);
        }
    }
}