using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace FinanceiroPessoal.Utilitarios.Util
{
    public static class Validacoes
    {
        public static bool ValidarEmail(string email) 
        {
            return  Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); ;
        }
        public static bool ValidarCPF(string cpf) { return true; }
        public static bool ValidarCnpj(string cnpj) { return true; }

        /// <summary>
        /// deve conter ao menos um dígito númerico
        /// deve conter ao menos uma letra minúscula
        /// deve conter ao menos uma letra maiúscula
        /// deve conter ao menos um caractere especial
        /// deve conter ao menos 8 caracteres
        /// </summary>
        /// <param name="senha"></param>
        /// <returns></returns>
        public static bool ValidarSenha(string senha) 
        {
            return Regex.IsMatch(senha, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#])(?:([0-9a-zA-Z$*&@#])(?!\1)){8}$"); 
        }
    }
}
