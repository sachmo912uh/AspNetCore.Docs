﻿using System;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Localization;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Localization;

namespace Localization.StarterWeb.Controllers
{
    public class TestController : Controller
    {
        private readonly IStringLocalizer _localizer;
        private readonly IStringLocalizer _localizer2;

        public TestController(IStringLocalizerFactory factory)
        {
            _localizer = factory.Create(typeof(SharedResource));
            _localizer2 = factory.Create("SharedResource", location: null);
        }       

        public IActionResult About()
        {
            ViewData["Message"] = _localizer["Your application description page."] 
                + " loc 2: " + _localizer2["Your application description page."];

            return View();
        }        
       
        public IActionResult Contact()
        {
            ViewData["Message"] = _localizer["Your contact page."]
                + " shared 2: " + _localizer2["Your contact page."];
            return View();
        }

        public IActionResult Hello(string name)
        {
            ViewData["Message"] = _localizer["<b>Hello</b><i> {0}</i>", name];

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
