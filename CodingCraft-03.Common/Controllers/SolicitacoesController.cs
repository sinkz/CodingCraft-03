using CodingCraft_03.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CodingCraft_03.Common.Controllers
{
    public class SolicitacoesController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Solicitacoes
        public async Task<ActionResult> Index()
        {
            return View(await db.Solicitacoes.ToListAsync());
        }


        // GET: Solicitacoes/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitacao solicitacao = await db.Solicitacoes.FindAsync(id);
            if (solicitacao == null)
            {
                return HttpNotFound();
            }
            return View(solicitacao);
        }

        // GET: Solicitacoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Solicitacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SolicitacaoId,Titulo,Descricao")] Solicitacao solicitacao)
        {
            if (ModelState.IsValid)
            {
                solicitacao.SolicitacaoId = Guid.NewGuid();
                solicitacao.DataCriacao = DateTime.Now;
                db.Solicitacoes.Add(solicitacao);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(solicitacao);
        }

        // GET: Solicitacoes/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitacao solicitacao = await db.Solicitacoes.FindAsync(id);
            if (solicitacao == null)
            {
                return HttpNotFound();
            }
            return View(solicitacao);
        }

        // POST: Solicitacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SolicitacaoId,DataCriacao,Titulo,Descricao")] Solicitacao solicitacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitacao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(solicitacao);
        }

        // GET: Solicitacoes/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitacao solicitacao = await db.Solicitacoes.FindAsync(id);
            if (solicitacao == null)
            {
                return HttpNotFound();
            }
            return View(solicitacao);
        }

        // POST: Solicitacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Solicitacao solicitacao = await db.Solicitacoes.FindAsync(id);
            db.Solicitacoes.Remove(solicitacao);
            await db.SaveChangesAsync();
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
