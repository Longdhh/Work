using Data.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkWebAPI.Controllers
{
    public class CompanyController : Controller
    {
        CompanyProvider companyProvider = new CompanyProvider();
        public IActionResult Index()
        {
            return View();
        }
    }
}
