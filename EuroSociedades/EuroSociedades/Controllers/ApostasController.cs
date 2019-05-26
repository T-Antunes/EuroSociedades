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
    public class ApostasController : Controller
    {
        private EurosociDB db = new EurosociDB();

        // GET: Apostas
        public ActionResult Index()
        {
            var apostas = db.Apostas.Include(a => a.Concurso).Include(a => a.Sociedade);
            return View(apostas.ToList());
        }

        // GET: Apostas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apostas apostas = db.Apostas.Find(id);
            if (apostas == null)
            {
                return HttpNotFound();
            }
            return View(apostas);
        }

        // GET: Apostas/Create
        public ActionResult Create()
        {
            ViewBag.ConcursoFK = new SelectList(db.Concursos, "ID", "ID");
            ViewBag.SociedadeFK = new SelectList(db.Sociedades, "ID", "Nome");
            return View();
        }

        // POST: Apostas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DataRegisto,ValorAposta,ValorPremio,ConcursoFK,SociedadeFK")] Apostas apostas)
        {
            if (ModelState.IsValid)
            {
                db.Apostas.Add(apostas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConcursoFK = new SelectList(db.Concursos, "ID", "ID", apostas.ConcursoFK);
            ViewBag.SociedadeFK = new SelectList(db.Sociedades, "ID", "Nome", apostas.SociedadeFK);
            return View(apostas);
        }

        // GET: Apostas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apostas apostas = db.Apostas.Find(id);
            if (apostas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConcursoFK = new SelectList(db.Concursos, "ID", "ID", apostas.ConcursoFK);
            ViewBag.SociedadeFK = new SelectList(db.Sociedades, "ID", "Nome", apostas.SociedadeFK);
            return View(apostas);
        }

        // POST: Apostas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DataRegisto,ValorAposta,ValorPremio,ConcursoFK,SociedadeFK")] Apostas apostas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apostas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConcursoFK = new SelectList(db.Concursos, "ID", "ID", apostas.ConcursoFK);
            ViewBag.SociedadeFK = new SelectList(db.Sociedades, "ID", "Nome", apostas.SociedadeFK);
            return View(apostas);
        }

        // GET: Apostas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apostas apostas = db.Apostas.Find(id);
            if (apostas == null)
            {
                return HttpNotFound();
            }
            return View(apostas);
        }

        // POST: Apostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apostas apostas = db.Apostas.Find(id);
            db.Apostas.Remove(apostas);
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
