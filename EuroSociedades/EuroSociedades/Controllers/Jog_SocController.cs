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
    public class Jog_SocController : Controller
    {
        private EurosociDB db = new EurosociDB();

        // GET: Jog_Soc
        public ActionResult Index()
        {
            var jog_Socs = db.Jog_Socs.Include(j => j.Jogador).Include(j => j.Sociedade);
            return View(jog_Socs.ToList());
        }

        // GET: Jog_Soc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jog_Soc jog_Soc = db.Jog_Socs.Find(id);
            if (jog_Soc == null)
            {
                return HttpNotFound();
            }
            return View(jog_Soc);
        }

        // GET: Jog_Soc/Create
        public ActionResult Create()
        {
            ViewBag.JogadorFK = new SelectList(db.Jogadores, "ID", "Nome");
            ViewBag.SociedadeFK = new SelectList(db.Sociedades, "ID", "Nome");
            return View();
        }

        // POST: Jog_Soc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DataEntrada,DataSaida,JogadorFK,SociedadeFK")] Jog_Soc jog_Soc)
        {
            if (ModelState.IsValid)
            {
                db.Jog_Socs.Add(jog_Soc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JogadorFK = new SelectList(db.Jogadores, "ID", "Nome", jog_Soc.JogadorFK);
            ViewBag.SociedadeFK = new SelectList(db.Sociedades, "ID", "Nome", jog_Soc.SociedadeFK);
            return View(jog_Soc);
        }

        // GET: Jog_Soc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jog_Soc jog_Soc = db.Jog_Socs.Find(id);
            if (jog_Soc == null)
            {
                return HttpNotFound();
            }
            ViewBag.JogadorFK = new SelectList(db.Jogadores, "ID", "Nome", jog_Soc.JogadorFK);
            ViewBag.SociedadeFK = new SelectList(db.Sociedades, "ID", "Nome", jog_Soc.SociedadeFK);
            return View(jog_Soc);
        }

        // POST: Jog_Soc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DataEntrada,DataSaida,JogadorFK,SociedadeFK")] Jog_Soc jog_Soc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jog_Soc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JogadorFK = new SelectList(db.Jogadores, "ID", "Nome", jog_Soc.JogadorFK);
            ViewBag.SociedadeFK = new SelectList(db.Sociedades, "ID", "Nome", jog_Soc.SociedadeFK);
            return View(jog_Soc);
        }

        // GET: Jog_Soc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jog_Soc jog_Soc = db.Jog_Socs.Find(id);
            if (jog_Soc == null)
            {
                return HttpNotFound();
            }
            return View(jog_Soc);
        }

        // POST: Jog_Soc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jog_Soc jog_Soc = db.Jog_Socs.Find(id);
            db.Jog_Socs.Remove(jog_Soc);
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
