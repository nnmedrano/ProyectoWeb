using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AmbientesController : Controller
    {
        private Entities db = new Entities();

        // GET: Ambientes
        public ActionResult Index()
        {
            var ambientes = db.Ambientes.Include(a => a.Stock);
            return View(ambientes.ToList());
        }

        // GET: Ambientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambiente ambiente = db.Ambientes.Find(id);
            if (ambiente == null)
            {
                return HttpNotFound();
            }
            return View(ambiente);
        }

        // GET: Ambientes/Create
        public ActionResult Create()
        {
            ViewBag.StockID = new SelectList(db.Stocks, "StockID", "Producto");
            return View();
        }

        // POST: Ambientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AmbienteID,StockID,Bathroom,Bedromm,Kitchen,Living")] Ambiente ambiente)
        {
            if (ModelState.IsValid)
            {
                db.Ambientes.Add(ambiente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StockID = new SelectList(db.Stocks, "StockID", "Producto", ambiente.StockID);
            return View(ambiente);
        }

        // GET: Ambientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambiente ambiente = db.Ambientes.Find(id);
            if (ambiente == null)
            {
                return HttpNotFound();
            }
            ViewBag.StockID = new SelectList(db.Stocks, "StockID", "Producto", ambiente.StockID);
            return View(ambiente);
        }

        // POST: Ambientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AmbienteID,StockID,Bathroom,Bedromm,Kitchen,Living")] Ambiente ambiente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ambiente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StockID = new SelectList(db.Stocks, "StockID", "Producto", ambiente.StockID);
            return View(ambiente);
        }

        // GET: Ambientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambiente ambiente = db.Ambientes.Find(id);
            if (ambiente == null)
            {
                return HttpNotFound();
            }
            return View(ambiente);
        }

        // POST: Ambientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ambiente ambiente = db.Ambientes.Find(id);
            db.Ambientes.Remove(ambiente);
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
