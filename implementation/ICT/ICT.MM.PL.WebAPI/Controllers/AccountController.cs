using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ICT.MM.DAL.DB.Models;
using ICT.MM.DAL.DB;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;

namespace ICT.MM.PL.WebAPI.Controllers {
    /// <summary>
    /// Controlador para as contas de utilizador presente na aplicação
    /// </summary>
    public class AccountController : Controller {
        //variavel de acesso a base de dados
        ICTDbContext db = new ICTDbContext();

        /// <summary>
        /// Retorna View para Registo de utilizadores
        /// </summary>
        /// <returns></returns>
        //GET:/Account/Registation
        public ActionResult Registration()
        {
            return View();
        }
        /// <summary>
        /// Regista na base de dados o Utilizador
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        //POST
        [HttpPost]
        public ActionResult Registration(Account acc)
        {
            //Coloca a role do utilizador que se vai registrar a "User"
            acc.Role = "User";

            //Verifica se o username introduzido não existe na base de dados e guarda mensagens de erro se for o caso
            var VerifyUsername = db.Accounts.Where(a=> a.Username==acc.Username);
            if(VerifyUsername != null)
            {
                ViewData["ErrorUser"] = "O nome de utilizador introduzido já existe";
            }
            else
            {
                ViewData["ErrorUser"] = "";
            }

            //Verifica se a palavra passe introduzida é complexa o suficiente
            if (StrongPassword(acc.Password)){
                //transforma a palavra passe em hash e guarda na base de dados
                acc.Password = HashPassword(acc.Password);
                db.Accounts.Add(acc);
                db.SaveChanges();
                ViewData["ErrorPass"] = "";
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewData["ErrorPass"] = "A palavra passe tem de ter pelo menos uma letra maiuscula, uma letra minuscula e um número";
            }
            return View();

        }

        /// <summary>
        /// Retorna a View de login
        /// </summary>
        /// <returns></returns>
        //GET
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Retorna a View de acesso negado
        /// </summary>
        /// <returns></returns>
        public ActionResult Forbidden()
        {
            return View();
        }
        /// <summary>
        /// Verifica com recurso a base de dados, se os dados de login introduzidos são validos
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(Account acc)
        {
            //verifica se o utilizador existe na base de dados e se o hash da palavra passe corresponde
            var lg = db.Accounts.Where(x => x.Username == acc.Username && x.Password == HashPassword(acc.Password)).FirstOrDefault();
            if (lg == null)
            {
                return RedirectToAction("Login", "Account");
            }

            //claims utilizados para autorização do utilizador que realiza login
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, lg.Username),
                new Claim("Role", lg.Role),
            };

            //associa os claims ao utilizador
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = false,

                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                IsPersistent = false,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.

            };
            //faz o login para a aplicação e cria a cookie utilizada para verifica se um utilizador esta logado e para verificar se tem acesso a determinado conteudo
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// realiza o logout
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            // Apaga as cookies de Autenticação
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        /// <summary>
        /// retorna a view para alteração da palavra passe
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [Authorize(Policy = "LoggedIn")]
        public async Task<IActionResult> ChangePassword(string username)
        {
            //verifica se o utilizador é null, e se nao existe a tabela accounts na base de dados
            if (username == null || db.Accounts == null)
            {
                return NotFound();
            }
            //verifica se o nome de utilizador introduzido existe na base de dados
            var acc = await db.Accounts.Where(a => a.Username==username).FirstOrDefaultAsync();
            if (acc == null)
            {
                return NotFound();
            }

            return View(acc);
        }
        /// <summary>
        /// Faz as verificações e faz a mudança da palavra passe da conta logada
        /// </summary>
        /// <param name="CurPass"></param>
        /// <param name="NewPass1"></param>
        /// <param name="NewPass2"></param>
        /// <param name="acc"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = "LoggedIn")]
        public async Task<IActionResult> ChangePassword(string CurPass,string NewPass1,string NewPass2,[Bind("Id,Username,Password,Name,Role")] Account acc)
        {   
            //procura na base de dados o uitlizador
            var verifyAcc = db.Accounts.Where(a=> a.Id == acc.Id);
            //verifica se o utilizador introduziu a palavra passe correta
            if (!(verifyAcc.Any(a => a.Username == acc.Username && a.Password == acc.Password) && HashPassword(CurPass) == acc.Password))
            {
                //faz logout
                await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Account", "Login");
            }
            //verifica se ambos os campos da nova palavra passe correspondem
            if(NewPass1 != NewPass2)
            {
                ViewData["ErrorPassDiff"] = "As palavras passe não são iguais.";
                return RedirectToAction("Account", "ChangePassword");
            }

            //verifica se o a nova palavra passe cumpre os requesitos
            if (StrongPassword(NewPass1))
            {
                //faz o hash da palvra passe e guarda na base de dados
                acc.Password = HashPassword(NewPass1);
                db.Update(acc);
                await db.SaveChangesAsync();

                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewData["ErrorPassNotStrong"] = "A palavra passe tem de conter pelo menos uma letra maiúscula, uma letra minúscula, um número e um caracter especial";
                return View(acc);
            }

           
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

        /// <summary>
        /// verifica se uma string tem pelo menos 8 caracteres, um digito, um letra maiuscula e uma letra minuscula
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public Boolean StrongPassword(string password)
        {
            if(password == null)
                return false;
            if (password.Length < 8)
                return false;
            if (!password.Any(c => char.IsDigit(c)))
                return false;
            if (!password.Any(c => char.IsUpper(c)))
                return false;
            if(!password.Any(c => char.IsLower(c)))
                return false;

            return true;
        }
    }
}
