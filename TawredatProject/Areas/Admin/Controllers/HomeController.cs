using BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TawredatProject.Models;

namespace TawredatProject.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin,الصفحة الرئيسية")]

    public class HomeController : Controller
    {

        ProductService productService;
        public HomeController(ProductService ProductService)
        {
            productService = ProductService;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Coming()
        {
            HomePageModel model = new HomePageModel();
            model.lstProducts = productService.GetMostSearched();

            return View(model);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
