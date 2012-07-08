using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tampinhas.Models;

namespace Tampinhas.Controllers
{ 
    public class ProjectsController : Controller
    {
        private TampinhasEntities db = new TampinhasEntities();

        //
        // GET: /Projects/
        [Authorize]
        public ViewResult Index()
        {
            var projectset = db.ProjectSet.Include(p => p.User).Include(p => p.Organization).Include(p => p.StatusType); 
            return View(projectset.ToList());
        }

        //
        // GET: /Projects/Details/5

        public ViewResult Details(int id)
        {
            Project project = db.ProjectSet.Find(id);
            return View(project);
        }

        //
        // GET: /Projects/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.OrganizationId = new SelectList(db.OrganizationSet, "Id", "Name");
            return View();
        } 

        //
        // POST: /Projects/Create

        [Authorize]
        [HttpPost]
        public ActionResult Create(Project project)
        {
            // TODO: retirar daqui o valor do utilizador hardcoded
            project.CreatorId = 1;
            project.StatusTypeId = 1; // Active
            project.CreationDate = System.DateTime.Now;
            project.ModifiedDate = System.DateTime.Now;

            if (ModelState.IsValid)
            {
                db.ProjectSet.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(project);
        }
        
        //
        // GET: /Projects/Edit/5
 
        public ActionResult Edit(int id)
        {
            Project project = db.ProjectSet.Find(id);
            ViewBag.CreatorId = new SelectList(db.UserSet, "Id", "Email", project.CreatorId);
            ViewBag.OrganizationId = new SelectList(db.OrganizationSet, "Id", "Name", project.OrganizationId);
            ViewBag.StatusTypeId = new SelectList(db.StatusTypeSet, "Id", "Description", project.StatusTypeId);
            return View(project);
        }

        //
        // POST: /Projects/Edit/5

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatorId = new SelectList(db.UserSet, "Id", "Email", project.CreatorId);
            ViewBag.OrganizationId = new SelectList(db.OrganizationSet, "Id", "Name", project.OrganizationId);
            ViewBag.StatusTypeId = new SelectList(db.StatusTypeSet, "Id", "Description", project.StatusTypeId);
            return View(project);
        }

        //
        // GET: /Projects/Delete/5
 
        public ActionResult Delete(int id)
        {
            Project project = db.ProjectSet.Find(id);
            return View(project);
        }

        //
        // POST: /Projects/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Project project = db.ProjectSet.Find(id);
            db.ProjectSet.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}