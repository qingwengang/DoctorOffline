using DoctorOffline.Entity;
using DoctorOffline.Models;
using DoctorOffline.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorOffline.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index(long muluId)
        {
            if (muluId <= 0)
            {
                muluId = 1;
            }
            StringBuilder sbHtml = new StringBuilder();
            List<SchoolMulu> muluList = new SchoolMuluService().GetAll();
            List<String> types = new List<string>();
            foreach(SchoolMulu mulu in muluList)
            {
                if (!types.Contains(mulu.Type1))
                {
                    types.Add(mulu.Type1);
                }
            }
            foreach(String type in types)
            {
                sbHtml.AppendFormat("<li><span>{0}</span>", type);
                if(muluList.Where(x => x.Type1 == type).Count() > 0)
                {
                    sbHtml.Append("<ul>");
                    foreach (var mulu in muluList.Where(x => x.Type1 == type))
                    {
                        sbHtml.AppendFormat("<li><span id='{1}' class='mulu {2}' onclick='GetContent({1})'>{0}</span></li>", mulu.Name,mulu.Id,mulu.IfPassed==1?"green":"");
                    }
                    sbHtml.Append("</ul>");
                }
                sbHtml.AppendFormat("</li>");
            }

            SchoolContent content = new SchoolContentService().GetByMuluId(muluId);
            if (String.IsNullOrEmpty(content.Titles))
            {
                content.Titles = "";
            }
            ViewData["titles"] = content.Titles.Split('|');
            ViewData["content"] = content;
            ViewData["html"] = sbHtml.ToString();
            ViewData["muluId"] = muluId;
            return View();
        }
        public JsonResult GetContent(long muluId)
        {
            SchoolContentModel model = new SchoolContentModel();
            SchoolContent content = new SchoolContentService().GetByMuluId(muluId);
            
            if (content != null)
            {
                if (!string.IsNullOrEmpty(content.Content))
                {
                    model.content = content.Content;
                }else
                {
                    model.content = content.OutContent;
                }
            }
            if(model.content==null)
            {
                model.content = "";
            }            
            StringBuilder sbLis = new StringBuilder();
            String[] titles = content.Titles.Split('|');
            foreach(var title in titles)
            {
                sbLis.AppendFormat("<li><a onclick=\"a('{0}')\">{0}</a><a onclick=\"b('{0}')\">bing</a></li>", title);
            }
            model.hs = sbLis.ToString();
            return Json(model);
        }
        public JsonResult SaveContent(long muluId,string content)
        {
            try
            {
                SchoolContent schoolContent = new SchoolContentService().GetByMuluId(muluId);
                schoolContent.Content = content;
                new SchoolContentService().Save(schoolContent);
            }catch(Exception e)
            {
                return Json("fail");
            }
            return Json("success");
        }
        public JsonResult Pass(long muluId)
        {
            try
            {
                SchoolMulu mulu = new SchoolMuluService().GetByMuluId(muluId);
                mulu.IfPassed = 1;
                new SchoolMuluService().Update(mulu);
            }
            catch (Exception e)
            {
                return Json("fail");
            }
            return Json("success");
        }
    }
}
