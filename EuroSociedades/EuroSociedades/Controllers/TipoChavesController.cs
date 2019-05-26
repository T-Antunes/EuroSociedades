using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EuroSociedades.Models;

namespace EuroSociedades.Controllers
{
    public class TipoChavesController : Controller
    {
        private EurosociDB db = new EurosociDB();

        // GET: TipoChaves
        public ActionResult Index()
        {
            return View(db.TipoChaves.ToList());
        }

        // GET: TipoChaves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoChaves tipoChaves = db.TipoChaves.Find(id);
            if (tipoChaves == null)
            {
                return HttpNotFound();
            }
            return View(tipoChaves);
        }

        // GET: TipoChaves/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoChaves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tipo")] TipoChaves tipoChaves)
        {
            if (ModelState.IsValid)
            {
                db.TipoChaves.Add(tipoChaves);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoChaves);
        }

        // GET: TipoChaves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoChaves tipoChaves = db.TipoChaves.Find(id);
            if (tipoChaves == null)
            {
                return HttpNotFound();
            }
            return View(tipoChaves);
        }

        // POST: TipoChaves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tipo")] TipoChaves tipoChaves)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoChaves).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoChaves);
        }

        // GET: TipoChaves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoChaves tipoChaves = db.TipoChaves.Find(id);
            if (tipoChaves == null)
            {
                return HttpNotFound();
            }
            return View(tipoChaves);
        }

        // POST: TipoChaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoChaves tipoChaves = db.TipoChaves.Find(id);
            db.TipoChaves.Remove(tipoChaves);
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
