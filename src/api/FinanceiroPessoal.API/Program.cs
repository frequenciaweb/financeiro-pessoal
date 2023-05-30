using FinanceiroPessoal.API;
using FinanceiroPessoal.Dominio.Contratos;
using FinanceiroPessoal.Infraestrutura.Dados.Repositorios;
using FinanceiroPessoal.Infraestrutura.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ICategoriaLancamentoRepositorio, CategoriaLancamentoRepositorio>();
builder.Services.AddScoped<ICartaoCreditoRepositorio, CartaoCreditoRepositorio>();

builder.Services.ConfigurarConexaoBanco(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.IniciarBancoDeDados(builder.Configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
