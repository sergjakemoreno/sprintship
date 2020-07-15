﻿using Abp.Auditing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace SprintTek.Web.Controllers
{
    public class HomeController : SprintTekControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [DisableAuditing]
        public IActionResult Index()
        {
            if (_webHostEnvironment.IsDevelopment())
            {
                return RedirectToAction("Index", "Ui");
            }

            return Redirect("/index.html");
        }
    }
}
