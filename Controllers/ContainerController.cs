using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP02.Data;
using TP02.Models;

namespace TP02.Controllers
{
    public class ContainerController : Controller
    {
        private readonly AppDbContext _context;

        public ContainerController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Containers.Include(c => c.BL);
            return View(await appDbContext.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["BLId"] = new SelectList(_context.BLs, "Id", "Numero");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Tipo,Tamanho,BLId")] Container container)
        {
            if (ModelState.IsValid)
            {
                container.Tipo = container.Tipo.Substring(0, 1).ToUpper() + container.Tipo.Substring(1).ToLower();
                container.Numero = container.Numero.ToUpper();

                _context.Add(container);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BLId"] = new SelectList(_context.BLs, "Id", "Numero", container.BLId);
            return View(container);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var container = await _context.Containers.FindAsync(id);
            if (container == null) return NotFound();

            ViewData["BLId"] = new SelectList(_context.BLs, "Id", "Numero", container.BLId);
            return View(container);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Tipo,Tamanho,BLId")] Container container)
        {
            if (id != container.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    container.Tipo = container.Tipo.Substring(0, 1).ToUpper() + container.Tipo.Substring(1).ToLower();
                    container.Numero = container.Numero.ToUpper();

                    _context.Update(container);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContainerExists(container.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BLId"] = new SelectList(_context.BLs, "Id", "Numero", container.BLId);
            return View(container);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var container = await _context.Containers
                .Include(c => c.BL)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (container == null) return NotFound();

            return View(container);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var container = await _context.Containers.FindAsync(id);
            if (container != null)
            {
                _context.Containers.Remove(container);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ContainerExists(int id)
        {
            return _context.Containers.Any(e => e.Id == id);
        }
    }
}