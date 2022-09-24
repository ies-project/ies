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
    /// Controller para os Cenarios
    /// </summary>
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    [Authorize(Policy = "LoggedIn")]
    public class ScenariosController : Controller
    {
        private readonly ICTDbContext _context;

        public ScenariosController(ICTDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Lista todos os cenarios presentes na base de dados
        /// </summary>
        /// <returns></returns>
        // GET: Scenarios
        public async Task<IActionResult> Index()
        {
              return _context.Scenarios != null ? 
                          View(await _context.Scenarios.ToListAsync()) :
                          Problem("Entity set 'ICTDbContext.Scenarios'  is null.");
        }
        /// <summary>
        /// Retorna a View com os detalhes de um cenario dado o id do cenario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Scenarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Scenarios == null)
            {
                return NotFound();
            }
            //procura na base de dados pelo cenario e retorna a view com os detalhe de um cenario
            var scenario = await _context.Scenarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scenario == null)
            {
                return NotFound();
            }

            return View(scenario);
        }
        /// <summary>
        /// Retorna a view para criar um novo Scenario
        /// </summary>
        /// <returns></returns>
        // GET: Scenarios/Create
        [Authorize(Policy = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Adiciona a base de dados um novo cenario
        /// </summary>
        /// <param name="scenario"></param>
        /// <returns></returns>
        // POST: Scenarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Scenario scenario)
        {
            if (ModelState.IsValid)
            {
                //adiciona e guarda um cenario na base de dados
                _context.Add(scenario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scenario);
        }
        /// <summary>
        /// Retorna a view para editar um cenario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Scenarios/Edit/5
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Scenarios == null)
            {
                return NotFound();
            }
            //procura na base de dados pelo scenario e retorna a view com esses dados
            var scenario = await _context.Scenarios.FindAsync(id);
            if (scenario == null)
            {
                return NotFound();
            }
            return View(scenario);
        }
        /// <summary>
        /// Atualiza um Cenario na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="scenario"></param>
        /// <returns></returns>
        // POST: Scenarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admin")]
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
                    //atualiza o scenario na base de dados 
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
        /// <summary>
        /// Retorna a view para o utilizador confirmar a eliminação de um cenario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Scenarios/Delete/5
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Scenarios == null)
            {
                return NotFound();
            }
            //procura na base de dados e retorna a view com os dados do cenario a eliminar
            var scenario = await _context.Scenarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scenario == null)
            {
                return NotFound();
            }

            return View(scenario);
        }
        /// <summary>
        /// Elimina da base de dados um scenario dado o seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Scenarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Scenarios == null)
            {
                return Problem("Entity set 'ICTDbContext.Scenarios'  is null.");
            }
            //procura na base de dados e elimina o scenario
            var scenario = await _context.Scenarios.FindAsync(id);
            if (scenario != null)
            {
                _context.Scenarios.Remove(scenario);
            }
            //procura e eliminar da base de dados todos os scenarioDevice que tenham como id de cenario o id do cenario a eliminar
            var scenarioDevices = _context.ScenarioDevices.Where(m => m.Id_Scenario == id);

            if (scenarioDevices != null)
            {
                _context.ScenarioDevices.RemoveRange(scenarioDevices);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Verifica se um scenario existe dado o seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ScenarioExists(int id)
        {
          return (_context.Scenarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
