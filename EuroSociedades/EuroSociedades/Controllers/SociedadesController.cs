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
    public class SociedadesController : Controller
    {
        private EurosociDB db = new EurosociDB();

        // GET: Sociedades
        public ActionResult Index()
        {
            var sociedades = db.Sociedades.Include(s => s.Gestor);
            return View(sociedades.ToList());
        }

        // GET: Sociedades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sociedades sociedades = db.Sociedades.Find(id);
            if (sociedades == null)
            {
                return HttpNotFound();
            }
            return View(sociedades);
        }

        // GET: Sociedades/Create
        public ActionResult Create()
        {
            ViewBag.GestorFK = new SelectList(db.Jogadores, "ID", "Nome");
            return View();
        }

        // POST: Sociedades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,DataConstituicao,GestorFK")] Sociedades sociedades)
        {
            if (ModelState.IsValid)
            {
                db.Sociedades.Add(sociedades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GestorFK = new SelectList(db.Jogadores, "ID", "Nome", sociedades.GestorFK);
            return View(sociedades);
        }

        // GET: Sociedades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sociedades sociedades = db.Sociedades.Find(id);
            if (sociedades == null)
            {
                return HttpNotFound();
            }
            ViewBag.GestorFK = new SelectList(db.Jogadores, "ID", "Nome", sociedades.GestorFK);
            return View(sociedades);
        }

        // POST: Sociedades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,DataConstituicao,GestorFK")] Sociedades sociedades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sociedades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GestorFK = new SelectList(db.Jogadores, "ID", "Nome", sociedades.GestorFK);
            return View(sociedades);
        }

        // GET: Sociedades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sociedades sociedades = db.Sociedades.Find(id);
            if (sociedades == null)
            {
                return HttpNotFound();
            }
            return View(sociedades);
        }

        // POST: Sociedades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sociedades sociedades = db.Sociedades.Find(id);
            db.Sociedades.Remove(sociedades);
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
