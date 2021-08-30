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
    public class TacGiasController : Controller
    {
        private readonly QuanLyBanSachContext _context;

        public TacGiasController(QuanLyBanSachContext context)
        {
            _context = context;
        }

        // GET: TacGias
        public async Task<IActionResult> Index()
        {
            return View(await _context.TacGia.ToListAsync());
        }

        // GET: TacGias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tacGia = await _context.TacGia
                .FirstOrDefaultAsync(m => m.MaTacGia == id);
            if (tacGia == null)
            {
                return NotFound();
            }

            return View(tacGia);
        }

        // GET: TacGias/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Createss()
        {
            return View();
        }

        // POST: TacGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTacGia,TenTacGia,DiaChi,TieuSu,DienThoai")] TacGia tacGia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tacGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tacGia);
        }

        // GET: TacGias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tacGia = await _context.TacGia.FindAsync(id);
            if (tacGia == null)
            {
                return NotFound();
            }
            return View(tacGia);
        }

        // POST: TacGias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaTacGia,TenTacGia,DiaChi,TieuSu,DienThoai")] TacGia tacGia)
        {
            if (id != tacGia.MaTacGia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tacGia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TacGiaExists(tacGia.MaTacGia))
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
            return View(tacGia);
        }

        // GET: TacGias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tacGia = await _context.TacGia
                .FirstOrDefaultAsync(m => m.MaTacGia == id);
            if (tacGia == null)
            {
                return NotFound();
            }

            return View(tacGia);
        }

        // POST: TacGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tacGia = await _context.TacGia.FindAsync(id);
            _context.TacGia.Remove(tacGia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TacGiaExists(int id)
        {
            return _context.TacGia.Any(e => e.MaTacGia == id);
        }
    }
}
