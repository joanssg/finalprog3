using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using final_prog3.Models;

namespace final_prog3.Controllers
{
    public class PermisoesController : Controller
    {
        private final_prog3Entities db = new final_prog3Entities();

        // GET: Permisos
        public ActionResult Index(string Busqueda, string valor)
        {


            if (Busqueda == "IdEmpleado")
            {
                int d = 0;
                if (!valor.IsEmpty())
                {
                    d = int.Parse(valor);
                }

                return View(db.Permisos.Where(m => m.IdEmpleado == d).ToList());
            }
            else
            {

                return View(db.Permisos.ToList());
            }
        }

        // GET: Permisos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Permisos/Create
        public ActionResult Create()
        {
            ViewBag.PersonList = new SelectList(db.Empleados.Where(m => m.estatus == "Activo"), "Id", "Nombre");
            return View();
        }

        // POST: Permisos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Permiso permiso)
        {
            try
            {
                int CodigoEmpleado = Convert.ToInt32(Request.Form["IdEmpleado"]);
                var EmpleadoSalida = db.Empleados.Where(m => m.Id == CodigoEmpleado && m.estatus == "Activo").First();
                int IdSalida = EmpleadoSalida.Id;
                permiso.IdEmpleado = IdSalida;
                db.Permisos.Add(permiso);
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