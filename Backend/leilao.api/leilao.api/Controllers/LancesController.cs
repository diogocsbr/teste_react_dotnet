using leilao.api.services.Lance;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leilao.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancesController : ControllerBase
    {
        IMediator mediator;
        public LancesController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        /// <summary>
        /// Método usado para Incluir o Lance
        /// </summary>
        /// <returns></returns>
        [HttpPost("salvar")]
        public async Task<IActionResult> Salvar([FromBody] SalvarLanceCommand model)
        {
            var resposta = await mediator.Send(model);
            return Ok(resposta);
        }

        /// <summary>
        /// Lista os Lances
        /// </summary>
        /// <returns></returns>
        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            ListarLanceQuery query = new ListarLanceQuery();
            var resposta = await mediator.Send(query);
            return Ok(resposta);
        }

    }
}
