using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VisionQuest.Models;

namespace VisionQuest.Controllers
{
    public class RecuerdosController : Controller
    {
        private VisionQuestContext db = new VisionQuestContext();

        // GET: Recuerdos
        public ActionResult Index()
        {
            var recuerdos = db.Recuerdos.Include(r => r.Sintezoide);
            return View(recuerdos.ToList());
        }

        // GET: Recuerdos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recuerdo recuerdo = db.Recuerdos.Find(id);
            if (recuerdo == null)
            {
                return HttpNotFound();
            }
            return View(recuerdo);
        }

        // GET: Recuerdos/Create
        public ActionResult Create()
        {
            ViewBag.SintezoideId = new SelectList(db.Sintezoides, "Id", "Nombre");
            return View();
        }

        // POST: Recuerdos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TituloRecuerdo,TipoRecuerdo,Claridad,SintezoideId")] Recuerdo recuerdo)
        {
            if (ModelState.IsValid)
            {
                db.Recuerdos.Add(recuerdo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SintezoideId = new SelectList(db.Sintezoides, "Id", "Nombre", recuerdo.SintezoideId);
            return View(recuerdo);
        }

        // GET: Recuerdos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recuerdo recuerdo = db.Recuerdos.Find(id);
            if (recuerdo == null)
            {
                return HttpNotFound();
            }
            ViewBag.SintezoideId = new SelectList(db.Sintezoides, "Id", "Nombre", recuerdo.SintezoideId);
            return View(recuerdo);
        }

        // POST: Recuerdos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TituloRecuerdo,TipoRecuerdo,Claridad,SintezoideId")] Recuerdo recuerdo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recuerdo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SintezoideId = new SelectList(db.Sintezoides, "Id", "Nombre", recuerdo.SintezoideId);
            return View(recuerdo);
        }

        // GET: Recuerdos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recuerdo recuerdo = db.Recuerdos.Find(id);
            if (recuerdo == null)
            {
                return HttpNotFound();
            }
            return View(recuerdo);
        }

        // POST: Recuerdos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recuerdo recuerdo = db.Recuerdos.Find(id);
            db.Recuerdos.Remove(recuerdo);
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
