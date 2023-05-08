using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AT_Guilherme_Duques.Data;
using AT_Guilherme_Duques.Models;
using AT_Guilherme_Duques.Repository;

namespace AT_Guilherme_Duques.Controllers
{
    public class PessoasController : Controller
    {
        private readonly AT_Guilherme_DuquesContext _context;

        public PessoasController(AT_Guilherme_DuquesContext context)
        {
            _context = context;
        }

        // GET: Friends
        public IActionResult Index(string searchString)
        {
            var friends = from f in _context.Pessoa select f;
            if (!String.IsNullOrEmpty(searchString))
            {
                friends = friends.Where(s => s.nome.Contains(searchString));
            }
            return View(friends.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (PessoaRepository.Details(id, _context) == null)
            {
                return NotFound();
            }
            return View(PessoaRepository.Details(id, _context));
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("iD,nome,sobrenome,DataPessoa")] Pessoa friend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friend);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(friend);
        }

        //GET: Friends/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (PessoaRepository.Edit(id, _context) == null)
            {
                return NotFound();
            }
            return View(PessoaRepository.Edit(id, _context));
        }

        // POST: Friends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("iD,nome,sobrenome,DataPessoa")] Pessoa pessoa)
        {
            if (id != pessoa.iD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoa);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.iD))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }


        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.iD == id);
        }


        // GET: Friends/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (PessoaRepository.Delete(id, _context) == null)
            {
                return NotFound();
            }

            return View(PessoaRepository.Delete(id, _context));
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var friend = _context.Pessoa.Find(id);
            _context.Pessoa.Remove(friend);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
