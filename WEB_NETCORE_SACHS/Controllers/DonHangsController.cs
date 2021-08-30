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
    public class DonHangsController : Controller
    {
        private readonly QuanLyBanSachContext _context;

        public DonHangsController(QuanLyBanSachContext context)
        {
            _context = context;
        }

        // GET: DonHangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DonHangs.ToListAsync());
        }

        // GET: DonHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs
                .FirstOrDefaultAsync(m => m.MaDonHang == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // GET: DonHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDonHang,NgayGiao,NgayDat,TtthanhToan,TtgiaoHang,MaKh,TongTien")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donHang);
        }

        // GET: DonHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            return View(donHang);
        }

        // POST: DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDonHang,NgayGiao,NgayDat,TtthanhToan,TtgiaoHang,MaKh,TongTien")] DonHang donHang)
        {
            if (id != donHang.MaDonHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHangExists(donHang.MaDonHang))
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
            return View(donHang);
        }

        // GET: DonHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs
                .FirstOrDefaultAsync(m => m.MaDonHang == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // POST: DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donHang = await _context.DonHangs.FindAsync(id);
            _context.DonHangs.Remove(donHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHangExists(int id)
        {
            return _context.DonHangs.Any(e => e.MaDonHang == id);
        }
    }
}
