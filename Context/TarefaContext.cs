using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Desafio_entity_mvc.Models;

//herda de DbContext chama a conexão com Dbset da Models
//Essa classe de contexto administra os objetos entidades durante o tempo de execução, 
//o que inclui preencher objetos com dados de um banco de dados, controlar alterações, e persistir dados para o banco de dados.
namespace Desafio_entity_mvc.Context
{
    public class TarefaContext : DbContext
    { 
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {

        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }


    
}