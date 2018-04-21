using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class ComprobanteDetallesController : Controller
    {
        private FacturadorEntities db = new FacturadorEntities();

        // GET: ComprobanteDetalles
        public ActionResult Index()
        {
            var comprobanteDetalle = db.ComprobanteDetalle.Include(c => c.Comprobante).Include(c => c.Producto);
            return View(comprobanteDetalle.ToList());
        }

        // GET: ComprobanteDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComprobanteDetalle comprobanteDetalle = db.ComprobanteDetalle.Find(id);
            if (comprobanteDetalle == null)
            {
                return HttpNotFound();
            }
            return View(comprobanteDetalle);
        }

        // GET: ComprobanteDetalles/Create
        public ActionResult Create()
        {
            ViewBag.ComprobanteId = new SelectList(db.Comprobante, "id", "Cliente");
            ViewBag.ProductoId = new SelectList(db.Producto, "id", "Nombre");
            return View();
        }

        // POST: ComprobanteDetalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ComprobanteId,ProductoId,Cantidad,PrecioUnitario,Monto")] ComprobanteDetalle comprobanteDetalle)
        {
            if (ModelState.IsValid)
            {
                db.ComprobanteDetalle.Add(comprobanteDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComprobanteId = new SelectList(db.Comprobante, "id", "Cliente", comprobanteDetalle.ComprobanteId);
            ViewBag.ProductoId = new SelectList(db.Producto, "id", "Nombre", comprobanteDetalle.ProductoId);
            return View(comprobanteDetalle);
        }

        // GET: ComprobanteDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComprobanteDetalle comprobanteDetalle = db.ComprobanteDetalle.Find(id);
            if (comprobanteDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComprobanteId = new SelectList(db.Comprobante, "id", "Cliente", comprobanteDetalle.ComprobanteId);
            ViewBag.ProductoId = new SelectList(db.Producto, "id", "Nombre", comprobanteDetalle.ProductoId);
            return View(comprobanteDetalle);
        }

        // POST: ComprobanteDetalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ComprobanteId,ProductoId,Cantidad,PrecioUnitario,Monto")] ComprobanteDetalle comprobanteDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comprobanteDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComprobanteId = new SelectList(db.Comprobante, "id", "Cliente", comprobanteDetalle.ComprobanteId);
            ViewBag.ProductoId = new SelectList(db.Producto, "id", "Nombre", comprobanteDetalle.ProductoId);
            return View(comprobanteDetalle);
        }

        // GET: ComprobanteDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComprobanteDetalle comprobanteDetalle = db.ComprobanteDetalle.Find(id);
            if (comprobanteDetalle == null)
            {
                return HttpNotFound();
            }
            return View(comprobanteDetalle);
        }

        // POST: ComprobanteDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComprobanteDetalle comprobanteDetalle = db.ComprobanteDetalle.Find(id);
            db.ComprobanteDetalle.Remove(comprobanteDetalle);
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
