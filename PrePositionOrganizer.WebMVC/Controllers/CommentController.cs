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
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            var aservice2 = new ApplicationService(userId);
            var model = service.GetComments();
            //List<Application> applications = aservice2.GetApplicationList().ToList();

            ViewData["ApplicationId"] = aservice2.GetApplications().Select(e => new SelectListItem
            {
                Text = e.CompanyName,
                Value = e.ApplicationId.ToString()
            });
            return View(model);
        }

        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var aservice = new ApplicationService(userId);

            List<Application> applications = aservice.GetApplicationList().ToList();

            ViewData["ApplicationId"] = aservice.GetApplications().Select(e => new SelectListItem
            {
                Text = e.CompanyName,
                Value = e.ApplicationId.ToString()
            });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreate model)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var aservice = new ApplicationService(userId);

            //List<Application> applications = aservice.GetApplicationList().ToList();

            ViewData["ApplicationId"] = aservice.GetApplications().Select(e => new SelectListItem
            {
                Text = e.CompanyName,
                Value = e.ApplicationId.ToString()
            });


            if (!ModelState.IsValid) return View(model);          
            

            var service = CreateCommentService();

            if (service.CreateComment(model))
            {
                TempData["SaveResult"] = "Your comment was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Comment was not added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCommentService();
            var model = svc.GetCommentById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCommentService();
            var detail = service.GetCommentById(id);
            var model =
                new CommentEdit
                {
                    CommentId = detail.CommentId,
                    Text = detail.Text,

                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CommentEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.CommentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCommentService();

            if (service.UpdateComment(model))
            {
                TempData["SaveResult"] = "Your comment was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your comment was not updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCommentService();
            var model = svc.GetCommentById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCommentService();

            service.DeleteComment(id);

            TempData["SaveResult"] = "Your comment was deleted.";

            return RedirectToAction("Index");
        }

        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            return service;
        }
    }
}