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
            //MemberShip
            pc.UserId = 1;
            pc.ProjectId = projectId;

            db.ProjectCommentSet.Add(pc);
            db.SaveChanges();


            return Details(projectId);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}