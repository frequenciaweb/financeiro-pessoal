using FinanceiroPessoal.Dominio.Entidades;

namespace FinanceiroPessoal.Teste.Entidades
{
    [TestClass]
    public class TestarUsuario
    {
        [TestMethod]
        public void TestarUsuarioComSucesso()
        {
            var Usuario = new Usuario("PAULO ROBERTO", 
                "jose_do_teste@exemplo.com",
                "Ab12#456", "automatico");            
            Assert.IsTrue(Usuario.Valido());
        }

        [TestMethod]
        public void TestarNomeErradoMenorque10()
        {
            var Usuario = new Usuario("PAULO",
                "jocom",
                "Ab12#4", "automatico");
                Assert.IsTrue(!Usuario.Valido() && Usuario.LerAnotacoesErro().Contains("Nome de usuário deve conter o mínimo de 10 caracteres"));
        }

        [TestMethod]
        public void TestarNomeErradoMaiorQue60()
        {
            var Usuario = new Usuario("PAULO PAULO PAULO PAULO PAULO PAULO PAULO PAULO PAULO PAULO PAULO PAULO PAULO PAULO",
                "jocom",
                "Ab12#4", "automatico");
            Assert.IsTrue(!Usuario.Valido() && Usuario.LerAnotacoesErro().Contains("Nome deve conter o máximo de 60 caracteres"));
        }

        [TestMethod]
        public void TestarNomeVazio()
        {
            var Usuario = new Usuario("",
                "jocom",
                "Ab12#4", "automatico");
            Assert.IsTrue(!Usuario.Valido() && Usuario.LerAnotacoesErro().Contains("Nome deve ser preenchido"));
        }

        [TestMethod]
        public void TestarEmailCorreto()
        {
            
            var Usuario = new Usuario("",
              "jose_do_teste@exemplo.com",
              "123456", "automatico");
            Assert.IsFalse(Usuario.Valido());
        }

        [TestMethod]
        public void TestarEmaileErradoSemArroba()
        {            
            var Usuario = new Usuario("",
              "jose_do_teste@exemplo.com",
              "123456", "automatico");
            Assert.IsFalse(Usuario.Valido());
        }

        [TestMethod]
        public void TestarTrocarSenhaCerta()
        {
            string senhaAtual = "Ab12#456";
            string senhaNova = "Ac12&485";

            var Usuario = new Usuario("PAULO ROBERTO",
      "jose_do_teste@exemplo.com",
      "Ab12#456", "automatico");

            Usuario.TrocarSenha(senhaAtual, senhaNova);
            Assert.IsTrue(Usuario.Valido());
        }

        [TestMethod]
        public void TestarTrocarSenhaAtualErrada()
        {
            string senhaAtual = "Ab12#457";
            string senhaNova = "Ac12&485";

            var Usuario = new Usuario("PAULO ROBERTO",
      "jose_do_teste@exemplo.com",
      "Ab12#456", "automatico");

            Usuario.TrocarSenha(senhaAtual, senhaNova);
            Assert.IsTrue(!Usuario.Valido() && Usuario.LerAnotacoesErro().Contains("Senha digitada não confere com a senha atual"));
        }

        [TestMethod]
        public void TestarTrocarSenhaSenhaInvalida()
        {
            string senhaAtual = "Ab12#456";
            string senhaNova = "Ac124485";

            var Usuario = new Usuario("PAULO ROBERTO",
      "jose_do_teste@exemplo.com",
      "Ab12#456", "automatico");

            Usuario.TrocarSenha(senhaAtual, senhaNova);
            Assert.IsTrue(!Usuario.Valido() && Usuario.LerAnotacoesErro().Contains("Senha inválida"));
        }

    }
}
