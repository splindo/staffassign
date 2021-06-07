using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RoomAssignment.Models;
using System.Data.SqlClient;

namespace RoomAssignment.Controllers
{
    public class NursesController : Controller
    {
        private NurseDBContext db = new NurseDBContext();

        // GET: Nurses
        public ActionResult Index()
        {
            SetViewTitle("Staff - ");

            var qs = Request.QueryString["Floor"];

            var emps = from Nurses in db.Nurses
                       where Nurses.Location == qs
                       select Nurses;

            List<Nurse> sortedEmps = emps.OrderBy(n => n.Name).ToList();
            return View(sortedEmps);
        }

        public ActionResult Info()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            ViewBag.Title = "View All Entries";

            var emps = from Nurses in db.Nurses
                       select Nurses;

            List<Nurse> sortedEmps = emps.OrderBy(n => n.Location).ThenBy(n => n.Name).ToList();

            return View(sortedEmps);
        }

        // GET: Nurses/Create
        public ActionResult Create()
        {
            SetViewTitle("Add Nurse - ");
            return View();
        }

        // POST: Nurses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Position,Name,Rooms,Phone,Location")] Nurse nurse, string pos)
        {

            if (ModelState.IsValid)
            {
                db.Nurses.Add(nurse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nurse);
        }


        public ActionResult CreatePCA()
        {
            SetViewTitle("Add PCA - ");
            return View();
        }

        // POST: Nurses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePCA([Bind(Include = "ID,Position,Name,Rooms,Phone,Location")] Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                db.Nurses.Add(nurse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nurse);
        }

        public ActionResult CreateChargeNurse()
        {
            SetViewTitle("Add Charge Nurse - ");
            return View();
        }

        // POST: Nurses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateChargeNurse([Bind(Include = "ID,Position,Name,Rooms,Phone,Location")] Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                db.Nurses.Add(nurse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nurse);
        }

        public ActionResult CreateRT()
        {
            SetViewTitle("Add RT - ");
            return View();
        }

        // POST: Nurses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRT([Bind(Include = "ID,Position,Name,Rooms,Phone,Location")] Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                db.Nurses.Add(nurse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nurse);
        }



        // GET: Nurses/Edit/5
        public ActionResult Edit(int? id)
        {
            SetViewTitle("Edit Entry - ");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nurse nurse = db.Nurses.Find(id);
            if (nurse == null)
            {
                return HttpNotFound();
            }
            return View(nurse);
        }

        // POST: Nurses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Position,Name,Rooms,Phone,Location")] Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nurse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nurse);
        }

        // GET: Nurses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nurse nurse = db.Nurses.Find(id);
            if (nurse == null)
            {
                return HttpNotFound();
            }
            return View(nurse);
        }

        // POST: Nurses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nurse nurse = db.Nurses.Find(id);
            db.Nurses.Remove(nurse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //retrieve querystring to determine floor, append to tab title

        private void SetViewTitle(string prefix)
        {
            var qs = Request.QueryString["Floor"];

            string title;

            if (qs == "CCU" || qs == "CDU")
            {
                title = qs;
            }
            else
            {
                title = "Floor " + qs;
            }

            ViewBag.Title = prefix + title;
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