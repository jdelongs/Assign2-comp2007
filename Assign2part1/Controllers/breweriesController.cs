using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assign2part1.Models;

namespace Assign2part1.Controllers
{
    public class breweriesController : Controller
    {
        //old db connection now in EFBreweriesRepository 
        //private StoreModel db = new StoreModel();

        //repo link 
        private IbreweriesRepository db;

        // if no param passed to constuctor use ef repsoitoy & Dbcontext
        public breweriesController()
        {
            this.db = new EFBreweriesRepository();
        }

        // if mock repo object passed to constuctor used mock interface for unit testing 
        public breweriesController(IbreweriesRepository smRepo)
        {
            this.db = smRepo;
        }
        // GET: breweries
        public ViewResult Index()
        {
            return View(db.Breweries.ToList());
        }
    

     // GET: breweries/Details/5
        public ViewResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            brewery brewery = db.Breweries.SingleOrDefault(a => a.breweryID == id);
            if (brewery == null)
            {
                return View("Error");
            }
            return View(brewery);
        }

      // GET: breweries/Create
        public ActionResult Create()
        {
            ViewBag.breweryID = new SelectList(db.Breweries, "breweryID");
            return View("Create");
        }

        // POST: breweries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "breweryID,breweryLocation,breweryName,features")] brewery brewery)
        {
            if (ModelState.IsValid)
            {
              
            }
            db.Save(brewery);

            return RedirectToAction("Index");
        }

        // GET: breweries/Edit/5
        public ViewResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Error"); 
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //new repository code 
            brewery brewery = db.Breweries.SingleOrDefault(a => a.breweryID == id);
            //scafold code 
            //brewery brewery = db.Breweries.Find(id);
            if (brewery == null)
            {
                return View("Error"); 
                //return HttpNotFound();
            }
            return View(brewery);
        }

        // POST: breweries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "breweryID,breweryLocation,breweryName,features")] brewery brewery)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }
            db.Save(brewery); 
            return View(brewery);
        }

        // GET: breweries/Delete/5
        public ViewResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error"); 
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //new repository code 
            brewery brewery = db.Breweries.SingleOrDefault(a => a.breweryID == id);
            //scafold code 
            //brewery brewery = db.Breweries.Find(id);
            if (brewery == null)
            {
                return View("Error"); 
                //return HttpNotFound();
            }
            return View(brewery);
        }

        // POST: breweries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            //new repository code 
            brewery brewery = db.Breweries.SingleOrDefault(a => a.breweryID == id);
            //scafold code 
            //db.Breweries.Remove(brewery);
            //db.SaveChanges();
            //brewery brewery = db.Breweries.Find(id);
            db.Delete(brewery); 
            return RedirectToAction("Index");
        }

        public ViewResult DeleteConfirmed(int? id)
        {
            throw new NotImplementedException();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
    }
