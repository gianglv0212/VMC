using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace VMC.Model
{
    public class DeviceModel : Config
    {
        public DataSet Device_Select(int type)
        {
            SqlCommand cmd = new SqlCommand("Device_Select");
            cmd.Parameters.Add(new SqlParameter("@type", type));
            return getDataSet(cmd);
        }
    }
}