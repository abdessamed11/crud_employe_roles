using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestion_des_étudiants.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace gestion_des_étudiants.Controllers
{

    public class EtudiantController : Controller
    {
        private readonly EtudiantDbContext _emp;
        public EtudiantController(EtudiantDbContext emp)
        {
            _emp = emp;
        }

        #region GET: EtudiantController

        public ActionResult Index()
        {
            var diplaydata = _emp.Etudiantt.ToList();
            return View(diplaydata);
        }
        #endregion

        #region GET: EtudiantController Search
        [HttpGet]
        public async Task<IActionResult> Index(string etsearch)
        {
            ViewData["getetudiant"] = etsearch;
            var etudquery = from x in _emp.Etudiantt select x;
            if (!string.IsNullOrEmpty(etsearch))
            {
                etudquery = etudquery.Where(x => x.Nom.Contains(etsearch) || x.Prenom.Contains(etsearch) || x.Adresse.Contains(etsearch));
            }
            return View(await etudquery.AsNoTracking().ToListAsync());
        }


        #endregion

        #region GET: EtudiantController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getdetails = await _emp.Etudiantt.FindAsync(id);
            return View(getdetails);
        }
        #endregion

        [Authorize(Roles ="admin")]

        #region GET: EtudiantController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EtudiantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Etudiant net)
        {
            if (ModelState.IsValid)
            {
                _emp.Add(net);
                await _emp.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(net);
        }
        #endregion

        #region GET: EtudiantController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getdetails = await _emp.Etudiantt.FindAsync(id);
            return View(getdetails);
        }

        // POST: EtudiantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Etudiant nep)
        {
            if (ModelState.IsValid)
            {
                _emp.Update(nep);
                await _emp.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nep);
        }
        #endregion

        #region GET: EtudiantController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getdetails = await _emp.Etudiantt.FindAsync(id);
            return View(getdetails);
        }

        // POST: EtudiantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var getdetails = await _emp.Etudiantt.FindAsync(id);
            _emp.Etudiantt.Remove(getdetails);
            await _emp.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
