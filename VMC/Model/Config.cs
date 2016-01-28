using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace VMC.Model
{
    public class Config
    {
        public SqlConnection getConnect()
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCON"].ConnectionString);
            if (cnn.State != ConnectionState.Open)
                cnn.Open();
            return cnn;
        }

        public Boolean ExcuteNonquery(SqlCommand cmd)
        {
            Boolean bRet = false;
            try
            {
                cmd.Connection = getConnect();
                //cmd.CommandText = "";
                cmd.CommandType = CommandType.StoredProcedure;
                //
                if (cmd.ExecuteNonQuery() > 0)  //kiem tra so luong ban ghi tac dung
                    bRet = true;
                else
                    bRet = false;
            }
            catch (Exception ex)
            {
                bRet = false;
                throw new Exception(ex.ToString());
            }
            finally // chay bt hoac chay co loi cung chay vao finnaly nay de dong ket noi va giai phong bo nho
            {
                if ((cmd.Connection != null) && (cmd.Connection.State == ConnectionState.Open))
                    cmd.Connection.Close(); //dong ket noi
                cmd.Dispose();  //
            }
            return bRet;
        }

        public DataSet getDataSet(SqlCommand cmd)
        {
            DataSet dsRet = new DataSet();
            try
            {
                cmd.Connection = getConnect();
                cmd.CommandType = CommandType.StoredProcedure;
                using (DataSet ds = new DataSet())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        dsRet = ds;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally // chay bt hoac chay co loi cung chay vao finnaly nay de dong ket noi va giai phong bo nho
            {
                if ((cmd.Connection != null) && (cmd.Connection.State == ConnectionState.Open))
                    cmd.Connection.Close(); //dong ket noi
                cmd.Dispose();  //
            }
            return dsRet;
        }

        public DataTable getDataTable(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection = getConnect();
                cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally // chay bt hoac chay co loi cung chay vao finnaly nay de dong ket noi va giai phong bo nho
            {
                if ((cmd.Connection != null) && (cmd.Connection.State == ConnectionState.Open))
                    cmd.Connection.Close(); //dong ket noi
                cmd.Dispose();  //
            }
            return dt;
        }
    }
}