using System;
using Microsoft.AspNetCore.Mvc;
using OdeToFood_Core.Data.Models;
using OdeToFood_Core.Data.Services;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantController : Controller
    {
        readonly IRestaurantData db;
        public RestaurantController(IRestaurantData data)
        {
            db = data;
        }
        // GET: Restaurant
        [HttpGet]
        public ActionResult Index(string name)
        {
            var model = db.GetAll();

            // pulling config data from Web.config
            //var test = ConfigurationManager.AppSettings["connectionString"];

            // Comes in from query string:
            var n = name ?? "no name given";

            // View only accepts a model instance
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.Get(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // These could be ambiguous at first --- MVC framework doesn't know what to talk to when it posts back the form.
        // Need to be more explicit
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //Model binding -- when MVC framework figures out what kind of model is included in the request 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant r)
        {
            // More of the long-form type of validation: use [DATA ANNOTATIONS] on models instead
            if (String.IsNullOrEmpty(r.Name))
            {
                ModelState.AddModelError(nameof(r.Name), "No empty names!");
            }

            // This doesn't work because there is a default enum value so Enum is always defined
            if (!Enum.IsDefined(typeof(CuisineType), r.Cuisine))
            {
                ModelState.AddModelError(nameof(r.Cuisine), "Cuisine is required.");
            }

            if (ModelState.IsValid)
            {
                db.Create(r);
                return RedirectToAction("Details/", new { id = r.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var restaurant = db.Get(id);
            if (restaurant == null)
            {
                return View(restaurant); // HttpNotFound();
            }

            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Restaurant r)
        {
            if (ModelState.IsValid)
            {
                db.Update(r);

                return RedirectToAction("Details/", new { id = r.Id });
            }

            return View(r);
        }
    }
}