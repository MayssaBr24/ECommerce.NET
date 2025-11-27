using atelier2.Models;
using atelier2.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace atelier2.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class CategoryController : Controller
    {

        readonly ICategorieRepository categoryRepository;
        public CategoryController(ICategorieRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        // GET: CategoryController
        [AllowAnonymous]

        public ActionResult Index()
        {
            var category = categoryRepository.GetAll();
            ViewData["Categories"] = category;

            return View(category);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var cat = categoryRepository.GetById(id);
            var categories = categoryRepository.GetAll();
            ViewData["Categories"] = categories;
            return View(cat);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            var categories = categoryRepository.GetAll();
            ViewData["Categories"] = categories;

            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                categoryRepository.Add(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var categories = categoryRepository.GetAll();
            ViewData["Categories"] = categories;
            return View(categoryRepository.GetById(id));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category cat)
        {
            try
            {
                categoryRepository.Update(cat);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var categories = categoryRepository.GetAll();
            ViewData["Categories"] = categories;
            return View(categoryRepository.GetById(id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Category cat)
        {
            try
            {
                categoryRepository.Delete(cat.CategoryId);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
