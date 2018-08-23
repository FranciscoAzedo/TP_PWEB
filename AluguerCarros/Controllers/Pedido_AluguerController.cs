using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AluguerCarros.Models.AlugarCarros;
using AluguerCarros.Models.DataContext;
using Microsoft.AspNet.Identity;

namespace AluguerCarros.Controllers
{
    public class Pedido_AluguerController : Controller
    {
        private AluguerCarrosContext db = new AluguerCarrosContext();

        // GET: Pedido_Aluguer
        public ActionResult Index()
        {
            return View(db.Pedidos.ToList());
        }

        // GET: Pedido_Aluguer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido_Aluguer pedido_Aluguer = db.Pedidos.Find(id);
            if (pedido_Aluguer == null)
            {
                return HttpNotFound();
            }
            return View(pedido_Aluguer);
        }

        // GET: Pedido_Aluguer/Create
        public ActionResult Create(int? CarroID)
        {
            if (CarroID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = new Pedido_Aluguer();
            model.Veiculo = db.Carros.Find(CarroID);
            model.CarroID = model.Veiculo.CarroID;
            return View(model);
        }

        // POST: Pedido_Aluguer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PedidoID,ClienteID,dataInicio,dataFim,CarroID")] Pedido_Aluguer pedido_Aluguer)
        {
            if (ModelState.IsValid)
            {
                pedido_Aluguer.ClienteID = User.Identity.GetUserId();
                db.Pedidos.Add(pedido_Aluguer);
                db.SaveChanges();
                return RedirectToAction("Index", "Carroes");
            }

            return View(pedido_Aluguer);
        }

        // GET: Pedido_Aluguer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido_Aluguer pedido_Aluguer = db.Pedidos.Find(id);
            if (pedido_Aluguer == null)
            {
                return HttpNotFound();
            }
            return View(pedido_Aluguer);
        }

        // POST: Pedido_Aluguer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PedidoID,ClienteID,dataInicio,dataFim")] Pedido_Aluguer pedido_Aluguer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido_Aluguer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedido_Aluguer);
        }

        // GET: Pedido_Aluguer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido_Aluguer pedido_Aluguer = db.Pedidos.Find(id);
            if (pedido_Aluguer == null)
            {
                return HttpNotFound();
            }
            return View(pedido_Aluguer);
        }

        // POST: Pedido_Aluguer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido_Aluguer pedido_Aluguer = db.Pedidos.Find(id);
            db.Pedidos.Remove(pedido_Aluguer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
