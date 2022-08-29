using BlazorMarco.Server.Models;
using BlazorMarco.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BlazorMarco.Client.Shared;
using BlazorMarco.Server.Helpers;

namespace BlazorMarco.Server.Controllers
{
    [Route("tareas")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly BlazorMarcoContext Context;

        public TareasController(BlazorMarcoContext context)
        {
            this.Context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Tarea>>> ObtenerTareas()
        //{
        //    return await Context.Tareas.ToListAsync(); 
        //}

        [HttpGet]
        public async Task<ActionResult<List<Tarea>>> GetTareas([FromQuery] Paginacion paginacion)
        {
            //string sqlStr = "select " +
            //                "TareaId, " +
            //                "NombreTarea, " +
            //                "Fecha, " +
            //                "Estatus, " +
            //                "Importante, " +
            //                "MetaId, " +
            //                $"Seleccionado from tareas " +
            //                $"where metaid={paginacion.MetaId} and "+
            //                $"NombreTarea like '%{paginacion.TextoFiltrar}% and "+
            //                $"Fecha = {paginacion.FechaFiltrar} and "+
            //                $"Estado = {paginacion.EstadoFiltrar}";
            string sqlStr = "select " +
                            "TareaId, " +
                            "NombreTarea, " +
                            "Fecha, " +
                            "Estatus, " +
                            "Importante, " +
                            "MetaId, " +
                            $"Seleccionado from tareas " +
                            $"where metaid={paginacion.MetaId} and " +
                            $"NombreTarea like '%{paginacion.TextoFiltrar}%' and " +
                            $"CONVERT(VARCHAR(10), fecha, 103) between '{paginacion.FechaFiltrar}' and '{paginacion.FechaFiltrar}'";
                           

            var queryable = Context.Tareas.FromSqlRaw(sqlStr).AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadAMostrar);

            return await queryable.Paginar(paginacion).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> ObtenerTareaPorId(int id)
        {
            var result = await Context.Tareas.Where(t => t.TareaId == id)
               .SingleOrDefaultAsync();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CrearTarea(Tarea tarea)
        {
            Context.Tareas.Attach(tarea);
            await Context.SaveChangesAsync();

            return tarea.TareaId;
        }

        [HttpPut]
        public async Task<ActionResult<int>> ActualizaTarea(Tarea tarea)
        {
            int resultado = 0;
            try
            {
                var r = Context.Update(tarea);
                var re = await Context.SaveChangesAsync();
                resultado = 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resultado;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> EliminaTarea(int Id)
        {
            int resultado = 0;
            try
            {
                var tarea = Context.Tareas.Where(t => t.TareaId == Id).FirstOrDefault();

                var r = Context.Remove(tarea);
                var re = await Context.SaveChangesAsync();
                resultado = 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resultado;
        }
    }
}
