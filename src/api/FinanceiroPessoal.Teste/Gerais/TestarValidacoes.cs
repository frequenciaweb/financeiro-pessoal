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
            Assert.IsTrue(Validacoes.Email(email));
        }

        [TestMethod]
        public void TestarValidarEmailErrado()
        {
            string email = "algumdominio.com";
            Assert.IsFalse(Validacoes.Email(email));
        }

        [TestMethod]
        public void TestarValidarEmailErradoSemArroba()
        {
            string email = "jose_do_teste@";
            Assert.IsFalse(Validacoes.Email(email));
        }

        [TestMethod]
        public void TestarValidadeCartaoCorreta()
        {   
            string validade = $"{DateTime.Now.Month.ToString().PadLeft(2,'0')}/{DateTime.Now.AddYears(1).Year}";
            Assert.IsTrue(Validacoes.ValidadeCartao(validade));
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("05/20231")]
        [DataRow("05/2a23")]
        [DataRow("0520023")]
        [DataRow("052/0231")]
        [DataRow("05/2022")]
        [DataRow("12/2021")]        
        public void TestarValidadeCartaoErrado(string validade)
        {             
            Assert.IsFalse(Validacoes.ValidadeCartao(validade));
        }

    }
}
