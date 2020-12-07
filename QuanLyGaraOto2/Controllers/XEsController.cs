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
    public class XEsController : Controller
    {
        private QuanLyGaraOto2Context db = new QuanLyGaraOto2Context();

        // GET: XEs
        public ActionResult Index()
        {
            var xEs = db.XEs.Include(x => x.HIEUXE).Where(x=>x.TienNo==0);
            return View(xEs.ToList());
        }

        public ActionResult Index2()
        {
            var xEs = db.XEs.Include(x => x.HIEUXE).Where(x => x.TienNo != 0);
            return View(xEs.ToList());
        }

        // GET: XEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XE xE = db.XEs.Find(id);
            if (xE == null)
            {
                return HttpNotFound();
            }
            return View(xE);
        }

        // GET: XEs/Create
        public ActionResult Create()
        {
            ViewBag.MaHX = new SelectList(db.HIEUXEs, "MaHX", "TenHX");
            return View();
        }

        // POST: XEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string bienSo, string tenChuXe, string diaChi, string dienThoai, short maHX)
        {
            XE xe = new XE();
            xe.BienSo = bienSo;
            xe.TenChuXe = tenChuXe;
            xe.DiaChi = diaChi;
            xe.DienThoai = dienThoai;
            xe.MaHX = maHX;
            xe.TienNo = 0;
            if (ModelState.IsValid)
            {
                db.XEs.Add(xe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHX = new SelectList(db.HIEUXEs, "MaHX", "TenHX", xe.MaHX);
            return View(xe);
        }

        // GET: XEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XE xE = db.XEs.Find(id);
            if (xE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHX = new SelectList(db.HIEUXEs, "MaHX", "TenHX", xE.MaHX);
            return View(xE);
        }

        // POST: XEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BienSo,MaHX,TenChuXe,DiaChi,DienThoai,TienNo")] XE xE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(xE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHX = new SelectList(db.HIEUXEs, "MaHX", "TenHX", xE.MaHX);
            return View(xE);
        }

        // GET: XEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XE xE = db.XEs.Find(id);
            if (xE == null)
            {
                return HttpNotFound();
            }
            return View(xE);
        }

        // POST: XEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            XE xE = db.XEs.Find(id);
            db.XEs.Remove(xE);
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
