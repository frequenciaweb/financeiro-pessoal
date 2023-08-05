using Microsoft.Extensions.Configuration;

namespace FinanceiroPessoal.Utilitarios.Util
{
    public static class Log
    {
        private static string ObterInnerExceptions(Exception exception)
        {
            string mensagem = exception.Message;

            if (exception.InnerException != null)
            {
                mensagem +=" Inner Exception "+ ObterInnerExceptions(exception.InnerException);
            }

            return mensagem;
        }

        public static void GravarExcessao(Exception exception)
        {
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json");
                var config = builder.Build();
                var caminho = config["Logs"]?.ToString();
                var nome = "log_erros_"+DateTime.Now.ToString("dd_MM_yyyy")+".log";

                if (!Directory.Exists(caminho))
                {
                    Directory.CreateDirectory(caminho);
                }

                using StreamWriter valor = new StreamWriter(caminho+ nome, true);

                string mensagem = ObterInnerExceptions(exception);

                mensagem += " STACK TRACE " + exception.StackTrace;

                valor.WriteLine("------------------------------------------------INICIO ERRO------------------------------------------------");
                valor.WriteLine(" ");
                valor.WriteLine(DateTime.Now+" "+mensagem);
                valor.WriteLine(" ");
                valor.WriteLine("------------------------------------------------FIM ERROR------------------------------------------------");
                valor.WriteLine(" ");
                valor.Flush();
            }
            catch
            {
            }
        }
    }
}
