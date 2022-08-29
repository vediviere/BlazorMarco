using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorMarco.Shared
{
    public class Tarea
    {        
        public int TareaId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NombreTarea { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estatus { get; set; }
        public bool Importante { get; set; }
        public bool Seleccionado { get; set; }

        public int MetaId { get; set; }
        public Meta Meta { get; set; }
    }
}