using leilao.api.services.Login;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leilao.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IMediator mediator;

        public LoginController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Salvar([FromBody] LoginCommand model)
        {
            dynamic resposta;

            try
            {
                resposta = await mediator.Send(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(resposta);
        }
    }
}
