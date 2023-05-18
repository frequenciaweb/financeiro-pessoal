﻿// <auto-generated />
using System;
using FinanceiroPessoal.Infraestrutura.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinanceiroPessoal.Infraestrutura.Migrations
{
    [DbContext(typeof(FinanceiroPessoalContext))]
    partial class FinanceiroPessoalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FinanceiroPessoal.Dominio.Entidades.CartaoCredito", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<bool>("Atualizado")
                        .HasColumnType("boolean")
                        .HasColumnName("atualizado");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("atualizado_em");

                    b.Property<string>("Banco")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("banco");

                    b.Property<int>("Bandeira")
                        .HasColumnType("integer")
                        .HasColumnName("bandeira");

                    b.Property<string>("CVV")
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("codigo_seguranca");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("criado_em");

                    b.Property<bool>("Deletado")
                        .HasColumnType("boolean")
                        .HasColumnName("deletado");

                    b.Property<DateTime?>("DeletadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deletado_em");

                    b.Property<int>("DiaMelhorCompra")
                        .HasColumnType("integer")
                        .HasColumnName("melhor_dia");

                    b.Property<decimal>("Limite")
                        .HasColumnType("numeric")
                        .HasColumnName("limite");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("nome");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)")
                        .HasColumnName("numero_cartao");

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("usuario_alteracao");

                    b.Property<string>("UsuarioDelecao")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("usuario_delecao");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("usuario_inclusao");

                    b.Property<string>("Validade")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("character varying(7)")
                        .HasColumnName("validade");

                    b.Property<int>("Vencimento")
                        .HasColumnType("integer")
                        .HasColumnName("vencimento");

                    b.HasKey("ID");

                    b.ToTable("cartao_credito");
                });

            modelBuilder.Entity("FinanceiroPessoal.Dominio.Entidades.CategoriaLancamento", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<bool>("Atualizado")
                        .HasColumnType("boolean")
                        .HasColumnName("atualizado");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("atualizado_em");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("criado_em");

                    b.Property<bool>("Deletado")
                        .HasColumnType("boolean")
                        .HasColumnName("deletado");

                    b.Property<DateTime?>("DeletadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deletado_em");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("nome");

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("usuario_alteracao");

                    b.Property<string>("UsuarioDelecao")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("usuario_delecao");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("usuario_inclusao");

                    b.HasKey("ID");

                    b.ToTable("lancamento_categorias");
                });

            modelBuilder.Entity("FinanceiroPessoal.Dominio.Entidades.FaturaCartao", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<bool>("Atualizado")
                        .HasColumnType("boolean")
                        .HasColumnName("atualizado");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("atualizado_em");

                    b.Property<Guid>("CartaoCreditoID")
                        .HasColumnType("uuid")
                        .HasColumnName("cartao_credito_id");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("criado_em");

                    b.Property<bool>("Deletado")
                        .HasColumnType("boolean")
                        .HasColumnName("deletado");

                    b.Property<DateTime?>("DeletadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deletado_em");

                    b.Property<Guid>("LancamentoID")
                        .HasColumnType("uuid")
                        .HasColumnName("lancamento_id");

                    b.Property<int>("Situacao")
                        .HasColumnType("integer")
                        .HasColumnName("situacao");

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("usuario_alteracao");

                    b.Property<string>("UsuarioDelecao")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("usuario_delecao");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("usuario_inclusao");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric")
                        .HasColumnName("valor_fatura");

                    b.HasKey("ID");

                    b.HasIndex("CartaoCreditoID");

                    b.HasIndex("LancamentoID");

                    b.ToTable("cartao_credito_fatura");
                });

            modelBuilder.Entity("FinanceiroPessoal.Dominio.Entidades.Lancamento", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<bool>("Atualizado")
                        .HasColumnType("boolean")
                        .HasColumnName("atualizado");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("atualizado_em");

                    b.Property<Guid>("CategoriaLancamentoID")
                        .HasColumnType("uuid")
                        .HasColumnName("categoria_lancamento_id");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("criado_em");

                    b.Property<bool>("Deletado")
                        .HasColumnType("boolean")
                        .HasColumnName("deletado");

                    b.Property<DateTime?>("DeletadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deletado_em");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("descricao");

                    b.Property<int>("FormaPagamento")
                        .HasColumnType("integer")
                        .HasColumnName("forma_pagmento");

                    b.Property<int>("Situacao")
                        .HasColumnType("integer")
                        .HasColumnName("situacao");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer")
                        .HasColumnName("tipo");

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("usuario_alteracao");

                    b.Property<string>("UsuarioDelecao")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("usuario_delecao");

                    b.Property<Guid>("UsuarioID")
                        .HasColumnType("uuid")
                        .HasColumnName("usuario_id");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("usuario_inclusao");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric")
                        .HasColumnName("valor");

                    b.Property<decimal>("ValorAcrescimo")
                        .HasColumnType("numeric")
                        .HasColumnName("valor_acrescimo");

                    b.Property<decimal>("ValorDesconto")
                        .HasColumnType("numeric")
                        .HasColumnName("valor_desconto");

                    b.Property<decimal>("ValorEfetivado")
                        .HasColumnType("numeric")
                        .HasColumnName("valor_efetivado");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("vencimento");

                    b.HasKey("ID");

                    b.HasIndex("CategoriaLancamentoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("lancamentos");
                });

            modelBuilder.Entity("FinanceiroPessoal.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<bool>("Atualizado")
                        .HasColumnType("boolean")
                        .HasColumnName("atualizado");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("atualizado_em");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("criado_em");

                    b.Property<bool>("Deletado")
                        .HasColumnType("boolean")
                        .HasColumnName("deletado");

                    b.Property<DateTime?>("DeletadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deletado_em");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("senha");

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("usuario_alteracao");

                    b.Property<string>("UsuarioDelecao")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("usuario_delecao");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("usuario_inclusao");

                    b.HasKey("ID");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("FinanceiroPessoal.Dominio.Entidades.FaturaCartao", b =>
                {
                    b.HasOne("FinanceiroPessoal.Dominio.Entidades.CartaoCredito", "CartaoCredito")
                        .WithMany("Faturas")
                        .HasForeignKey("CartaoCreditoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceiroPessoal.Dominio.Entidades.Lancamento", "Lancamento")
                        .WithMany()
                        .HasForeignKey("LancamentoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CartaoCredito");

                    b.Navigation("Lancamento");
                });

            modelBuilder.Entity("FinanceiroPessoal.Dominio.Entidades.Lancamento", b =>
                {
                    b.HasOne("FinanceiroPessoal.Dominio.Entidades.CategoriaLancamento", "CategoriaLancamento")
                        .WithMany()
                        .HasForeignKey("CategoriaLancamentoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceiroPessoal.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaLancamento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FinanceiroPessoal.Dominio.Entidades.CartaoCredito", b =>
                {
                    b.Navigation("Faturas");
                });
#pragma warning restore 612, 618
        }
    }
}
