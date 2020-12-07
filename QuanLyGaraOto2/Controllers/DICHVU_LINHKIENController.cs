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
    public class DICHVU_LINHKIENController : Controller
    {
        private QuanLyGaraOto2Context db = new QuanLyGaraOto2Context();

        // GET: DICHVU_LINHKIEN
        public ActionResult Index()
        {
            return View(db.DICHVU_LINHKIEN.ToList());
        }

        public ActionResult Index3()
        {
            return View(db.DICHVU_LINHKIEN.Where(m=>m.SoLuongTonKho<=15).ToList());
        }

        //Thêm vào phiếu sửa chữa session
        public ActionResult ThemVaoPhieuSC_Session(int id)
        {
            
            if(Session["PhieuSuaChua"]==null)
            {
                Session["PhieuSuaChua"] = new List<CT_PHIEUSUACHUA>();
            }
            List<CT_PHIEUSUACHUA> phieuSuaChua = Session["PhieuSuaChua"] as List<CT_PHIEUSUACHUA>;
            
            //kiểm tra nếu chưa có sản phẩm này trong giỏ hàng
            if (phieuSuaChua.FirstOrDefault(m => m.MaDV_LK == id) == null)
            {
                DICHVU_LINHKIEN dV_LK = db.DICHVU_LINHKIEN.Find(id);
                CT_PHIEUSUACHUA cT_PHIEUSUACHUA = new CT_PHIEUSUACHUA();
                
                cT_PHIEUSUACHUA.MaDV_LK = id;
                cT_PHIEUSUACHUA.SoLuong = 1;
                cT_PHIEUSUACHUA.ThanhTien = (double)((double)cT_PHIEUSUACHUA.SoLuong * dV_LK.DonGia);
                
                phieuSuaChua.Add(cT_PHIEUSUACHUA);
            }
            else
            {
                DICHVU_LINHKIEN dV_LK = db.DICHVU_LINHKIEN.Find(id);
                CT_PHIEUSUACHUA cT_PHIEUSUACHUA = phieuSuaChua.FirstOrDefault(m => m.MaDV_LK == id);
                cT_PHIEUSUACHUA.SoLuong++;
                cT_PHIEUSUACHUA.ThanhTien = (double)(cT_PHIEUSUACHUA.ThanhTien + dV_LK.DonGia);
                
            }
            return RedirectToAction("SessionCreate", "PhieuSuaChuas");
        }
        public ActionResult Index2()
        {
            return View(db.DICHVU_LINHKIEN.ToList());
        }
        // GET: DICHVU_LINHKIEN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DICHVU_LINHKIEN dICHVU_LINHKIEN = db.DICHVU_LINHKIEN.Find(id);
            if (dICHVU_LINHKIEN == null)
            {
                return HttpNotFound();
            }
            return View(dICHVU_LINHKIEN);
        }

        // GET: DICHVU_LINHKIEN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DICHVU_LINHKIEN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDV_LK,TenDV_LK,DonGia,SoLuongTonKho")] DICHVU_LINHKIEN dICHVU_LINHKIEN)
        {
            if (ModelState.IsValid)
            {
                db.DICHVU_LINHKIEN.Add(dICHVU_LINHKIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dICHVU_LINHKIEN);
        }

        // GET: DICHVU_LINHKIEN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DICHVU_LINHKIEN dICHVU_LINHKIEN = db.DICHVU_LINHKIEN.Find(id);
            if (dICHVU_LINHKIEN == null)
            {
                return HttpNotFound();
            }
            return View(dICHVU_LINHKIEN);
        }

        // POST: DICHVU_LINHKIEN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDV_LK,TenDV_LK,DonGia,SoLuongTonKho")] DICHVU_LINHKIEN dICHVU_LINHKIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dICHVU_LINHKIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dICHVU_LINHKIEN);
        }

        // GET: DICHVU_LINHKIEN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DICHVU_LINHKIEN dICHVU_LINHKIEN = db.DICHVU_LINHKIEN.Find(id);
            if (dICHVU_LINHKIEN == null)
            {
                return HttpNotFound();
            }
            return View(dICHVU_LINHKIEN);
        }

        // POST: DICHVU_LINHKIEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DICHVU_LINHKIEN dICHVU_LINHKIEN = db.DICHVU_LINHKIEN.Find(id);
            db.DICHVU_LINHKIEN.Remove(dICHVU_LINHKIEN);
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
