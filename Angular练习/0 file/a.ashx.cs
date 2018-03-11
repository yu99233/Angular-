using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angular练习._0_file
{
    /// <summary>
    /// a 的摘要说明
    /// </summary>
    public class a:IHttpHandler
    {

        public void ProcessRequest (HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var v1 = Convert.ToInt32(context.Request["a"]);
            var v2 = Convert.ToInt32(context.Request["b"]);
            var num = v1 + v2;
            context.Response.Write(num);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}