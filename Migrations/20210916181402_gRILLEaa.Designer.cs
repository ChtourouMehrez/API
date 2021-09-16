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
    [Migration("20210916181402_gRILLEaa")]
    partial class gRILLEaa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Banque", b =>
                {
                    b.Property<int>("BanqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeBanque")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodePostal")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fax")
                        .HasColumnType("int");

                    b.Property<string>("Paye")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RaisonSociale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Siege")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteWeb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tel")
                        .HasColumnType("int");

                    b.Property<string>("Ville")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BanqueId");

                    b.ToTable("Banques");
                });

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

            modelBuilder.Entity("Models.ChargePatronale", b =>
                {
                    b.Property<int>("ChargePatronaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeChargePatronale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeExpoloitation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Taux")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("ChargePatronaleId");

                    b.ToTable("ChargePatronales");
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

            modelBuilder.Entity("Models.EnfantPersonnel", b =>
                {
                    b.Property<int>("EnfantPersonnelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EnCharge")
                        .HasColumnType("bit");

                    b.Property<bool>("EtudiantNonBoursier")
                        .HasColumnType("bit");

                    b.Property<bool>("Hendicape")
                        .HasColumnType("bit");

                    b.Property<string>("NomPrenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonnelKey")
                        .HasColumnType("int");

                    b.Property<int?>("PersonnelKey1")
                        .HasColumnType("int");

                    b.Property<int?>("PersonnelSessionKey")
                        .HasColumnType("int");

                    b.Property<int>("SessionKey")
                        .HasColumnType("int");

                    b.Property<int?>("SessionKey1")
                        .HasColumnType("int");

                    b.Property<string>("Situation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnfantPersonnelId");

                    b.HasIndex("SessionKey1");

                    b.HasIndex("PersonnelKey1", "PersonnelSessionKey");

                    b.ToTable("EnfantPersonnels");
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

                    b.Property<int>("QualificationId")
                        .HasColumnType("int");

                    b.Property<int>("Salaire")
                        .HasColumnType("int");

                    b.HasKey("GrilleId");

                    b.HasIndex("CategorieId");

                    b.HasIndex("EchelonId");

                    b.HasIndex("QualificationId");

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

            modelBuilder.Entity("Models.ModeReglement", b =>
                {
                    b.Property<int>("ModeReglementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModeReglementId");

                    b.ToTable("ModeReglements");
                });

            modelBuilder.Entity("Models.Nature", b =>
                {
                    b.Property<int>("NatureId")
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

                    b.HasKey("NatureId");

                    b.ToTable("Natures");
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

            modelBuilder.Entity("Models.Personnel", b =>
                {
                    b.Property<int>("PersonnelKey")
                        .HasColumnType("int");

                    b.Property<int>("SessionKey")
                        .HasColumnType("int");

                    b.Property<bool>("Aarrondie")
                        .HasColumnType("bit");

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CCB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<int>("ChargePatronaleId")
                        .HasColumnType("int");

                    b.Property<bool>("ChefFamille")
                        .HasColumnType("bit");

                    b.Property<decimal>("CoefConge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ComplementSalaire")
                        .HasColumnType("decimal(18,3)");

                    b.Property<DateTime>("DateCIN")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateCNSS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateDebut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateDebutContrat")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateEchange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateEmbauche")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateFinContrat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateSortie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EchelonId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EnActivite")
                        .HasColumnType("bit");

                    b.Property<string>("EtatCivil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lieu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatriculeAssuranceSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatriculePersonnel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModeReglementId")
                        .HasColumnType("int");

                    b.Property<string>("Nationalite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NbreParentAcharge")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NonRegle")
                        .HasColumnType("bit");

                    b.Property<string>("NumeroCNSS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganigrammeId")
                        .HasColumnType("int");

                    b.Property<bool>("ParentCharge")
                        .HasColumnType("bit");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QualificationId")
                        .HasColumnType("int");

                    b.Property<int>("RegimeId")
                        .HasColumnType("int");

                    b.Property<bool>("STC")
                        .HasColumnType("bit");

                    b.Property<decimal>("SalaireBase")
                        .HasColumnType("decimal(18,3)");

                    b.Property<string>("Sexe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoumisImpot")
                        .HasColumnType("bit");

                    b.Property<int>("TypeContratId")
                        .HasColumnType("int");

                    b.HasKey("PersonnelKey", "SessionKey");

                    b.HasIndex("CategorieId");

                    b.HasIndex("ChargePatronaleId");

                    b.HasIndex("EchelonId");

                    b.HasIndex("ModeReglementId");

                    b.HasIndex("OrganigrammeId");

                    b.HasIndex("QualificationId");

                    b.HasIndex("RegimeId");

                    b.HasIndex("SessionKey");

                    b.HasIndex("TypeContratId");

                    b.ToTable("Personnels");
                });

            modelBuilder.Entity("Models.PrimePersonnel", b =>
                {
                    b.Property<int>("PrimePersonnelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonnelKey")
                        .HasColumnType("int");

                    b.Property<int?>("PersonnelKey1")
                        .HasColumnType("int");

                    b.Property<int?>("PersonnelSessionKey")
                        .HasColumnType("int");

                    b.Property<int>("TypePrimeId")
                        .HasColumnType("int");

                    b.Property<decimal>("montant")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("PrimePersonnelId");

                    b.HasIndex("TypePrimeId");

                    b.HasIndex("PersonnelKey1", "PersonnelSessionKey");

                    b.ToTable("PrimePersonnels");
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

            modelBuilder.Entity("Models.Session", b =>
                {
                    b.Property<int>("SessionKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Cloturer")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateCloture")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDebutSession")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFinSession")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOuverture")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exercice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoisSession")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroSession")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trimestre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypePaiesId")
                        .HasColumnType("int");

                    b.Property<string>("UserCloture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserOuverture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SessionKey");

                    b.HasIndex("TypePaiesId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Models.TypeCNSS", b =>
                {
                    b.Property<int>("TypeCNSSId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Taux")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("TypeCNSSId");

                    b.ToTable("TypeCNSSs");
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

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("Models.EnfantPersonnel", b =>
                {
                    b.HasOne("Models.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionKey1");

                    b.HasOne("Models.Personnel", "Personnel")
                        .WithMany()
                        .HasForeignKey("PersonnelKey1", "PersonnelSessionKey");

                    b.Navigation("Personnel");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Models.Grille", b =>
                {
                    b.HasOne("Models.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Echelon", "Echelon")
                        .WithMany()
                        .HasForeignKey("EchelonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Qualification", "Qualification")
                        .WithMany()
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Echelon");

                    b.Navigation("Qualification");
                });

            modelBuilder.Entity("Models.Personnel", b =>
                {
                    b.HasOne("Models.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.ChargePatronale", "ChargePatronale")
                        .WithMany()
                        .HasForeignKey("ChargePatronaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Echelon", "Echelon")
                        .WithMany()
                        .HasForeignKey("EchelonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.ModeReglement", "ModeReglement")
                        .WithMany()
                        .HasForeignKey("ModeReglementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Organigramme", "Organigramme")
                        .WithMany()
                        .HasForeignKey("OrganigrammeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Qualification", "Qualification")
                        .WithMany()
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Regime", "Regime")
                        .WithMany()
                        .HasForeignKey("RegimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.TypeContrat", "TypeContrat")
                        .WithMany()
                        .HasForeignKey("TypeContratId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("ChargePatronale");

                    b.Navigation("Echelon");

                    b.Navigation("ModeReglement");

                    b.Navigation("Organigramme");

                    b.Navigation("Qualification");

                    b.Navigation("Regime");

                    b.Navigation("Session");

                    b.Navigation("TypeContrat");
                });

            modelBuilder.Entity("Models.PrimePersonnel", b =>
                {
                    b.HasOne("Models.TypePrime", "TypePrime")
                        .WithMany()
                        .HasForeignKey("TypePrimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Personnel", "Personnel")
                        .WithMany()
                        .HasForeignKey("PersonnelKey1", "PersonnelSessionKey");

                    b.Navigation("Personnel");

                    b.Navigation("TypePrime");
                });

            modelBuilder.Entity("Models.Session", b =>
                {
                    b.HasOne("Models.TypePaies", "TypePaies")
                        .WithMany()
                        .HasForeignKey("TypePaiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypePaies");
                });
#pragma warning restore 612, 618
        }
    }
}
