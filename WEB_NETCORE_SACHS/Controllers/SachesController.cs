using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEB_NETCORE_SACHS.Models;

namespace WEB_NETCORE_SACHS.Controllers
{
    public class SachesController : Controller
    {
        private readonly QuanLyBanSachContext _context;

        public SachesController(QuanLyBanSachContext context)
        {
            _context = context;
        }

        // GET: Saches
        public async Task<IActionResult> Index()
        {
            var quanLyBanSachContext = _context.Saches;
            return View(await quanLyBanSachContext.ToListAsync());
        }

        // GET: Saches/Details/5
        public async Task<IActionResult> Details(int? MaSach)
        {
            if (MaSach == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches
                .FirstOrDefaultAsync(m => m.MaSach == MaSach);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }
        public async Task<IActionResult> SachTheoChuDe(int? MaChuDe=0)
        {
            if(MaChuDe==null)
            {
                return NotFound();
            }
            List<Sach> Sach= await _context.Saches.Where(n => n.MaChuDe == MaChuDe).ToListAsync();
              
            if (Sach==null)
            {
                return NotFound();
            }
            return View(Sach);
        }
        public async Task<IActionResult>SachTheoNXB(int? MaNXB=0)
        {
            if(MaNXB==null)
            {
                return NotFound();
            }
            var Sach = _context.Saches.Where(m => m.MaNxb == MaNXB).ToListAsync();
            //var Sach = await _context.Saches
            //    .FirstOrDefaultAsync(m => m.MaNxb== MaNXB);
           
            if(Sach==null)
            {
                return NotFound();
            }
            return View(await Sach);
        }
        public async Task<IActionResult>ChiTiet(int? MaSach)
        {
            if (MaSach == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches
                .Include(s => s.NhaXuatBan)
                .Include(s => s.ChuDe)
                .FirstOrDefaultAsync(m => m.MaSach == MaSach);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }
        // GET: Saches/Create
        public IActionResult Create()
        {
            ViewData["MaChuDe"] = new SelectList(_context.ChuDes, "MaChuDe", "MaChuDe");
            ViewData["MaNxb"] = new SelectList(_context.NhaXuatBans, "MaNxb", "MaNxb");
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSach,TenSach,GiaBan,MoTa,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNxb,Moi")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChuDe"] = new SelectList(_context.ChuDes, "MaChuDe", "TenChude", sach.MaChuDe);
            ViewData["MaNxb"] = new SelectList(_context.NhaXuatBans, "MaNxb", "TenNxb", sach.MaNxb);
            return View(sach);
        }

        // GET: Saches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches.FindAsync(id);
            if (sach == null)
            {
                return NotFound();
            }
            ViewData["MaChuDe"] = new SelectList(_context.ChuDes, "MaChuDe", "MaChuDe", sach.MaChuDe);
            ViewData["MaNxb"] = new SelectList(_context.NhaXuatBans, "MaNxb", "MaNxb", sach.MaNxb);
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSach,TenSach,GiaBan,MoTa,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNxb,Moi")] Sach sach)
        {
            if (id != sach.MaSach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SachExists(sach.MaSach))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChuDe"] = new SelectList(_context.ChuDes, "MaChuDe", "TenChuDe");
            ViewData["MaNxb"] = new SelectList(_context.NhaXuatBans, "MaNxb", "TenNxb");
            return View(sach);
        }

        // GET: Saches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches
                .Include(s => s.ChuDe)
                .Include(s => s.NhaXuatBan)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // POST: Saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sach = await _context.Saches.FindAsync(id);
            _context.Saches.Remove(sach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SachExists(int id)
        {
            return _context.Saches.Any(e => e.MaSach == id);
        }
    }
}
