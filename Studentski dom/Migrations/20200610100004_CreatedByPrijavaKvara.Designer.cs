﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Studentski_dom.Models;

namespace Studentski_dom.Migrations
{
    [DbContext(typeof(NasContext))]
    [Migration("20200610100004_CreatedByPrijavaKvara")]
    partial class CreatedByPrijavaKvara
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Studentski_dom.Models.PrijavaKvara", b =>
                {
                    b.Property<int>("PrijavaKvaraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("HitanKvar")
                        .HasColumnType("bit");

                    b.Property<string>("OpisKvara")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Rijeseno")
                        .HasColumnType("bit");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<string>("TipKvara")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VrijemePrijave")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrijavaKvaraID");

                    b.HasIndex("StudentID");

                    b.ToTable("PrijavaKvara");
                });

            modelBuilder.Entity("Studentski_dom.Models.PrijavaObroka", b =>
                {
                    b.Property<int>("PrijavaObrokaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Rucak")
                        .HasColumnType("bit");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<bool>("Vecera")
                        .HasColumnType("bit");

                    b.Property<bool>("ZaPonijetRucak")
                        .HasColumnType("bit");

                    b.Property<bool>("ZaPonijetVecera")
                        .HasColumnType("bit");

                    b.HasKey("PrijavaObrokaID");

                    b.HasIndex("StudentID");

                    b.ToTable("PrijavaObroka");
                });

            modelBuilder.Entity("Studentski_dom.Models.PrijavaStudenta", b =>
                {
                    b.Property<int>("PrijavaStudentaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdresaStanovanja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrojIndeksa")
                        .HasColumnType("int");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CiklusStudija")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fakultet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fotografija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GodinaStudiranja")
                        .HasColumnType("int");

                    b.Property<string>("ImePrezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrijavaStudentaID");

                    b.ToTable("PrijavaStudenta");
                });

            modelBuilder.Entity("Studentski_dom.Models.Radnik", b =>
                {
                    b.Property<int>("RadnikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImePrezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UposlenikDomaID")
                        .HasColumnType("int");

                    b.Property<int>("UposlenikID")
                        .HasColumnType("int");

                    b.Property<string>("Usluga")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RadnikID");

                    b.HasIndex("UposlenikDomaID");

                    b.ToTable("Radnik");
                });

            modelBuilder.Entity("Studentski_dom.Models.Soba", b =>
                {
                    b.Property<int>("SobaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojSobe")
                        .HasColumnType("int");

                    b.Property<int>("Sprat")
                        .HasColumnType("int");

                    b.Property<bool>("Zauzeta")
                        .HasColumnType("bit");

                    b.HasKey("SobaID");

                    b.ToTable("Soba");
                });

            modelBuilder.Entity("Studentski_dom.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojBonova")
                        .HasColumnType("int");

                    b.Property<int>("PrijavaStudentaID")
                        .HasColumnType("int");

                    b.Property<int>("SobaID")
                        .HasColumnType("int");

                    b.HasKey("StudentID");

                    b.HasIndex("PrijavaStudentaID");

                    b.HasIndex("SobaID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Studentski_dom.Models.UposlenikDoma", b =>
                {
                    b.Property<int>("UposlenikDomaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImePrezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UposlenikDomaID");

                    b.ToTable("UposlenikDoma");
                });

            modelBuilder.Entity("Studentski_dom.Models.PrijavaKvara", b =>
                {
                    b.HasOne("Studentski_dom.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Studentski_dom.Models.PrijavaObroka", b =>
                {
                    b.HasOne("Studentski_dom.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Studentski_dom.Models.Radnik", b =>
                {
                    b.HasOne("Studentski_dom.Models.UposlenikDoma", "UposlenikDoma")
                        .WithMany()
                        .HasForeignKey("UposlenikDomaID");
                });

            modelBuilder.Entity("Studentski_dom.Models.Student", b =>
                {
                    b.HasOne("Studentski_dom.Models.PrijavaStudenta", "PrijavaStudenta")
                        .WithMany()
                        .HasForeignKey("PrijavaStudentaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Studentski_dom.Models.Soba", "Soba")
                        .WithMany()
                        .HasForeignKey("SobaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
