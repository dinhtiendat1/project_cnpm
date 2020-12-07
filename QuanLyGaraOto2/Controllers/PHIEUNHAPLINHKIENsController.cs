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
    public class PHIEUNHAPLINHKIENsController : Controller
    {
        private QuanLyGaraOto2Context db = new QuanLyGaraOto2Context();

        // GET: PHIEUNHAPLINHKIENs
        public ActionResult Index()
        {
            var pHIEUNHAPLINHKIENs = db.PHIEUNHAPLINHKIENs.Include(p => p.NHACUNGCAP);
            return View(pHIEUNHAPLINHKIENs.ToList());
        }

        //Tạo session nhà cung cấp
        [HttpPost]
        public ActionResult CreateSessionNCC(int maNCC)
        {
            NHACUNGCAP nHACUNGCAP = db.NHACUNGCAPs.FirstOrDefault(x => x.MaNCC == maNCC);
            Session["NhaCungCap"] = nHACUNGCAP;
            Session["MaNCC"] = nHACUNGCAP.MaNCC;
            return RedirectToAction("PhieuNhapLinhKien");
        }

        public ActionResult LuuPhieuNhapLinhKien()
        {
            List<CT_PHIEUNHAPLK> phieuNhapLK = Session["PhieuNhapLK"] as List<CT_PHIEUNHAPLK>;
            short maNCC = (short)Session["MaNCC"];
            PHIEUNHAPLINHKIEN pHIEUNHAPLINHKIEN = new PHIEUNHAPLINHKIEN()
            {
                NgayNhap = DateTime.Now,
                MaNCC = maNCC
            };
            db.PHIEUNHAPLINHKIENs.Add(pHIEUNHAPLINHKIEN);
            
            foreach(var item in phieuNhapLK)
            {
                CT_PHIEUNHAPLK cT_PHIEUNHAPLK = new CT_PHIEUNHAPLK()
                {
                    MaDV_LK = item.MaDV_LK,
                    Ma_PhieuNLK = pHIEUNHAPLINHKIEN.Ma_PhieuNLK,
                    SoLuong = item.SoLuong
                };               
                db.CT_PHIEUNHAPLK.Add(cT_PHIEUNHAPLK);
                DICHVU_LINHKIEN dICHVU_LINHKIEN = db.DICHVU_LINHKIEN.FirstOrDefault(m => m.MaDV_LK == item.MaDV_LK);
                dICHVU_LINHKIEN.SoLuongTonKho += item.SoLuong;
                db.Entry(dICHVU_LINHKIEN).State = EntityState.Modified;

            }
            db.SaveChanges();
            Session.Remove("PhieuNhapLK");
            Session.Remove("NhaCungCap");
            Session.Remove("MaNCC");
            return RedirectToAction("index");
        }

        public ActionResult PhieuNhapLinhKien()
        {
            if(Session["NhaCungCap"]!=null)
            {
                List<CT_PHIEUNHAPLK> phieuNhapLK = Session["PhieuNhapLK"] as List<CT_PHIEUNHAPLK>;
                if (phieuNhapLK == null)
                {
                    ViewBag.NhaCungCap = Session["NhaCungCap"];
                    ViewBag.Message = "Chưa có linh kiện/dịch vụ nào trong phiếu sữa chữa";
                    return View("PhieuNhapLKException");
                }
                else
                {
                    ViewBag.NhaCungCap = Session["NhaCungCap"];
                    var result = from g in phieuNhapLK
                                 join l in db.DICHVU_LINHKIEN on g.MaDV_LK equals l.MaDV_LK
                                 select new TMP_CT_PHIEUNHAPLK
                                 {
                                     TenDV_LK = l.TenDV_LK,
                                     SoLuong = g.SoLuong,
                                     DonGia = (double)l.DonGia,
                                     ThanhTien = (double)(l.DonGia * g.SoLuong)
                                 };
                    ViewData["data"] = result;
                    return View(result);
                }

            }
            return View();
        }

        public ActionResult PhieuNhapLKException()
        {
            return View();
        }

        public ActionResult ThemVaoPhieuSuaChua(int maDV_LK, int soLuong)
        {
            if (Session["PhieuNhapLK"] == null)
            {
                Session["PhieuNhapLK"] = new List<CT_PHIEUNHAPLK>();
            }
            List<CT_PHIEUNHAPLK> phieuNhapLK = Session["PhieuNhapLK"] as List<CT_PHIEUNHAPLK>;
            if(phieuNhapLK.FirstOrDefault(x => x.MaDV_LK==maDV_LK)==null)
            {
                DICHVU_LINHKIEN dICHVU_LINHKIEN = db.DICHVU_LINHKIEN.Find(maDV_LK);
                CT_PHIEUNHAPLK cT_PHIEUNHAPLK=new CT_PHIEUNHAPLK();
                cT_PHIEUNHAPLK.MaDV_LK = maDV_LK;
                cT_PHIEUNHAPLK.SoLuong = soLuong;
                phieuNhapLK.Add(cT_PHIEUNHAPLK);
            }
            else
            {
                DICHVU_LINHKIEN dICHVU_LINHKIEN = db.DICHVU_LINHKIEN.Find(maDV_LK);
                CT_PHIEUNHAPLK cT_PHIEUNHAPLK = phieuNhapLK.FirstOrDefault(m => m.MaDV_LK == maDV_LK);
                cT_PHIEUNHAPLK.SoLuong += soLuong;

            }
            return RedirectToAction("PhieuNhapLinhKien");
        }
        // GET: PHIEUNHAPLINHKIENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUNHAPLINHKIEN pHIEUNHAPLINHKIEN = db.PHIEUNHAPLINHKIENs.Find(id);
            if (pHIEUNHAPLINHKIEN == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUNHAPLINHKIEN);
        }

        // GET: PHIEUNHAPLINHKIENs/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC");
            return View();
        }

        // POST: PHIEUNHAPLINHKIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_PhieuNLK,NgayNhap,MaNCC")] PHIEUNHAPLINHKIEN pHIEUNHAPLINHKIEN)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUNHAPLINHKIENs.Add(pHIEUNHAPLINHKIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC", pHIEUNHAPLINHKIEN.MaNCC);
            return View(pHIEUNHAPLINHKIEN);
        }

        // GET: PHIEUNHAPLINHKIENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUNHAPLINHKIEN pHIEUNHAPLINHKIEN = db.PHIEUNHAPLINHKIENs.Find(id);
            if (pHIEUNHAPLINHKIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC", pHIEUNHAPLINHKIEN.MaNCC);
            return View(pHIEUNHAPLINHKIEN);
        }

        // POST: PHIEUNHAPLINHKIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_PhieuNLK,NgayNhap,MaNCC")] PHIEUNHAPLINHKIEN pHIEUNHAPLINHKIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUNHAPLINHKIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC", pHIEUNHAPLINHKIEN.MaNCC);
            return View(pHIEUNHAPLINHKIEN);
        }

        // GET: PHIEUNHAPLINHKIENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUNHAPLINHKIEN pHIEUNHAPLINHKIEN = db.PHIEUNHAPLINHKIENs.Find(id);
            if (pHIEUNHAPLINHKIEN == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUNHAPLINHKIEN);
        }

        // POST: PHIEUNHAPLINHKIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHIEUNHAPLINHKIEN pHIEUNHAPLINHKIEN = db.PHIEUNHAPLINHKIENs.Find(id);
            db.PHIEUNHAPLINHKIENs.Remove(pHIEUNHAPLINHKIEN);
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
