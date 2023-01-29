using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_entity_mvc.Context;
using Microsoft.AspNetCore.Mvc;
using Desafio_entity_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_entity_mvc.Controllers
{
    public class TarefaController : Controller
    {
        private readonly TarefaContext _context;
        public TarefaController (TarefaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tarefa = _context.Tarefas.ToList();
            return View(tarefa);
        }
        public IActionResult Incluir()
        {
            
            return View();
        }
         [HttpPost]
        public IActionResult Incluir(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(tarefa);

            }
        }
         
        public async Task<IActionResult> Buscar(string ? buscaTitulo, DateTime ? buscaData, EnumStatusTarefa ? buscaStatus)
        {
            if (_context.Tarefas == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var tarefa = from m in _context.Tarefas select m;

            if (!String.IsNullOrEmpty(buscaTitulo))
            {
                tarefa = tarefa.Where(x=> x.Titulo!.Contains(buscaTitulo));
                

            }
            
            if (buscaData != null)
            {
                tarefa = tarefa.Where(x=> x.Data! == (buscaData));
                

            }

            if (buscaStatus != null)
            {
                tarefa = tarefa.Where(x=> x.Status! == (buscaStatus));
                

            }


            return View(await tarefa.ToListAsync());
           
            
        }

        

        
        public IActionResult Editar (int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(tarefa);
            }
            
        }
        
        [HttpPost]
        public IActionResult Editar(Tarefa tarefa)       
        {
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            
                    

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(tarefa);
            }
        }

        [HttpPost]
        public IActionResult Deletar(Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

       
       
    }
}