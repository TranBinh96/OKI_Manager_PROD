using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRespository;
using Bulky.DataAccess.Respository.IRespository;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers;

public class CategoryController : Controller
{
    public readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public IActionResult Index()
    {
        var objCategoryList = _unitOfWork.Category.GetAll().ToList();
        return View(objCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category obj)
    {
        /*if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name","The Display Order cannot exactly match the Name.");
        }

        if (obj.Name.ToLower( )== "test")
        {
            ModelState.AddModelError("","Test is an invalid value");
        }*/
        if (ModelState.IsValid)
        {
            _unitOfWork.Category.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category created successfully"; 
            return RedirectToAction("Index");
        }

        return View();
    }
    
    public IActionResult Edit(int? id)
    {
        if (id == null && id == 0)
        {
            return NotFound();
        }

        Category categoryToDb = _unitOfWork.Category.GetFirstOrDefault(x=> x.CategoryId == id  );
        if (categoryToDb == null)
        {
            return NotFound();
        }
        return View(categoryToDb);
        
    }
    
    [HttpPost]
    public IActionResult Edit(Category obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Category.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category update successfully";
            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult Delete(int? id)
    {
        if (id == 0 || id == null)
        {
            return NotFound();
        }

        var category = _unitOfWork.Category.GetFirstOrDefault(x=> x.CategoryId ==id);    
        if (category != null)
        {
            return View(category);
        }
        
        return NotFound();
    }
    
    [HttpPost]
    public IActionResult Delete(Category obj) 
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category delete successfully";
            return RedirectToAction("Index");
        }

        return View();
    }
}