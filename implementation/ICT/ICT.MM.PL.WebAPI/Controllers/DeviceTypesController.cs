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
    /// Controller para os tipos de dispositivos
    /// </summary>
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    [Authorize(Policy = "LoggedIn")]
    public class DeviceTypesController : Controller
    {
        private readonly ICTDbContext _context;

        public DeviceTypesController(ICTDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Lista os dispositivos presentes na base de dados
        /// </summary>
        /// <returns></returns>
        // GET: DeviceTypes
        public async Task<IActionResult> Index()
        {
              return _context.DeviceTypes != null ? 
                          View(await _context.DeviceTypes.ToListAsync()) :
                          Problem("Entity set 'ICTDbContext.DeviceTypes'  is null.");
        }

        /// <summary>
        /// Mostra os detalhes de um tipo de dispositivo dado o seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: DeviceTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DeviceTypes == null)
            {
                return NotFound();
            }
            //procura na base de dados e retorna a view com a informação do tipo de dispositivo
            var deviceType = await _context.DeviceTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deviceType == null)
            {
                return NotFound();
            }

            return View(deviceType);
        }
        /// <summary>
        /// Retorna a view para criar um novo tipo de dispositivo
        /// </summary>
        /// <returns></returns>
        // GET: DeviceTypes/Create
        [Authorize(Policy = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Cria um novo tipo de dispositivo na base de dados
        /// </summary>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        // POST: DeviceTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] DeviceType deviceType)
        {
            if (ModelState.IsValid)
            {
                //adiciona o novo tipo de dispositivo á base de dados
                _context.Add(deviceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deviceType);
        }
        /// <summary>
        /// Retorna a view para editar um tipo de dispositivo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: DeviceTypes/Edit/5
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DeviceTypes == null)
            {
                return NotFound();
            }
            //procura na base de dados pelo tipo de dispositivo
            var deviceType = await _context.DeviceTypes.FindAsync(id);
            if (deviceType == null)
            {
                return NotFound();
            }
            return View(deviceType);
        }
        /// <summary>
        /// Atualiza um tipo de dispositivo na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        // POST: DeviceTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] DeviceType deviceType)
        {
            if (id != deviceType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Atualiza o tipo de dispositivo na base de dados
                    _context.Update(deviceType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceTypeExists(deviceType.Id))
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
            return View(deviceType);
        }
        /// <summary>
        /// Retorna a view para o utilizador confirmar a eliminaçao de um tipo de dispositivo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: DeviceTypes/Delete/5
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DeviceTypes == null)
            {
                return NotFound();
            }
            //procura na base de dados pelo tipo de dispositivo e retorna a view com essas informações
            var deviceType = await _context.DeviceTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deviceType == null)
            {
                return NotFound();
            }

            return View(deviceType);
        }
        /// <summary>
        /// Elimina um tipo de dispositivo da base de dados dado o seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: DeviceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DeviceTypes == null)
            {
                return Problem("Entity set 'ICTDbContext.DeviceTypes'  is null.");
            }
            //Procura na base de dados pelo tipo de dispositivo e se exitir elimina-o
            var deviceType = await _context.DeviceTypes.FindAsync(id);

            if (deviceType != null)
            {
                _context.DeviceTypes.Remove(deviceType);
            }

            //Procura e elimina da base de dados todos os dispositivo que sejam do tipo que estamos a apagar 
            var devices = _context.Devices.Where(m => m.Id_DeviceType == id).ToList();
            if (devices != null)
            {
                _context.Devices.RemoveRange(devices);
            }

            //Elimina da tabela ScenariosDevices todas a ocorrencias de dispositivos que tenham de ser eliminados
            foreach(Device device in devices)
            {
                if (_context.ScenarioDevices.Where(x => x.Id_Device == device.Id) != null)
                {
                    _context.ScenarioDevices.RemoveRange(_context.ScenarioDevices.Where(x => x.Id_Device == device.Id));
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Verifica se determinado tipo de dispositivo existe na base de dados dado o seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DeviceTypeExists(int id)
        {
          return (_context.DeviceTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
