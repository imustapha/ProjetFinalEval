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
        public ActionResult Create(projet Projet,FormCollection  fc)
        {
           var testid = fc["collaborateurpe"];
           
           List<int> x=new List<int>();
           string val0 = "";
           for (int i = 0; i < testid.Length;i++ )
           {
               while ((i < testid.Length)&&(testid[i] != ','))
               {
                 
                   val0 = val0 + testid[i];
                   i++;
                 
                  
               }
               int val = Int32.Parse(val0);
               x.Add(val);
               val0 = "";
              
           //    if (testid[i].Equals(',')){
               
           //    val0 = "";
           //    }
           //else
           //{ 
           //    val0=val0+testid[i];
              
           //}
           
              
           } 
            for(int i=0;i<x.Count();i++){
               int b = x[i];
               Projet.collaborateurpe.Add(bd.collaborateurpe.Where(m => m.IDCOLLABORATEURPE == b).FirstOrDefault());

               //Projet.collaborateurpe.Add(bd.collaborateurpe.Single(m => m.IDCOLLABORATEURPE == b));
               
                   }
           var testid1 = fc["collaborateurtitulaire"];

           List<int> x1 = new List<int>();
           string val01 = "";
           for (int i = 0; i < testid1.Count(); i++)
           {
               while ((i < testid1.Length) && (testid1[i] != ','))
               {

                   val01 = val01 + testid1[i];
                   i++;


               }
               int val1 = Int32.Parse(val01);
               x1.Add(val1);
               val01 = "";

           } for (int i = 0; i < x1.Count(); i++)
              
           {int b=x1[i];
           Projet.collaborateurtitulaire.Add(bd.collaborateurtitulaire.Where(m => m.IDCOLLABORATEURTITULAIRE == b).FirstOrDefault());
               //Projet.collaborateurtitulaire.Add(bd.collaborateurtitulaire.Single(m => m.IDCOLLABORATEURTITULAIRE == b));
           }
           ViewBag.collaborateurtitulaire = new MultiSelectList(bd.collaborateurtitulaire, "IDCOLLABORATEURTITULAIRE", "NOM" + " " + "PRENOM");
            ViewBag.collaborateurpe = new MultiSelectList(bd.collaborateurpe, "IDCOLLABORATEURPE", "NOMPE");
            ViewBag.client = new SelectList(bd.client, "IDCLIENT", "ABREVIATION");
            Projet.client = bd.client.Single(m => m.IDCLIENT == Projet.IDCLIENT);
            try
            {
                // TODO: Add insert logic here
                
                if (ModelState.IsValid) {
                    var pro = new projet { IDPROJET=Projet.IDPROJET, NOMPROJET=Projet.NOMPROJET, DATEDEBUT=Projet.DATEDEBUT,
                    DATEFIN=Projet.DATEFIN, TYPE=Projet.TYPE, FLAGTYPE=Projet.FLAGTYPE, IDCLIENT=Projet.IDCLIENT,
                    collaborateurtitulaire=Projet.collaborateurtitulaire, collaborateurpe=Projet.collaborateurpe,client=Projet.client};

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
