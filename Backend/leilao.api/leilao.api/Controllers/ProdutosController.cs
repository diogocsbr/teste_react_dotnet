using leilao.api.services.Produtos;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leilao.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        IMediator mediator;

        public ProdutosController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        /// <summary>
        /// Método usado para Incluir e Alterar o Produto
        /// </summary>
        /// <returns></returns>
        [HttpPost("salvar")]
        public async Task<IActionResult> Salvar([FromBody] SalvarProdutoCommand model)
        {
            var resposta = await mediator.Send(model);
            return Ok(resposta);
        }

        /// <summary>
        /// Lista os Produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            ListarProdutoQuery query = new ListarProdutoQuery();
            var resposta = await mediator.Send(query);
            return Ok(resposta);
        }

        /// <summary>
        /// Seleciona o Produto
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("selecionar")]
        public async Task<IActionResult> Selecionar([FromQuery] int Id)
        {
            SelecionarProdutoQuery query = new SelecionarProdutoQuery() { Id = Id };
            var resposta = await mediator.Send(query);
            return Ok(resposta);
        }


    }
}
