using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WEB_NETCORE_SACHS.Models;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace WEB_NETCORE_SACHS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
      
        public async Task<IActionResult> Index(int page =0)
        {
            int kichthuc = 10;
            int tongdong = db.Saches.ToList().Count();
            int sotrang = (int)tongdong / kichthuc;
            ViewBag.sotrang = sotrang;
            this.ViewBag.Page = page;
            
            var qry = db.Saches.Skip(page * kichthuc).Take(kichthuc).ToListAsync();

           
            return View(await qry);
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
