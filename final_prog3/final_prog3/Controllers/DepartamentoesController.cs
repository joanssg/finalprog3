﻿using System;
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
    public class DepartamentoesController : Controller
        {
        private final_prog3Entities db = new final_prog3Entities();

        // GET: Departamentos
        public ActionResult Index()
        {
            var departamentos = db.Departamentos;
            return View(departamentos.ToList());
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamentos.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // GET: Departamentos/Create
        public ActionResult Create()
        {
            ViewBag.Encargado = new SelectList(db.Empleados, "Id", "Codigo");

            return View();

        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Codigo,Nombre")] Departamento departamento)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    string CodigoEncargado = Request.Form["Encargado"];
                    var EncargadoDep = db.Empleados.Where(m => m.Codigo == CodigoEncargado).First();
                    int IdEncargado = EncargadoDep.Id;
                    departamento.Encargado = IdEncargado;
                    db.Departamentos.Add(departamento);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                catch
                {

                }


            }
            ViewBag.NoResultados = "No hay ningún empleado con este código";
            ViewBag.Encargado = new SelectList(db.Empleados, "Id", "Codigo", departamento.Encargado);
            return View(departamento);

        }

        // GET: Departamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamentos.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Encargado = new SelectList(db.Empleados, "Id", "Codigo", departamento.Encargado);
            return View(departamento);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Codigo,Nombre")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string CodigoEncargado = Request.Form["Encargado"];
                    var EncargadoDep = db.Empleados.Where(m => m.Codigo == CodigoEncargado).First();
                    int IdEncargado = EncargadoDep.Id;
                    departamento.Encargado = IdEncargado;
                    db.Entry(departamento).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {

                }

            }
            ViewBag.NoResultados = "No hay ningún empleado con este código";
            ViewBag.Encargado = new SelectList(db.Empleados, "Id", "Codigo", departamento.Encargado);
            return View(departamento);
        }

        // GET: Departamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamentos.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departamento departamento = db.Departamentos.Find(id);
            db.Departamentos.Remove(departamento);
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
