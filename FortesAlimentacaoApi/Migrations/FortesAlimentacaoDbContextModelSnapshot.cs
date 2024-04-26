﻿// <auto-generated />
using System;
using System.Collections.Generic;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FortesAlimentacaoApi.Migrations
{
    [DbContext(typeof(FortesAlimentacaoDbContext))]
    partial class FortesAlimentacaoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_admin");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("status");

                    b.ComplexProperty<Dictionary<string, object>>("Gestor", "FortesAlimentacaoApi.Database.Models.Admin.Gestor#Gestor", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("email");

                            b1.Property<string>("Matricula")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("matricula");

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("nome");

                            b1.Property<string>("Senha")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("senha");
                        });

                    b.HasKey("Id");

                    b.ToTable("tb_admins");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.ControleData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_controle_data");

                    b.Property<bool>("Atipico")
                        .HasColumnType("boolean")
                        .HasColumnName("atipico");

                    b.Property<DateTimeOffset>("DataRefeicao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_refeicao");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.HasKey("Id");

                    b.ToTable("tb_controle_datas");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.Encarregado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_admin");

                    b.ComplexProperty<Dictionary<string, object>>("Gestor", "FortesAlimentacaoApi.Database.Models.Encarregado.Gestor#Gestor", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("email");

                            b1.Property<string>("Matricula")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("matricula");

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("nome");

                            b1.Property<string>("Senha")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("senha");
                        });

                    b.HasKey("Id");

                    b.ToTable("tb_encarregados");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_endereco");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cep");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cidade");

                    b.Property<string>("Complemento")
                        .HasColumnType("text")
                        .HasColumnName("complemento");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("estado");

                    b.Property<int?>("Numero")
                        .HasColumnType("integer")
                        .HasColumnName("numero");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("rua");

                    b.HasKey("Id");

                    b.ToTable("tb_enderecos");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.Equipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_equipe");

                    b.Property<Guid>("GestaoEquipeId")
                        .HasColumnType("uuid")
                        .HasColumnName("gestao_equipe_id");

                    b.Property<Guid>("OperarioID")
                        .HasColumnType("uuid")
                        .HasColumnName("operario_id");

                    b.HasKey("Id");

                    b.HasIndex("GestaoEquipeId");

                    b.HasIndex("OperarioID");

                    b.ToTable("tb_equipes");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.GestaoEquipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_gestao_equipe");

                    b.Property<Guid>("EncarregadoId")
                        .HasColumnType("uuid")
                        .HasColumnName("encarregado_id");

                    b.Property<Guid>("ObraId")
                        .HasColumnType("uuid")
                        .HasColumnName("obra_id");

                    b.Property<string>("Setor")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("setor");

                    b.HasKey("Id");

                    b.HasIndex("EncarregadoId");

                    b.HasIndex("ObraId");

                    b.ToTable("tb_gestao_equipes");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.Obra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_obra");

                    b.Property<DateTimeOffset?>("DataFinal")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_final");

                    b.Property<DateTimeOffset>("DataInicial")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_inicial");

                    b.Property<Guid>("EnderecoId")
                        .HasColumnType("uuid")
                        .HasColumnName("endereco_id");

                    b.Property<string>("Identificacao")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("identificacao");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("tb_obras");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.Operario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_operario");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("matricula");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("Matricula")
                        .IsUnique();

                    b.ToTable("tb_operarios");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.Refeicao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_refeicao");

                    b.Property<bool>("Almoco")
                        .HasColumnType("boolean")
                        .HasColumnName("almoco");

                    b.Property<bool>("Cafe")
                        .HasColumnType("boolean")
                        .HasColumnName("cafe");

                    b.Property<Guid>("ControleDataId")
                        .HasColumnType("uuid")
                        .HasColumnName("controle_data_id");

                    b.Property<Guid>("EquipeId")
                        .HasColumnType("uuid")
                        .HasColumnName("equipe_id");

                    b.Property<bool>("Jantar")
                        .HasColumnType("boolean")
                        .HasColumnName("jantar");

                    b.HasKey("Id");

                    b.HasIndex("ControleDataId");

                    b.HasIndex("EquipeId");

                    b.ToTable("tb_refeicoes");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.Equipe", b =>
                {
                    b.HasOne("FortesAlimentacaoApi.Database.Models.GestaoEquipe", "GestaoEquipe")
                        .WithMany("Equipes")
                        .HasForeignKey("GestaoEquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FortesAlimentacaoApi.Database.Models.Operario", "Operario")
                        .WithMany("Equipes")
                        .HasForeignKey("OperarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GestaoEquipe");

                    b.Navigation("Operario");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.GestaoEquipe", b =>
                {
                    b.HasOne("FortesAlimentacaoApi.Database.Models.Encarregado", "Encarregrado")
                        .WithMany("GestaoEquipes")
                        .HasForeignKey("EncarregadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FortesAlimentacaoApi.Database.Models.Obra", "Obra")
                        .WithMany("GestaoEquipes")
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Encarregrado");

                    b.Navigation("Obra");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.Obra", b =>
                {
                    b.HasOne("FortesAlimentacaoApi.Database.Models.Endereco", "Endereco")
                        .WithMany("Obras")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.Refeicao", b =>
                {
                    b.HasOne("FortesAlimentacaoApi.Database.Models.ControleData", "ControleData")
                        .WithMany("Refeicoes")
                        .HasForeignKey("ControleDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FortesAlimentacaoApi.Database.Models.Equipe", "Equipe")
                        .WithMany("Refeicoes")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ControleData");

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.ControleData", b =>
                {
                    b.Navigation("Refeicoes");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.Encarregado", b =>
                {
                    b.Navigation("GestaoEquipes");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.Endereco", b =>
                {
                    b.Navigation("Obras");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.Equipe", b =>
                {
                    b.Navigation("Refeicoes");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.GestaoEquipe", b =>
                {
                    b.Navigation("Equipes");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.Obra", b =>
                {
                    b.Navigation("GestaoEquipes");
                });

            modelBuilder.Entity("FortesAlimentacaoApi.Database.Models.Operario", b =>
                {
                    b.Navigation("Equipes");
                });
#pragma warning restore 612, 618
        }
    }
}
