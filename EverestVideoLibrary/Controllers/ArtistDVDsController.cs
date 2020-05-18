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
    public class ArtistDVDsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArtistDVDs
        public ActionResult Index()
        {
            var artistDVDs = db.ArtistDVDs.Include(a => a.Artists).Include(a => a.DVDs);
            return View(artistDVDs.ToList());
        }

        // GET: ArtistDVDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistDVD artistDVD = db.ArtistDVDs.Find(id);
            if (artistDVD == null)
            {
                return HttpNotFound();
            }
            return View(artistDVD);
        }

        // GET: ArtistDVDs/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "ID", "Name");
            ViewBag.AlbumId = new SelectList(db.DVDDetails, "Id", "Name");
            return View();
        }

        // POST: ArtistDVDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ArtistId,AlbumId")] ArtistDVD artistDVD)
        {
            if (ModelState.IsValid)
            {
                db.ArtistDVDs.Add(artistDVD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "ID", "Name", artistDVD.ArtistId);
            ViewBag.AlbumId = new SelectList(db.DVDDetails, "Id", "Name", artistDVD.AlbumId);
            return View(artistDVD);
        }

        // GET: ArtistDVDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistDVD artistDVD = db.ArtistDVDs.Find(id);
            if (artistDVD == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ID", "Name", artistDVD.ArtistId);
            ViewBag.AlbumId = new SelectList(db.DVDDetails, "Id", "Name", artistDVD.AlbumId);
            return View(artistDVD);
        }

        // POST: ArtistDVDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ArtistId,AlbumId")] ArtistDVD artistDVD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artistDVD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ID", "Name", artistDVD.ArtistId);
            ViewBag.AlbumId = new SelectList(db.DVDDetails, "Id", "Name", artistDVD.AlbumId);
            return View(artistDVD);
        }

        // GET: ArtistDVDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistDVD artistDVD = db.ArtistDVDs.Find(id);
            if (artistDVD == null)
            {
                return HttpNotFound();
            }
            return View(artistDVD);
        }

        // POST: ArtistDVDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtistDVD artistDVD = db.ArtistDVDs.Find(id);
            db.ArtistDVDs.Remove(artistDVD);
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
