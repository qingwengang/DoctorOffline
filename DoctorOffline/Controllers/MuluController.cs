using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorOffline.Entity;
using DoctorOffline.Models;
using DoctorOffline.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorOffline.Controllers
{
    public class MuluController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<MuluModel> mms=new OnlineMuluService().getMuluModel();
            List<OnlineMulu> muluList = new OnlineMuluService().getMuluList();
            ViewData["mulus"]=muluList;
            ViewData["mm"]=mms;
            return View();
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
    }
}
