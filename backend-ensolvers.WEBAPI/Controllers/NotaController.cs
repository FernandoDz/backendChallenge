using Backend.BL;
using Backend.EN;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace backend_ensolvers.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotaController : ControllerBase
    {
        private NotaBL notaBL = new NotaBL();

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Nota>> Get()
        {
            return await notaBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<Nota> Get(int id)
        {
            Nota nota = new Nota();
            nota.Id = id;
            return await notaBL.ObtenerPorIdAsync(nota);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Nota nota)
        {
            try
            {
                await notaBL.CrearAsync(nota);
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Nota nota)
        {
            if (nota.Id == id)
            {
                await notaBL.ModificarAsync(nota);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Nota nota = new Nota();
                nota.Id = id;
                await notaBL.EliminarAsync(nota);
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("Buscar")]
        public async Task<List<Nota>> Buscar([FromBody] object pNota)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strNota = JsonSerializer.Serialize(pNota);
            Nota nota = JsonSerializer.Deserialize<Nota>(strNota, option);
            var notas = await notaBL.BuscarAsync(nota);
            return notas;
        }

    }
}
