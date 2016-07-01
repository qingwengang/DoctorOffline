using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorOffline.Entity;
using DoctorOffline.Models;
using DoctorOffline.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorOffline.Controllers
{
    public class MuluController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<OnlineMulu> muluList = new OnlineMuluService().getMuluList();
            ViewData["mulus"]=muluList;
            MuluModel model = new OnlineMuluService().getMuluModelById(0);
            ViewData["html"] = GetHTML(model);
            return View(model);
        }
        public String GetHTML(MuluModel model)
        {
            StringBuilder sbHtml = new StringBuilder();
            sbHtml.Append("<li>");
            sbHtml.AppendFormat("<span id='{0}' class='folder' onclick='AddClick({0},{1},\"{2}\");'>{3}</span>",model.MuluId,model.Level,model.MuluName,model.MuluName);
            if(model.children!=null && model.children.Count > 0)
            {
                sbHtml.Append("<ul>");
                foreach (var item in model.children)
                {
                    sbHtml.Append(GetHTML(item));
                }
                sbHtml.Append("</ul>");
            }
            sbHtml.Append("</li>");
            return sbHtml.ToString();
        }
        public IActionResult AddMulu(MuluModel model){
            OnlineMulu mulu = new OnlineMulu();
            mulu.Name = model.MuluName;
            mulu.Level = model.Level;
            mulu.ParentId = model.ParentId;
            new OnlineMuluService().AddMulu(mulu);
            return this.RedirectToAction("Index");
        }

        public IActionResult MuluDetail(long muluid)
        {
            MuluModel mm=new OnlineMuluService().getMuluDetail(muluid);
            if (muluid == 0)
            {
                OnlineMulu root = new OnlineMulu();
                root.ParentId = 0;
                root.Level = 0;
                root.Name = "Root";
                mm.mulu = root;
            }
            ViewData["mm"]=mm;
            return View();
        }
        public JsonResult EditRelation(long currentMuluId,string ask120Relation,string fhRelation,string JJRelation,string JKRelation,string SJRelation)
        {
            OnlineMuluRelation relation = new OnlineMuluRelation();
            relation.OnlineMuluId = currentMuluId;
            relation.Ask120Relation = ask120Relation;
            relation.FHRelation = fhRelation;
            relation.JJRelation = JJRelation;
            relation.JKRelation = JKRelation;
            relation.SJRelation = SJRelation;
            new OnlineMuluRelationService().Save(relation);
            return Json("success");
        } 
        public JsonResult GetRelation(long onlineMulu)
        {
            RelationModel model = new RelationModel();
            var relList = new OnlineMuluRelationService().GetByOnlineMuluId(onlineMulu);
            OnlineMuluRelation rel = null;
            if(relList!=null && relList.Count > 0)
            {
                rel = relList.FirstOrDefault();
            }
            if (rel != null)
            {
                model.ask120Relation = rel.Ask120Relation;
                model.fhRelation = rel.FHRelation;
                model.JJRelation = rel.JJRelation;
                model.JKRelation = rel.JKRelation;
                model.SJRelation = rel.SJRelation;
            }else
            {
                //model.ask120Relation = "";
                //model.fhRelation = "";
                //model.JJRelation = "";
                //model.JKRelation = "";
                //model.SJRelation = "";
            }
            return Json(model);
        }
    }
}
