using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VMC.Common
{
    public class FillData
    {
        public static String FillDataTextbox(DataSet ds, TextBox[] Arr)
        {
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    txtname.Text = ds.Tables[0].Rows[0]["name"].ToString();
            //}
            return "";
        }

        public static void FillDataListBox(DataSet dsFull, DataSet dsSelected, ListBox lb, string field, string val, string fieldSelect)
        {
            lb.DataSource = dsFull;
            lb.DataTextField = field;
            lb.DataValueField = val;
            lb.DataBind();
            if (dsSelected != null && dsSelected.Tables.Count > 0 && dsSelected.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsSelected.Tables[0].Rows.Count; i++)
                {
                    foreach (ListItem item in lb.Items)
                    {
                        if (item.Value.Equals(dsSelected.Tables[0].Rows[i][fieldSelect].ToString()))
                            item.Selected = true;
                    }
                }
            }
        }
    }
}