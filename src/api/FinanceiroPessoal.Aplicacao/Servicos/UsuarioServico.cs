using FinanceiroPessoal.Dominio.Contratos.Repositorios;
using FinanceiroPessoal.Dominio.Contratos.Servicos;
using FinanceiroPessoal.Dominio.Entidades;
using FinanceiroPessoal.Infraestrutura.EF;
using FinanceiroPessoal.Utilitarios.Util;

namespace FinanceiroPessoal.Aplicacao.Servicos
{
    public class UsuarioServico : ServicoBase, IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(FinanceiroPessoalContext contexto, IUsuarioRepositorio usuarioRepositorio) : base(contexto)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public (bool, Usuario?) Logar(string login, string senha, out string msgErro)
        {
            msgErro = string.Empty;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
            {
                msgErro = "Informe os dados para login";
                return (false, null);
            }

            Usuario? usuario = _usuarioRepositorio.Logar(login, Seguranca.HashMd5(senha));

            if (usuario != null && usuario.Ativo)
            {
                _usuarioRepositorio.RegistrarAcesso(usuario.ID);
                Commit();

                return (true, usuario);
            }
            else if (usuario != null && !usuario.Ativo)
            {
                msgErro = "Usuário inativo";
                return (false, null);
            }
            else
            {
                msgErro = "Usuário ou senha inválido";
                return (false, null);
                
            }
        }
        
    }
}
