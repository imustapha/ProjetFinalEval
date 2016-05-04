using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetFinalEval.Controllers
{
    public class ProjetController : Controller
    {
        private bd_evaluationEntities3 bd = new bd_evaluationEntities3();
        // GET: Projet
        public ActionResult Index()
        {
            return View(bd.projet.ToList());
        }

        // GET: Projet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Projet/Create
        public ActionResult Create()
        {
            ViewBag.collaborateurtitulaire = new SelectList(bd.collaborateurtitulaire, "IDCOLLABORATEURTITULAIRE", "NOM");
            ViewBag.collaborateurpe = new SelectList(bd.collaborateurpe, "IDCOLLABORATEURPE", "NOMPE");
            ViewBag.client = new SelectList(bd.client, "IDCLIENT", "ABREVIATION");

            return View();
        }

        // POST: Projet/Create
        [HttpPost]
        public ActionResult Create(projet Projet)
        {
            ViewBag.collaborateurtitulaire = new SelectList(bd.collaborateurtitulaire, "IDCOLLABORATEURTITULAIRE", "NOM");
            ViewBag.collaborateurpe = new SelectList(bd.collaborateurpe, "IDCOLLABORATEURPE", "NOMPE");
            ViewBag.client = new SelectList(bd.client, "IDCLIENT", "ABREVIATION");
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid) {
                    var pro = new projet { IDPROJET=Projet.IDPROJET, NOMPROJET=Projet.NOMPROJET, DATEDEBUT=Projet.DATEDEBUT,
                    DATEFIN=Projet.DATEFIN, TYPE=Projet.TYPE, FLAGTYPE=Projet.FLAGTYPE, IDCLIENT=Projet.IDCLIENT,
                    collaborateurtitulaire=Projet.collaborateurtitulaire, collaborateurpe=Projet.collaborateurpe};
                    var x = bd.projet.Add(Projet);
                    bd.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Projet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Projet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Projet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Projet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
