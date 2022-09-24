using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security;
using ICT.MM.DAL.DB;
using System.Web.Http;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using ActionNameAttribute = Microsoft.AspNetCore.Mvc.ActionNameAttribute;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authorization;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;

namespace ICT.MM.PL.WebAPI.Controllers
{
    /// <summary>
    /// Controller para os devices
    /// </summary>
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    [Authorize(Policy = "LoggedIn")]
    public class DevicesController : Controller
    {
        //variavel de acesso a base de dados
        private readonly ICTDbContext _context;

        public DevicesController(ICTDbContext context)
        {
            _context = context;
        }

        // GET: Devices
        /// <summary>
        /// Lista os dispositivos presentes na base de dados
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var iCTDbContext = _context.Devices.Include(d => d.DeviceType);

            return View(await iCTDbContext.ToListAsync());
        }
        /// <summary>
        /// Retorna a view com os detalhes de um dispositivo, dando o id do device 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Devices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Devices == null)
            {
                return NotFound();
            }
            //procura na base de dados pelo dispositivo
            var device = await _context.Devices
                .Include(d => d.DeviceType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        /// <summary>
        /// Retorna a view para criar um novo dispositivo
        /// </summary>
        /// <returns></returns>
        // GET: Devices/Create
        [Authorize(Policy = "Admin")]
        public IActionResult Create()
        {
            //envia para a view a lista de todos os tipos de dispositivos para o utilizador poder selecionar o tipo de dispositivo correto de entre os que existem na base de dados
            ViewData["Id_DeviceType"] = new SelectList(_context.DeviceTypes, "Id", "Name");
            return View();
        }
        /// <summary>
        /// Cria na base de dados um novo dispositivo dispositivo 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Id_DeviceType,Name,Description,ManufacturedDate,LastMaintenanceDate,MaintenanceDueDate,ManufacturedBy,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Device device)
        {
            if (ModelState.IsValid)
            {
                //alguma atribuições basicas
                device.LastMaintenanceDate = null;
                device.ModifiedDate = null;
                device.ModifiedBy = null;
                device.CreatedDate = DateTime.Now;
                device.CreatedBy = User.Identity.Name;
                //guardar na base de dados
                _context.Add(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_DeviceType"] = new SelectList(_context.DeviceTypes, "Id", "Name", device.Id_DeviceType);
            return View(device);
        }
        /// <summary>
        /// retorna a view para editar um dispositivo dando o seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Devices/Edit/5
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Devices == null)
            {
                return NotFound();
            }
            //procura na base de dados o dispositivo
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            ViewData["Id_DeviceType"] = new SelectList(_context.DeviceTypes, "Id", "Name", device.Id_DeviceType);
            return View(device);
        }
        /// <summary>
        /// Guarda na base de dados as alterações realizadas ao dispositivo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="device"></param>
        /// <returns></returns>
        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_DeviceType,Name,Description,ManufacturedDate,LastMaintenanceDate,MaintenanceDueDate,ManufacturedBy,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Device device)
        {
            //faz se algumas verificações para editar o dispositivo
            if (id != device.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                
                try
                {
                    //Algumas atribuições simples
                    device.ModifiedDate = DateTime.Now;
                    device.ModifiedBy = User.Identity.Name;
                    //guardas as alterações na base de dados
                    _context.Update(device);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceExists(device.Id))
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
            ViewData["Id_DeviceType"] = new SelectList(_context.DeviceTypes, "Id", "Name", device.Id_DeviceType);
            return View(device);
        }
        /// <summary>
        /// Retorna a view para se confirmar a eliminiação de um dispositivo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Devices/Delete/5
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Devices == null)
            {
                return NotFound();
            }
            //procura na base de dados o dispositivo
            var device = await _context.Devices
                .Include(d => d.DeviceType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }
        /// <summary>
        /// Elimina um dispositivo da base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Devices == null)
            {
                return Problem("Entity set 'ICTDbContext.Devices'  is null.");
            }
            //procura na base de dados o dipositivo e se exitir elimina-o da base de dados
            var device = await _context.Devices.FindAsync(id);
            if (device != null)
            {
                _context.Devices.Remove(device);
            }
            //procura na base de dados por ScenarioDevice que possuam como id_Device o id desse device e elimina os a todos 
            var scenarioDevices = _context.ScenarioDevices.Where(m => m.Id_Device == id);

            if (scenarioDevices != null)
            {
                _context.ScenarioDevices.RemoveRange(scenarioDevices);
            }
            //guarda as alterações da base de dados
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Verifica se um dispositivo existe dado o seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DeviceExists(int id)
        {
          return (_context.Devices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
