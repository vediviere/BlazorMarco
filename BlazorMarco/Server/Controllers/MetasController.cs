using BlazorMarco.Server.Models;
using BlazorMarco.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMarco.Server.Controllers
{
    [Route("metas")]
    [ApiController]
    public class MetasController : ControllerBase
    {
        private readonly BlazorMarcoContext Context;

        public MetasController(BlazorMarcoContext context)
        {
            this.Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Meta>>> ObtenerMetas()
        {
          var metasList = await Context.Metas//.ToListAsync();
                .Include(m => m.Tareas).ToListAsync();

            return metasList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meta>> ObtenerMetaPorId(int id)
        {
            var result = await Context.Metas
                .Include(m => m.Tareas)
               .Where(m => m.MetaId == id)
               .SingleOrDefaultAsync();

            var m = result.PorcentajeTareasTerminadas();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CrearMeta(Meta meta)
        {
            try
            {
                Context.Metas.Attach(meta);
                await Context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return meta.MetaId;
        }

        [HttpPut]
        public async Task<ActionResult<int>> ActualizaMeta(Meta meta)
        {
            int resultado = 0;
            try
            {
                var r = Context.Update(meta);
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
        public async Task<ActionResult<int>> EliminaMeta(int Id)
        {
            int resultado = 0;
            try
            {
                var meta = Context.Metas.Find(Id);
                var r = Context.Remove(meta);
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
