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
    public class JogadoresController : Controller
    {
        private EurosociDB db = new EurosociDB();

        // GET: Jogadores
        public ActionResult Index()
        {
            return View(db.Jogadores.ToList());
        }

        // GET: Jogadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogadores jogadores = db.Jogadores.Find(id);
            if (jogadores == null)
            {
                return HttpNotFound();
            }
            return View(jogadores);
        }

        // GET: Jogadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jogadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Username,Email,DataNascimento")] Jogadores jogadores)
        {
            if (ModelState.IsValid)
            {
                db.Jogadores.Add(jogadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jogadores);
        }

        // GET: Jogadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogadores jogadores = db.Jogadores.Find(id);
            if (jogadores == null)
            {
                return HttpNotFound();
            }
            return View(jogadores);
        }

        // POST: Jogadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Username,Email,DataNascimento")] Jogadores jogadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jogadores);
        }

        // GET: Jogadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogadores jogadores = db.Jogadores.Find(id);
            if (jogadores == null)
            {
                return HttpNotFound();
            }
            return View(jogadores);
        }

        // POST: Jogadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogadores jogadores = db.Jogadores.Find(id);
            db.Jogadores.Remove(jogadores);
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
