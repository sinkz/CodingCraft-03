using CodingCraft_03.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Mvc;


namespace CodingCraft_03.Common.Controllers
{
    public class CursosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cursos
        public async Task<ActionResult> Index()
        {
            return View(await db.Cursos.ToListAsync());
        }

        public ActionResult NewLineSolicitacoes(Guid? SolicitacaoId = null)
        {
            ViewBag.Solicitacoes = new SelectList(db.Solicitacoes, "SolicitacaoId", "Titulo");
            return PartialView("_LineSolicitacao", new Solicitacao { SolicitacaoId = Guid.NewGuid() });
        }

        // GET: Cursos/Details/5
        public async Task<ActionResult>Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = await db.Cursos.FindAsync(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            return View(new Curso
            {
                Solicitacoes = new List<SolicitacaoCurso>()
            });

        }

        // POST: Cursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CursoId,NomeCurso,Descricao,DataCriacao,AcessoLivre,Solicitacoes")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
           
                    Console.WriteLine(curso.Solicitacoes);
                    curso.CursoId = Guid.NewGuid();
                    curso.DataCriacao = DateTime.Now;
                    db.Cursos.Add(curso);
                    await db.SaveChangesAsync();
                    scope.Complete();
                    return RedirectToAction("Index");
                }

            }

            return View(curso);
        }

        // GET: Cursos/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = await db.Cursos.FindAsync(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CursoId,NomeCurso,Descricao,DataCriacao,AcessoLivre")] Curso curso)
        {
            if (ModelState.IsValid)
            {
        
                db.Entry(curso).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = await db.Cursos.FindAsync(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Curso curso = await db.Cursos.FindAsync(id);
            db.Cursos.Remove(curso);
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

