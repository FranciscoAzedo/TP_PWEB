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

namespace AluguerCarros.Controllers
{
    public class AvaliacaosController : Controller
    {
        private AluguerCarrosContext db = new AluguerCarrosContext();

        // GET: Avaliacaos
        public ActionResult Index()
        {
            return View(db.Avaliacoes.ToList());
        }

        // GET: Avaliacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacoes.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        // GET: Avaliacaos/Create
        public ActionResult Avaliacao_Dono(int id, string Dono)
        {
            Avaliacao_Alugador aval = new Avaliacao_Alugador();
            aval.PedidoID = id;
            aval.Dono = Dono;
            return View(aval);
        }

        // POST: Avaliacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Avaliacao_Dono([Bind(Include = "AvaliacaoID,Tempo_Resposta,Simpatia,Resultado,PedidoID,Dono")] Avaliacao_Alugador avaliacao)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<Pedido_Aluguer> pedidos = db.Pedidos.ToList();
                Pedido_Aluguer pedido = new Pedido_Aluguer();
                foreach (var p in pedidos)
                {
                    if (p.PedidoID == avaliacao.PedidoID)
                    {
                        pedido = p;
                    }
                }
                pedido.aval_Dono = true;
                if (pedido.aval_Dono == true && pedido.aval_Cli == true && pedido.aval_Carro == true)
                {
                    pedido.Estado = "Concluido";
                }
                avaliacao.Tipo = "Avaliacao Dono";
                db.Avaliacoes.Add(avaliacao);
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(avaliacao);
        }

        // GET: Avaliacaos/Create
        public ActionResult Avaliacao_Carro(int id, int CarroID)
        {
            Avaliacao_Carro aval = new Avaliacao_Carro();
            aval.PedidoID = id;
            aval.CarroID = CarroID;
            return View(aval);
        }

        // POST: Avaliacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Avaliacao_Carro([Bind(Include = "AvaliacaoID,Limpeza_Veiculo,Estado_Veiculo,Resultado,PedidoID,CarroID")] Avaliacao_Carro avaliacao)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<Pedido_Aluguer> pedidos = db.Pedidos.ToList();
                Pedido_Aluguer pedido = new Pedido_Aluguer();
                foreach (var p in pedidos)
                {
                    if (p.PedidoID == avaliacao.PedidoID)
                    {
                        pedido = p;
                    }
                }
                pedido.aval_Carro = true;
                if (pedido.aval_Dono == true && pedido.aval_Cli == true && pedido.aval_Carro == true)
                {
                    pedido.Estado = "Concluido";
                }
                avaliacao.Tipo = "Avaliacao Carro";
                db.Avaliacoes.Add(avaliacao);
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(avaliacao);
        }

        // GET: Avaliacaos/Create
        public ActionResult Create(int id, string Cliente)
        {
            Avaliacao_Cliente aval = new Avaliacao_Cliente();
            aval.PedidoID = id;
            aval.Cliente = Cliente;
            return View(aval);
        }

        // POST: Avaliacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AvaliacaoID,Comportamento,Estado_Veiculo,Resultado,PedidoID,Cliente")] Avaliacao_Cliente avaliacao)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<Pedido_Aluguer> pedidos = db.Pedidos.ToList();
                Pedido_Aluguer pedido = new Pedido_Aluguer();
                foreach (var p in pedidos)
                {
                    if (p.PedidoID == avaliacao.PedidoID)
                    {
                        pedido = p;
                    }
                }
                pedido.aval_Cli = true;
                if (pedido.aval_Dono == true && pedido.aval_Cli == true && pedido.aval_Carro == true)
                {
                    pedido.Estado = "Concluido";
                }
                avaliacao.Tipo = "Avaliacao Cliente";
                db.Avaliacoes.Add(avaliacao);
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(avaliacao);
        }

        // GET: Avaliacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacoes.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        // POST: Avaliacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AvaliacaoID,Resultado")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avaliacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(avaliacao);
        }

        // GET: Avaliacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacoes.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        // POST: Avaliacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Avaliacao avaliacao = db.Avaliacoes.Find(id);
            db.Avaliacoes.Remove(avaliacao);
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
