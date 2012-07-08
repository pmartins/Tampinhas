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
            // TODO: to filter only active projects here
            var projectset = db.ProjectSet.Include(p => p.User).Include(p => p.Organization).Include(p => p.StatusType)
                .Include(p => p.Organization.District).Include(p => p.Organization.County);
            
            if (!String.IsNullOrEmpty(searchString))
            {
                projectset = projectset.Where(l => l.Organization.District.Name.ToUpper().Contains(searchString.ToUpper())
                    || l.Organization.County.Name.ToUpper().Contains(searchString.ToUpper())
                    || l.Organization.Location.ToUpper().Contains(searchString.ToUpper()));
            }

            projectset.OrderByDescending(p => p.CreationDate);

            return View(projectset.ToList());
        }



        //
        // GET: /ActiveProjects/Details/5
        public ViewResult Details(int id)
        {
            Project project = db.ProjectSet.Include(p => p.User).Include(p => p.Organization).Include(p => p.StatusType)
                .Include(p => p.Organization.District).Include(p => p.Organization.County)
                .Single(p => p.Id == id);
                    
            var ppcvm = new ProjectProjectCommentViewModel();

            ppcvm.Project = project;
       
            var commentsSet = db.ProjectCommentSet.Where(pc => pc.ProjectId == id).OrderBy(pc => pc.ComentDate);
            ppcvm.ProjectComments = commentsSet.ToList();
            
            return View(ppcvm);
        }


        [HttpPost]
        public ViewResult Details(string comment, int projectId)
        {
            var pc = new ProjectComment();
            pc.Comment = comment;
            pc.ComentDate = DateTime.Now;
            // TODO: obter o id do utilizador...
            pc.UserId = 1;
            pc.ProjectId = projectId;

            db.ProjectCommentSet.Add(pc);
            db.SaveChanges();


            return Details(projectId);
        }

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