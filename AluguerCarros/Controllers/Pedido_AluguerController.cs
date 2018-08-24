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
            IEnumerable<Pedido_Aluguer> pedidos_pendentes = db.Pedidos.Where(p => p.Veiculo.Dono == User.Identity.Name).Where(p=> p.Estado == "Pendente");
            IEnumerable<Pedido_Aluguer> pedidos_ativos = db.Pedidos.Where(p => p.Veiculo.Dono == User.Identity.Name).Where(p => p.Estado == "Aceite" || p.Estado == "Espera de Avaliacao");
            IEnumerable<Pedido_Aluguer> pedidos_resolvidos = db.Pedidos.Where(p => p.Veiculo.Dono == User.Identity.Name).Where(p => p.Estado == "Recusado" || p.Estado == "Concluido" || p.Estado == "Cancelado");
            IEnumerable<Carro> carros = db.Carros.ToList();
            PedidosViewModel pedidos = new PedidosViewModel();
            foreach (var pedido in pedidos_pendentes)
            {
                foreach (var carro in carros)
                {
                    if (carro.CarroID == pedido.CarroID)
                    {
                        pedido.Veiculo = carro;
                        break;
                    }
                }
            }
            foreach (var pedido in pedidos_ativos)
            {
                if (pedido.Estado == "Aceite" && pedido.dataFim < DateTime.Today)
                {
                    pedido.Estado = "Espera de Avaliacao";
                    pedido.aval_Carro = false;
                    pedido.aval_Cli = false;
                    pedido.aval_Dono = false;
                    db.Entry(pedido).State = EntityState.Modified; 
                }
                foreach (var carro in carros)
                {
                    if (carro.CarroID == pedido.CarroID)
                    {
                        pedido.Veiculo = carro;
                        break;
                    }
                }
            }
            foreach (var pedido in pedidos_resolvidos)
            {
                foreach (var carro in carros)
                {
                    if (carro.CarroID == pedido.CarroID)
                    {
                        pedido.Veiculo = carro;
                        break;
                    }
                }
            }
            db.SaveChanges();
            pedidos.pedidos_resolvidos = pedidos_resolvidos;
            pedidos.pedidos_ativos = pedidos_ativos;
            pedidos.pedidos_pendentes = pedidos_pendentes;
            return View(pedidos);
        }

        public ActionResult CancelarPedido(int id)
        {
            Pedido_Aluguer p = new Pedido_Aluguer();
            IEnumerable<Pedido_Aluguer> pedidos = db.Pedidos.ToList();
            foreach (var pedido in pedidos)
            {
                if(pedido.PedidoID == id)
                {
                    p = pedido;
                    break;
                }
            }
            p.Estado = "Cancelado";
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("PedidosEfetuados", "Pedido_Aluguer");
        }        
        
        public ActionResult PedidosEfetuados()
        {
            IEnumerable<Pedido_Aluguer> pedidos_pendentes = db.Pedidos.Where(p => p.Cliente == User.Identity.Name).Where(p => p.Estado == "Pendente");
            IEnumerable<Pedido_Aluguer> pedidos_ativos = db.Pedidos.Where(p => p.Cliente == User.Identity.Name).Where(p=>p.Estado == "Aceite" || p.Estado == "Espera de Avaliacao");
            IEnumerable<Pedido_Aluguer> pedidos_resolvidos = db.Pedidos.Where(p => p.Cliente == User.Identity.Name).Where(p => p.Estado == "Recusado" || p.Estado == "Concluido" || p.Estado == "Cancelado");
            IEnumerable<Carro> carros = db.Carros.ToList();
            PedidosViewModel pedidos = new PedidosViewModel();
            foreach (var pedido in pedidos_pendentes)
            {
                foreach (var carro in carros)
                {
                    if (carro.CarroID == pedido.CarroID)
                    {
                        pedido.Veiculo = carro;
                        break;
                    }
                }
            }
            foreach (var pedido in pedidos_ativos)
            {
                if (pedido.Estado == "Aceite" && pedido.dataFim < DateTime.Today)
                {
                    pedido.Estado = "Espera de Avaliacao";
                    pedido.aval_Carro = false;
                    pedido.aval_Cli = false;
                    pedido.aval_Dono = false;
                    db.Entry(pedido).State = EntityState.Modified;
                }
                foreach (var carro in carros)
                {
                    if (carro.CarroID == pedido.CarroID)
                    {
                        pedido.Veiculo = carro;
                        break;
                    }
                } 
            }
            foreach (var pedido in pedidos_resolvidos)
            {
                foreach (var carro in carros)
                {
                    if (carro.CarroID == pedido.CarroID)
                    {
                        pedido.Veiculo = carro;
                        break;
                    }
                }
            }
            db.SaveChanges();
            pedidos.pedidos_pendentes = pedidos_pendentes;
            pedidos.pedidos_ativos = pedidos_ativos;
            pedidos.pedidos_resolvidos = pedidos_resolvidos;
            return View(pedidos);
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

        public ActionResult TratarPedido(int id, bool Estado)
        {
            IEnumerable<Pedido_Aluguer> pedidos = db.Pedidos.Where(p => p.PedidoID == id);
            Pedido_Aluguer ped = pedidos.ElementAt(0);
            if (Estado == false)
            {
                ped.Estado = "Recusado";
                db.Entry(ped).State = EntityState.Modified;
                db.SaveChanges();                
            }
            else
            {
                pedidos = db.Pedidos.Where(p => p.CarroID == ped.CarroID).Where(p => p.Estado == "Pendente");
                foreach(var p in pedidos)
                {
                    if(p.dataInicio <= ped.dataFim) {
                        p.Estado = "Recusado";
                        db.Entry(p).State = EntityState.Modified;
                    }
                }
                ped.Estado = "Aceite";
                ped.Veiculo.Disponivel = false;
                db.Entry(ped).State = EntityState.Modified;
                db.Entry(ped.Veiculo).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Pedido_Aluguer");
        }

        // GET: Pedido_Aluguer/Create
        public ActionResult Create(int CarroID)
        {
            /*if (CarroID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/
            var model = new Pedido_Aluguer();
            model.CarroID = CarroID;
            return View(model);
        }

        // POST: Pedido_Aluguer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PedidoID,ClienteID,dataInicio,dataFim,CarroID")] Pedido_Aluguer pedido_Aluguer)
        {
            if (pedido_Aluguer.dataInicio != null && pedido_Aluguer.dataInicio < DateTime.Today)
            {
                TempData["DataInicial"] = "Insira uma data atual";
                if (pedido_Aluguer.dataInicio != null && pedido_Aluguer.dataInicio > pedido_Aluguer.dataFim)
                {
                    TempData["DataFinal"] = "Data Fim inferior à Data Inicial";
                }
            }
            else if (pedido_Aluguer.dataInicio != null && pedido_Aluguer.dataInicio > pedido_Aluguer.dataFim)
            {
                TempData["DataFinal"] = "Data Fim inferior à Data Inicial";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    pedido_Aluguer.Veiculo = db.Carros.Find(pedido_Aluguer.CarroID);
                    pedido_Aluguer.Estado = "Pendente"; 
                    pedido_Aluguer.Cliente = User.Identity.Name;
                    db.Pedidos.Add(pedido_Aluguer);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Carroes");
                }
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
