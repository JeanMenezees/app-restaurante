using System.Linq;
using Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entidades;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private IRepositorioMesa _repositorioMesa;

        public MesaController(IRepositorioMesa repositorioMesa)
        {
            _repositorioMesa = repositorioMesa;
        }

        [HttpGet("ObterMesa")]
        public async Task<ActionResult<Mesa>> ObterMesa(int idMesa)
        {
            try
            {
                var mesa = await _repositorioMesa.ObterMesaPorId(idMesa);
                return Ok(mesa);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Mesa");
            }
        }

        [HttpPost("ZerarContaMesa")]
        public async Task<ActionResult<Mesa>> ZerarContaMesa(int idMesa)
        {
            try
            {
                await _repositorioMesa.ZerarContaDaMesa(idMesa);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Mesa");
            }
        }

        [HttpPost("AdicionarNaConta")]
        public async Task<ActionResult<Mesa>> AdicionarNaConta(int idMesa, decimal valor)
        {
            try
            {
                await _repositorioMesa.AdicionarContaNaMesa(idMesa, valor);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Mesa");
            }
        }

        [HttpPut("AdicionarCliente")]
        public async Task<ActionResult<Mesa>> AdicionarCliente(int idMesa, [FromBody] Mesa mesa)
        {
            try
            {
                if (idMesa == mesa.Id)
                {
                    await _repositorioMesa.AdicionarClienteNaMesa(mesa);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest("Falha ao adicionar Cliente");
            }
        }

        [HttpPost("RemoverCliente")]
        public async Task<ActionResult<Mesa>> RemoverCliente(int idMesa)
        {
            try
            {
                await _repositorioMesa.RemoverClienteNaMesa(idMesa);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Mesa");
            }
        }
    }
}