using FoxmindedCrudProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace FoxmindedCrudProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<Event> events = DbInitializer.db.Events;
            return View(events);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event model)
        {
            int maxId = DbInitializer.db.Events.Max(x => x.Id);
            model.Id = maxId + 1;

            DbInitializer.db.Events.Add(model);
            //db.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = DbInitializer.db.Events.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Event Model)
        {
            var data = DbInitializer.db.Events.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null)
            {
                data.Category = Model.Category;
                data.Name = Model.Name;
                data.Images = Model.Images;
                data.Description = Model.Description;
                data.Place = Model.Place;
                data.Time = Model.Time;
                data.AdditionalInfo = Model.AdditionalInfo;
                data.AdditionalInfo = Model.AdditionalInfo;
                //db.SaveChanges();
            }

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = DbInitializer.db.Events.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Delete(Event Model)
        {
            var data = DbInitializer.db.Events.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null)
            {
                DbInitializer.db.Events.Remove(data);
            }

            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }

        public ActionResult Details(int id)
        {
            var data = DbInitializer.db.Events.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}