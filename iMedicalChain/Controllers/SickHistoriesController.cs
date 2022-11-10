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
    public class SickHistoriesController : Controller
    {
        private readonly AppDataContext _context;

        public SickHistoriesController(AppDataContext context)
        {
            _context = context;
        }

        // GET: SickHistories
        public async Task<IActionResult> Index()
        {
              return View(await _context.SickHistories.ToListAsync());
        }

        // GET: SickHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SickHistories == null)
            {
                return NotFound();
            }

            var sickHistory = await _context.SickHistories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sickHistory == null)
            {
                return NotFound();
            }

            return View(sickHistory);
        }

        // GET: SickHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SickHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HospitalName,TimeToCome,SickDefinedTime,GetHospitalName,DiagnozGetHospitalName,DiagnozinReception,ClinicalDiagnoz,FinalDiagnoz,MainDiagnoz,MainSickResult,Complaints,AnamnesisMorbi,AnamnesisVitae,createdAt,updatedAt,Id")] SickHistory sickHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sickHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sickHistory);
        }

        // GET: SickHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SickHistories == null)
            {
                return NotFound();
            }

            var sickHistory = await _context.SickHistories.FindAsync(id);
            if (sickHistory == null)
            {
                return NotFound();
            }
            return View(sickHistory);
        }

        // POST: SickHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HospitalName,TimeToCome,SickDefinedTime,GetHospitalName,DiagnozGetHospitalName,DiagnozinReception,ClinicalDiagnoz,FinalDiagnoz,MainDiagnoz,MainSickResult,Complaints,AnamnesisMorbi,AnamnesisVitae,createdAt,updatedAt,Id")] SickHistory sickHistory)
        {
            if (id != sickHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sickHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SickHistoryExists(sickHistory.Id))
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
            return View(sickHistory);
        }

        // GET: SickHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SickHistories == null)
            {
                return NotFound();
            }

            var sickHistory = await _context.SickHistories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sickHistory == null)
            {
                return NotFound();
            }

            return View(sickHistory);
        }

        // POST: SickHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SickHistories == null)
            {
                return Problem("Entity set 'AppDataContext.SickHistories'  is null.");
            }
            var sickHistory = await _context.SickHistories.FindAsync(id);
            if (sickHistory != null)
            {
                _context.SickHistories.Remove(sickHistory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SickHistoryExists(int id)
        {
          return _context.SickHistories.Any(e => e.Id == id);
        }
    }
}
