using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iMedicalChain.Core;
using iMedicalChain.Data;

namespace iMedicalChain.Controllers
{
    public class SickSheetsController : Controller
    {
        private readonly AppDataContext _context;

        public SickSheetsController(AppDataContext context)
        {
            _context = context;
        }

        // GET: SickSheets
        public async Task<IActionResult> Index()
        {
            var appDataContext = _context.SickSheets.Include(s => s.Doctors).Include(s => s.Patient).Include(s => s.SickHistory);
            return View(await appDataContext.ToListAsync());
        }

        // GET: SickSheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SickSheets == null)
            {
                return NotFound();
            }

            var sickSheet = await _context.SickSheets
                .Include(s => s.Doctors)
                .Include(s => s.Patient)
                .Include(s => s.SickHistory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sickSheet == null)
            {
                return NotFound();
            }

            return View(sickSheet);
        }

        // GET: SickSheets/Create
        public IActionResult Create()
        {
            ViewData["DoctorsId"] = new SelectList(_context.Doctors, "Id", "Discriminator");
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id");
            ViewData["SickHistoryId"] = new SelectList(_context.SickHistories, "Id", "Id");
            return View();
        }

        // POST: SickSheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorsId,PatientId,SickHistoryId,createdAt,updatedAt,Id")] SickSheet sickSheet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sickSheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorsId"] = new SelectList(_context.Doctors, "Id", "Discriminator", sickSheet.DoctorsId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", sickSheet.PatientId);
            ViewData["SickHistoryId"] = new SelectList(_context.SickHistories, "Id", "Id", sickSheet.SickHistoryId);
            return View(sickSheet);
        }

        // GET: SickSheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SickSheets == null)
            {
                return NotFound();
            }

            var sickSheet = await _context.SickSheets.FindAsync(id);
            if (sickSheet == null)
            {
                return NotFound();
            }
            ViewData["DoctorsId"] = new SelectList(_context.Doctors, "Id", "Discriminator", sickSheet.DoctorsId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", sickSheet.PatientId);
            ViewData["SickHistoryId"] = new SelectList(_context.SickHistories, "Id", "Id", sickSheet.SickHistoryId);
            return View(sickSheet);
        }

        // POST: SickSheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorsId,PatientId,SickHistoryId,createdAt,updatedAt,Id")] SickSheet sickSheet)
        {
            if (id != sickSheet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sickSheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SickSheetExists(sickSheet.Id))
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
            ViewData["DoctorsId"] = new SelectList(_context.Doctors, "Id", "Discriminator", sickSheet.DoctorsId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", sickSheet.PatientId);
            ViewData["SickHistoryId"] = new SelectList(_context.SickHistories, "Id", "Id", sickSheet.SickHistoryId);
            return View(sickSheet);
        }

        // GET: SickSheets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SickSheets == null)
            {
                return NotFound();
            }

            var sickSheet = await _context.SickSheets
                .Include(s => s.Doctors)
                .Include(s => s.Patient)
                .Include(s => s.SickHistory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sickSheet == null)
            {
                return NotFound();
            }

            return View(sickSheet);
        }

        // POST: SickSheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SickSheets == null)
            {
                return Problem("Entity set 'AppDataContext.SickSheets'  is null.");
            }
            var sickSheet = await _context.SickSheets.FindAsync(id);
            if (sickSheet != null)
            {
                _context.SickSheets.Remove(sickSheet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SickSheetExists(int id)
        {
          return _context.SickSheets.Any(e => e.Id == id);
        }
    }
}
