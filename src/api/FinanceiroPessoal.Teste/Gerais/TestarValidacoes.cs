using FinanceiroPessoal.Utilitarios.Util;

namespace FinanceiroPessoal.Teste.Gerais
{
    [TestClass]
    public class TestarValidacoes
    {

        [TestMethod]
        public void TestarValidarEmailCerto()
        {
            string email = "jose_do_teste@algumdominio.com";
            Assert.IsTrue(Validacoes.ValidarEmail(email));
        }

        [TestMethod]
        public void TestarValidarEmailErrado()
        {
            string email = "algumdominio.com";
            Assert.IsFalse(Validacoes.ValidarEmail(email));
        }

        [TestMethod]
        public void TestarValidarEmailErradoSemArroba()
        {
            string email = "jose_do_teste@";
            Assert.IsFalse(Validacoes.ValidarEmail(email));
        }



    }
}
