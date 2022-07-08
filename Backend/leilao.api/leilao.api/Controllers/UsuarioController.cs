using leilao.api.services.Usuario;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leilao.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IMediator mediator;

        public UsuarioController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        /// <summary>
        /// Método usado para Incluir e Alterar o Usuario
        /// </summary>
        /// <returns></returns>
        [HttpPost("salvar")]
        public async Task<IActionResult> Salvar([FromBody] SalvarUsuarioCommand model) 
        {
            var resposta = await mediator.Send(model);
            return Ok(resposta);
        }

        /// <summary>
        /// Lista os Usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet("listar")]
        public async Task<IActionResult> Listar() 
        {
            ListarUsuarioQuery query = new ListarUsuarioQuery();
            var resposta = await mediator.Send(query);
            return Ok(resposta);
        }

        /// <summary>
        /// Seleciona o Usuario
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("selecionar")]
        public async Task<IActionResult> Selecionar([FromQuery] int Id)
        { 
            SelecionarUsuarioQuery query = new SelecionarUsuarioQuery() { Id = Id };
            var resposta = await mediator.Send(query);
            return Ok(resposta);
        }
    }
}
