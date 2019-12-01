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
    public class LicenciasController : Controller
    {
        private final_prog3Entities db = new final_prog3Entities();
        // GET: Licencias
        public ActionResult Index()
        {
            return View(db.Licencias.ToList());
        }

        // GET: Licencias/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Licencias/Create
        public ActionResult Create()
        {
            ViewBag.PersonList = new SelectList(db.Empleados.Where(m => m.estatus == "Activo"), "Id", "Nombre");
            return View();
        }

        // POST: Licencias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Licencia licencia)
        {
            try
            {
                int CodigoEmpleado = Convert.ToInt32(Request.Form["IdEmpleado"]);
                var EmpleadoSalida = db.Empleados.Where(m => m.Id == CodigoEmpleado && m.estatus == "Activo").First();
                int IdSalida = EmpleadoSalida.Id;
                licencia.IdEmpleado = IdSalida;
                db.Licencias.Add(licencia);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
            }
            ViewBag.NoResultados = "No hay ningún empleado con este código";
            return View();
        }


    }
}
