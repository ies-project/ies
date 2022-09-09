using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICT.MM.DAL.DB;

namespace ICT.MM.PL.WebAPI.Controllers
{
    public class ScenarioDevicesController : Controller
    {
        private readonly ICTDbContext _context;

        public ScenarioDevicesController(ICTDbContext context)
        {
            _context = context;
        }

        // GET: ScenarioDevices
        public async Task<IActionResult> Index()
        {
            var iCTDbContext = _context.ScenarioDevices.Include(s => s.Device).Include(s => s.Scenario);
            return View(await iCTDbContext.ToListAsync());
        }

        // GET: ScenarioDevices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ScenarioDevices == null)
            {
                return NotFound();
            }

            var scenarioDevice = await _context.ScenarioDevices
                .Include(s => s.Device)
                .Include(s => s.Scenario)
                .FirstOrDefaultAsync(m => m.Id_Scenario == id);
            if (scenarioDevice == null)
            {
                return NotFound();
            }

            return View(scenarioDevice);
        }

        // GET: ScenarioDevices/Create
        public IActionResult Create()
        {
            ViewData["Id_Device"] = new SelectList(_context.Devices, "Id", "Description");
            ViewData["Id_Scenario"] = new SelectList(_context.Scenarios, "Id", "Description");
            return View();
        }

        // POST: ScenarioDevices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Scenario,Id_Device,ManufacturedDate,LastMaintenanceDate,MaintenanceDueDate,OriginalState,CurrentState")] ScenarioDevice scenarioDevice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scenarioDevice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Device"] = new SelectList(_context.Devices, "Id", "Description", scenarioDevice.Id_Device);
            ViewData["Id_Scenario"] = new SelectList(_context.Scenarios, "Id", "Description", scenarioDevice.Id_Scenario);
            return View(scenarioDevice);
        }

        // GET: ScenarioDevices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ScenarioDevices == null)
            {
                return NotFound();
            }

            var scenarioDevice = await _context.ScenarioDevices.FindAsync(id);
            if (scenarioDevice == null)
            {
                return NotFound();
            }
            ViewData["Id_Device"] = new SelectList(_context.Devices, "Id", "Description", scenarioDevice.Id_Device);
            ViewData["Id_Scenario"] = new SelectList(_context.Scenarios, "Id", "Description", scenarioDevice.Id_Scenario);
            return View(scenarioDevice);
        }

        // POST: ScenarioDevices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Scenario,Id_Device,ManufacturedDate,LastMaintenanceDate,MaintenanceDueDate,OriginalState,CurrentState")] ScenarioDevice scenarioDevice)
        {
            if (id != scenarioDevice.Id_Scenario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scenarioDevice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScenarioDeviceExists(scenarioDevice.Id_Scenario))
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
            ViewData["Id_Device"] = new SelectList(_context.Devices, "Id", "Description", scenarioDevice.Id_Device);
            ViewData["Id_Scenario"] = new SelectList(_context.Scenarios, "Id", "Description", scenarioDevice.Id_Scenario);
            return View(scenarioDevice);
        }

        // GET: ScenarioDevices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ScenarioDevices == null)
            {
                return NotFound();
            }

            var scenarioDevice = await _context.ScenarioDevices
                .Include(s => s.Device)
                .Include(s => s.Scenario)
                .FirstOrDefaultAsync(m => m.Id_Scenario == id);
            if (scenarioDevice == null)
            {
                return NotFound();
            }

            return View(scenarioDevice);
        }

        // POST: ScenarioDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ScenarioDevices == null)
            {
                return Problem("Entity set 'ICTDbContext.ScenarioDevices'  is null.");
            }
            var scenarioDevice = await _context.ScenarioDevices.FindAsync(id);
            if (scenarioDevice != null)
            {
                _context.ScenarioDevices.Remove(scenarioDevice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScenarioDeviceExists(int id)
        {
          return (_context.ScenarioDevices?.Any(e => e.Id_Scenario == id)).GetValueOrDefault();
        }
    }
}
