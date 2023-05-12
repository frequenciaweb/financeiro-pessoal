using FinanceiroPessoal.Utilitarios.Util;

namespace FinanceiroPessoal.Teste.Gerais
{
    [TestClass]
    public class TestarSenhaSegura
    {
        [TestMethod]
        public void TestarSenhaValida()
        {
            string senha = "b23#A467";
            Assert.IsTrue(condition: Validacoes.ValidarSenha(senha));
        }

        [TestMethod]
        public void TestarMinimo8Caracteres()
        {
            string senha = "b23#A4";
            Assert.IsFalse(condition: Validacoes.ValidarSenha(senha));
        }

        [TestMethod]
        public void TestarMaximo8Caracteres()
        {
            string senha = "b23#A46710";
            Assert.IsFalse(condition: Validacoes.ValidarSenha(senha));
        }

        [TestMethod]
        public void TestarCaracteresEspecial()
        {
            string senha = "b203A467";
            Assert.IsFalse(condition: Validacoes.ValidarSenha(senha));
        }

        [TestMethod]
        public void TestarLetraMaiusculaEMinusculaEspecial()
        {
            string senha = "B23#A467";
            Assert.IsFalse(condition: Validacoes.ValidarSenha(senha));
        }

        [TestMethod]
        public void TestarSemNumeros()
        {
            string senha = "bab#Aegh";
            Assert.IsFalse(condition: Validacoes.ValidarSenha(senha));
        }

        [TestMethod]
        public void TestarSemLetras()
        {
            string senha = "123#4567";
            Assert.IsFalse(condition: Validacoes.ValidarSenha(senha));
        }
    }
}
