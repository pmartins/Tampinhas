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
    public class OrganizationController : Controller
    {
        private TampinhasEntities db = new TampinhasEntities();

        //
        // GET: /Organization/

        public ViewResult Index()
        {
            var organizationset = db.OrganizationSet.Include(o => o.District).Include(o => o.County);
            return View(organizationset.ToList());
        }

        //
        // GET: /Organization/Details/5

        public ViewResult Details(int id)
        {
            Organization organization = db.OrganizationSet.Find(id);
            return View(organization);
        }

        //
        // GET: /Organization/Create

        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(db.PlaceSet, "Id", "Name");
            ViewBag.CountyId = new SelectList(db.PlaceSet, "Id", "Name");
            return View();
        } 

        //
        // POST: /Organization/Create

        [HttpPost]
        public ActionResult Create(Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.OrganizationSet.Add(organization);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.DistrictId = new SelectList(db.PlaceSet, "Id", "Name", organization.DistrictId);
            ViewBag.CountyId = new SelectList(db.PlaceSet, "Id", "Name", organization.CountyId);
            return View(organization);
        }
        
        //
        // GET: /Organization/Edit/5
 
        public ActionResult Edit(int id)
        {
            Organization organization = db.OrganizationSet.Find(id);
            ViewBag.DistrictId = new SelectList(db.PlaceSet, "Id", "Name", organization.DistrictId);
            ViewBag.CountyId = new SelectList(db.PlaceSet, "Id", "Name", organization.CountyId);
            return View(organization);
        }

        //
        // POST: /Organization/Edit/5

        [HttpPost]
        public ActionResult Edit(Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(db.PlaceSet, "Id", "Name", organization.DistrictId);
            ViewBag.CountyId = new SelectList(db.PlaceSet, "Id", "Name", organization.CountyId);
            return View(organization);
        }

        //
        // GET: /Organization/Delete/5
 
        public ActionResult Delete(int id)
        {
            Organization organization = db.OrganizationSet.Find(id);
            return View(organization);
        }

        //
        // POST: /Organization/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Organization organization = db.OrganizationSet.Find(id);
            db.OrganizationSet.Remove(organization);
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