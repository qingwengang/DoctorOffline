using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoctorOffline.Entity;
using DoctorOffline.Service;

namespace DoctorOffline.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<OnlineMulu> muluList = new OnlineMuluService().getMuluList();
            ViewData["mulus"]=muluList;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
