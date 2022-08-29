using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMarco.Server.Models
{
    public class Paginacion
    {
        public int Pagina { get; set; } = 1;
        public int CantidadAMostrar { get; set; } = 10;
        public int MetaId { get; set; }
        public string TextoFiltrar { get; set; }
        public string FechaFiltrar { get; set; } 

        //public bool EstadoFiltrar { get; set; } = false;
    }
}
