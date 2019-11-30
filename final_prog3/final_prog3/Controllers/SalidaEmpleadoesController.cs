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
    public class SalidaEmpleadoesController : Controller
    {
        private final_prog3Entities db = new final_prog3Entities();

        // GET: SalidaEmpleadoes
        public ActionResult Index()
        {
            return View(db.SalidaEmpleados.ToList());
        }

        // GET: SalidaEmpleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleados.Find(id);
            if (salidaEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmpleado);
        }

        // GET: SalidaEmpleadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalidaEmpleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEmpleado,TipoSalida,Motivo,FechaSalida")] SalidaEmpleado salidaEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.SalidaEmpleados.Add(salidaEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salidaEmpleado);
        }

        // GET: SalidaEmpleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleados.Find(id);
            if (salidaEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmpleado);
        }

        // POST: SalidaEmpleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmpleado,TipoSalida,Motivo,FechaSalida")] SalidaEmpleado salidaEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salidaEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salidaEmpleado);
        }

        // GET: SalidaEmpleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleados.Find(id);
            if (salidaEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmpleado);
        }

        // POST: SalidaEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleados.Find(id);
            db.SalidaEmpleados.Remove(salidaEmpleado);
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
