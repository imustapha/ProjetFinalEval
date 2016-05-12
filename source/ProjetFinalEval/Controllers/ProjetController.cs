﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            projet pr = bd.projet.Find(id);
            if (pr == null)
                return HttpNotFound();


            return View(pr);
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
        public ActionResult Create([Bind(Exclude = "collaborateurtitulaire,collaborateurpe")]projet Projet, FormCollection fc)
        {
           var testid = fc["collaborateurpe"];
           string[] testids = testid.Split(',');
           foreach (var item in testids)
           {
               int b = int.Parse(item);
               Projet.collaborateurpe.Add(bd.collaborateurpe.Where(m => m.IDCOLLABORATEURPE == b).FirstOrDefault());
           }
           var testid1 = fc["collaborateurtitulaire"];
            string[] tt=testid1.Split(',');
            foreach(var item in tt){
                int b = int.Parse(item);
                Projet.collaborateurtitulaire.Add(bd.collaborateurtitulaire.Where(m => m.IDCOLLABORATEURTITULAIRE == b).FirstOrDefault());

            }
          
              
           
           
           
           ViewBag.collaborateurtitulaire = new MultiSelectList(bd.collaborateurtitulaire, "IDCOLLABORATEURTITULAIRE", "NOM");
            ViewBag.collaborateurpe = new MultiSelectList(bd.collaborateurpe, "IDCOLLABORATEURPE", "NOMPE");
            ViewBag.client = new SelectList(bd.client, "IDCLIENT", "ABREVIATION");
            Projet.client = bd.client.Single(m => m.IDCLIENT == Projet.IDCLIENT);
            try
            {
                // TODO: Add insert logic here
                
                if (ModelState.IsValid) {
                   
                    var y = bd.projet.Add(Projet);
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
        public ActionResult Edit(int? id)
        {

            ViewBag.collaborateurtitulaire = new SelectList(bd.collaborateurtitulaire, "IDCOLLABORATEURTITULAIRE", "NOM",bd.projet.Find(id).collaborateurtitulaire);
            ViewBag.collaborateurpe = new SelectList(bd.collaborateurpe, "IDCOLLABORATEURPE", "NOMPE",bd.projet.Find(id).collaborateurpe);
            ViewBag.IDCLIENT = new SelectList(bd.client, "IDCLIENT", "ABREVIATION",bd.projet.Find(id).client.IDCLIENT);
           

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            projet col = bd.projet.Find(id);
            
            if (col == null)
                return HttpNotFound();
            return View(col);
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
