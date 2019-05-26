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
    public class PagamentosController : Controller
    {
        private EurosociDB db = new EurosociDB();

        // GET: Pagamentos
        public ActionResult Index()
        {
            var pagamentos = db.Pagamentos.Include(p => p.Jog_Soc);
            return View(pagamentos.ToList());
        }

        // GET: Pagamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            if (pagamentos == null)
            {
                return HttpNotFound();
            }
            return View(pagamentos);
        }

        // GET: Pagamentos/Create
        public ActionResult Create()
        {
            ViewBag.Jog_SocFK = new SelectList(db.Jog_Socs, "ID", "ID");
            return View();
        }

        // POST: Pagamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DataPagamento,ValorPago,Jog_SocFK")] Pagamentos pagamentos)
        {
            if (ModelState.IsValid)
            {
                db.Pagamentos.Add(pagamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Jog_SocFK = new SelectList(db.Jog_Socs, "ID", "ID", pagamentos.Jog_SocFK);
            return View(pagamentos);
        }

        // GET: Pagamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            if (pagamentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jog_SocFK = new SelectList(db.Jog_Socs, "ID", "ID", pagamentos.Jog_SocFK);
            return View(pagamentos);
        }

        // POST: Pagamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DataPagamento,ValorPago,Jog_SocFK")] Pagamentos pagamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Jog_SocFK = new SelectList(db.Jog_Socs, "ID", "ID", pagamentos.Jog_SocFK);
            return View(pagamentos);
        }

        // GET: Pagamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            if (pagamentos == null)
            {
                return HttpNotFound();
            }
            return View(pagamentos);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            db.Pagamentos.Remove(pagamentos);
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
