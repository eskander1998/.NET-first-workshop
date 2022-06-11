using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GP.Data;
using GP.Domain.Entities;
using GP.Web.Models;
//
using Microsoft.EntityFrameworkCore;
using GP.Service;


namespace GP.Web.Controllers
{
    public class ClientController : Controller
    {
        // GET: ClientController
        private readonly IClientService clientservice;
        public ClientController(IClientService _clientservice)
        {
            clientservice = _clientservice;
        }
        public ActionResult Index()
        {
            //return View(servclt.GetAll().ToList());
            var listclient = clientservice.GetMany().ToList();

            List<ClientModel> listclientmodel = new List<ClientModel>();

            foreach (var client in listclient)
            {
                var clientmodel = new ClientModel(client);
                clientmodel.PrixFactures = clientservice.GetTotalFacturePrice(client.Cin);
                listclientmodel.Add(clientmodel);
            }

            return View(listclientmodel);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = clientservice.GetMany()
                .FirstOrDefault(m => m.Cin == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            try
            {
                clientservice.Add(client);
                clientservice.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
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

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
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
