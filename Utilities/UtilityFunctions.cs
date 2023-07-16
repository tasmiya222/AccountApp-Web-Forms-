using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AccountApp
{
    public class UtilityFunctions
    {
        public UtilityFunctions()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string GetCurrentUserRole()
        {
            if (HttpContext.Current.Session["LoggedInUserRole"] == null)
            {
                //HttpContext.Current.Response.Redirect("~/");
                HttpContext.Current.Response.Redirect("~/Login.aspx");
                return "";
            }

            return HttpContext.Current.Session["LoggedInUserRole"].ToString();
        }

        public static string GetCurrentEntityType()
        {
            if (HttpContext.Current.Session["LoggedInUserEntityType"] == null)
            {
                //HttpContext.Current.Response.Redirect("~/");
                HttpContext.Current.Response.Redirect("~/Login.aspx");
                return "";
            }

            return HttpContext.Current.Session["LoggedInUserEntityType"].ToString();
        }

        public static string GetCurrentEntityID()
        {
            if (HttpContext.Current.Session["LoggedInUserEntityID"] == null)
            {
                //HttpContext.Current.Response.Redirect("~/");
                HttpContext.Current.Response.Redirect("~/Login.aspx");
                return "";
            }

            return HttpContext.Current.Session["LoggedInUserEntityID"].ToString();
        }

        public static string GetCurrentUserID()
        {
            if (HttpContext.Current.Session["LoggedInUserID"] == null)
            {
                //HttpContext.Current.Response.Redirect("~/");
                HttpContext.Current.Response.Redirect("~/Login.aspx");
                return "";
            }

            return HttpContext.Current.Session["LoggedInUserID"].ToString();
        }

        public static string GetCurrentUserName()
        {
            if (HttpContext.Current.Session["LoggedInUserName"] == null)
            {
                //HttpContext.Current.Response.Redirect("~/");
                HttpContext.Current.Response.Redirect("~/Login.aspx");
                return "";
            }

            return HttpContext.Current.Session["LoggedInUserName"].ToString();
        }

        public static string GetCurrentUserEmail()
        {
            if (HttpContext.Current.Session["LoggedInUserEmail"] == null)
            {
                //HttpContext.Current.Response.Redirect("~/");
                HttpContext.Current.Response.Redirect("~/Login.aspx");
                return "";
            }

            return HttpContext.Current.Session["LoggedInUserEmail"].ToString();
        }


        public static string GetDomainUrl()
        {
            return ConfigurationManager.AppSettings["WebsiteUrl"].ToString();
        }

        public static bool IsCompanyUser()
        {
            if (GetCurrentEntityType() == "company")
            {
                return true;
            }
            return false;

        }

        public static string GetFileName(object fileName)
        {

            if (fileName == null)
                return "";
            var file = fileName.ToString();
            var str = file.Substring(fileName.ToString().IndexOf("_", System.StringComparison.Ordinal) + 1);


            return str;
        }


        public static bool IsImage(object path)
        {

            if (path == null)
                return false;
            var flag = path.ToString().EndsWith(".jpg") || path.ToString().EndsWith(".jpeg") || path.ToString().EndsWith(".gif") || path.ToString().EndsWith(".png");


            return flag;
        }

        public static string GetUniqueString()
        {
            return Convert.ToString((long)((((DateTime.Now.Hour + DateTime.Now.Minute) + DateTime.Now.Second) + DateTime.Now.Millisecond) + DateTime.Now.Ticks));
        }

        internal static object InsertIntoEmailLog(string emailType, string recordType, string v1, string v2, string subject, string description, int recordID, Dictionary<string, string> attachmentsPath, out int emailLogId, string status)
        {
            throw new NotImplementedException();
        }
    }
}