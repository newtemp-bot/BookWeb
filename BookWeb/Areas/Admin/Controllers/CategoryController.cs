using BookWeb.DataAccess.Repository.IRepository;
using BookWeb.Models;
using BookWeb.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        //private readonly ApplicationDbContext _db;
        //private readonly ICategoryRepository _categoryRepo;

        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            //_categoryRepo = db;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.CatName == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                //_categoryRepo.Add(obj);
                //_categoryRepo.Save();
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";

                return RedirectToAction("Index");
            }
            // If ModelState is not valid, return the view with validation errors
            return View(obj);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            //Category? categoryFromDb = _categoryRepo.Get(u => u.CatId == id);
            // Category? categoryFromDb = _db.Categories.Find(id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.CatId == id);
            //Category? categoryFromDb2 = _db.Categories.Where(u => u.CatId == id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (obj.CatName == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                // Update properties of categoryFromDb with obj properties

                //_categoryRepo.Update(obj);
                //_categoryRepo.Save();
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Update successfully";



                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            //Category? categoryFromDb = _categoryRepo.Get(u => u.CatId == id);
            // Category? categoryFromDb = _db.Categories.Find(id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.CatId == id);
            //Category? categoryFromDb2 = _db.Categories.Where(u => u.CatId == id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            // Category? obj = _categoryRepo.Get(u => u.CatId == id);
            if (obj == null)
            {
                return NotFound();
            }

            //_categoryRepo.Remove(obj);
            //_categoryRepo.Save();

            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();

            TempData["success"] = "Category Deleted successfully";

            return RedirectToAction("Index");
        }

    }
}
