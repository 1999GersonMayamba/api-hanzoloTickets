﻿// <auto-generated />
using System;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220409225906_Manutencao#RedePrestadores#Two")]
    partial class ManutencaoRedePrestadoresTwo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.AlocacaoManutencao", b =>
                {
                    b.Property<Guid>("IdAlocacaoManutencao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataManutencao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRegisto")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdManutencao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdAlocacaoManutencao");

                    b.HasIndex("IdManutencao");

                    b.HasIndex("IdUser");

                    b.ToTable("AlocacaoManutencao");
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Property<Guid>("IdDepartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDepartamento");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("Domain.Entities.Dominio", b =>
                {
                    b.Property<Guid>("IdDominio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IdTipoDominio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDominio");

                    b.HasIndex("IdTipoDominio");

                    b.ToTable("Dominio");
                });

            modelBuilder.Entity("Domain.Entities.Equipamento", b =>
                {
                    b.Property<Guid>("IdEquipamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdProjecto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSubFamilia")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdEquipamento");

                    b.HasIndex("IdProjecto");

                    b.HasIndex("IdSubFamilia");

                    b.ToTable("Equipamento");
                });

            modelBuilder.Entity("Domain.Entities.EspecialidadeMedica", b =>
                {
                    b.Property<Guid>("IdEspecialidadeMedica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdDepartamento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUnidade")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdEspecialidadeMedica");

                    b.HasIndex("IdDepartamento");

                    b.HasIndex("IdUnidade");

                    b.ToTable("EspecialidadeMedica");
                });

            modelBuilder.Entity("Domain.Entities.EstadoManutencao", b =>
                {
                    b.Property<Guid>("IdEstadoManutencao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstadoManutencao");

                    b.ToTable("EstadoManutencao");
                });

            modelBuilder.Entity("Domain.Entities.Familia", b =>
                {
                    b.Property<Guid>("IdFamilia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFamilia");

                    b.ToTable("Familia");
                });

            modelBuilder.Entity("Domain.Entities.GrupoSexo", b =>
                {
                    b.Property<Guid>("IdGrupoSexo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGrupoSexo");

                    b.ToTable("GrupoSexo");
                });

            modelBuilder.Entity("Domain.Entities.Manutencao", b =>
                {
                    b.Property<Guid>("IdManutencao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Assunto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataRegisto")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataResolucao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdEstadoManutencao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdOrigemManutencao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdPrestador")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUnidade")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdManutencao");

                    b.HasIndex("IdEstadoManutencao");

                    b.HasIndex("IdOrigemManutencao");

                    b.HasIndex("IdPrestador");

                    b.HasIndex("IdUnidade");

                    b.HasIndex("IdUser");

                    b.ToTable("Manutencao");
                });

            modelBuilder.Entity("Domain.Entities.Municipio", b =>
                {
                    b.Property<Guid>("IdMunicipio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdProvincia")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdMunicipio");

                    b.HasIndex("IdProvincia");

                    b.ToTable("Municipio");
                });

            modelBuilder.Entity("Domain.Entities.NotaUtilizador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUtilizador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("Domain.Entities.OrigemManutencao", b =>
                {
                    b.Property<Guid>("IdOrigemManutencao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdOrigemManutencao");

                    b.ToTable("OrigemManutencao");
                });

            modelBuilder.Entity("Domain.Entities.Prestador", b =>
                {
                    b.Property<Guid>("IdPrestador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdMunicipio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("Nif")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPrestador");

                    b.HasIndex("IdMunicipio");

                    b.ToTable("Prestador");
                });

            modelBuilder.Entity("Domain.Entities.PrestadorUtilizador", b =>
                {
                    b.Property<Guid>("IdPrestadorUtilizador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdEspecialidadeMedica")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPrestador")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdPrestadorUtilizador");

                    b.HasIndex("IdEspecialidadeMedica");

                    b.HasIndex("IdPrestador");

                    b.HasIndex("IdUser");

                    b.ToTable("PrestadorUtilizador");
                });

            modelBuilder.Entity("Domain.Entities.Prioridade", b =>
                {
                    b.Property<Guid>("IdPrioridade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPrioridade");

                    b.ToTable("Prioridade");
                });

            modelBuilder.Entity("Domain.Entities.Projecto", b =>
                {
                    b.Property<Guid>("IdProjecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProjecto");

                    b.ToTable("Projecto");
                });

            modelBuilder.Entity("Domain.Entities.ProjectoManutencao", b =>
                {
                    b.Property<Guid>("IdProjectoManutencao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdManutencao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProjecto")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdProjectoManutencao");

                    b.HasIndex("IdManutencao");

                    b.HasIndex("IdProjecto");

                    b.ToTable("ProjectoManutencao");
                });

            modelBuilder.Entity("Domain.Entities.Provincia", b =>
                {
                    b.Property<Guid>("IdProvincia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProvincia");

                    b.ToTable("Provincia");
                });

            modelBuilder.Entity("Domain.Entities.SubFamilia", b =>
                {
                    b.Property<Guid>("IdSubFamilia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Decricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdFamilia")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdSubFamilia");

                    b.HasIndex("IdFamilia");

                    b.ToTable("SubFamilia");
                });

            modelBuilder.Entity("Domain.Entities.TipoDominio", b =>
                {
                    b.Property<Guid>("IdTipoDominio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoDominio");

                    b.ToTable("TipoDominio");
                });

            modelBuilder.Entity("Domain.Entities.TipoUnidade", b =>
                {
                    b.Property<Guid>("IdTipoUnidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoUnidade");

                    b.ToTable("TipoUnidade");
                });

            modelBuilder.Entity("Domain.Entities.Unidade", b =>
                {
                    b.Property<Guid>("IdUnidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdDominio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdMunicipio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdTipoUnidade")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("Nif")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUnidade");

                    b.HasIndex("IdDominio");

                    b.HasIndex("IdMunicipio");

                    b.HasIndex("IdTipoUnidade");

                    b.ToTable("Unidade");
                });

            modelBuilder.Entity("Domain.Entities.UnidadeUtilizador", b =>
                {
                    b.Property<Guid>("IdUnidadeUtilizador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdEspecialidadeMedica")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUnidade")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdUnidadeUtilizador");

                    b.HasIndex("IdEspecialidadeMedica");

                    b.HasIndex("IdUnidade");

                    b.HasIndex("IdUser");

                    b.ToTable("UnidadeUtilizador");
                });

            modelBuilder.Entity("Domain.Identity.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IdDominio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("IdTipoUtilizador")
                        .HasColumnType("int");

                    b.Property<bool>("IsActivo")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeerID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdTipoUtilizador");

                    b.ToTable("User", "Identity");
                });

            modelBuilder.Entity("Domain.Identity.Entities.GrupoPermissao", b =>
                {
                    b.Property<int>("IdGrupoPermissao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGrupoPermissao");

                    b.ToTable("GruposPermissoes", "Identity");
                });

            modelBuilder.Entity("Domain.Identity.Entities.Permissao", b =>
                {
                    b.Property<int>("IdPermissao")
                        .HasColumnType("int");

                    b.Property<int>("IdGrupoPermissao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPermissao");

                    b.HasIndex("IdGrupoPermissao");

                    b.ToTable("Permissoes", "Identity");
                });

            modelBuilder.Entity("Domain.Identity.Entities.PermissaoUtilizador", b =>
                {
                    b.Property<Guid>("IdPermissaoUtilizador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdPermissao")
                        .HasColumnType("int");

                    b.Property<string>("IdUtilizador")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdPermissaoUtilizador");

                    b.HasIndex("IdPermissao");

                    b.HasIndex("IdUtilizador");

                    b.ToTable("PermissoesUtilizadores", "Identity");
                });

            modelBuilder.Entity("Domain.Identity.Entities.TipoUtilizador", b =>
                {
                    b.Property<int>("IdTipoUtilizador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoUtilizador");

                    b.ToTable("TipoUtilizador", "Identity");
                });

            modelBuilder.Entity("Domain.Entities.AlocacaoManutencao", b =>
                {
                    b.HasOne("Domain.Entities.Manutencao", "Manutencao")
                        .WithMany()
                        .HasForeignKey("IdManutencao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Identity.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("IdUser");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Manutencao");
                });

            modelBuilder.Entity("Domain.Entities.Dominio", b =>
                {
                    b.HasOne("Domain.Entities.TipoDominio", "TipoDominio")
                        .WithMany()
                        .HasForeignKey("IdTipoDominio");

                    b.Navigation("TipoDominio");
                });

            modelBuilder.Entity("Domain.Entities.Equipamento", b =>
                {
                    b.HasOne("Domain.Entities.Projecto", "Projecto")
                        .WithMany()
                        .HasForeignKey("IdProjecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.SubFamilia", "SubFamilia")
                        .WithMany()
                        .HasForeignKey("IdSubFamilia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projecto");

                    b.Navigation("SubFamilia");
                });

            modelBuilder.Entity("Domain.Entities.EspecialidadeMedica", b =>
                {
                    b.HasOne("Domain.Entities.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("IdDepartamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Unidade", "Unidade")
                        .WithMany()
                        .HasForeignKey("IdUnidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("Domain.Entities.Manutencao", b =>
                {
                    b.HasOne("Domain.Entities.EstadoManutencao", "EstadoManutencao")
                        .WithMany()
                        .HasForeignKey("IdEstadoManutencao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.OrigemManutencao", "OrigemManutencao")
                        .WithMany()
                        .HasForeignKey("IdOrigemManutencao");

                    b.HasOne("Domain.Entities.Prestador", "Prestador")
                        .WithMany()
                        .HasForeignKey("IdPrestador");

                    b.HasOne("Domain.Entities.Unidade", "Unidade")
                        .WithMany()
                        .HasForeignKey("IdUnidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Identity.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("IdUser");

                    b.Navigation("ApplicationUser");

                    b.Navigation("EstadoManutencao");

                    b.Navigation("OrigemManutencao");

                    b.Navigation("Prestador");

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("Domain.Entities.Municipio", b =>
                {
                    b.HasOne("Domain.Entities.Provincia", "Provincia")
                        .WithMany()
                        .HasForeignKey("IdProvincia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provincia");
                });

            modelBuilder.Entity("Domain.Entities.Prestador", b =>
                {
                    b.HasOne("Domain.Entities.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("IdMunicipio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("Domain.Entities.PrestadorUtilizador", b =>
                {
                    b.HasOne("Domain.Entities.EspecialidadeMedica", "EspecialidadeMedica")
                        .WithMany()
                        .HasForeignKey("IdEspecialidadeMedica");

                    b.HasOne("Domain.Entities.Prestador", "Prestador")
                        .WithMany()
                        .HasForeignKey("IdPrestador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Identity.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("IdUser");

                    b.Navigation("ApplicationUser");

                    b.Navigation("EspecialidadeMedica");

                    b.Navigation("Prestador");
                });

            modelBuilder.Entity("Domain.Entities.ProjectoManutencao", b =>
                {
                    b.HasOne("Domain.Entities.Manutencao", "Manutencao")
                        .WithMany("ProjectoManutencao")
                        .HasForeignKey("IdManutencao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Projecto", "Projecto")
                        .WithMany()
                        .HasForeignKey("IdProjecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manutencao");

                    b.Navigation("Projecto");
                });

            modelBuilder.Entity("Domain.Entities.SubFamilia", b =>
                {
                    b.HasOne("Domain.Entities.Familia", "Familia")
                        .WithMany()
                        .HasForeignKey("IdFamilia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Familia");
                });

            modelBuilder.Entity("Domain.Entities.Unidade", b =>
                {
                    b.HasOne("Domain.Entities.Dominio", "Dominio")
                        .WithMany()
                        .HasForeignKey("IdDominio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("IdMunicipio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TipoUnidade", "TipoUnidade")
                        .WithMany()
                        .HasForeignKey("IdTipoUnidade");

                    b.Navigation("Dominio");

                    b.Navigation("Municipio");

                    b.Navigation("TipoUnidade");
                });

            modelBuilder.Entity("Domain.Entities.UnidadeUtilizador", b =>
                {
                    b.HasOne("Domain.Entities.EspecialidadeMedica", "EspecialidadeMedica")
                        .WithMany()
                        .HasForeignKey("IdEspecialidadeMedica");

                    b.HasOne("Domain.Entities.Unidade", "Unidade")
                        .WithMany()
                        .HasForeignKey("IdUnidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Identity.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("IdUser");

                    b.Navigation("ApplicationUser");

                    b.Navigation("EspecialidadeMedica");

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("Domain.Identity.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Domain.Identity.Entities.TipoUtilizador", "TipoUtilizador")
                        .WithMany()
                        .HasForeignKey("IdTipoUtilizador");

                    b.Navigation("TipoUtilizador");
                });

            modelBuilder.Entity("Domain.Identity.Entities.Permissao", b =>
                {
                    b.HasOne("Domain.Identity.Entities.GrupoPermissao", "GrupoPermissao")
                        .WithMany("Permissoes")
                        .HasForeignKey("IdGrupoPermissao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoPermissao");
                });

            modelBuilder.Entity("Domain.Identity.Entities.PermissaoUtilizador", b =>
                {
                    b.HasOne("Domain.Identity.Entities.Permissao", "Permissao")
                        .WithMany()
                        .HasForeignKey("IdPermissao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Identity.Entities.ApplicationUser", "Utilizador")
                        .WithMany("Permissoes")
                        .HasForeignKey("IdUtilizador");

                    b.Navigation("Permissao");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("Domain.Entities.Manutencao", b =>
                {
                    b.Navigation("ProjectoManutencao");
                });

            modelBuilder.Entity("Domain.Identity.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Permissoes");
                });

            modelBuilder.Entity("Domain.Identity.Entities.GrupoPermissao", b =>
                {
                    b.Navigation("Permissoes");
                });
#pragma warning restore 612, 618
        }
    }
}
