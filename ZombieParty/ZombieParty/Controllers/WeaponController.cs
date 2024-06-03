using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;


namespace ZombieParty.Controllers
{
    public class WeaponController : Controller
    {
        private BaseDonnees _baseDonnees { get; set; }

        public WeaponController(BaseDonnees baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }
        public IActionResult Index()
        {
            this.ViewBag.MaListe = _baseDonnees.Weapons.ToList();
            return View(this.ViewBag.MaListe);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Weapon weapon)
        {
            _baseDonnees.Weapons.Add(weapon);
            TempData["Success"] = $"Zombie {weapon.Name} added";
            return this.RedirectToAction("Index");
        }
    }
}
