using FinanceiroPessoal.API.Models;
using FinanceiroPessoal.API.Servico;
using FinanceiroPessoal.Dominio.Contratos.Repositorios;
using FinanceiroPessoal.Dominio.Contratos.Servicos;
using FinanceiroPessoal.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinanceiroPessoal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioServico _usuarioServico;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuariosController(IUsuarioServico usuarioServico, 
            IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioServico = usuarioServico;
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost("Logar")]
        [AllowAnonymous]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioLogado))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Logar(Logon logon) 
        {

           (bool logado, Usuario usuario) = _usuarioServico.Logar(logon.Login, logon.Senha, out string msgErro);
            if (logado)
            {
                return Ok(new UsuarioLogado(usuario, TokenServico.Gerar(usuario)));
            }
            else
            {
                return BadRequest(msgErro);
            }
            
        }

        [HttpGet("ListarAtivos")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Usuario>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize (Roles = "Administrador")]
        public IActionResult ListarAtivos()
        {   
           return Ok(_usuarioRepositorio.ListarAtivos());
        }

    }
}
