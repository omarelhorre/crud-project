using Microsoft.AspNetCore.Mvc;
using stagiaireCRUD.Data;
using stagiaireCRUD.Models;

namespace stagiaireCRUD.Controllers
{
    public class EtudiantController : Controller
    {
        private readonly AppDbContext _context;
        public EtudiantController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var etudiants = _context.Etudiants.ToList();
            
            return View(etudiants);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Etudiant etudiant)
        {
            _context.Etudiants.Add(etudiant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var etudiant = _context.Etudiants.Find(id);
            return View(etudiant);
        }
        [HttpPost]
        public IActionResult Edit(Etudiant etudiant)
        {
            _context.Etudiants.Update(etudiant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var etudiant = _context.Etudiants.Find(id);
            return View(etudiant);
        }
        [HttpPost, ActionName("Delete")] //redefinition with the same name
        public IActionResult DeleteConfirmed(int id)
        {
            var etudiant = _context.Etudiants.Find(id);
            _context.Etudiants.Remove(etudiant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}