﻿// <auto-generated />
using Alunos.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alunos.Infra.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210825173045_two")]
    partial class two
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alunos.Domain.Service.Alunos.Entities.AlunosEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RA")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Alunos.Domain.Service.MateriaAlunos.MateriaAlunosEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdAlunos")
                        .HasColumnType("int");

                    b.Property<int>("IdMaterias")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAlunos");

                    b.HasIndex("IdMaterias");

                    b.ToTable("MateriaAlunos");
                });

            modelBuilder.Entity("Alunos.Domain.Service.MateriaProfessores.MateriaProfessoresEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdMaterias")
                        .HasColumnType("int");

                    b.Property<int>("IdProfessores")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMaterias");

                    b.HasIndex("IdProfessores");

                    b.ToTable("MateriaProfessores");
                });

            modelBuilder.Entity("Alunos.Domain.Service.Materias.Entities.MateriasEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("Alunos.Domain.Service.Professores.Entities.ProfessoresEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("Alunos.Domain.Service.MateriaAlunos.MateriaAlunosEntity", b =>
                {
                    b.HasOne("Alunos.Domain.Service.Alunos.Entities.AlunosEntity", "Alunos")
                        .WithMany()
                        .HasForeignKey("IdAlunos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alunos.Domain.Service.Materias.Entities.MateriasEntity", "Materias")
                        .WithMany()
                        .HasForeignKey("IdMaterias")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alunos");

                    b.Navigation("Materias");
                });

            modelBuilder.Entity("Alunos.Domain.Service.MateriaProfessores.MateriaProfessoresEntity", b =>
                {
                    b.HasOne("Alunos.Domain.Service.Materias.Entities.MateriasEntity", "Materias")
                        .WithMany()
                        .HasForeignKey("IdMaterias")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alunos.Domain.Service.Professores.Entities.ProfessoresEntity", "Professores")
                        .WithMany()
                        .HasForeignKey("IdProfessores")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materias");

                    b.Navigation("Professores");
                });
#pragma warning restore 612, 618
        }
    }
}
