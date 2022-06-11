using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.Data;
using GP.Domain.Entities;
//
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using GP.Service;
using GP.Web.Models;
//
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace GP.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController

        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService _prdsrv, ICategoryService _catsrv, IWebHostEnvironment _hostEnvironment)
        {
            productService = _prdsrv;
            categoryService = _catsrv;
            hostEnvironment = _hostEnvironment;
        }

        public ActionResult Index2()
        {
            var list = productService.GetMany();
            return View(list);
        }
        public ActionResult Index(string filtre)
        {
            var listproduct = productService.GetMany();

            if (!String.IsNullOrEmpty(filtre))
            {
                listproduct = productService.GetProductByName(filtre);
            }

            List<ProductModel> listproductmodel = new List<ProductModel>();

            foreach (var product in listproduct)
            {
                var productmodel = new ProductModel(product);
                productmodel.NbreClient = productService.GetClientNbre(product.ProductId);
                listproductmodel.Add(productmodel);
            }

            return View(listproductmodel);
        }

        public ActionResult _Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = productService.GetMany()
                .FirstOrDefault(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            return PartialView(product);

        }
        // GET: ProductController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = productService.GetMany()
                .FirstOrDefault(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(categoryService.GetMany(), "CategoryId", "Name");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p, IFormFile file )
        {
            try
            {
                string wwwRootPath = hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                p.ImageName = fileName;
                string path = Path.Combine(wwwRootPath + "/Upload/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                productService.Add(p);
                productService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = productService.GetById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.CategoryId = new SelectList(categoryService.GetMany(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prd)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    productService.Update(prd);
                    productService.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(prd.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryId = new SelectList(categoryService.GetMany(), "CategoryId", "Name", prd.CategoryId);
            return View(prd);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = productService.GetMany()
                .FirstOrDefault(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var product = productService.GetById(id);
            productService.Delete(product);
            productService.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return productService.GetMany().Any(e => e.ProductId == id);
        }
    }
}
