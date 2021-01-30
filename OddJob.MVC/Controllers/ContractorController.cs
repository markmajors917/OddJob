using Microsoft.AspNet.Identity;
using OddJob.Models;
using OddJob.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OddJob.MVC.Controllers
{
    public class ContractorController : Controller
    {
        // GET: Contractor
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ContractorService(userId);
            var model = service.GetContractors();

            return View(model);
        }


        // POST: Contractor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContractorCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ContractorService(userId);

            service.CreateContractor(model);

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var svc = CreateContractorService();
            var model = svc.GetContractorById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateContractorService();
            var detail = service.GetContractorById(id);
            var model =
                new ContractorEdit
                {
                    LastName = detail.LastName,
                    FirstName = detail.FirstName,
                    Age = detail.Age,
                    JobId = detail.JobId,

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContractorEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ContractorId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateContractorService();

            if (service.UpdateContractor(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Contractor could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateContractorService();
            var model = svc.GetContractorById(id);

            return View(model);
        }
        private ContractorService CreateContractorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ContractorService(userId);
            return service;
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateContractorService();

            service.DeleteContractor(id);

            TempData["SaveResult"] = "Contractor was deleted";

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
            //Contractor contractor = _db.Contractors.Find(id);
            //if (contractor == null)
            {
                return HttpNotFound();
            }
        }
    }
}