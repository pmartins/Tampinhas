using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tampinhas.Models;
using Tampinhas.ViewModels;

namespace Tampinhas.Controllers
{ 
    public class ActiveProjectsController : Controller
    {
        private TampinhasEntities db = new TampinhasEntities();

        //
        // GET: /ActiveProjects/

        public ViewResult Index(string searchString)
        {
            var projectset = db.ProjectSet.Include(p => p.User).Include(p => p.Organization).Include(p => p.StatusType);
            
            if (!String.IsNullOrEmpty(searchString))
            {
                projectset = projectset.Where(l => l.Organization.District.Name.ToUpper().Contains(searchString.ToUpper())
                    || l.Organization.County.Name.ToUpper().Contains(searchString.ToUpper())
                    || l.Organization.Location.ToUpper().Contains(searchString.ToUpper()));
            }

            projectset.OrderByDescending(p => p.CreationDate);
            
            return View(projectset.ToList());
        }



        ////
        //// GET: /ActiveProjects/Details/5

        //public ViewResult Details(int id)
        //{
        //    Project project = db.ProjectSet.Single(p => p.Id == id);
        //    return View(project);
        //}

        ////
        //// GET: /ActiveProjects/Create

        //public ActionResult Create()
        //{
        //    ViewBag.CreatorId = new SelectList(db.UserSet, "Id", "Email");
        //    ViewBag.OrganizationId = new SelectList(db.OrganizationSet, "Id", "Name");
        //    ViewBag.StatusTypeId = new SelectList(db.StatusTypeSet, "Id", "Description");
        //    return View();
        //} 

        ////
        //// POST: /ActiveProjects/Create

        //[HttpPost]
        //public ActionResult Create(Project project)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ProjectSet.Add(project);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");  
        //    }

        //    ViewBag.CreatorId = new SelectList(db.UserSet, "Id", "Email", project.CreatorId);
        //    ViewBag.OrganizationId = new SelectList(db.OrganizationSet, "Id", "Name", project.OrganizationId);
        //    ViewBag.StatusTypeId = new SelectList(db.StatusTypeSet, "Id", "Description", project.StatusTypeId);
        //    return View(project);
        //}
        
        ////
        //// GET: /ActiveProjects/Edit/5
 
        //public ActionResult Edit(int id)
        //{
        //    Project project = db.ProjectSet.Single(p => p.Id == id);
        //    ViewBag.CreatorId = new SelectList(db.UserSet, "Id", "Email", project.CreatorId);
        //    ViewBag.OrganizationId = new SelectList(db.OrganizationSet, "Id", "Name", project.OrganizationId);
        //    ViewBag.StatusTypeId = new SelectList(db.StatusTypeSet, "Id", "Description", project.StatusTypeId);
        //    return View(project);
        //}

        ////
        //// POST: /ActiveProjects/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Project project)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(project).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CreatorId = new SelectList(db.UserSet, "Id", "Email", project.CreatorId);
        //    ViewBag.OrganizationId = new SelectList(db.OrganizationSet, "Id", "Name", project.OrganizationId);
        //    ViewBag.StatusTypeId = new SelectList(db.StatusTypeSet, "Id", "Description", project.StatusTypeId);
        //    return View(project);
        //}

        ////
        //// GET: /ActiveProjects/Delete/5
 
        //public ActionResult Delete(int id)
        //{
        //    Project project = db.ProjectSet.Single(p => p.Id == id);
        //    return View(project);
        //}

        ////
        //// POST: /ActiveProjects/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{            
        //    Project project = db.ProjectSet.Find(id);
        //    db.ProjectSet.Remove(project);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");

        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}