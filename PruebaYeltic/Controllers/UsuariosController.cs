using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using PruebaYeltic.Models;
using PruebaYeltic.Enumerables;

namespace PruebaYeltic.Controllers
{
    public class UsuariosController : Controller
    {

        private BD_PruebaYelticEntities db = new BD_PruebaYelticEntities();

        // GET: Index
        public ActionResult Index()
        {
            List<Usuarios> usuarios = db.Usuarios.ToList();
            var usuariosActivos = from Us in usuarios where Us.bitActivo.Equals(true) select Us;
            return View(usuariosActivos);
        }

        // GET: Crear
        public ActionResult Crear()
        {
            ViewBag.idPuesto = new SelectList(db.CatPuestos, "idPuesto", "varPuesto");
            ViewBag.idSucursal = new SelectList(db.CatSucursales, "idSucursal", "varSursal");
            return View();
        }

        // POST: Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Exclude = "varSexo, bitActivo")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                usuarios.varSexo = usuarios.Sexo.GetDescripcion().ToString();
                usuarios.bitActivo = true;
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPuesto = new SelectList(db.CatPuestos, "idPuesto", "varPuesto", usuarios.idPuesto);
            ViewBag.idSucursal = new SelectList(db.CatSucursales, "idSucursal", "varSursal", usuarios.idSucursal);
            return View(usuarios);
        }

        // GET: Actualizar
        public ActionResult Actualizar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPuesto = new SelectList(db.CatPuestos, "idPuesto", "varPuesto", usuarios.idPuesto);
            ViewBag.idSucursal = new SelectList(db.CatSucursales, "idSucursal", "varSursal", usuarios.idSucursal);
            return View(usuarios);
        }

        // POST: Actualizar
        [HttpPost]
        // holis
        [ValidateAntiForgeryToken]
        public ActionResult Actualizar([Bind(Include = "idUsuario, idSucursal, idPuesto, varNombre, varPrimerApellido, varSegundoApellido, varSexo, bitActivo")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPuesto = new SelectList(db.CatPuestos, "idPuesto", "varPuesto", usuarios.idPuesto);
            ViewBag.idSucursal = new SelectList(db.CatSucursales, "idSucursal", "varSursal", usuarios.idSucursal);
            return View(usuarios);
        }
    }
}