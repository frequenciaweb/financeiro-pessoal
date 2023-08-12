using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceiroPessoal.Dominio.Util
{
    public abstract class EntidadeValidacao
    {
        /// <summary>
        /// Metodo que retorna Se a entidade é valida
        /// com base nas regras
        /// </summary>
        public virtual bool Valido()
        {
            return _erros.Count == 0;
        }

        /// <summary>
        /// Lista as mensagens de erro de regra de negocio e validações
        /// </summary>
        public IReadOnlyList<string> Erros
        {
            get
            {
                return _erros.ToList();
            }
        }

        /// <summary>
        /// Armazena as anotações de erros
        /// </summary>
        private List<string> _erros { get; set; } = new List<string>();

        /// <summary>
        /// Retorna todos as anotações de erros em uma unica linha
        /// </summary>
        /// <returns></returns>
        public string LerAnotacoesErro()
        {
            return string.Join(",", _erros);
        }

        public void LimparMensagensErro()
        {
            _erros.Clear();
        }

        /// <summary>
        /// Inclui uma anotação de erro
        /// </summary>
        /// <param name="mensagem"></param>
        public void IncluirAnotacaoErro(string mensagem)
        {
            _erros.Add(mensagem);
        }

    }
}