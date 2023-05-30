using FinanceiroPessoal.Dominio.Entidades;
using FinanceiroPessoal.Teste.Comum;

namespace FinanceiroPessoal.Teste.Entidades
{
    [TestClass]
    public class TestarFaturaCartao :TesteBase
    {
        [TestMethod]
        public void TestarValorMenorQueZero()
        {
            var fatura = new FaturaCartao(-50,Guid.NewGuid(),Guid.NewGuid(),"automatico");
            Assert.IsTrue(!fatura.Valido() && fatura.LerAnotacoesErro().Contains("Valor da fatura deve ser especificado corretamente"));
        }

        [TestMethod]
        public void TestarFaturaSucesso()
        {
            var fatura = new FaturaCartao(valor: 100, cartaoCreditoID: Guid.Parse("9f00bfdd-0450-46e1-8499-6d8963b6973f"), lancamentoID:  Guid.NewGuid(), usuarioInclusao: "automatico");
            Context.Faturas.Add(fatura);

            Assert.IsTrue(fatura.Valido());            
            Assert.IsTrue(Context.SaveChanges() > 0);


        }
    }
}
