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
using Microsoft.AspNetCore.Identity;

namespace TawredatProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplierSubscriptionController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        SupplierService supplierService;
        SupplierSubscriptionService supplierSubscriptionService;

        TawredatDbContext ctx;
        public SupplierSubscriptionController(UserManager<ApplicationUser> userManager, SupplierService SupplierService,SupplierSubscriptionService SupplierSubscriptionService,AboutAppService AboutAppService, TawredatDbContext context)
        {
            supplierService = SupplierService;
            _userManager = userManager;
            supplierSubscriptionService = SupplierSubscriptionService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, اشتراكات التجار")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstSupplierSubscription = supplierSubscriptionService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbSupplierSubscription ITEM, int id, List<IFormFile> files)
        {
            ITEM.SupplierName = _userManager.Users.Where(a => a.Id == ITEM.SupplierId.ToString()).FirstOrDefault().FirstName;
            if (ITEM.SupplierSubscriptionId == null)
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





                    var result = supplierSubscriptionService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Supplier Subscription  Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Supplier Subscription Profile  Creating.";
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






                    var result = supplierSubscriptionService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Supplier Subscription Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Supplier Subscription Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstSupplierSubscription = supplierSubscriptionService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف   اشتراكات التجار")]
        public IActionResult Delete(Guid id)
        {

            TbSupplierSubscription oldItem = ctx.TbSupplierSubscriptions.Where(a => a.SupplierSubscriptionId == id).FirstOrDefault();



            var result = supplierSubscriptionService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Supplier Subscription Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Supplier Subscription Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstSupplierSubscription = supplierSubscriptionService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل   اشتراكات التجار")]
        public IActionResult Form(Guid? id)
        {
            TbSupplierSubscription oldItem = ctx.TbSupplierSubscriptions.Where(a => a.SupplierSubscriptionId == id).FirstOrDefault();
            ViewBag.Suppliers = _userManager.Users.Where(a => a.Status == "تاجر").ToList();

            return View(oldItem);
        }
    }
}
