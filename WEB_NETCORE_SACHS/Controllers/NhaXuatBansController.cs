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
    public class NhaXuatBansController : Controller
    {
        private readonly QuanLyBanSachContext _context;
       

        public NhaXuatBansController(QuanLyBanSachContext context)
        {
            _context = context;
        }

        // GET: NhaXuatBans
        public async Task<IActionResult> Index()
        {
            return View(await _context.NhaXuatBans.ToListAsync());
        }
        public IActionResult OnGetPartial() =>
        new PartialViewResult
            {
                ViewName = "_AuthorPartialRP",
                ViewData = ViewData,
            };
        // GET: NhaXuatBans/Details/5
        public PartialViewResult _NhaXB_PartialView()
        {
            var nxb = _context.NhaXuatBans.Take(15).ToList();
            return PartialView(nxb);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaXuatBan = await _context.NhaXuatBans
                .FirstOrDefaultAsync(m => m.MaNxb == id);
            if (nhaXuatBan == null)
            {
                return NotFound();
            }

            return View(nhaXuatBan);
        }

        // GET: NhaXuatBans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhaXuatBans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNxb,TenNxb,DiaChi,DienThoai")] NhaXuatBan nhaXuatBan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaXuatBan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhaXuatBan);
        }

        // GET: NhaXuatBans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaXuatBan = await _context.NhaXuatBans.FindAsync(id);
            if (nhaXuatBan == null)
            {
                return NotFound();
            }
            return View(nhaXuatBan);
        }

        // POST: NhaXuatBans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaNxb,TenNxb,DiaChi,DienThoai")] NhaXuatBan nhaXuatBan)
        {
            if (id != nhaXuatBan.MaNxb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaXuatBan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaXuatBanExists(nhaXuatBan.MaNxb))
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
            return View(nhaXuatBan);
        }

        // GET: NhaXuatBans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaXuatBan = await _context.NhaXuatBans
                .FirstOrDefaultAsync(m => m.MaNxb == id);
            if (nhaXuatBan == null)
            {
                return NotFound();
            }

            return View(nhaXuatBan);
        }

        // POST: NhaXuatBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhaXuatBan = await _context.NhaXuatBans.FindAsync(id);
            _context.NhaXuatBans.Remove(nhaXuatBan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaXuatBanExists(int id)
        {
            return _context.NhaXuatBans.Any(e => e.MaNxb == id);
        }
    }
}
