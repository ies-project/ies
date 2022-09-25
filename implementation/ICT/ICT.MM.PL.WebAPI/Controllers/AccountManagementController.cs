using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICT.MM.DAL.DB;
using ICT.MM.DAL.DB.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Security.Cryptography;

namespace ICT.MM.PL.WebAPI.Controllers
{
    /// <summary>
    /// controller utilizado para gerir as contas dos utilizadores
    /// </summary>
    [Authorize(Policy = "Root")]
    public class AccountManagementController : Controller
    {   
        //variavel de acesso a base de dados
        private readonly ICTDbContext _context;

        /// <summary>
        /// construtor da classe
        /// </summary>
        /// <param name="context"></param>
        public AccountManagementController(ICTDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Lista os utilizadores 
        /// </summary>
        /// <returns></returns>
        // GET: AccountManagement
        public async Task<IActionResult> Index()
        {
              return _context.Accounts != null ? 
                          View(await _context.Accounts.ToListAsync()) :
                          Problem("Entity set 'ICTDbContext.Accounts'  is null.");
        }
        /// <summary>
        /// Mostra os detalhes de uma conta
        /// </summary>
        /// <param name="id">Da conta de utilizador</param>
        /// <returns></returns>
        // GET: AccountManagement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //verifica se o id e valido e se existe os Accounts na base de dados
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            //procura na base de dados pelo utilizador 
            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);

            //verifica se a conta existe na base de dados
            if (account == null)
            {
                return NotFound();
            }
            //retorna a view com os detalhes da conta
            return View(account);
        }
        /// <summary>
        /// retorna a view para criar um utilizador
        /// </summary>
        /// <returns></returns>
        // GET: AccountManagement/Create
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Adiciona a nova conta de utilizador a base de dados
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        // POST: AccountManagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Username,Password,Role")] Account account)
        {
            
            if (ModelState.IsValid)
            {   
                //faz o hash da password e adiciona a conta de utilizador a base de dados
                account.Password = HashPassword(account.Password);
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }
        /// <summary>
        /// retorna a view de edit dos utilizadores
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: AccountManagement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //verifica se o id e valido e se existe os Accounts na base de dados
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }
            //procura na base de dados a conta especifica
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            //retorna a view com as informações da conta
            return View(account);
        }
        /// <summary>
        /// Guarda na base de dados as alterações as alterações feitas
        /// </summary>
        /// <param name="PassTemp"></param>
        /// <param name="id"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        // POST: AccountManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string PassTemp, int id, [Bind("Id,Name,Username,Password,Role")] Account account)
        {
            //verificações se o id corresponde
            if (id != account.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    //verifica se a palavra passe foi alterada
                    if (PassTemp != "********")
                    {
                        //guarda as alterações feitas nas base de dados com a alteração da palavra passe
                        account.Password = HashPassword(PassTemp);
                        _context.Update(account);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        //guarda as alterações feitas nas base de dados sem a alteração da palavra passe
                        _context.Update(account);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
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
            return View(account);
        }
        /// <summary>
        /// Retorna a view para eliminar uma conta de utilizador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: AccountManagement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //verifica se o id e valido e se existe os Accounts na base de dados
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }
            //procura na base de dados o utilizador e retorna a view para eliminar com as informações para da conta de utilizador
            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }
        /// <summary>
        /// Elimina um utilizador da base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: AccountManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //verifica se existe os Accounts na base de dados
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'ICTDbContext.Accounts'  is null.");
            }
            //procura na base de dados pelo utilizador e se exitir remove a conta da base de dados
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// verifica se uma conta existe, dando o id da mesma
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool AccountExists(int id)
        {
          return (_context.Accounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        /// <summary>
        /// Transforma uma string em hash, código retirado do seguinte video:
        /// https://www.youtube.com/watch?v=2yEiwjUEZ78
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string HashPassword(string password)
        {
            var sha = SHA256.Create();

            var asByteArray = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asByteArray);

            return Convert.ToBase64String(hashedPassword);
        }
    }
}
