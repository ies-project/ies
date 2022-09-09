﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICT.MM.DAL.DB;

namespace ICT.MM.PL.WebAPI.Controllers
{
    public class ScenariosController : Controller
    {
        private readonly ICTDbContext _context;

        public ScenariosController(ICTDbContext context)
        {
            _context = context;
        }

        // GET: Scenarios
        public async Task<IActionResult> Index()
        {
              return _context.Scenarios != null ? 
                          View(await _context.Scenarios.ToListAsync()) :
                          Problem("Entity set 'ICTDbContext.Scenarios'  is null.");
        }

        // GET: Scenarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Scenarios == null)
            {
                return NotFound();
            }

            var scenario = await _context.Scenarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scenario == null)
            {
                return NotFound();
            }

            return View(scenario);
        }

        // GET: Scenarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Scenarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Scenario scenario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scenario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scenario);
        }

        // GET: Scenarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Scenarios == null)
            {
                return NotFound();
            }

            var scenario = await _context.Scenarios.FindAsync(id);
            if (scenario == null)
            {
                return NotFound();
            }
            return View(scenario);
        }

        // POST: Scenarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Scenario scenario)
        {
            if (id != scenario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scenario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScenarioExists(scenario.Id))
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
            return View(scenario);
        }

        // GET: Scenarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Scenarios == null)
            {
                return NotFound();
            }

            var scenario = await _context.Scenarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scenario == null)
            {
                return NotFound();
            }

            return View(scenario);
        }

        // POST: Scenarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Scenarios == null)
            {
                return Problem("Entity set 'ICTDbContext.Scenarios'  is null.");
            }
            var scenario = await _context.Scenarios.FindAsync(id);
            if (scenario != null)
            {
                _context.Scenarios.Remove(scenario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScenarioExists(int id)
        {
          return (_context.Scenarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
