using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICT.MM.DAL.DB;
using Microsoft.AspNetCore.Authorization;

namespace ICT.MM.PL.WebAPI.Controllers
{
    /// <summary>
    /// Controller para os ScenarioDevices
    /// </summary>
    [Authorize(Policy = "LoggedIn")]
    public class ScenarioDevicesController : Controller
    {
        private readonly ICTDbContext _context;

        public ScenarioDevicesController(ICTDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Lista todos os ScenariosDevices presentes na base de dados
        /// </summary>
        /// <returns></returns>
        // GET: ScenarioDevices
        public async Task<IActionResult> Index()
        {
            var iCTDbContext = _context.ScenarioDevices.Include(s => s.Device).Include(s => s.Scenario);
            return View(await iCTDbContext.ToListAsync());
        }

        /// <summary>
        /// Mostra os detalhes de um ScenarioDevice dado o id do cenario e o id do device
        /// </summary>
        /// <param name="idScen"></param>
        /// <param name="idDevi"></param>
        /// <returns></returns>
        // GET: ScenarioDevices/Details/5
        public async Task<IActionResult> Details(int? idScen, int? idDevi)
        {
            if (idScen == null || idDevi == null || _context.ScenarioDevices == null)
            {
                return NotFound();
            }
            //Procura na base de dados pelo ScenarioDevice e retorna a view com os dados
            var scenarioDevice = await _context.ScenarioDevices
                .Include(s => s.Device)
                .Include(s => s.Scenario)
                .FirstOrDefaultAsync(m => m.Id_Scenario == idScen && m.Id_Device == idDevi);
            if (scenarioDevice == null)
            {
                return NotFound();
            }

            return View(scenarioDevice);
        }
        /// <summary>
        /// Retorna a View para criar um novo ScenarioDevice
        /// </summary>
        /// <returns></returns>
        // GET: ScenarioDevices/Create
        [Authorize(Policy = "Admin")]
        public IActionResult Create()
        {
            ViewData["Id_Device"] = new SelectList(_context.Devices, "Id", "Name");
            ViewData["Id_Scenario"] = new SelectList(_context.Scenarios, "Id", "Name");
            return View();
        }

        /// <summary>
        /// Adiciona a base de dados o novo ScenarioDevice
        /// </summary>
        /// <param name="scenarioDevice"></param>
        /// <returns></returns>
        // POST: ScenarioDevices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([Bind("Id_Scenario,Id_Device,ManufacturedDate,LastMaintenanceDate,MaintenanceDueDate,OriginalState,CurrentState")] ScenarioDevice scenarioDevice)
        {
            if (ModelState.IsValid)
            {
                //Adiconar a vase de dados o novo ScenarioDevice
                _context.Add(scenarioDevice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Device"] = new SelectList(_context.Devices, "Id", "Name", scenarioDevice.Id_Device);
            ViewData["Id_Scenario"] = new SelectList(_context.Scenarios, "Id", "Name", scenarioDevice.Id_Scenario);
            return View(scenarioDevice);
        }
        /// <summary>
        /// Retorna a view para realizar o edit de um ScenarioDevice com todas as suas informações
        /// </summary>
        /// <param name="idScen"></param>
        /// <param name="idDevi"></param>
        /// <returns></returns>
        // GET: ScenarioDevices/Edit?idScen=2&idDevi=6
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Edit(int? idScen, int? idDevi)
        {
            if (idScen == null || idDevi == null || _context.ScenarioDevices == null)
            {
                return NotFound();
            }
            //procura na base de dados pelo Scenario device correspondente e retorna a view
            var scenarioDevice = await _context.ScenarioDevices.FindAsync(idScen,idDevi);
            if (scenarioDevice == null)
            {
                return NotFound();
            }
            return View(scenarioDevice);
        }
        /// <summary>
        /// Atualiza um ScenarioDevice na base de dados
        /// </summary>
        /// <param name="scenarioDevice"></param>
        /// <returns></returns>
        // POST: ScenarioDevices/Edit?idScen=2&idDevi=6
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Edit([Bind("Id_Scenario,Id_Device,ManufacturedDate,LastMaintenanceDate,MaintenanceDueDate,OriginalState,CurrentState")] ScenarioDevice scenarioDevice)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Atualiza o ScenarioDevice na base de dados
                    _context.Update(scenarioDevice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScenarioDeviceExists(scenarioDevice.Id_Scenario, scenarioDevice.Id_Device))
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
            return View(scenarioDevice);
        }
        /// <summary>
        /// Retorna a View para confirmação de eliminação do ScenarioDevice dado o id do cenario e o id do device
        /// </summary>
        /// <param name="idScen"></param>
        /// <param name="idDevi"></param>
        /// <returns></returns>
        // GET: ScenarioDevices/Delete/5
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(int? idScen, int? idDevi)
        {

            if (idScen == null || idDevi == null || _context.ScenarioDevices == null)
            {
                return NotFound();
            }
            //procura na base de dados pelo scenarioDevice e retorna a view com a informação deste
            var scenarioDevice = await _context.ScenarioDevices
                .Include(s => s.Device)
                .Include(s => s.Scenario)
                .FirstOrDefaultAsync(m => m.Id_Scenario == idScen && m.Id_Device == idDevi);
            if (scenarioDevice == null)
            {
                return NotFound();
            }

            return View(scenarioDevice);
        }
        /// <summary>
        /// Elimina da base de dados um ScenarioDevice
        /// </summary>
        /// <param name="sc"></param>
        /// <returns></returns>
        // POST: ScenarioDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(ScenarioDevice sc)
        {
            if (_context.ScenarioDevices == null)
            {
                return Problem("Entity set 'ICTDbContext.ScenarioDevices'  is null.");
            }
            //procura e elimina da base de dados o scenarioDevice
            var scenarioDevice = await _context.ScenarioDevices.FindAsync(sc.Id_Scenario, sc.Id_Device);
            if (scenarioDevice != null)
            {
                _context.ScenarioDevices.Remove(scenarioDevice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Verifica se um ScenarioDevice existe
        /// </summary>
        /// <param name="idScen"></param>
        /// <param name="idDevi"></param>
        /// <returns></returns>
        private bool ScenarioDeviceExists(int idScen, int idDevi)
        {
          return (_context.ScenarioDevices?.Any(e => e.Id_Scenario == idScen && e.Id_Device == idDevi)).GetValueOrDefault();
        }
    }
}
