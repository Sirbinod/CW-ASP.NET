﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EverestVideoLibrary.Models;

namespace EverestVideoLibrary.Controllers
{
    public class DVDDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DVDDetails
        public ActionResult Index()
        {
            return View(db.DVDDetails.ToList());
        }

        // GET: DVDDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDDetails dVDDetails = db.DVDDetails.Find(id);
            if (dVDDetails == null)
            {
                return HttpNotFound();
            }
            return View(dVDDetails);
        }

        // GET: DVDDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DVDDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ReleaseDate,Length,CoverImagePath")] DVDDetails dVDDetails)
        {
            if (ModelState.IsValid)
            {
                db.DVDDetails.Add(dVDDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dVDDetails);
        }

        // GET: DVDDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDDetails dVDDetails = db.DVDDetails.Find(id);
            if (dVDDetails == null)
            {
                return HttpNotFound();
            }
            return View(dVDDetails);
        }

        // POST: DVDDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ReleaseDate,Length,CoverImagePath")] DVDDetails dVDDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dVDDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dVDDetails);
        }

        // GET: DVDDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDDetails dVDDetails = db.DVDDetails.Find(id);
            if (dVDDetails == null)
            {
                return HttpNotFound();
            }
            return View(dVDDetails);
        }

        // POST: DVDDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DVDDetails dVDDetails = db.DVDDetails.Find(id);
            db.DVDDetails.Remove(dVDDetails);
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
