using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var headingValue = hm.GetList();
            return View(headingValue);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,

                                                      Value = x.CategoryId.ToString()

                                                  }).ToList() ;
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Items p)
        {
            HeadingValidator hv = new HeadingValidator();
            ValidationResult results = hv.Validate(p);
            if (results.IsValid)
            {
                hm.HeadingAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;

            var headingValue = hm.GetById(id); 
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Items p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }


        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            
            hm.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }

       
    }
}