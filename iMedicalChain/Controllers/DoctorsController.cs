using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iMedicalChain.Core;
using iMedicalChain.Data;
using System.Text.Json;
using iMedicalChain.Services;

namespace iMedicalChain.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly AppDataContext _context;
        private readonly IBlockServices _blockServices;

        public DoctorsController(AppDataContext context, IBlockServices blockServices)
        {
            _context = context;
            this._blockServices = blockServices;
        }

        // GET: Doctors
        public async Task<IActionResult> Index()
        {
              return View(await _context.Doctors.ToListAsync());
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound();
            }

            var doctors = await _context.Doctors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctors == null)
            {
                return NotFound();
            }

            return View(doctors);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,BirhtDay,Adress,PasspordSeriaAndNumber,PINFL,PhoneNumber,createdAt,updatedAt,Id")] Doctors doctors)
        {
            if (ModelState.IsValid)
            {

                var last = await _context.Blocks.ToListAsync();
                if (last.Count == 0)
                {
                    string update = JsonSerializer.Serialize<Doctors>(doctors);

                    await _blockServices.AddBlock(update, "first_block");
                }
                else
                {
                    string hash = last[^1].hash;
                    string update = JsonSerializer.Serialize<Doctors>(doctors);

                    await _blockServices.AddBlock(update, hash);
                }
                _context.Add(doctors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctors);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound();
            }

            var doctors = await _context.Doctors.FindAsync(id);
            if (doctors == null)
            {
                return NotFound();
            }
            return View(doctors);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,BirhtDay,Adress,PasspordSeriaAndNumber,PINFL,PhoneNumber,createdAt,updatedAt,Id")] Doctors doctors)
        {
            if (id != doctors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorsExists(doctors.Id))
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
            return View(doctors);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound();
            }

            var doctors = await _context.Doctors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctors == null)
            {
                return NotFound();
            }

            return View(doctors);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doctors == null)
            {
                return Problem("Entity set 'AppDataContext.Doctors'  is null.");
            }
            var doctors = await _context.Doctors.FindAsync(id);
            if (doctors != null)
            {
                _context.Doctors.Remove(doctors);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorsExists(int id)
        {
          return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
