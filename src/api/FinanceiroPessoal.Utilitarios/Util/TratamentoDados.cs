using System.Text.RegularExpressions;

namespace FinanceiroPessoal.Utilitarios.Util
{
    public static class TratamentoDados
    {
        public static string RetornarNumeros(string valor)
        {
            return Regex.Replace(valor, @"[^\d]", "");
        }

        public static DateTime ParaData(this string valor)
        {
            /// Todo: Melhorar a função para conversão de datas  
            DateTime.TryParse(valor, out DateTime saida);
            return saida;
        }

        public static bool ParaBoleano(this object valor)
        {
            if (valor == null)
            {
                return false;
            }

            if (valor is bool)
            {
                return (bool)valor;
            }

            if (valor is string)
            {
                bool.TryParse((string)valor, out bool saida);
                return saida;
            }

            return false;
        }

        public static int ParaNumero(this object valor)
        {
            if (valor == null)
            {
                return 0;
            }

            if (valor is int)
            {
                return (int)valor;
            }

            if (valor is bool)
            {
                if (bool.Parse((string)valor) == true)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            if (valor is string)
            {
                int.TryParse((string)valor,out int saida);
                return saida;
            }

            return 0;
        }
    }
}
