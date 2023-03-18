using BL;
using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System;
using TawredatProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace TawredatProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PurchaseSubscribtionController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        PurchaserSubscriptionService purchaserSubscription;

        TawredatDbContext ctx;
        public PurchaseSubscribtionController(UserManager<ApplicationUser> userManager, PurchaserSubscriptionService PurchaserSubscription, TawredatDbContext context)
        {
           
            _userManager = userManager;
            purchaserSubscription = PurchaserSubscription;
            ctx = context;

        }
        [Authorize(Roles = "Admin, اشتراكات مديري المشتريات")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstPurchaseSubscribtion = purchaserSubscription.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbPurchaseSubscribtion ITEM, int id, List<IFormFile> files)
        {
            ITEM.PurchaserName = _userManager.Users.Where(a => a.Id == ITEM.PurchaserId.ToString()).FirstOrDefault().FirstName;
            if (ITEM.PurchaserSubscriptionId == null)
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





                    var result = purchaserSubscription.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Purchaser Subscription  Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Purchaser Subscription Profile  Creating.";
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






                    var result = purchaserSubscription.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Purchaser Subscription Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Purchaser Subscription Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstPurchaseSubscribtion = purchaserSubscription.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف   اشتراكات مديري المشتريات")]
        public IActionResult Delete(Guid id)
        {

            TbPurchaseSubscribtion oldItem = ctx.TbPurchaseSubscribtions.Where(a => a.PurchaserSubscriptionId == id).FirstOrDefault();



            var result = purchaserSubscription.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Purchaser Subscription Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Purchaser Subscription Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstPurchaseSubscribtion = purchaserSubscription.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل   اشتراكات مديري المشتريات")]
        public IActionResult Form(Guid? id)
        {
            TbPurchaseSubscribtion oldItem = ctx.TbPurchaseSubscribtions.Where(a => a.PurchaserSubscriptionId == id).FirstOrDefault();
            ViewBag.Purchasers = _userManager.Users.Where(a => a.Status == "مدير مشتريات").ToList();

            return View(oldItem);
        }
    }
}
