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
using DLL;
using System.Web.UI;
using System.Data.SqlClient;

namespace AluguerCarros.Controllers
{
    public class CarroesController : Controller
    {
        private AluguerCarrosContext db = new AluguerCarrosContext();

        // GET: Carroes
        public ActionResult Index()
        {
            CarroViewModel cvm = new CarroViewModel();
            cvm.carros = db.Carros.Where(c => c.Dono != User.Identity.Name).Where(c => c.Disponivel == true);
            cvm.marcas = db.Marcas.ToList();
            cvm.modelos = db.Modelos.ToList();
            return View(cvm);
        }

        // GET: Carroes
        public ActionResult MeusCarros()
        {
            return View(db.Carros.Where(c=>c.Dono == User.Identity.Name));
        }

        // GET: Carroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carros.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // GET: Carroes/Create
        public ActionResult Create()
        {
            CarroViewModel cvm = new CarroViewModel();
            cvm.marcas = db.Marcas.ToList();
            cvm.modelos = db.Modelos.ToList();

            return View(cvm);
        }

        // POST: Carroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarroID,Matricula,Marca,Modelo,Combustivel,Lugares,Portas,Preco_Diario,Preco_Mensal,Condicoes,Zona,Disponivel,DonoID")] Carro carro)
        {
            Class1 matricula = new Class1();
            CarroViewModel cvm = new CarroViewModel();
            
            if (carro.Matricula != null && matricula.VerificaMatricula(carro.Matricula))
            {
                IEnumerable<Carro> carros = db.Carros.ToList();

                foreach(var c in carros)
                {
                    if (c.Matricula == carro.Matricula && c.CarroID != carro.CarroID)
                    {
                        TempData["Matricula"] = "Já existe um carro com esta matrícula";
                        cvm.marcas = db.Marcas.ToList();
                        cvm.modelos = db.Modelos.ToList();
                        cvm.carro = carro;
                        return View(cvm);
                    }
                }
                
                if (ModelState.IsValid)
                {
                    carro.Dono = User.Identity.GetUserName();
                    db.Carros.Add(carro);
                    db.SaveChanges();
                    return RedirectToAction("MeusCarros");
                }
            }
            else
            {
                TempData["Matricula"] = "Formato da matrícula inválido! (AA-12-34)";
            }

            cvm.marcas = db.Marcas.ToList();
            cvm.modelos = db.Modelos.ToList();
            cvm.carro = carro;
            return View(cvm);
        }

        // GET: Carroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carros.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarroID,Matricula,Marca,Modelo,Combustivel,Lugares,Portas,Preco_Diario,Preco_Mensal,Condicoes,Zona,Disponivel,DonoID")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                carro.Dono = User.Identity.GetUserName();
                db.Entry(carro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MeusCarros");
            }
            return View(carro);
        }

        // GET: Carroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carros.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro carro = db.Carros.Find(id);
            db.Carros.Remove(carro);
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
