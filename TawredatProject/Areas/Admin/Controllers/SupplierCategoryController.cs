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
    public class SupplierCategoryController : Controller
    {
        SupplierCategoryService supplierCategoryService;

        TawredatDbContext ctx;
        public SupplierCategoryController(SupplierCategoryService SupplierCategoryService, TawredatDbContext context)
        {

            supplierCategoryService = SupplierCategoryService;
            ctx = context;

        }
        [Authorize(Roles = "Admin, اقسام التجار")]
        public IActionResult Index()
        {

            HomePageModel model = new HomePageModel();
            model.lstSupplierCategories = supplierCategoryService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbSupplierCategory ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.SupplierCategoryId == null)
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





                    var result = supplierCategoryService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Supplier Category  Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Supplier Category  Profile  Creating.";
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






                    var result = supplierCategoryService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Supplier Category  Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Supplier Category  Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstSupplierCategories = supplierCategoryService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف  اقسام التجار")]
        public IActionResult Delete(Guid id)
        {

            TbSupplierCategory oldItem = ctx.TbSupplierCategories.Where(a => a.SupplierCategoryId == id).FirstOrDefault();



            var result = supplierCategoryService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Supplier Category  Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Supplier Category  Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstSupplierCategories = supplierCategoryService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin, اضافة او تعديل  اقسام التجار")]
        public IActionResult Form(Guid? id)
        {
            TbSupplierCategory oldItem = ctx.TbSupplierCategories.Where(a => a.SupplierCategoryId == id).FirstOrDefault();
            

            return View(oldItem);
        }
    }
}
