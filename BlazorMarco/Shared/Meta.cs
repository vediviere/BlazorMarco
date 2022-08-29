using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BlazorMarco.Shared
{
    public class Meta
    {
        public int MetaId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NombreMeta { get; set; }
        public DateTime Fecha { get; set; }
        public Boolean Estatus { get; set; }

        public int TotalTareas()
        {
            return Tareas.Count;
        }

        public int TareasTerminadas()
        {
            return Tareas.Where(t => t.Estatus == true).Count();
        }

        public string PorcentajeTareasTerminadas()
        {
            string resultado = "0";

            if(TotalTareas() > 0)
            { 
                resultado = ((TareasTerminadas() * 100) / TotalTareas()).ToString();
            }
            
            return resultado;
        }

        public List<Tarea> Tareas { get; set; } = new List<Tarea>();
    }
}
