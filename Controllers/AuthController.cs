using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using stagiaireCRUD.Data;
using stagiaireCRUD.Models;
namespace stagiaireCRUD.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
        return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var etudiant = _context.Etudiants.FirstOrDefault(est => est.Email == email);
            if(etudiant == null)
            {
                ViewBag.Error = "Email introuvable";
                return View();
            }
            if (etudiant.password != password)
            {
                ViewBag.Error = "Mot de passe incorrect";
                return View();
            }
            HttpContext.Session.SetInt32("EtudiantId",etudiant.Id);
            HttpContext.Session.SetString("Nom",etudiant.Nom);  
            return RedirectToAction("Index","Etudiant");
        }
    }
}