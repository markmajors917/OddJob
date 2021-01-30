using Microsoft.AspNet.Identity;
using OddJob.Datal;
using OddJob.Models;
using OddJob.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OddJob.MVC.Controllers
{
    public class ParentController : Controller
    {
        // GET: Parent
       
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ParentService(userId);
            var model = service.GetParents();

            return View(model);
        }


        // POST: Parent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParentCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ParentService(userId);

            service.CreateParent(model);

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var svc = CreateParentService();
            var model = svc.GetParentId(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateParentService();
            var detail = service.GetParentId(id);
            var model =
                new ParentEdit
                {
                    ParentId = detail.ParentId,
                    ParentApproval = detail.ParentApproval
                   
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ParentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ParentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateParentService();

            if (service.UpdateParent(model))
            {
                TempData["SaveResult"] = "Parent was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your parent could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateParentService();
            var model = svc.GetParentId(id);

            return View(model);
        }
        private ParentService CreateParentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ParentService(userId);
            return service;
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateParentService();

            service.DeleteParent(id);

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
            //Parent parent = _db.Parents.Find(id);
            //if (parent == null)
            {
                return HttpNotFound();
            }
        }
    }
}