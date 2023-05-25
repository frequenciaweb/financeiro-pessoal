using FinanceiroPessoal.Dominio.Entidades;
using FinanceiroPessoal.Dominio.Enumeradores;
using FinanceiroPessoal.Teste.Comum;
using FinanceiroPessoal.Utilitarios.Util;
using System.ComponentModel;

namespace FinanceiroPessoal.Teste.Entidades
{
    [TestClass]
    public class TestarCartaoCredito : TesteBase
    {
        [TestMethod]
        public void TestarCartaoValido()
        {
            string validade = $"{DateTime.Now.Month.ToString().PadLeft(2, '0')}/{DateTime.Now.AddYears(1).Year}";
            var cartao = new CartaoCredito("WAY", "343543285186412", "123", validade, 10, 5, 100, "ITAU", EnumBandeiraCartao.AmericanExpress, donoCartaoUsuarioID: Guid.Parse("eb0b8c09-e93b-44b3-a68a-4c27bce54b2a"),"sistema");
            Assert.IsTrue(cartao.Valido());

            Context.Cartoes.Add(cartao);
            Assert.IsTrue(Context.SaveChanges() > 0);

        }

        [DataTestMethod]
        [DataRow("5151819390739851")]
        [DataRow("4532130712460843")]
        [DataRow("5151819390739851146")]
        [DataRow("5151819390739")]
        public void TestarNumeroValido(string numero)
        {
            Assert.IsTrue(Validacoes.CartaoCredito(numero));
        }

        [DataTestMethod]
        [DataRow("51518193907398512492")]
        [DataRow("515181939073")]
        [DataRow("515B8C93A0A398B1")]
        [DataRow("")]
        public void TestarNumeroInvalido(string numero)
        {
            Assert.IsFalse(Validacoes.CartaoCredito(numero));
        }
    }
}
