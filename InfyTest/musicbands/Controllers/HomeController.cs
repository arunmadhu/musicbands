﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using musicbands.Models;
using musicbands.Models.ui;
using musicbands.services;
using musicbands.translator;
using Newtonsoft.Json;

namespace musicbands.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFestivalServices service;

        public HomeController(IFestivalServices _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "The band record lable heirarchy is shown below...";
            return View();
        }

        public JsonResult GetTreeData()
        {
            var apidata = service.GetFestivals();
            var translator = new Transltor();

            return Json(translator.TranslateFesticalApi(apidata));

            //var model = new LabelModel();
            //return Json(model.GetTreeModel());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
