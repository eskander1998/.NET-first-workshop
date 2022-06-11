using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GP.Data;
using GP.Domain.Entities;
//
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using GP.Service;
using System.Globalization;

namespace GP.Web.Controllers
{
    public class FactureController : Controller
    {
        // GET: FactureController
        private readonly IFactureService fctsrv;
        private readonly IClientService cltsrv;
        private readonly IProductService prdsrv;
        public FactureController(IFactureService _fctsrv, IClientService _cltsrv, IProductService _prdsrv)
        {
            fctsrv = _fctsrv;
            cltsrv = _cltsrv;
            prdsrv = _prdsrv;
        }
        public ActionResult Index()
        {
            return View(fctsrv.GetMany());
        }

        // GET: FactureController/Details/5
        public ActionResult Details(int? Productid, int? ClientId, DateTime Dateachat)
        {
            if (Productid == null)
            {
                return NotFound();
            }

            var facture = fctsrv.GetMany()
                .FirstOrDefault(m => m.ProductFk == Productid && m.ClientFk== ClientId && m.DateAchat == Dateachat);
            if (facture == null)
            {
                return NotFound();
            }

            return View(facture);
        }

        // GET: FactureController/Create
        public ActionResult Create()
        {
            ViewBag.ProductFk = new SelectList(prdsrv.GetMany(), "ProductId", "Name");
            ViewBag.ClientFk = new SelectList(cltsrv.GetMany(), "Cin", "Prenom");
            return View();
        }

        // POST: FactureController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Facture facture)
        {
            try
            {
                fctsrv.Add(facture);
                fctsrv.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FactureController/Edit/5
        public ActionResult Edit(int? Productid, int? ClientId, DateTime Dateachat)
        {
            if ((Productid == null)|| (ClientId==null))
            {
                return NotFound();
            }

            var facture = fctsrv.GetMany()
                .FirstOrDefault(m => m.ProductFk == Productid && m.ClientFk == ClientId && m.DateAchat == Dateachat); 
            if (facture == null)
            {
                return NotFound();
            }
            //ViewBag.ProductFk = prdsrv.GetMany().Where(a => a.ProductId == Productid).FirstOrDefault().Name;
            //ViewBag.ClientFk = cltsrv.GetMany().Where(a => a.Cin == ClientId).FirstOrDefault().Prenom; 

            return View(facture);
        }

        // POST: FactureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Facture facture)
        {

            try
            {
                Facture fct = fctsrv.GetMany().Where(f => f.ProductFk == facture.ProductFk && f.ClientFk == facture.ClientFk && f.DateAchat== facture.DateAchat)
                .FirstOrDefault();

                fct.Prix = facture.Prix;

                fctsrv.Update(fct);
                fctsrv.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View(facture);
            }
        }

        // GET: FactureController/Delete/5
        public ActionResult Delete(int? Productid, int? ClientId, DateTime Dateachat)
        {
            if ((Productid == null) || (ClientId == null))
            {
                return NotFound();
            }
            Facture facture = fctsrv.GetMany()
                .FirstOrDefault(m => m.ProductFk == Productid && m.ClientFk == ClientId && m.DateAchat == Dateachat); 
            if (facture == null)
            {
                return NotFound();
            }
            return View(facture);
        }

        // POST: FactureController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Productid, int ClientId, DateTime Dateachat)
        {
            try
            {
                Facture facture = fctsrv.GetMany()
                .FirstOrDefault(m => m.ProductFk == Productid && m.ClientFk == ClientId && m.DateAchat == Dateachat);
               
                fctsrv.Delete(facture);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
