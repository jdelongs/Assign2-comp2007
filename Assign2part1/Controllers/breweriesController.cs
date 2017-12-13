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
        private StoreModel db = new StoreModel();

        // GET: breweries
        public ActionResult Index()
        {
            return View(db.breweries.ToList());
        }

        // GET: breweries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            brewery brewery = db.breweries.Find(id);
            if (brewery == null)
            {
                return HttpNotFound();
            }
            return View(brewery);
        }

        // GET: breweries/Create
        public ActionResult Create()
        {
            return View();
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
                db.breweries.Add(brewery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brewery);
        }

        // GET: breweries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            brewery brewery = db.breweries.Find(id);
            if (brewery == null)
            {
                return HttpNotFound();
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
                db.Entry(brewery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brewery);
        }

        // GET: breweries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            brewery brewery = db.breweries.Find(id);
            if (brewery == null)
            {
                return HttpNotFound();
            }
            return View(brewery);
        }

        // POST: breweries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            brewery brewery = db.breweries.Find(id);
            db.breweries.Remove(brewery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
