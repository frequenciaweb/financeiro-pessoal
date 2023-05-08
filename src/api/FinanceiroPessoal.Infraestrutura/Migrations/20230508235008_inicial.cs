using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceiroPessoal.Infraestrutura.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cartao_credito",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    numero_cartao = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    codigo_seguranca = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    validade = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    vencimento = table.Column<int>(type: "integer", nullable: false),
                    melhor_dia = table.Column<int>(type: "integer", nullable: false),
                    limite = table.Column<decimal>(type: "numeric", nullable: false),
                    banco = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    bandeira = table.Column<int>(type: "integer", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletado = table.Column<bool>(type: "boolean", nullable: false),
                    atualizado = table.Column<bool>(type: "boolean", nullable: false),
                    usuario_inclusao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    usuario_alteracao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    usuario_delecao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartao_credito", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lancamento_categorias",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletado = table.Column<bool>(type: "boolean", nullable: false),
                    atualizado = table.Column<bool>(type: "boolean", nullable: false),
                    usuario_inclusao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    usuario_alteracao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    usuario_delecao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lancamento_categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    senha = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletado = table.Column<bool>(type: "boolean", nullable: false),
                    atualizado = table.Column<bool>(type: "boolean", nullable: false),
                    usuario_inclusao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    usuario_alteracao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    usuario_delecao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lancamentos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false),
                    tipo = table.Column<int>(type: "integer", nullable: false),
                    descricao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    valor = table.Column<decimal>(type: "numeric", nullable: false),
                    valor_efetivado = table.Column<decimal>(type: "numeric", nullable: false),
                    valor_desconto = table.Column<decimal>(type: "numeric", nullable: false),
                    valor_acrescimo = table.Column<decimal>(type: "numeric", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    categoria_lancamento_id = table.Column<Guid>(type: "uuid", nullable: false),
                    forma_pagmento = table.Column<int>(type: "integer", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletado = table.Column<bool>(type: "boolean", nullable: false),
                    atualizado = table.Column<bool>(type: "boolean", nullable: false),
                    usuario_inclusao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    usuario_alteracao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    usuario_delecao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lancamentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_lancamentos_lancamento_categorias_categoria_lancamento_id",
                        column: x => x.categoria_lancamento_id,
                        principalTable: "lancamento_categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lancamentos_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cartao_credito_fatura",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    cartao_credito_id = table.Column<Guid>(type: "uuid", nullable: false),
                    valor_fatura = table.Column<decimal>(type: "numeric", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false),
                    lancamento_id = table.Column<Guid>(type: "uuid", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletado = table.Column<bool>(type: "boolean", nullable: false),
                    atualizado = table.Column<bool>(type: "boolean", nullable: false),
                    usuario_inclusao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    usuario_alteracao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    usuario_delecao = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartao_credito_fatura", x => x.id);
                    table.ForeignKey(
                        name: "FK_cartao_credito_fatura_cartao_credito_cartao_credito_id",
                        column: x => x.cartao_credito_id,
                        principalTable: "cartao_credito",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cartao_credito_fatura_lancamentos_lancamento_id",
                        column: x => x.lancamento_id,
                        principalTable: "lancamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartao_credito_fatura_cartao_credito_id",
                table: "cartao_credito_fatura",
                column: "cartao_credito_id");

            migrationBuilder.CreateIndex(
                name: "IX_cartao_credito_fatura_lancamento_id",
                table: "cartao_credito_fatura",
                column: "lancamento_id");

            migrationBuilder.CreateIndex(
                name: "IX_lancamentos_categoria_lancamento_id",
                table: "lancamentos",
                column: "categoria_lancamento_id");

            migrationBuilder.CreateIndex(
                name: "IX_lancamentos_usuario_id",
                table: "lancamentos",
                column: "usuario_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartao_credito_fatura");

            migrationBuilder.DropTable(
                name: "cartao_credito");

            migrationBuilder.DropTable(
                name: "lancamentos");

            migrationBuilder.DropTable(
                name: "lancamento_categorias");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
