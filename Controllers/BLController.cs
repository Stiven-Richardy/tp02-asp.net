using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP02.Data;
using TP02.Models;

namespace TP02.Controllers
{
    public class BLController : Controller
    {
        private readonly AppDbContext _context;

        public BLController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bls = await _context.BLs.ToListAsync();
            return View(bls);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Consignee,Navio")] BL bl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bl);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var bl = await _context.BLs.FindAsync(id);
            if (bl == null) return NotFound();

            return View(bl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Consignee,Navio")] BL bl)
        {
            if (id != bl.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BLExists(bl.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bl);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var bl = await _context.BLs.FirstOrDefaultAsync(m => m.Id == id);
            if (bl == null) return NotFound();

            return View(bl);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bl = await _context.BLs.FindAsync(id);
            if (bl != null)
            {
                _context.BLs.Remove(bl);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BLExists(int id)
        {
            return _context.BLs.Any(e => e.Id == id);
        }
    }
}