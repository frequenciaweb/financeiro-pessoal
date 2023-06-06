using FinanceiroPessoal.Dominio.Entidades;
using FinanceiroPessoal.Dominio.Enumeradores;
using FinanceiroPessoal.Utilitarios.Util;

namespace FinanceiroPessoal.Infraestrutura.EF
{
    public static class SEED
    {
        public static void Popular(FinanceiroPessoalContext context)
        {
            if (context.Usuarios.Count() == 0)
            {
                context.Usuarios.Add(new Usuario(Guid.Parse("eb0b8c09-e93b-44b3-a68a-4c27bce54b2a"), "Administrador", "administrador@sistema.com", Seguranca.HashMd5("123456"), "migrations"));
            }

            if (context.Cartoes.Count() == 0)
            {
                var cartao = new CartaoCredito(
                    nome: "WAY",
                    numero: "1234567890124567",
                    cvv: "123",
                    validade: $"{DateTime.Now.Month}/{DateTime.Now.AddYears(1).Year}",
                    vencimento: 10,
                    diaMelhorCompra: 1,
                    limite: 500,
                    banco: "SANTANDER",
                    bandeira: Dominio.Enumeradores.EnumBandeiraCartao.Hipercard,
                    donoCartaoUsuarioID: Guid.Parse("eb0b8c09-e93b-44b3-a68a-4c27bce54b2a"),
                    usuarioInclusao: "migrations");

                context.Cartoes.Add(cartao);
            }


            if (context.Cartoes.Count() == 0)
            {
                string validade = $"{DateTime.Now.Month.ToString().PadLeft(2, '0')}/{DateTime.Now.AddYears(1).Year}";
                var cartao = new CartaoCredito(Guid.Parse("9f00bfdd-0450-46e1-8499-6d8963b6973f"),"WAY", "343543285186412", "123", validade, 10, 5, 100, "ITAU", EnumBandeiraCartao.AmericanExpress, donoCartaoUsuarioID: Guid.Parse("eb0b8c09-e93b-44b3-a68a-4c27bce54b2a"), "sistema");
                context.Cartoes.Add(cartao);
            }
            context.SaveChanges();
        }
    }
}
