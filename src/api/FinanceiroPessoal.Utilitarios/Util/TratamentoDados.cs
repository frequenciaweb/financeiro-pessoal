using System.Text.RegularExpressions;

namespace FinanceiroPessoal.Utilitarios.Util
{
    public static class TratamentoDados
    {
        public static string RetornarNumeros(string valor)
        {
            return Regex.Replace(valor, @"[^\d]", "");
        }
    }
}
