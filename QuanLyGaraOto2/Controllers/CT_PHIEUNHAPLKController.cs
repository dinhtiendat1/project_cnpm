using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyGaraOto2.Models;

namespace QuanLyGaraOto2.Controllers
{
    public class CT_PHIEUNHAPLKController : Controller
    {
        private QuanLyGaraOto2Context db = new QuanLyGaraOto2Context();

        // GET: CT_PHIEUNHAPLK
        public ActionResult Index()
        {
            var cT_PHIEUNHAPLK = db.CT_PHIEUNHAPLK.Include(c => c.DICHVU_LINHKIEN).Include(c => c.PHIEUNHAPLINHKIEN);
            return View(cT_PHIEUNHAPLK.ToList());
        }

        // GET: CT_PHIEUNHAPLK/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_PHIEUNHAPLK cT_PHIEUNHAPLK = db.CT_PHIEUNHAPLK.Find(id);
            if (cT_PHIEUNHAPLK == null)
            {
                return HttpNotFound();
            }
            return View(cT_PHIEUNHAPLK);
        }

        // GET: CT_PHIEUNHAPLK/Create
        public ActionResult Create()
        {
            ViewBag.MaDV_LK = new SelectList(db.DICHVU_LINHKIEN, "MaDV_LK", "TenDV_LK");
            ViewBag.Ma_PhieuNLK = new SelectList(db.PHIEUNHAPLINHKIENs, "Ma_PhieuNLK", "Ma_PhieuNLK");
            return View();
        }

        // POST: CT_PHIEUNHAPLK/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDV_LK,Ma_PhieuNLK,SoLuong")] CT_PHIEUNHAPLK cT_PHIEUNHAPLK)
        {
            if (ModelState.IsValid)
            {
                db.CT_PHIEUNHAPLK.Add(cT_PHIEUNHAPLK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDV_LK = new SelectList(db.DICHVU_LINHKIEN, "MaDV_LK", "TenDV_LK", cT_PHIEUNHAPLK.MaDV_LK);
            ViewBag.Ma_PhieuNLK = new SelectList(db.PHIEUNHAPLINHKIENs, "Ma_PhieuNLK", "Ma_PhieuNLK", cT_PHIEUNHAPLK.Ma_PhieuNLK);
            return View(cT_PHIEUNHAPLK);
        }

        // GET: CT_PHIEUNHAPLK/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_PHIEUNHAPLK cT_PHIEUNHAPLK = db.CT_PHIEUNHAPLK.Find(id);
            if (cT_PHIEUNHAPLK == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDV_LK = new SelectList(db.DICHVU_LINHKIEN, "MaDV_LK", "TenDV_LK", cT_PHIEUNHAPLK.MaDV_LK);
            ViewBag.Ma_PhieuNLK = new SelectList(db.PHIEUNHAPLINHKIENs, "Ma_PhieuNLK", "Ma_PhieuNLK", cT_PHIEUNHAPLK.Ma_PhieuNLK);
            return View(cT_PHIEUNHAPLK);
        }

        // POST: CT_PHIEUNHAPLK/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDV_LK,Ma_PhieuNLK,SoLuong")] CT_PHIEUNHAPLK cT_PHIEUNHAPLK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_PHIEUNHAPLK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDV_LK = new SelectList(db.DICHVU_LINHKIEN, "MaDV_LK", "TenDV_LK", cT_PHIEUNHAPLK.MaDV_LK);
            ViewBag.Ma_PhieuNLK = new SelectList(db.PHIEUNHAPLINHKIENs, "Ma_PhieuNLK", "Ma_PhieuNLK", cT_PHIEUNHAPLK.Ma_PhieuNLK);
            return View(cT_PHIEUNHAPLK);
        }

        // GET: CT_PHIEUNHAPLK/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_PHIEUNHAPLK cT_PHIEUNHAPLK = db.CT_PHIEUNHAPLK.Find(id);
            if (cT_PHIEUNHAPLK == null)
            {
                return HttpNotFound();
            }
            return View(cT_PHIEUNHAPLK);
        }

        // POST: CT_PHIEUNHAPLK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_PHIEUNHAPLK cT_PHIEUNHAPLK = db.CT_PHIEUNHAPLK.Find(id);
            db.CT_PHIEUNHAPLK.Remove(cT_PHIEUNHAPLK);
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
