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
    public class ThamGiasController : Controller
    {
        private readonly QuanLyBanSachContext _context;

        public ThamGiasController(QuanLyBanSachContext context)
        {
            _context = context;
        }

        // GET: ThamGias
        public async Task<IActionResult> Index()
        {
            var quanLyBanSachContext = _context.ThamGia.Include(t => t.MaSach).Include(t => t.MaTacGia);
            return View(await quanLyBanSachContext.ToListAsync());
        }

        // GET: ThamGias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thamGia = await _context.ThamGia
                .Include(t => t.MaSach)
                .Include(t => t.MaTacGia)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (thamGia == null)
            {
                return NotFound();
            }

            return View(thamGia);
        }

        // GET: ThamGias/Create
        public IActionResult Create()
        {
            ViewData["MaSach"] = new SelectList(_context.Saches, "MaSach", "MaSach");
            ViewData["MaTacGia"] = new SelectList(_context.TacGia, "MaTacGia", "MaTacGia");
            return View();
        }

        // POST: ThamGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSach,MaTacGia,VaiTro,ViTri")] ThamGia thamGia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thamGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaSach"] = new SelectList(_context.Saches, "MaSach", "MaSach", thamGia.MaSach);
            ViewData["MaTacGia"] = new SelectList(_context.TacGia, "MaTacGia", "MaTacGia", thamGia.MaTacGia);
            return View(thamGia);
        }

        // GET: ThamGias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thamGia = await _context.ThamGia.FindAsync(id);
            if (thamGia == null)
            {
                return NotFound();
            }
            ViewData["MaSach"] = new SelectList(_context.Saches, "MaSach", "MaSach", thamGia.MaSach);
            ViewData["MaTacGia"] = new SelectList(_context.TacGia, "MaTacGia", "MaTacGia", thamGia.MaTacGia);
            return View(thamGia);
        }

        // POST: ThamGias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSach,MaTacGia,VaiTro,ViTri")] ThamGia thamGia)
        {
            if (id != thamGia.MaSach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thamGia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThamGiaExists(thamGia.MaSach))
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
            ViewData["MaSach"] = new SelectList(_context.Saches, "MaSach", "MaSach", thamGia.MaSach);
            ViewData["MaTacGia"] = new SelectList(_context.TacGia, "MaTacGia", "MaTacGia", thamGia.MaTacGia);
            return View(thamGia);
        }

        // GET: ThamGias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thamGia = await _context.ThamGia
                .Include(t => t.MaSach)
                .Include(t => t.MaTacGia)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (thamGia == null)
            {
                return NotFound();
            }

            return View(thamGia);
        }

        // POST: ThamGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thamGia = await _context.ThamGia.FindAsync(id);
            _context.ThamGia.Remove(thamGia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThamGiaExists(int id)
        {
            return _context.ThamGia.Any(e => e.MaSach == id);
        }
    }
}
