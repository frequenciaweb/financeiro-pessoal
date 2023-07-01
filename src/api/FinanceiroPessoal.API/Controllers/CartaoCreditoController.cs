using FinanceiroPessoal.Dominio.Contratos.Repositorios;
using FinanceiroPessoal.Dominio.Contratos.Servicos;
using FinanceiroPessoal.Dominio.Entidades;
using FinanceiroPessoal.Dominio.ViewModels.Entrada;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace FinanceiroPessoal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartaoCreditoController : ControllerBase
    {
        private readonly ICartaoCreditoServico _cartaoCreditoServico;
        private readonly ICartaoCreditoRepositorio _cartaoCreditoRepositorio;
        public CartaoCreditoController(ICartaoCreditoServico cartaoCreditoServico, ICartaoCreditoRepositorio cartaoCreditoRepositorio)
        {
            _cartaoCreditoServico = cartaoCreditoServico;
            _cartaoCreditoRepositorio = cartaoCreditoRepositorio;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Dominio.ViewModels.Saida.CartaoCredito))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult POST(VMCartaoCreditoIncluir cartao)
        {
            cartao.UsuarioInclusao = User.Identity.Name;
            (bool salvo, string msg, CartaoCredito cartaoSalvo) = _cartaoCreditoServico.Incluir(cartao);
            if (salvo)
            {

                Dominio.ViewModels.Saida.CartaoCredito saida = cartaoSalvo;
                return Ok(new { msg = msg, cartao = saida });
            }
            else
            {
                return BadRequest(msg);
            }

        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult PUT(VMCartaoCreditoAlterar cartao)
        {
            cartao.UsuarioInclusao = User.Identity.Name;
            (bool salvo, string msg) = _cartaoCreditoServico.Alterar(cartao);
            if (salvo)
            {
                return Ok(msg);
            }
            else
            {
                return BadRequest(msg);
            }

        }

        [HttpPost("Excluir")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Excluir(VMCartaoCreditoExcluir cartao)
        {
            (bool salvo, string msg) = _cartaoCreditoServico.Excluir(cartao);
            if (salvo)
            {
                return Ok(msg);
            }
            else
            {
                return BadRequest(msg);
            }
        }
    }
}
