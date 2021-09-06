﻿// <auto-generated />
using System;
using API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210902234607_Grillesalaires")]
    partial class Grillesalaires
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Categorie", b =>
                {
                    b.Property<int>("CategorieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategorieId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Models.Conge", b =>
                {
                    b.Property<int>("CongeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CongeNonPaye")
                        .HasColumnType("bit");

                    b.Property<bool>("ForceMajeur")
                        .HasColumnType("bit");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TauxForceMajeurCompteSolde")
                        .HasMaxLength(10)
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("CongeId");

                    b.ToTable("Conges");
                });

            modelBuilder.Entity("Models.Echelon", b =>
                {
                    b.Property<int>("EchelonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EchelonId");

                    b.ToTable("Echelons");
                });

            modelBuilder.Entity("Models.Grille", b =>
                {
                    b.Property<int>("GrilleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<int>("DureepourPassage")
                        .HasColumnType("int");

                    b.Property<int>("EchelonId")
                        .HasColumnType("int");

                    b.Property<int>("NbreMoisAnciente")
                        .HasColumnType("int");

                    b.Property<int>("RegimeId")
                        .HasColumnType("int");

                    b.Property<int>("Salaire")
                        .HasColumnType("int");

                    b.HasKey("GrilleId");

                    b.ToTable("Grilles");
                });

            modelBuilder.Entity("Models.JoursFerie", b =>
                {
                    b.Property<int>("JoursFerieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Chome")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateAu")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDu")
                        .HasColumnType("datetime2");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Paye")
                        .HasColumnType("bit");

                    b.HasKey("JoursFerieId");

                    b.ToTable("JoursFeries");
                });

            modelBuilder.Entity("Models.Organigramme", b =>
                {
                    b.Property<int>("OrganigrammeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganigrammeId");

                    b.ToTable("Organigrammes");
                });

            modelBuilder.Entity("Models.Qualification", b =>
                {
                    b.Property<int>("QualificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeQualification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QualificationId");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("Models.Regime", b =>
                {
                    b.Property<int>("RegimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RegimeId");

                    b.ToTable("Regimes");
                });

            modelBuilder.Entity("Models.ServiceDepartement", b =>
                {
                    b.Property<int>("ServiceDepartementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceDepartementId");

                    b.ToTable("ServiceDepartements");
                });

            modelBuilder.Entity("Models.TypeContrat", b =>
                {
                    b.Property<int>("TypeContratId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeTypeContrat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CompterAnciente")
                        .HasColumnType("bit");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeContratId");

                    b.ToTable("TypeContrats");
                });

            modelBuilder.Entity("Models.TypePaies", b =>
                {
                    b.Property<int>("TypePaiesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AutreCalcule")
                        .HasColumnType("bit");

                    b.Property<string>("CodePaie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Declarer")
                        .HasColumnType("bit");

                    b.Property<bool>("PECNote")
                        .HasColumnType("bit");

                    b.Property<bool>("PECPointage")
                        .HasColumnType("bit");

                    b.Property<bool>("PECPrime")
                        .HasColumnType("bit");

                    b.HasKey("TypePaiesId");

                    b.ToTable("TypePaie");
                });

            modelBuilder.Entity("Models.TypePrime", b =>
                {
                    b.Property<int>("TypePrimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodePrime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Cotisable")
                        .HasColumnType("bit");

                    b.Property<bool>("Fixe")
                        .HasColumnType("bit");

                    b.Property<bool>("Horaire")
                        .HasColumnType("bit");

                    b.Property<bool>("Imposable")
                        .HasColumnType("bit");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PointageNormal")
                        .HasColumnType("bit");

                    b.Property<bool>("PriseConsideration")
                        .HasColumnType("bit");

                    b.HasKey("TypePrimeId");

                    b.ToTable("TypePrimes");
                });
#pragma warning restore 612, 618
        }
    }
}
