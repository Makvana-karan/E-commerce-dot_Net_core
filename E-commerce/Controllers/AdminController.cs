using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class AdminController : Controller
        
    {
        private myContext _context;
        public AdminController(myContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           string admin_session = HttpContext.Session.GetString("admin_session");
            if(admin_session != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var row = _context.tbl_admin.FirstOrDefault(a => a.admin_email == email);
            if (row != null && row.admin_password == password) {
                HttpContext.Session.SetString("admin_session", row.admin_id.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Incorrect...";
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("admin_session");
            return RedirectToAction("Login");
        }

        public IActionResult Profile()
        {
            string admin_session = HttpContext.Session.GetString("admin_session");
            if (admin_session != null)
            { 
                var adminId = HttpContext.Session.GetString("admin_session");
          var ids = _context.tbl_admin.Where(a => a.admin_id == int.Parse(adminId)).ToList();
            return View(ids);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public IActionResult Profile(Admin admin)
        {
            _context.tbl_admin.Update(admin);
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }
    }
}
