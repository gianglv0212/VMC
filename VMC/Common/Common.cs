using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using VMC.EO;

namespace VMC.Common
{
    public class Common
    {
        public static Object getDBNull(Object objInput, TypeCode tDataType)
        {
            Int16 iiTemp = 0;
            Int32 iTemp = 0;
            Int64 lTemp = 0;
            String sTemp = "";
            switch (tDataType)
            {
                case TypeCode.Int16:
                    if (!Int16.TryParse(Convert.ToString(objInput), out iiTemp))
                        return DBNull.Value;
                    else if (iiTemp == 0)
                        return DBNull.Value;
                    else
                        return objInput;
                    break;
                case TypeCode.Int32:
                    if (!Int32.TryParse(Convert.ToString(objInput), out iTemp))
                        return DBNull.Value;
                    else if (iTemp == 0)
                        return DBNull.Value;
                    else
                        return objInput;
                    break;

                case TypeCode.Int64:
                    if (!Int64.TryParse(Convert.ToString(objInput), out lTemp))
                        return DBNull.Value;
                    else if (iTemp == 0)
                        return DBNull.Value;
                    else
                        return objInput;
                    break;
                case TypeCode.String:
                    if (String.IsNullOrEmpty(Convert.ToString(objInput)))
                        return DBNull.Value;
                    break;
                default: return objInput; break;
            }
            return objInput;
        }

        public static String getQueryString(String sKey)
        {
            if (System.Web.HttpContext.Current.Request.QueryString[sKey] == null)
                return "";
            else
                return System.Web.HttpContext.Current.Request.QueryString[sKey];
        }

        public static LoginEO getUserInfo()
        {
            LoginEO objRet = new LoginEO();
            if (System.Web.HttpContext.Current.Session["uid"] != null)
                objRet = (LoginEO)System.Web.HttpContext.Current.Session["uid"];
            return objRet;
        }

        public static string MD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public static string UTF8toASCII(string text)
        {
            //First to lower case 
            text = text.ToLowerInvariant();

            for (int i = 32; i < 48; i++)
            {

                text = text.Replace(((char)i).ToString(), " ");

            }
            text = text.Replace(".", "-");

            text = text.Replace(" ", "-");

            text = text.Replace(",", "-");

            text = text.Replace(";", "-");

            text = text.Replace(":", "-");
            text = text.Replace("?", "-");
            text = text.Replace("!", "-");
            text = text.Replace("(", "-");
            text = text.Replace(")", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");

            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);

            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        
    }
}