using FinanceiroPessoal.Dominio.Entidades;

namespace FinanceiroPessoal.Infraestrutura.EF
{
    public static class SEED
    {
        public static void Popular(FinanceiroPessoalContext context)
        {
            if (context.Usuarios.Count() == 0)
            {
                context.Usuarios.Add(new Usuario(Guid.Parse("eb0b8c09-e93b-44b3-a68a-4c27bce54b2a"), "Administrador", "administrador@sistema.com", "123456", "migrations"));
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

            context.SaveChanges();
        }
    }
}
