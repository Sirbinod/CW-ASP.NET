using System;
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
    public class ProducerDVDsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProducerDVDs
        public ActionResult Index()
        {
            var producerDVDs = db.ProducerDVDs.Include(p => p.DVDs).Include(p => p.Producers);
            return View(producerDVDs.ToList());
        }

        // GET: ProducerDVDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerDVD producerDVD = db.ProducerDVDs.Find(id);
            if (producerDVD == null)
            {
                return HttpNotFound();
            }
            return View(producerDVD);
        }

        // GET: ProducerDVDs/Create
        public ActionResult Create()
        {
            ViewBag.DVDDetailsId = new SelectList(db.DVDDetails, "Id", "Name");
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name");
            return View();
        }

        // POST: ProducerDVDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProducerId,DVDDetailsId")] ProducerDVD producerDVD)
        {
            if (ModelState.IsValid)
            {
                db.ProducerDVDs.Add(producerDVD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DVDDetailsId = new SelectList(db.DVDDetails, "Id", "Name", producerDVD.DVDDetailsId);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", producerDVD.ProducerId);
            return View(producerDVD);
        }

        // GET: ProducerDVDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerDVD producerDVD = db.ProducerDVDs.Find(id);
            if (producerDVD == null)
            {
                return HttpNotFound();
            }
            ViewBag.DVDDetailsId = new SelectList(db.DVDDetails, "Id", "Name", producerDVD.DVDDetailsId);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", producerDVD.ProducerId);
            return View(producerDVD);
        }

        // POST: ProducerDVDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProducerId,DVDDetailsId")] ProducerDVD producerDVD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producerDVD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DVDDetailsId = new SelectList(db.DVDDetails, "Id", "Name", producerDVD.DVDDetailsId);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", producerDVD.ProducerId);
            return View(producerDVD);
        }

        // GET: ProducerDVDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerDVD producerDVD = db.ProducerDVDs.Find(id);
            if (producerDVD == null)
            {
                return HttpNotFound();
            }
            return View(producerDVD);
        }

        // POST: ProducerDVDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProducerDVD producerDVD = db.ProducerDVDs.Find(id);
            db.ProducerDVDs.Remove(producerDVD);
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
