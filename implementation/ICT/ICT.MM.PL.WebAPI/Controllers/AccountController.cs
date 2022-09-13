using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ICT.MM.DAL.DB.Models;
using ICT.MM.DAL.DB;

namespace ICT.MM.PL.WebAPI.Controllers {
    public class AccountController : Controller {

        ICTDbContext db = new ICTDbContext();

        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Account acc)
        {
            db.Accounts.Add(acc);
            db.SaveChanges();
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account acc)
        {
            var lg = db.Accounts.Where(x => x.Username == acc.Username && x.Password == acc.Password).FirstOrDefault();
            if (lg != null)
            {
                return RedirectToAction("Index","Devices");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
