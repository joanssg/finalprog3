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
    public class CargoesController : Controller
    {
        
            private final_prog3Entities db = new final_prog3Entities();

            // GET: Cargos
            public ActionResult Index()
            {
                return View(db.Cargos.ToList());
            }

            // GET: Cargos/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cargo cargo = db.Cargos.Find(id);
                if (cargo == null)
                {
                    return HttpNotFound();
                }
                return View(cargo);
            }

            // GET: Cargos/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Cargos/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "Id,Codigo,Nombre")] Cargo cargo)
            {
                if (ModelState.IsValid)
                {
                    db.Cargos.Add(cargo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(cargo);
            }

            // GET: Cargos/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cargo cargo = db.Cargos.Find(id);
                if (cargo == null)
                {
                    return HttpNotFound();
                }
                return View(cargo);
            }

            // POST: Cargos/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "Id,Codigo,Nombre")] Cargo cargo)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(cargo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(cargo);
            }

            // GET: Cargos/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cargo cargo = db.Cargos.Find(id);
                if (cargo == null)
                {
                    return HttpNotFound();
                }
                return View(cargo);
            }

            // POST: Cargos/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Cargo cargo = db.Cargos.Find(id);
                db.Cargos.Remove(cargo);
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
