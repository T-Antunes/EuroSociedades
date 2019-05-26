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
    public class ChavesController : Controller
    {
        private EurosociDB db = new EurosociDB();

        // GET: Chaves
        public ActionResult Index()
        {
            var chaves = db.Chaves.Include(c => c.TipoChave);
            return View(chaves.ToList());
        }

        // GET: Chaves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chaves chaves = db.Chaves.Find(id);
            if (chaves == null)
            {
                return HttpNotFound();
            }
            return View(chaves);
        }

        // GET: Chaves/Create
        public ActionResult Create()
        {
            ViewBag.TipoChaveFK = new SelectList(db.TipoChaves, "ID", "Tipo");
            return View();
        }

        // POST: Chaves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Preco,Numeros,Estrelas,TipoChaveFK")] Chaves chaves)
        {
            if (ModelState.IsValid)
            {
                db.Chaves.Add(chaves);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoChaveFK = new SelectList(db.TipoChaves, "ID", "Tipo", chaves.TipoChaveFK);
            return View(chaves);
        }

        // GET: Chaves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chaves chaves = db.Chaves.Find(id);
            if (chaves == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoChaveFK = new SelectList(db.TipoChaves, "ID", "Tipo", chaves.TipoChaveFK);
            return View(chaves);
        }

        // POST: Chaves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Preco,Numeros,Estrelas,TipoChaveFK")] Chaves chaves)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chaves).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoChaveFK = new SelectList(db.TipoChaves, "ID", "Tipo", chaves.TipoChaveFK);
            return View(chaves);
        }

        // GET: Chaves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chaves chaves = db.Chaves.Find(id);
            if (chaves == null)
            {
                return HttpNotFound();
            }
            return View(chaves);
        }

        // POST: Chaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chaves chaves = db.Chaves.Find(id);
            db.Chaves.Remove(chaves);
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
