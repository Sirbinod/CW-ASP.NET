using EverestVideoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EverestVideoLibrary.Controllers
{
    public class ReportController : Controller
    {
        private ApplicationDbContext dbCon = new ApplicationDbContext();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FilterTilesByLastName(string LastName)
        {
            ViewBag.LastName = dbCon.Artists.ToList();
            if (String.IsNullOrEmpty(LastName))
            {
                return View();
            }
            var data = dbCon.ArtistDVDs.Include("DVDs").Include("Artists").Where(X => X.Artists.LastName == LastName).ToList();
            return View(data);
        }
        public ActionResult FilterNotLoanDVDByLastName(string LastName)
        {
            var data = dbCon.Loans
            return View();

        }
    }
}