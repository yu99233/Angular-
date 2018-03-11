using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Angular练习._11_简易angular留言板项目
{
    /// <summary>
    /// thes 的摘要说明
    /// </summary>
    public class thes:IHttpHandler
    {

        public void ProcessRequest (HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var method = context.Request["action"];
            using(worldEntities db = new worldEntities())
            {
                if(method == "look")
                {
                    var pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
                    var list = db.weibo.Where(a => true).OrderByDescending(a => a.ID).Skip((pageIndex - 1) * 5).Take(5).ToList();
                    var count = list.Count();
                    var listSer = JsonConvert.SerializeObject(list);
                    context.Response.Write(listSer);
                }
                if(method == "page")
                {
                    var list = db.weibo.Where(a => true).ToList();
                    var count = list.Count();
                    var pageCount = (count + 5 - 1) / 5;
                    context.Response.Write(pageCount);
                }
                if(method == "add")
                {
                    var con = context.Request["con"];
                    if(!string.IsNullOrEmpty(con))
                    {
                        weibo entity = new weibo();
                        entity.Content = con;
                        entity.Acc = 0;
                        entity.Ref = 0;
                        var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970,1,1));
                        var time = (int)(DateTime.Now - startTime).TotalSeconds;
                        entity.Times = time;
                        db.weibo.Add(entity);
                        db.SaveChanges();

                        var list = db.weibo.Where(a => true).OrderByDescending(a => a.ID).FirstOrDefault();

                        var listSer = JsonConvert.SerializeObject(list);
                        context.Response.Write(listSer);

                    }
                }
                if(method == "del")
                {
                    var con = context.Request["con"];
                    if(!string.IsNullOrEmpty(con))
                    {
                        var intId = Convert.ToInt32(con);
                        var dbQ = db.Set<weibo>();
                        var entity = dbQ.Where(a => a.ID == intId).FirstOrDefault();
                        dbQ.Remove(entity);
                        db.SaveChanges();
                    }
                }
                if(method == "ref")
                {
                    var con = context.Request["con"];
                    if(!string.IsNullOrEmpty(con))
                    {
                        var intId = Convert.ToInt32(con);
                        var dbQ = db.Set<weibo>();
                        var entity = dbQ.Where(a => a.ID == intId).FirstOrDefault();
                        entity.Ref++;
                        db.SaveChanges();
                    }
                }
                if(method == "acc")
                {
                    var con = context.Request["con"];
                    if(!string.IsNullOrEmpty(con))
                    {
                        var intId = Convert.ToInt32(con);
                        var dbQ = db.Set<weibo>();
                        var entity = dbQ.Where(a => a.ID == intId).FirstOrDefault();
                        entity.Acc++;
                        db.SaveChanges();
                    }
                }
            }


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