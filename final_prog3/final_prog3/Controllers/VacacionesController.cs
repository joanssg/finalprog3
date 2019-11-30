using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using final_prog3.Models;

namespace final_prog3.Controllers
{
    public class VacacionesController : Controller
    {
        private final_prog3Entities db = new final_prog3Entities();

        // GET: Vacaciones
        public ActionResult Index()
        {
            return View(db.Vacaciones.ToList());
        }

        // GET: Vacaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacacione vacacione = db.Vacaciones.Find(id);
            if (vacacione == null)
            {
                return HttpNotFound();
            }
            return View(vacacione);
        }

        // GET: Vacaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vacaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEmpleado,Desde,Hasta,Año,Comentarios")] Vacacione vacacione)
        {
            if (ModelState.IsValid)
            {
                db.Vacaciones.Add(vacacione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vacacione);
        }

        // GET: Vacaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacacione vacacione = db.Vacaciones.Find(id);
            if (vacacione == null)
            {
                return HttpNotFound();
            }
            return View(vacacione);
        }

        // POST: Vacaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmpleado,Desde,Hasta,Año,Comentarios")] Vacacione vacacione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacacione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vacacione);
        }

        // GET: Vacaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacacione vacacione = db.Vacaciones.Find(id);
            if (vacacione == null)
            {
                return HttpNotFound();
            }
            return View(vacacione);
        }

        // POST: Vacaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacacione vacacione = db.Vacaciones.Find(id);
            db.Vacaciones.Remove(vacacione);
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
