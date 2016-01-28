using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace VMC
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("file",
            "File/Edit/{FileId}",
            "~/FileEdit/Edit.aspx");
            //admin
            routes.MapPageRoute("permission",
            "Role/Permission/{RoleId}",
            "~/Role/Permission.aspx");
            //routes.MapPageRoute("Manage",
            //"{Account}/{Manage}",
            //"~/Account/Manage.aspx");

            routes.EnableFriendlyUrls();
        }
        //public static bool SendMail(string YourName, string srcEmail, string desEmail, string Subject, string Content)
        //{
        //    String FilterMail = "[Bộ lọc] ";
        //    SmtpClient SmtpServer = new SmtpClient();
        //    SmtpServer.Credentials = new System.Net.NetworkCredential("email gui", "pass email gui");
        //    SmtpServer.Port = 587;
        //    SmtpServer.Host = "smtp.gmail.com";
        //    SmtpServer.EnableSsl = true;
        //    MailMessage mail = new MailMessage();
        //    String[] addr = desEmail.Split(',');
        //    mail.From = new MailAddress(srcEmail, srcEmail, System.Text.Encoding.UTF8);
        //    Byte i;
        //    for (i = 0; i < addr.Length; i++)
        //        mail.To.Add(addr[i]);
        //    mail.Subject = FilterMail + Subject;
        //    mail.Bcc.Add("thang.991992@gmail.com");
        //    mail.Body = Content;
        //    mail.IsBodyHtml = true;
        //    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        //    mail.ReplyTo = new MailAddress(srcEmail);
        //    SmtpServer.Send(mail);
        //    return true;
        //}
    }
}
