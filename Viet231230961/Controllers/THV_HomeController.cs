using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Viet231230961.Models;

namespace Viet231230961.Controllers
{
    public class THV_HomeController : Controller
    {
        private readonly ILogger<THV_HomeController> _logger;
        private readonly VanTai2512V1Context db;
        public THV_HomeController(ILogger<THV_HomeController> logger, VanTai2512V1Context context)
        {
            db = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult ChuyenXe()
        {
            var model = db.Chuyens
                          .OrderBy(x => x.SoXe)
                          .Take(6)
                          .Select(x => new
                          {
                              x.MaChuyen,
                              x.MaTuyen,
                              x.SoXe,
                              x.MaLaiXe,
                               x.SoXeNavigation,
                               x.MaLaiXeNavigation,

                              Ngay = x.NgayGio == null ? null : x.NgayGio.Value.ToString("dd/MM/yyyy"),
                              Gio = x.NgayGio == null ? null : x.NgayGio.Value.ToString("HH:mm")

                          })
                          .ToList();

            return Json(model);
        }
        public JsonResult TuyenXe()
        {
            var mode = db.Tuyens;
            return Json(mode);
        }
        public JsonResult ChuyenXeTheoTuyen(string maTuyen)
        {
            var model = db.Chuyens
                          .Where(x => x.MaTuyen == maTuyen)
                          .OrderBy(x => x.SoXe)
                          .Select(x => new
                          {
                              x.MaChuyen,
                              x.MaTuyen,
                              x.SoXe,
                              x.MaLaiXe,
                              Ngay = x.NgayGio == null ? null : x.NgayGio.Value.ToString("dd/MM/yyyy"),
                              Gio = x.NgayGio == null ? null : x.NgayGio.Value.ToString("HH:mm")
                          })
                          .ToList();

            return Json(model);
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
