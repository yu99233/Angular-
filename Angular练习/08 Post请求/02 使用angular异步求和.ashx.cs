using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angular练习._08_Post请求
{
    /// <summary>
    /// _02_使用angular异步求和 的摘要说明
    /// </summary>
    public class _02_使用angular异步求和:IHttpHandler
    {

        public void ProcessRequest (HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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