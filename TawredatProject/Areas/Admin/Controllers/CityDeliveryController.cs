using BL;
using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System;
using TawredatProject.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace TawredatProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityDeliveryController : Controller
    {
        CityService cityService;
        CityDeliveryService cityDeliveryService;

        TawredatDbContext ctx;
        public CityDeliveryController(CityService CityService, CityDeliveryService CityDeliveryService, TawredatDbContext context)
        {
            cityService = CityService;
            cityDeliveryService = CityDeliveryService;
            ctx = context;

        }
        [Authorize(Roles = "Admin,قيمة الشحن للمدن")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstCityDeliveryFees = cityDeliveryService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbCityDeliveryFees ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.CityDeliveryFeesId == null)
            {


                if (ModelState.IsValid)
                {
                    //foreach (var file in files)
                    //{
                    //    if (file.Length > 0)
                    //    {
                    //        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    //        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                    //        using (var stream = System.IO.File.Create(filePaths))
                    //        {
                    //            await file.CopyToAsync(stream);
                    //        }
                    //        ITEM.ab = ImageName;
                    //    }
                    //}





                    var result = cityDeliveryService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "City Delivery Fess Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in City Delivery Fess Profile  Creating.";
                    }


                }


            }
            else
            {
                if (ModelState.IsValid)
                {
                    //foreach (var file in files)
                    //{
                    //    if (file.Length > 0)
                    //    {
                    //        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    //        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                    //        using (var stream = System.IO.File.Create(filePaths))
                    //        {
                    //            await file.CopyToAsync(stream);
                    //        }
                    //        ITEM.MainConsultingImage = ImageName;
                    //    }
                    //}






                    var result = cityDeliveryService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "City Delivery Fess Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in City Delivery Fess Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstCityDeliveryFees = cityDeliveryService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف قيمة الشحن للمدن")]
        public IActionResult Delete(Guid id)
        {

            TbCityDeliveryFees oldItem = ctx.TbCityDeliveryFeess.Where(a => a.CityDeliveryFeesId == id).FirstOrDefault();



            var result = cityDeliveryService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "City Delivery Fess Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in City Delivery Fess Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstCityDeliveryFees = cityDeliveryService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل قيمة الشحن للمدن")]
        public IActionResult Form(Guid? id)
        {
            TbCityDeliveryFees oldItem = ctx.TbCityDeliveryFeess.Where(a => a.CityDeliveryFeesId == id).FirstOrDefault();

            ViewBag.realCities = cityService.getAll();

            return View(oldItem);
        }
    }
}
