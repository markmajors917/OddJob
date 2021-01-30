using Microsoft.AspNet.Identity;
using OddJob.Data;
using OddJob.Datal;
using OddJob.Models;
using OddJob.MVC.Models;
using OddJob.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OddJob.MVC.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        
        
        // GET: Job
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobService(userId);
            var model = service.GetJobs();

            return View(model);
        }


        // POST: Job
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateJob model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobService(userId);

            service.CreateJob(model);

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateJobService();
            var detail = service.GetJobById(id);
            var model =
                new JobEdit
                {
                    JobId = detail.JobId,
                    JobDescription = detail.JobDescription,
                    JobName = detail.JobName,
                    Price = detail.Price,
                    EstimatedHours = detail.EstimatedHours
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.JobId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateJobService();

            if (service.UpdateJob(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your job could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);

            return View(model);
        }
        private JobService CreateJobService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobService(userId);
            return service;
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateJobService();

            service.DeleteJob(id);

            TempData["SaveResult"] = "Your job was deleted";

            return RedirectToAction("Index");
        }


        // GET : Delete
        // Job/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //Job job = _db.Jobs.Find(id);
            //if (job == null)
            {
                return HttpNotFound();
            }
        }
    }
}
          

    

