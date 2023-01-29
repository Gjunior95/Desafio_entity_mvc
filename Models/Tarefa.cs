// Classe com estrutura(propriedades) da tabela do banco
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace Desafio_entity_mvc.Models
{
    public class Tarefa
    {
        
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}")]
        public DateTime  Data { get; set; }
        public EnumStatusTarefa Status { get; set; }

    }
}