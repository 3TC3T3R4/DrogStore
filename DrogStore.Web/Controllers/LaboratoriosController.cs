using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrogStore.Web.Data;
using DrogStore.Web.Models;

namespace DrogStore.Web.Controllers
{
    public class LaboratoriosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LaboratoriosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Laboratorios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Laboratorios.ToListAsync());
        }

        // GET: Laboratorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Laboratorios == null)
            {
                return NotFound();
            }

            var laboratorio = await _context.Laboratorios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laboratorio == null)
            {
                return NotFound();
            }

            return View(laboratorio);
        }

        // GET: Laboratorios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laboratorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Nit,Ubicacion,Tipo")] Laboratorio laboratorio)
        {
            try
            {
                _context.Add(laboratorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, "hay un registro con el mismo nombre.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty,
                   dbUpdateException.InnerException.Message);
                }
            }
            return View(laboratorio);
        }

        // GET: Laboratorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Laboratorios == null)
            {
                return NotFound();
            }

            var laboratorio = await _context.Laboratorios.FindAsync(id);
            if (laboratorio == null)
            {
                return NotFound();
            }
            return View(laboratorio);
        }

        // POST: Laboratorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Laboratorio laboratorio)
        {
            if (id != laboratorio.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laboratorio);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if
                   (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "hay un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
                       dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(laboratorio);
        }

        // GET: Laboratorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Laboratorios == null)
            {
                return NotFound();
            }

            var laboratorio = await _context.Laboratorios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laboratorio == null)
            {
                return NotFound();
            }

            return View(laboratorio);
        }

        // POST: Laboratorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Laboratorios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Laboratorios'  is null.");
            }
            var laboratorio = await _context.Laboratorios.FindAsync(id);
            if (laboratorio != null)
            {
                _context.Laboratorios.Remove(laboratorio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaboratorioExists(int id)
        {
          return _context.Laboratorios.Any(e => e.Id == id);
        }
    }
}
