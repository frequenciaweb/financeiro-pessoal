﻿using FinanceiroPessoal.API.Models;
using FinanceiroPessoal.Dominio.Contratos.Servicos;
using FinanceiroPessoal.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinanceiroPessoal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioServico _usuarioServico;
        public UsuariosController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        [HttpPost("Logar")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioLogado))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Logar(Logon logon) 
        {

           (bool logado, Usuario usuario) = _usuarioServico.Logar(logon.Login, logon.Senha, out string msgErro);
            if (logado)
            {
                return Ok(new UsuarioLogado(usuario));
            }
            else
            {
                return BadRequest(msgErro);
            }
            
        }
    }
}