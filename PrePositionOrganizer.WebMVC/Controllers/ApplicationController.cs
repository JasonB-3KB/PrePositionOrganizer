using Microsoft.AspNet.Identity;
using PrePositionOrganizer.Data;
using PrePositionOrganizer.Models;
using PrePositionOrganizer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrePositionOrganizer.WebMVC.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        // GET: Application
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ApplicationService(userId);
            List<Application> applications = service.GetApplicationList().ToList();
            var model = service.GetApplications();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationCreate model)
        {
            if (!ModelState.IsValid) return View(model);           
            

            var service = CreateApplicationService();
            if (service.CreateApplication(model))
            {
                TempData["SaveResult"] = "Your Entry was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Entry was unsuccessful.");
            return View(model);            
        }

        public ActionResult Details(int id)
        {
            var svc = CreateApplicationService();
            var model = svc.GetApplicationById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateApplicationService();
            var detail = service.GetApplicationById(id);
            var model =
                new ApplicationEdit
                {
                    ApplicationId = detail.ApplicationId,
                    Status = detail.Status,
                    MyInterest = detail.MyInterest
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ApplicationEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.ApplicationId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateApplicationService();

            if (service.UpdateApplication(model))
            {
                TempData["SaveResult"] = "Your Application was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Application was not updated.");
            return View(model);
        }
        private ApplicationService CreateApplicationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ApplicationService(userId);
            return service;
        }
    }
}