using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace FinanceiroPessoal.Utilitarios.Util
{
    public static class Validacoes
    {
        public static bool Email(string email) 
        {
            return  Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); ;
        }
        public static bool CPF(string cpf) { return true; }
        public static bool Cnpj(string cnpj) { return true; }

        /// <summary>
        /// deve conter ao menos um dígito númerico
        /// deve conter ao menos uma letra minúscula
        /// deve conter ao menos uma letra maiúscula
        /// deve conter ao menos um caractere especial
        /// deve conter ao menos 8 caracteres
        /// </summary>
        /// <param name="senha"></param>
        /// <returns></returns>
        public static bool Senha(string senha) 
        {
            return Regex.IsMatch(senha, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#])(?:([0-9a-zA-Z$*&@#])(?!\1)){8}$"); 
        }

        public static bool ValidadeCartao(string vencimento)
        {
            if (string.IsNullOrEmpty(vencimento))
            {
                return false;
            }

            if (vencimento.Length != 7)
            {
                return false;
            }

            if (TratamentoDados.RetornarNumeros(vencimento).Length != 6)
            {
                return false;
            }            

            if (!vencimento.Contains("/"))
            {
                return false;
            }
             
            if (vencimento.Substring(2,1) != "/")
            {
                return false;
            }

            int mes = int.Parse(vencimento.Substring(0,2));
            int ano = int.Parse(vencimento.Substring(3, 4));           

            if (ano < DateTime.Now.Year) {
                return false;
            }
            else if (ano == DateTime.Now.Year && mes < DateTime.Now.Month)
            {
                return false;
            }

            return true;
        }

        public static bool CartaoCredito(string numero)
        {
            if (string.IsNullOrEmpty(numero))
            {
                return false;
            }

            string n = TratamentoDados.RetornarNumeros(valor: numero);
            if (n.Length < 13 || n.Length > 19)
            {
                return false;
            }             

            return true;

        }
    }
}
