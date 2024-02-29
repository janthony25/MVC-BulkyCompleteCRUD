﻿using BulkyBook.DataAccess;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC_BulkyCompleteCRUD.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category added succesfully";
            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Edit(int? id)
        {

            if(id == null || id == 0)
            {
                return NotFound();
            }
            // var categoryFromDb = _db.Categories.Find(id);

            var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Name == "id");

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category updated succesfully";
            return RedirectToAction("Index");
        }


        // GET
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.Categories.Find(id);
            if (obj == null)
            {

                return NotFound();
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category deleted succesfully";
            return RedirectToAction("Index");
        }



    }
}
