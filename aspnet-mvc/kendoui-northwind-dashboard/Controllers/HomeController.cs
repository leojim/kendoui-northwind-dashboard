﻿using Kendo.Mvc.UI;
using KendoUI.Northwind.Dashboard.Models;
using System.Collections.Generic;
using System.Linq; 
using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using System.Collections;

namespace KendoUI.Northwind.Dashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            
            return View();
        }

        public ActionResult Customers()
        {
            PopulateEmployees();
            PopulateProducts();
            return PartialView();
        }

        public ActionResult Products()
        { 
            return PartialView();
        }

        public ActionResult Statistics()
        {
            return PartialView();
        }

        public ActionResult GetCountries()
        {
            var northwind = new NorthwindEntities();

            var countries = new string[] {
                    "Albania",
                    "Andorra",
                    "Armenia",
                    "Austria",
                    "Azerbaijan",
                    "Belarus",
                    "Belgium",
                    "Bosnia & Herzegovina",
                    "Bulgaria",
                    "Croatia",
                    "Cyprus",
                    "Czech Republic",
                    "Denmark",
                    "Estonia",
                    "Finland",
                    "France",
                    "Georgia",
                    "Germany",
                    "Greece",
                    "Hungary",
                    "Iceland",
                    "Ireland",
                    "Italy",
                    "Kosovo",
                    "Latvia",
                    "Liechtenstein",
                    "Lithuania",
                    "Luxembourg",
                    "Macedonia",
                    "Malta",
                    "Moldova",
                    "Monaco",
                    "Montenegro",
                    "Netherlands",
                    "Norway",
                    "Poland",
                    "Portugal",
                    "Romania",
                    "Russia",
                    "San Marino",
                    "Serbia",
                    "Slovakia",
                    "Slovenia",
                    "Spain",
                    "Sweden",
                    "Switzerland",
                    "Turkey",
                    "Ukraine",
                    "United Kingdom",
                    "Vatican City"
                };

            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Products_Read(string text)
        {
            var northwind = new NorthwindEntities();

            var products = northwind.Products.Select(product => new ProductViewModel
            {
                CategoryID = product.CategoryID,
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice ?? 0,
                UnitsInStock = product.UnitsInStock ?? 0,
                UnitsOnOrder = product.UnitsOnOrder ?? 0,
                Discontinued = product.Discontinued
            });

            if (!string.IsNullOrEmpty(text))
            {
                products = products.Where(p => p.ProductName.Contains(text));
            }

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        private void PopulateEmployees()
        {
            ViewData["employees"] = new NorthwindEntities().Employees.Select(e => new EmployeeViewModel
            {
                EmployeeID = e.EmployeeID,
                EmployeeName = e.FirstName + " " + e.LastName
            }).OrderBy(e => e.EmployeeName);
        }

        private void PopulateProducts()
        {
            ViewData["products"] = new NorthwindEntities().Products.Select(e => new ProductViewModel
            {
                ProductID = e.ProductID,
                ProductName = e.ProductName
            }).OrderBy(e => e.ProductName);
        }

    }
}
