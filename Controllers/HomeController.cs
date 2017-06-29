using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using demoken.Model;

namespace demoken.Controllers
{
   public class HomeController : Controller
    {
        StoreContext db;
        public HomeController()
        {
            db = new StoreContext();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Sales_Read([DataSourceRequest] DataSourceRequest request)
        {
            var sales = db.MonthlySales.Select(i => new MonthlySaleVm { id = i.Id, month = i.Month, videoGames = i.VideoGames, dvds = i.DVDs, bluRays = i.BluRays });
            return Json(sales.ToDataSourceResult(request));
        }
        [HttpPost]
        public IActionResult Sales_Create([DataSourceRequest] DataSourceRequest request, MonthlySaleVm vm)
        {
            var model = new MonthlySale { Month = vm.month, VideoGames = vm.videoGames, DVDs = vm.dvds, BluRays = vm.bluRays };
            db.MonthlySales.Add(model);
            db.SaveChanges();
            vm.id = model.Id;
            return Json((new[] { vm }).ToDataSourceResult(request));
        }
        [HttpPut]
        public IActionResult Sales_Update([DataSourceRequest] DataSourceRequest request, MonthlySaleVm vm)
        {
            var model = db.MonthlySales.Single(i => i.Id == vm.id);
            model.Month = vm.month;
            model.VideoGames = vm.videoGames;
            model.DVDs = vm.dvds;
            model.BluRays = vm.bluRays;
            db.SaveChanges();
            return Json(new[] { vm }.ToDataSourceResult(request));
        }

        [HttpDelete]
        public ActionResult Sales_Destroy([DataSourceRequest] DataSourceRequest request, MonthlySaleVm vm)
        {
            var model = db.MonthlySales.Single(i => i.Id == vm.id);
            db.MonthlySales.Remove(model);
            db.SaveChanges();
            return Json(new[] { vm }.ToDataSourceResult(request));
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
