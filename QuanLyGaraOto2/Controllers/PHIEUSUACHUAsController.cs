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
    public class PHIEUSUACHUAsController : Controller
    {
        private QuanLyGaraOto2Context db = new QuanLyGaraOto2Context();

        // GET: PHIEUSUACHUAs
        public ActionResult Index()
        {
            var pHIEUSUACHUAs = db.PHIEUSUACHUAs.Include(p => p.XE);
            return View(pHIEUSUACHUAs.ToList());
        }

        // GET: PHIEUSUACHUAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUSUACHUA pHIEUSUACHUA = db.PHIEUSUACHUAs.Find(id);
            if (pHIEUSUACHUA == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUSUACHUA);
        }

        // GET: PHIEUSUACHUAs/Create
        public ActionResult Create()
        {
            ViewBag.BienSo = new SelectList(db.XEs, "BienSo","BienSo");
            return View();
        }
        [HttpPost]
        public ActionResult CreateSessionXe(string bienSo)
        {
            XE xe = db.XEs.FirstOrDefault(x => x.BienSo.Equals(bienSo));
            Session["xe"] = xe;
            Session["bienSo"] = xe.BienSo;
            return RedirectToAction("SessionCreate");
        }

        // POST: PHIEUSUACHUAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        public ActionResult SessionCreate()
        {



            //Kiểm tra xe trong phiếu sữa chữa k trống
            if (Session["xe"] != null)
            {

                
                List<CT_PHIEUSUACHUA> phieuSuaChua = Session["PhieuSuaChua"] as List<CT_PHIEUSUACHUA>;
                if (phieuSuaChua == null)
                {
                    ViewBag.Xe = Session["xe"];
                    ViewBag.Message = "Chưa có linh kiện/dịch vụ nào trong phiếu sữa chữa";
                    return View("SessionCreateException");
                }
                else
                {
                    ViewBag.Xe = Session["xe"];
                    var result = from g in phieuSuaChua
                                 join l in db.DICHVU_LINHKIEN on g.MaDV_LK equals l.MaDV_LK
                                 select new TMP_CT_PHIEUSC
                                 {
                                     TenDV_LK = l.TenDV_LK,
                                     DonGia=(double)l.DonGia,
                                     SoLuong=(int)g.SoLuong,
                                     ThanhTien=(double)(l.DonGia*g.SoLuong)
                                        
                                 };
                    ViewData["data"] = result;
                    return View(result);
                }

            }
            else
            {
                return RedirectToAction("Create");
            }

        }
        public ActionResult SessionCreateException()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuSC,NgaySuaChua,NgayThuTien,SoTienThu,NgayTiepNhanXe,BienSo")] PHIEUSUACHUA pHIEUSUACHUA)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUSUACHUAs.Add(pHIEUSUACHUA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BienSo = new SelectList(db.XEs, "BienSo", "TenChuXe", pHIEUSUACHUA.BienSo);
            return View(pHIEUSUACHUA);
        }

        // GET: PHIEUSUACHUAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUSUACHUA pHIEUSUACHUA = db.PHIEUSUACHUAs.Find(id);
            if (pHIEUSUACHUA == null)
            {
                return HttpNotFound();
            }
            ViewBag.BienSo = new SelectList(db.XEs, "BienSo", "TenChuXe", pHIEUSUACHUA.BienSo);
            return View(pHIEUSUACHUA);
        }

        // POST: PHIEUSUACHUAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuSC,NgaySuaChua,NgayThuTien,SoTienThu,NgayTiepNhanXe,BienSo")] PHIEUSUACHUA pHIEUSUACHUA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUSUACHUA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BienSo = new SelectList(db.XEs, "BienSo", "TenChuXe", pHIEUSUACHUA.BienSo);
            return View(pHIEUSUACHUA);
        }

        // GET: PHIEUSUACHUAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUSUACHUA pHIEUSUACHUA = db.PHIEUSUACHUAs.Find(id);
            if (pHIEUSUACHUA == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUSUACHUA);
        }

        // POST: PHIEUSUACHUAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHIEUSUACHUA pHIEUSUACHUA = db.PHIEUSUACHUAs.Find(id);
            db.PHIEUSUACHUAs.Remove(pHIEUSUACHUA);
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
