using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using LibraryManagement.Shared.Models;

namespace Shared.Data;

public partial class LibraryDbContext : DbContext
{
    public LibraryDbContext()
    {
    }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adherent> Adherents { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Aquisition> Aquisitions { get; set; }

    public virtual DbSet<Auteur> Auteurs { get; set; }

    public virtual DbSet<AuteurSecondaire> AuteurSecondaires { get; set; }

    public virtual DbSet<Categorie> Categories { get; set; }

    public virtual DbSet<CoAuteur> CoAuteurs { get; set; }
    public virtual DbSet<Collection> Collections { get; set; }

    public virtual DbSet<Commande> Commandes { get; set; }

    public virtual DbSet<CopieHistoPenaliteAdherent> CopieHistoPenaliteAdherents { get; set; }

    public virtual DbSet<Diplome> Diplomes { get; set; }

    public virtual DbSet<Discipline> Disciplines { get; set; }

    public virtual DbSet<Editeur> Editeurs { get; set; }

    public virtual DbSet<Etablissement> Etablissements { get; set; }

    public virtual DbSet<EtatAdherent> EtatAdherents { get; set; }

    public virtual DbSet<EtatExemplaire> EtatExemplaires { get; set; }

    public virtual DbSet<Exemplaire> Exemplaires { get; set; }

    public virtual DbSet<Fonction> Fonctions { get; set; }

    public virtual DbSet<Fournisseur> Fournisseurs { get; set; }

    public virtual DbSet<HistoriqueAuth> HistoriqueAuths { get; set; }

    public virtual DbSet<HistoriquePenaliteAdherent> HistoriquePenaliteAdherents { get; set; }

    public virtual DbSet<HistoriquePret> HistoriquePrets { get; set; }

    public virtual DbSet<JoursFery> JoursFeries { get; set; }

    public virtual DbSet<Langue> Langues { get; set; }

    public virtual DbSet<MentionEdition> MentionEditions { get; set; }
    public virtual DbSet<MentionResCollection> MentionResCollections { get; set; }
    public virtual DbSet<MentionResponsabilite> MentionResponsabilites { get; set; }

    public virtual DbSet<MotsCle> MotsCles { get; set; }

    public virtual DbSet<MotsVide> MotsVides { get; set; }

    public virtual DbSet<Newacqui> Newacquis { get; set; }

    public virtual DbSet<Notice> Notices { get; set; }

    public virtual DbSet<NoticeCollection> NoticeCollections { get; set; }

    public virtual DbSet<NoticeDipDisEtab> NoticeDipDisEtabs { get; set; }

    public virtual DbSet<NoticeEdition> NoticeEditions { get; set; }



    public virtual DbSet<NoticeMentionEdition> NoticeMentionEditions { get; set; }

    public virtual DbSet<NoticeTerme> NoticeTermes { get; set; }
    public virtual DbSet<NoticeLangue> NoticeLangues { get; set; }

    public virtual DbSet<NoticeTermeExact> NoticeTermeExacts { get; set; }

    public virtual DbSet<NoticeTheme> NoticeThemes { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<ParametresCatlibPret> ParametresCatlibPrets { get; set; }

    public virtual DbSet<Pay> Pays { get; set; }

    public virtual DbSet<PaysPublication> PaysPublications { get; set; }
    public virtual DbSet<Penalite> Penalites { get; set; }

    public virtual DbSet<PenaliteAdherent> PenaliteAdherents { get; set; }

    public virtual DbSet<PenaliteAdherentTemp> PenaliteAdherentTemps { get; set; }

    public virtual DbSet<Periodicite> Periodicites { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Pret> Prets { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Selection> Selections { get; set; }
    public virtual DbSet<SelectionNotice> SelectionNotices { get; set; }


    public virtual DbSet<SourceArticle> SourceArticles { get; set; }

    public virtual DbSet<TableCdd> TableCdds { get; set; }

    public virtual DbSet<Terme> Termes { get; set; }

    public virtual DbSet<TermeExact> TermeExacts { get; set; }

    public virtual DbSet<Theme> Themes { get; set; }

    public virtual DbSet<TypeNotice> TypeNotices { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<Ville> Villes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=MATAOUI;Password=mataoui123;Data Source=localhost:1521/XEPDB1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("MATAOUI")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Adherent>(entity =>
        {
            entity.HasKey(e => e.IdAdherent).HasName("ADHERENT_PK");

            entity.ToTable("ADHERENT");

            entity.Property(e => e.IdAdherent)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_ADHERENT");

            entity.Property(e => e.EtatAdherent)
                .HasColumnType("NUMBER")
                .HasColumnName("ETAT_ADHERENT");
            entity.Property(e => e.IdCategorie)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ID_CATEGORIE");
            entity.Property(e => e.IdPosition)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_POSITION");
            entity.Property(e => e.Nom)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NOM");
            entity.Property(e => e.Prenom)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("PRENOM");

            entity.HasOne(a => a.Position)
                .WithMany()
                .HasForeignKey(a => a.IdPosition);

            entity.HasOne(a => a.Categorie)
                .WithMany()
                .HasForeignKey(a => a.IdCategorie);

            entity.HasMany(a => a.PenaliteAdherents)
                .WithOne()
                .HasForeignKey(p => p.IdAdherent);


            entity.HasMany(a => a.Prets)
                .WithOne(p => p.Adherent)
                .HasForeignKey(p => p.IdAdherent);

            entity.HasMany(a => a.HistoriquePenaliteAdherents)
                .WithOne(h => h.Adherent)
                .HasForeignKey(h => h.IdAdherent)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
                
            entity.HasMany(a => a.HistoriquePrets)
                .WithOne(a => a.Adherent)
                .HasForeignKey(a => a.IdAdherent);

            entity.HasMany(a => a.Reservations)
                .WithOne(r => r.Adherent)
                .HasForeignKey(r => r.IdAdherent);
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("ADMIN_PK");

            entity.ToTable("ADMIN");

            entity.Property(e => e.IdAdmin)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_ADMIN");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
        });

        modelBuilder.Entity<Aquisition>(entity =>
        {
            entity.HasKey(e => new { e.NumCommande, e.IdExemplaire }).HasName("AQUISITION_PK");

            entity.ToTable("AQUISITION");

            entity.Property(e => e.NumCommande)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("NUM_COMMANDE");
            entity.Property(e => e.IdExemplaire)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ID_EXEMPLAIRE");
            entity.Property(e => e.PrixUnitaire)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PRIX_UNITAIRE");
        });

        modelBuilder.Entity<AuteurSecondaire>(entity =>
        {
            entity.HasKey(e => new { e.IdNotice, e.IdMentionRes, e.IdFonction });

            entity.ToTable("AUTEUR_SECONDAIRE");

            entity.Property(e => e.IdNotice)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_NOTICE");

            entity.Property(e => e.IdMentionRes)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_MENTION_RES");

            entity.Property(e => e.IdFonction)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_FONCTION");

            entity.HasOne(d => d.Notice)
                .WithMany(p => p.AuteurSecondaires)
                .HasForeignKey(d => d.IdNotice);

            entity.HasOne(d => d.MentionResponsabilite)
                .WithMany(p => p.AuteurSecondaires)
                .HasForeignKey(d => d.IdMentionRes);

            entity.HasOne(d => d.Fonction)
                .WithMany(p => p.AuteurSecondaires)
                .HasForeignKey(d => d.IdFonction);
        });
        modelBuilder.Entity<Auteur>(entity =>
        {
            entity.HasKey(e => new { e.IdNotice, e.IdMentionRes }).HasName("AUTEUR_PK");

            entity.ToTable("AUTEUR");

            entity.HasIndex(e => e.IdNotice, "LIEN_138_FK");

            entity.HasIndex(e => e.IdMentionRes, "LIEN_143_FK");

            entity.Property(e => e.IdNotice)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_NOTICE");
            entity.Property(e => e.IdMentionRes)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_MENTION_RES");

        });


        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.HasKey(e => e.IdCategorie).HasName("CATEGORIE_PK");

            entity.ToTable("CATEGORIE");

            entity.Property(e => e.IdCategorie)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_CATEGORIE");
            entity.Property(e => e.DureePret)
                .HasColumnType("NUMBER")
                .HasColumnName("DUREE_PRET");
            entity.Property(e => e.LibelleCategorie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LIBELLE_CATEGORIE");
            entity.Property(e => e.NombreDocument)
                .HasColumnType("NUMBER")
                .HasColumnName("NOMBRE_DOCUMENT");
        });

        modelBuilder.Entity<CoAuteur>(entity =>
        {
            entity.HasKey(e => new { e.IdNotice, e.IdMentionRes }).HasName("COAUTEUR_PK");

            entity.ToTable("CO_AUTEUR");

            entity.HasIndex(e => e.IdNotice, "LIEN_138_FK");

            entity.HasIndex(e => e.IdMentionRes, "LIEN_143_FK");

            entity.Property(e => e.IdNotice)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_NOTICE");
            entity.Property(e => e.IdMentionRes)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_MENTION_RES");

        });
        modelBuilder.Entity<Collection>(entity =>
        {
            entity.HasKey(e => e.IdCollection);

            entity.ToTable("COLLECTION");

            entity.Property(e => e.IdCollection)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_COLLECTION");
            entity.Property(e => e.IssnCollection)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ISSN_COLLECTION");
            entity.Property(e => e.SousTitreCollection)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SOUS_TITRE_COLLECTION");
            entity.Property(e => e.TitreCollection)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TITRE_COLLECTION");


        });

        modelBuilder.Entity<Commande>(entity =>
        {
            entity.HasKey(e => e.NumCommande).HasName("COMMANDE_PK");

            entity.ToTable("COMMANDE");

            entity.Property(e => e.NumCommande)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("NUM_COMMANDE");
            entity.Property(e => e.DateReception)
                .HasColumnType("DATE")
                .HasColumnName("DATE_RECEPTION");
            entity.Property(e => e.IdFournisseur)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_FOURNISSEUR");
            entity.Property(e => e.MontantGlobal)
                .IsUnicode(false)
                .HasColumnName("MONTANT_GLOBAL");
            entity.Property(e => e.Observation)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("OBSERVATION");

            entity.HasOne(d => d.IdFournisseurNavigation).WithMany(p => p.Commandes)
                .HasForeignKey(d => d.IdFournisseur)
                .HasConstraintName("COMMANDE_FOURNISSEUR_FK1");
        });

        modelBuilder.Entity<CopieHistoPenaliteAdherent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("COPIE_HISTO_PENALITE_ADHERENT");

            entity.Property(e => e.DatePenalite)
                .HasColumnType("DATE")
                .HasColumnName("DATE_PENALITE");
            entity.Property(e => e.IdAdherent)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_ADHERENT");
            entity.Property(e => e.NombreJoursPenalite)
                .HasColumnType("NUMBER")
                .HasColumnName("NOMBRE_JOURS_PENALITE");
        });

        modelBuilder.Entity<Diplome>(entity =>
        {
            entity.HasKey(e => e.IdDiplome);

            entity.ToTable("DIPLOME");

            entity.Property(e => e.IdDiplome)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_DIPLOME");
            entity.Property(e => e.Diplome1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DIPLOME");
        });

        modelBuilder.Entity<Discipline>(entity =>
        {
            entity.HasKey(e => e.IdDiscipline);

            entity.ToTable("DISCIPLINE");

            entity.Property(e => e.IdDiscipline)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_DISCIPLINE");
            entity.Property(e => e.Discipline1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DISCIPLINE");
        });

        modelBuilder.Entity<Editeur>(entity =>
        {
            entity.HasKey(e => e.IdEditeur);

            entity.ToTable("EDITEUR");

            entity.Property(e => e.IdEditeur)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_EDITEUR");
            entity.Property(e => e.Editeur1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EDITEUR");
        });

        modelBuilder.Entity<Etablissement>(entity =>
        {
            entity.HasKey(e => e.IdEtablissement);

            entity.ToTable("ETABLISSEMENT");

            entity.Property(e => e.IdEtablissement)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_ETABLISSEMENT");
            entity.Property(e => e.Etablissement1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ETABLISSEMENT");
        });

        modelBuilder.Entity<EtatAdherent>(entity =>
        {
            entity.HasKey(e => e.IdEtat).HasName("ETAT_ADHERENT_PK");

            entity.ToTable("ETAT_ADHERENT");

            entity.Property(e => e.IdEtat)
                .HasColumnName("ID_ETAT")
                .HasConversion(new ValueConverter<int, int>(
                    v => v,
                    v => v
                ))
                .ValueGeneratedNever();

            entity.Property(e => e.DescEtat)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("DESC_ETAT");
        });

        modelBuilder.Entity<EtatExemplaire>(entity =>
        {
            entity.HasKey(e => e.IdEtat).HasName("ETAT_EXEMPLAIRE_PK");

            entity.ToTable("ETAT_EXEMPLAIRE");

            entity.Property(e => e.IdEtat)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_ETAT");
            entity.Property(e => e.LibelleEtat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LIBELLE_ETAT");
        });

        modelBuilder.Entity<Exemplaire>(entity =>
        {
            entity.HasKey(e => e.IdExemplaire).HasName("EXEMPLAIRE_PK");

            entity.ToTable("EXEMPLAIRE");

            entity.Property(e => e.IdExemplaire)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ID_EXEMPLAIRE");
            entity.Property(e => e.Cote)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("COTE");
            entity.Property(e => e.IdEtat)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_ETAT");

            entity.HasOne(d => d.EtatExemplaire)
                .WithMany(p => p.Exemplaires)
                .HasForeignKey(d => d.IdEtat)
                .HasConstraintName("EXEMPLAIRE_ETAT_EXEMPLAIR_FK1");

            entity.HasMany(d => d.Prets)
                .WithOne(d => d.Exemplaire)
                .HasForeignKey(d => d.IdExemplaire);

            entity.HasMany(d => d.HistoriquePrets)
                .WithOne(d => d.Exemplaire)
                .HasForeignKey(d => d.IdExemplaire);
            
            entity.HasOne(e => e.Notice)
                .WithMany(n => n.Exemplaires)
                .HasForeignKey(e => e.Cote)
                .HasPrincipalKey(n => n.Cote)
                .IsRequired(false);
        });

        modelBuilder.Entity<Fonction>(entity =>
        {
            entity.HasKey(e => e.IdFonction);

            entity.ToTable("FONCTION");

            entity.Property(e => e.IdFonction)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_FONCTION");
            entity.Property(e => e.Fonction1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FONCTION");

            entity.Ignore(e => e.Notices);
            entity.Ignore(e => e.MentionResponsabilites);
        });

        modelBuilder.Entity<Fournisseur>(entity =>
        {
            entity.HasKey(e => e.IdFournisseur).HasName("FOURNISSEUR_PK");

            entity.ToTable("FOURNISSEUR");

            entity.Property(e => e.IdFournisseur)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_FOURNISSEUR");
            entity.Property(e => e.Adresse)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("ADRESSE");
            entity.Property(e => e.Mail)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("MAIL");
            entity.Property(e => e.NumTel)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("NUM_TEL");
            entity.Property(e => e.RaisonSociale)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("RAISON_SOCIALE");
        });

        modelBuilder.Entity<HistoriqueAuth>(entity =>
        {
            entity.HasKey(e => new { e.IdAdmin, e.DateOperation, e.IdAdherent }).HasName("HISTORIQUE_AUTH_PK");

            entity.ToTable("HISTORIQUE_AUTH");

            entity.Property(e => e.IdAdmin)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_ADMIN");
            entity.Property(e => e.DateOperation)
                .HasPrecision(6)
                .HasColumnName("DATE_OPERATION");
            entity.Property(e => e.IdAdherent)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_ADHERENT");
            entity.Property(e => e.IdTypeOperation)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_TYPE_OPERATION");

            entity.HasOne(d => d.IdAdherentNavigation).WithMany(p => p.HistoriqueAuths)
                .HasForeignKey(d => d.IdAdherent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("HISTORIQUE_AUTH_ADHERENT_FK1");

            entity.HasOne(d => d.IdTypeOperationNavigation).WithMany(p => p.HistoriqueAuths)
                .HasForeignKey(d => d.IdTypeOperation)
                .HasConstraintName("HISTORIQUE_AUTH_OPERATION_FK1");
        });

        modelBuilder.Entity<HistoriquePenaliteAdherent>(entity =>
        {
            entity.HasKey(e => new { e.IdAdherent, e.DatePenalite }).HasName("HISTORIQUE_PENALITE_ADHER_PK");

            entity.ToTable("HISTORIQUE_PENALITE_ADHERENT");

            entity.Property(e => e.IdAdherent)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_ADHERENT");

            entity.Property(e => e.DatePenalite)
                .HasColumnType("DATE")
                .HasColumnName("DATE_PENALITE");

            entity.Property(e => e.NombreJoursPenalite)
                .HasColumnType("NUMBER")
                .HasColumnName("NOMBRE_JOURS_PENALITE");
        });

        modelBuilder.Entity<HistoriquePret>(entity =>
        {
            entity.HasKey(hp => new { hp.IdAdherent, hp.IdExemplaire, hp.DatePret });

            entity.ToTable("HISTORIQUE_PRET");

            entity.Property(e => e.DatePret)
                .HasColumnType("DATE")
                .HasColumnName("DATE_PRET");
            entity.Property(e => e.DateRetour)
                .HasColumnType("DATE")
                .HasColumnName("DATE_RETOUR");
            entity.Property(e => e.IdAdherent)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_ADHERENT");
            entity.Property(e => e.IdExemplaire)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ID_EXEMPLAIRE");

            // entity.HasOne<Exemplaire>()
            //     .WithMany(e => e.HistoriquePrets)
            //     .HasForeignKey(hp => hp.IdExemplaire);

            // entity.HasOne<Adherent>()
            //    .WithMany(e => e.HistoriquePrets)
            //    .HasForeignKey(hp => hp.IdAdherent);

        });

        modelBuilder.Entity<JoursFery>(entity =>
        {
            entity.HasKey(e => e.DateJourFerie).HasName("JOURS_FERIES_PK");

            entity.ToTable("JOURS_FERIES");

            entity.Property(e => e.DateJourFerie)
                .HasColumnType("DATE")
                .HasColumnName("DATE_JOUR_FERIE");
        });

        modelBuilder.Entity<Langue>(entity =>
        {
            entity.HasKey(e => e.IdLangue);

            entity.ToTable("LANGUE");

            entity.Property(e => e.IdLangue)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_LANGUE");
            entity.Property(e => e.Langue1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LANGUE");
        });

        modelBuilder.Entity<MentionResCollection>(entity =>
        {
            entity.HasKey(e => new { e.IdCollection, e.IdMentionRes }).HasName("MENTION_RES_COLLECTION_PK");

            entity.ToTable("MENTION_RES_COLLECTION");

            entity.HasIndex(e => e.IdCollection, "LIEN_163_FK");

            entity.HasIndex(e => e.IdMentionRes, "LIEN_143_FK");

            entity.Property(e => e.IdCollection)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_COLLECTION");
            entity.Property(e => e.IdMentionRes)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_MENTION_RES");

        });

        modelBuilder.Entity<MentionEdition>(entity =>
        {
            entity.HasKey(e => e.IdNotice).HasName("MENTION_EDITION_PK");

            entity.ToTable("MENTION_EDITION");

            entity.Property(e => e.IdNotice)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_NOTICE");
            entity.Property(e => e.Mention)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MENTION");
        });

        modelBuilder.Entity<MentionResponsabilite>(entity =>
        {
            entity.HasKey(e => e.IdMentionRes);

            entity.ToTable("MENTION_RESPONSABILITE");

            entity.HasIndex(e => e.AutrePartie, "INDEX_AUTRE_PARTIE_AUTEUR");

            entity.HasIndex(e => e.Nom, "INDEX_NOM_AUTEUR");

            entity.Property(e => e.IdMentionRes)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_MENTION_RES");
            entity.Property(e => e.AutrePartie)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("AUTRE_PARTIE");
            entity.Property(e => e.Collectivite)
                .HasDefaultValueSql("0\n   ")
                .HasColumnType("NUMBER")
                .HasColumnName("COLLECTIVITE");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NOM");


            entity.HasMany(e => e.Collections)
                    .WithMany(e => e.MentionResponsabilites)
                    .UsingEntity<MentionResCollection>();

            entity.HasMany(e => e.AuteurNotices)
                    .WithMany(e => e.Auteurs)
                    .UsingEntity<Auteur>();


            entity.HasMany(e => e.CoAuteurNotices)
                .WithMany(e => e.CoAuteurs)
                .UsingEntity<CoAuteur>();

            entity.HasMany(e => e.AuteurSecondaireNotices)
                .WithMany(e => e.AuteurSecondairesMentionRes)
                .UsingEntity<AuteurSecondaire>();
        });

        modelBuilder.Entity<MotsCle>(entity =>
        {
            entity.HasKey(e => e.IdMotCle);

            entity.ToTable("MOTS_CLES");

            entity.Property(e => e.IdMotCle)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_MOT_CLE");
            entity.Property(e => e.IsIndexed)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("IS_INDEXED");
            entity.Property(e => e.MotCle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MOT_CLE");
        });

        modelBuilder.Entity<MotsVide>(entity =>
        {
            entity.HasKey(e => e.MotVide);

            entity.ToTable("MOTS_VIDES");

            entity.Property(e => e.MotVide)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MOT_VIDE");
        });

        modelBuilder.Entity<Newacqui>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NEWACQUIS");

            entity.Property(e => e.IdNotice)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_NOTICE");
        });

        modelBuilder.Entity<Notice>(entity =>
        {
            entity.HasKey(e => e.IdNotice);
            entity.ToTable("NOTICE");
            
            entity.HasIndex(e => e.Date1erPub, "INDEX_DATE_1ER_PUB");
            entity.HasIndex(e => e.IdPeriodicite, "NOTICE_PERIODICITE_FK");
            entity.HasIndex(e => e.IdSourceArticle, "NOTICE_SOURCE_ARTICLE_FK");
            entity.HasIndex(e => e.IdType, "TYPE_NOTICE_FK");

            entity.Property(e => e.IdNotice)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_NOTICE");
            entity.Property(e => e.Accessibilite)
                .HasMaxLength(1).IsUnicode(false)
                .HasDefaultValueSql("1")
                .HasColumnName("ACCESSIBILITE");
            entity.Property(e => e.Cdd)
                .HasMaxLength(15).IsUnicode(false)
                .HasColumnName("CDD");
            entity.Property(e => e.CollationAutresCarMat)
                .HasMaxLength(50).IsUnicode(false)
                .HasColumnName("COLLATION_AUTRES_CAR_MAT");
            entity.Property(e => e.CollationFormat)
                .HasMaxLength(50).IsUnicode(false)
                .HasColumnName("COLLATION_FORMAT");
            entity.Property(e => e.CollationImpMaterielle)
                .HasMaxLength(50).IsUnicode(false)
                .HasColumnName("COLLATION_IMP_MATERIELLE");
            entity.Property(e => e.Cote)
                .HasMaxLength(25).IsUnicode(false)
                .HasColumnName("COTE");
            entity.Property(e => e.Date1erPub)
                .HasMaxLength(50).IsUnicode(false)
                .HasColumnName("DATE_1ER_PUB");
            entity.Property(e => e.ExemplaireExiste)
                .HasDefaultValueSql("0")
                .HasColumnType("NUMBER")
                .HasColumnName("EXEMPLAIRE_EXISTE");
            entity.Property(e => e.IdPeriodicite)
                .HasMaxLength(2).IsUnicode(false)
                .HasColumnName("ID_PERIODICITE");
            entity.Property(e => e.IdSourceArticle)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_SOURCE_ARTICLE");
            entity.Property(e => e.IdType)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_TYPE");
            entity.Property(e => e.IsIndexed)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("IS_INDEXED");
            entity.Property(e => e.Isbn)
                .HasMaxLength(255).IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.IssnNotice)
                .HasMaxLength(50).IsUnicode(false)
                .HasColumnName("ISSN_NOTICE");
            entity.Property(e => e.Localisation)
                .HasMaxLength(255).IsUnicode(false)
                .HasColumnName("LOCALISATION");
            entity.Property(e => e.NPartie)
                .HasMaxLength(255).IsUnicode(false)
                .HasColumnName("N_PARTIE");
            entity.Property(e => e.NbrExemple)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("NBR_EXEMPLE");
            entity.Property(e => e.NoteGenerale)
                .HasMaxLength(255).IsUnicode(false)
                .HasColumnName("NOTE_GENERALE");
            entity.Property(e => e.NumeroVol)
                .HasMaxLength(50).IsUnicode(false)
                .HasColumnName("NUMERO_VOL");
            entity.Property(e => e.Resume)
                .HasMaxLength(2048).IsUnicode(false)
                .HasColumnName("RESUME");
            entity.Property(e => e.SousTitre)
                .HasMaxLength(512).IsUnicode(false)
                .HasColumnName("SOUS_TITRE");
            entity.Property(e => e.TitreCle)
                .HasMaxLength(255).IsUnicode(false)
                .HasColumnName("TITRE_CLE");
            entity.Property(e => e.TitrePropre)
                .HasMaxLength(512).IsUnicode(false)
                .HasColumnName("TITRE_PROPRE");
            entity.Property(e => e.TypeDonneesResourceElec)
                .HasMaxLength(256).IsUnicode(false)
                .HasColumnName("TYPE_DONNEES_RESOURCE_ELEC");

            entity.HasAlternateKey(n => n.Cote);

            // ── FK vers tables de référence ──────────────────────────────────────────

            // One-To-Many , T has Many Notice
            entity.HasOne(a => a.TableCdd)
                .WithMany(t => t.Notices)
                .HasForeignKey(a => a.Cdd)
                .HasConstraintName("NOTICE_TABLE_CDD_FK1")
                .IsRequired(false);

            entity.HasOne(d => d.Periodicite)
                .WithMany(p => p.Notices)
                .HasForeignKey(d => d.IdPeriodicite)
                .HasConstraintName("FK_NOTICE_ASSOC_513_PERIODIC")
                .IsRequired(false); ;

            entity.HasOne(d => d.SourceArticle)
                .WithMany(p => p.Notices)
                .HasForeignKey(d => d.IdSourceArticle)
                .HasConstraintName("FK_NOTICE_NOTICE_SO_SOURCE_A");

            entity.HasOne(d => d.TypeNotice)
                .WithMany(p => p.Notices)
                .HasForeignKey(d => d.IdType)
                .HasConstraintName("FK_NOTICE_ASSOC_379_TYPE_NOT");

            // one to one
            entity.HasOne(d => d.MentionEdition)
                .WithOne(p => p.Notice)
                .HasForeignKey<MentionEdition>(e => e.IdNotice)
                .IsRequired(false);

            entity.HasOne(d => d.NoticeMentionEdition)
               .WithOne(p => p.Notice)
               .HasForeignKey<NoticeMentionEdition>(e => e.IdNotice)
               .IsRequired(false);


            // one to many : Notice Has many T


            entity.HasMany(d => d.NoticeEditions)
                .WithOne(p => p.Notice)
                .HasForeignKey(d => d.IdNotice)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_NOTICE_E_LIEN_900_NOTICE");

            entity.HasMany(e => e.Termes)
                .WithMany(e => e.Notices)
                .UsingEntity<NoticeTerme>(
                    j =>
                    {
                        j.HasKey(nt => new { nt.IdNotice, nt.IdTerme });
                        j.ToTable("NOTICE_TERME");

                        j.HasOne(nt => nt.Notice)
                        .WithMany()
                        .HasForeignKey(nt => nt.IdNotice);

                        j.HasOne(nt => nt.Terme)
                        .WithMany()
                        .HasForeignKey(nt => nt.IdTerme);

                        j.Property(nt => nt.PoidsTerme)
                        .HasColumnName("POIDS_TERME")
                        .HasColumnType("NUMBER(38)")
                        .HasPrecision(38, 0);
                    }
                );
            entity.HasMany(e => e.TermeExacts)
                .WithMany(e => e.Notices)
                .UsingEntity<NoticeTermeExact>(
                    j =>
                    {
                        j.HasKey(nt => new { nt.IdNotice, nt.IdTermeExact });
                        j.ToTable("NOTICE_TERME_EXACT");

                        j.HasOne(nt => nt.Notice)
                        .WithMany()
                        .HasForeignKey(nt => nt.IdNotice);

                        j.HasOne(nt => nt.TermeExact)
                        .WithMany()
                        .HasForeignKey(nt => nt.IdTermeExact);

                        j.Property(nt => nt.PoidsTerme)
                        .HasColumnName("POIDS_TERME")
                        .HasColumnType("NUMBER(38)")
                        .HasPrecision(38, 0)
                        .IsRequired(false);
                    }
                );
            entity.HasMany(e => e.Langues)
                .WithMany(e => e.Notices)
                .UsingEntity<NoticeLangue>(
                    j =>
                    {
                        j.HasKey(nt => new { nt.IdNotice, nt.IdLangue });
                        j.ToTable("NOTICE_LANGUE");

                        j.HasOne(nt => nt.Notice)
                        .WithMany()
                        .HasForeignKey(nt => nt.IdNotice);

                        j.HasOne(nt => nt.Langue)
                        .WithMany()
                        .HasForeignKey(nt => nt.IdLangue);

                    }
                );
            entity.HasMany(e => e.MotsCles)
                .WithMany(e => e.Notices)
                .UsingEntity<NoticeMotCle>(
                    j =>
                    {
                        j.HasKey(nt => new { nt.IdNotice, nt.IdMotCle });
                        j.ToTable("NOTICE_MOT_CLE");

                        j.HasOne(nt => nt.Notice)
                        .WithMany()
                        .HasForeignKey(nt => nt.IdNotice);

                        j.HasOne(nt => nt.MotsCle)
                        .WithMany()
                        .HasForeignKey(nt => nt.IdMotCle);

                    }
                );
            entity.HasMany(e => e.Selections)
                .WithMany(e => e.Notices)
                .UsingEntity<SelectionNotice>(
                    j =>
                    {
                        j.HasKey(nt => new { nt.IdNotice, nt.IdSelection });
                        j.ToTable("SELECTION_NOTICE");

                        j.HasOne(nt => nt.Notice)
                        .WithMany()
                        .HasForeignKey(nt => nt.IdNotice);

                        j.HasOne(nt => nt.Selection)
                        .WithMany()
                        .HasForeignKey(nt => nt.IdSelection);

                    }
                );
            entity.HasMany(e => e.Pays)
                .WithMany(e => e.Notices)
                .UsingEntity<PaysPublication>(
                    j =>
                    {
                        j.HasKey(nt => new { nt.IdNotice, nt.IdPays });
                        j.ToTable("PAYS_PUBLICATION");

                        j.HasOne(nt => nt.Notice)
                        .WithMany()
                        .HasForeignKey(nt => nt.IdNotice);

                        j.HasOne(nt => nt.Pay)
                        .WithMany()
                        .HasForeignKey(nt => nt.IdPays);
                    }
                );
            entity.HasMany(e => e.Collections)
               .WithMany(e => e.Notices)
               .UsingEntity<NoticeCollection>(
                   j =>
                   {
                       j.HasKey(nt => new { nt.IdNotice, nt.IdCollection });
                       j.ToTable("NOTICE_TERME_EXACT");

                       j.HasOne(nt => nt.Notice)
                       .WithMany()
                       .HasForeignKey(nt => nt.IdNotice);

                       j.HasOne(nt => nt.Collection)
                       .WithMany()
                       .HasForeignKey(nt => nt.IdCollection);

                       j.Property(nt => nt.NumeroDansCollection)
                       .HasColumnName("NUMERO_DANS_COLLECTION")
                       .HasColumnType("VARCHAR2(10)")
                       .IsRequired(false);
                   }
               );

               


        });

        modelBuilder.Entity<NoticeCollection>(entity =>
        {
            entity.HasKey(e => new { e.IdNotice, e.IdCollection });

            entity.ToTable("NOTICE_COLLECTION");

            entity.HasIndex(e => e.IdNotice, "LIEN_144_FK");

            entity.HasIndex(e => e.IdCollection, "LIEN_145_FK");

            entity.Property(e => e.IdNotice)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_NOTICE");
            entity.Property(e => e.IdCollection)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_COLLECTION");
            entity.Property(e => e.NumeroDansCollection)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NUMERO_DANS_COLLECTION");
        });

        modelBuilder.Entity<NoticeDipDisEtab>(entity =>
        {
            entity.HasKey(e => e.IdNotice);

            entity.ToTable("NOTICE_DIP_DIS_ETAB");

            entity.HasIndex(e => e.AnneSoutenance, "INDEX_DATE_SOUTENANCE");

            entity.HasIndex(e => e.IdDiplome, "LIEN_155_FK");

            entity.HasIndex(e => e.IdEtablissement, "LIEN_156_FK");

            entity.HasIndex(e => e.IdDiscipline, "LIEN_157_FK");

            entity.Property(e => e.IdNotice)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_NOTICE");
            entity.Property(e => e.AnneSoutenance)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ANNE_SOUTENANCE");
            entity.Property(e => e.IdDiplome)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_DIPLOME");
            entity.Property(e => e.IdDiscipline)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_DISCIPLINE");
            entity.Property(e => e.IdEtablissement)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_ETABLISSEMENT");
            entity.Property(e => e.NoteTexte)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NOTE_TEXTE");

            entity.HasOne(d => d.Notice)
                .WithOne(p => p.NoticeDipDisEtab)
                .HasForeignKey<NoticeDipDisEtab>(e => e.IdNotice)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            entity.HasOne(d => d.Diplome)
                .WithMany(p => p.NoticeDipDisEtabs)
                .HasForeignKey(e => e.IdDiplome)
                .IsRequired();
            entity.HasOne(d => d.Etablissement)
                .WithMany(p => p.NoticeDipDisEtabs)
                .HasForeignKey(e => e.IdEtablissement)
                .IsRequired();

            entity.HasOne(d => d.Discipline)
                .WithMany(p => p.NoticeDipDisEtabs)
                .HasForeignKey(e => e.IdDiscipline)
                .IsRequired();
        });

        modelBuilder.Entity<NoticeEdition>(entity =>
        {
            entity.HasKey(e => new { e.IdVille, e.IdEditeur, e.IdNotice });

            entity.ToTable("NOTICE_EDITION");

            entity.HasIndex(e => e.DateEdition, "INDEX_DATE_EDITION");

            entity.HasIndex(e => e.IdVille, "LIEN_898_FK");

            entity.HasIndex(e => e.IdEditeur, "LIEN_899_FK");

            entity.HasIndex(e => e.IdNotice, "LIEN_900_FK");

            entity.Property(e => e.IdVille)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_VILLE");
            entity.Property(e => e.IdEditeur)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_EDITEUR");
            entity.Property(e => e.IdNotice)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_NOTICE");
            entity.Property(e => e.DateEdition)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("DATE_EDITION");

            entity.HasOne(d => d.Editeur)
                .WithMany(p => p.NoticeEditions)
                .HasForeignKey(d => d.IdEditeur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NOTICE_E_LIEN_899_EDITEUR");

            entity.HasOne(d => d.Notice)
                .WithMany(p => p.NoticeEditions)
                .HasForeignKey(d => d.IdNotice)
                .HasConstraintName("FK_NOTICE_E_LIEN_900_NOTICE");

            entity.HasOne(d => d.Ville)
                .WithMany(p => p.NoticeEditions)
                .HasForeignKey(d => d.IdVille)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NOTICE_E_LIEN_898_VILLE");
        });

        modelBuilder.Entity<NoticeLangue>(entity =>
        {
            entity.HasKey(e => e.IdNotice).HasName("PK_NOTICE_LANGUE");
            entity.ToTable("NOTICE_LANGUE");

            entity.Property(e => e.IdNotice)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_NOTICE");

            entity.Property(e => e.IdLangue)
                .HasMaxLength(3)
                .HasColumnName("ID_LANGUE");

        });
        modelBuilder.Entity<NoticeMentionEdition>(entity =>
        {
            entity.HasKey(e => e.IdNotice).HasName("NOTICE_MENTION_EDITION_PK");

            entity.ToTable("NOTICE_MENTION_EDITION");

            entity.Property(e => e.IdNotice)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_NOTICE");
            entity.Property(e => e.MentionEdition)
                .HasMaxLength(2048)
                .IsUnicode(false)
                .HasColumnName("MENTION_EDITION");


        });

        modelBuilder.Entity<NoticeTerme>(entity =>
        {
            entity.HasKey(e => new { e.IdTerme, e.IdNotice });

            entity.ToTable("NOTICE_TERME");

            entity.HasIndex(e => e.IdTerme, "LIEN_507_FK");

            entity.HasIndex(e => e.IdNotice, "LIEN_508_FK");

            entity.Property(e => e.IdTerme)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_TERME");
            entity.Property(e => e.IdNotice)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_NOTICE");
            entity.Property(e => e.PoidsTerme)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("POIDS_TERME");

        });

        modelBuilder.Entity<NoticeTermeExact>(entity =>
        {
            entity.HasKey(e => new { e.IdTermeExact, e.IdNotice }).HasName("NOTICE_TERME_EXACT_PK");

            entity.ToTable("NOTICE_TERME_EXACT");

            entity.Property(e => e.IdTermeExact)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_TERME_EXACT");
            entity.Property(e => e.IdNotice)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_NOTICE");
            entity.Property(e => e.PoidsTerme)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("POIDS_TERME");
        });

        modelBuilder.Entity<NoticeTheme>(entity =>
        {
            entity.HasKey(e => new { e.IdNotice, e.IdTheme });

            entity.ToTable("NOTICE_THEME");

            entity.HasIndex(e => e.IdNotice, "LIEN_150_FK");

            entity.HasIndex(e => e.IdTheme, "LIEN_151_FK");

            entity.Property(e => e.IdNotice)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_NOTICE");
            entity.Property(e => e.IdTheme)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ID_THEME");
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasKey(e => e.IdOperation).HasName("OPERATION_PK");

            entity.ToTable("OPERATION");

            entity.Property(e => e.IdOperation)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_OPERATION");
            entity.Property(e => e.Operation1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OPERATION");
        });

        modelBuilder.Entity<ParametresCatlibPret>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PARAMETRES_CATLIB_PRET");

            entity.Property(e => e.DureeReservation)
                .HasColumnType("NUMBER")
                .HasColumnName("DUREE_RESERVATION");
        });

        modelBuilder.Entity<Pay>(entity =>
        {
            entity.HasKey(e => e.IdPays);

            entity.ToTable("PAYS");

            entity.Property(e => e.IdPays)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_PAYS");
            entity.Property(e => e.Pays)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PAYS");
        });
        modelBuilder.Entity<PaysPublication>(entity =>
        {
            entity.HasKey(e => new { e.IdNotice, e.IdPays });

            entity.ToTable("PAYS_PUBLICATION");  // ← nom correct selon le DDL Oracle

            entity.HasIndex(e => e.IdNotice, "LIEN_148_FK");
            entity.HasIndex(e => e.IdPays, "LIEN_149_FK");

            entity.Property(e => e.IdNotice)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_NOTICE");
            entity.Property(e => e.IdPays)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_PAYS");
        });
        modelBuilder.Entity<Penalite>(entity =>
        {
            entity.HasKey(e => new { e.IdCategorie, e.JoursRetard }).HasName("PENALITE_PK");

            entity.ToTable("PENALITE");

            entity.Property(e => e.IdCategorie)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_CATEGORIE");
            entity.Property(e => e.JoursRetard)
                .HasColumnType("NUMBER")
                .HasColumnName("JOURS_RETARD");
            entity.Property(e => e.NombreJoursRetard)
                .HasColumnType("NUMBER")
                .HasColumnName("NOMBRE_JOURS_RETARD");

            entity.HasOne(p => p.Categorie)
                .WithMany(c => c.Penalites)
                .HasForeignKey(p => p.IdCategorie)
                .IsRequired(false);
        });

        modelBuilder.Entity<PenaliteAdherent>(entity =>
        {
            entity.HasKey(e => e.IdAdherent).HasName("PENALITE_ADHERENT_PK");

            entity.ToTable("PENALITE_ADHERENT");

            entity.Property(e => e.IdAdherent)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_ADHERENT");
            entity.Property(e => e.DatePenalite)
                .HasColumnType("DATE")
                .HasColumnName("DATE_PENALITE");
            entity.Property(e => e.NombreJoursPenalite)
                .HasDefaultValueSql("0\n   ")
                .HasColumnType("NUMBER")
                .HasColumnName("NOMBRE_JOURS_PENALITE");
            
            entity.HasOne(p => p.Adherent)
                    .WithMany(a => a.PenaliteAdherents)
                    .HasForeignKey(p => p.IdAdherent)
                    .IsRequired(false);
        });

        modelBuilder.Entity<PenaliteAdherentTemp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PENALITE_ADHERENT_TEMP");

            entity.Property(e => e.DatePenalite)
                .HasColumnType("DATE")
                .HasColumnName("DATE_PENALITE");
            entity.Property(e => e.IdAdherent)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_ADHERENT");
            entity.Property(e => e.NombreJoursPenalite)
                .HasColumnType("NUMBER")
                .HasColumnName("NOMBRE_JOURS_PENALITE");
        });

        modelBuilder.Entity<Periodicite>(entity =>
        {
            entity.HasKey(e => e.IdPeriodicite);

            entity.ToTable("PERIODICITE");

            entity.Property(e => e.IdPeriodicite)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ID_PERIODICITE");
            entity.Property(e => e.Periodicite1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PERIODICITE");

            entity.HasMany(e => e.Notices)
                .WithOne(e => e.Periodicite)
                .HasForeignKey(e => e.IdPeriodicite)
                .HasConstraintName("FK_NOTICE_ASSOC_513_PERIODIC")
                .IsRequired(false);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.IdPosition).HasName("POSITION_PK");

            entity.ToTable("POSITION");

            entity.Property(e => e.IdPosition)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_POSITION");
            entity.Property(e => e.LibellePosition)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LIBELLE_POSITION");
        });

        modelBuilder.Entity<Pret>(entity =>
        {
            entity.HasKey(e => new { e.IdAdherent, e.IdExemplaire, e.DatePret }).HasName("PRET_PK");

            entity.ToTable("PRET","MATAOUI");

            entity.Property(e => e.IdAdherent)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_ADHERENT");
            entity.Property(e => e.IdExemplaire)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ID_EXEMPLAIRE");
            entity.Property(e => e.DatePret)
                .HasColumnType("DATE")
                .HasColumnName("DATE_PRET");

            entity.Property(e => e.EtatDuree)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'F'\n   ")
                .HasColumnName("ETAT_DUREE");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => new { e.IdAdherent, e.Cote, e.HeureReservation }).HasName("RESERVATION_PK");

            entity.ToTable("RESERVATION");

            entity.Property(e => e.IdAdherent)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_ADHERENT");
            entity.Property(e => e.Cote)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("COTE");
            entity.Property(e => e.HeureReservation)
                .HasPrecision(6)
                .HasColumnName("HEURE_RESERVATION");

            entity.HasOne(r => r.Notice)
                .WithMany(n => n.Reservations)
                .HasForeignKey(e => e.Cote)
                .HasPrincipalKey(n => n.Cote)
                .IsRequired(false);

        });

        modelBuilder.Entity<Selection>(entity =>
        {
            entity.HasKey(e => e.IdSelection).HasName("SELECTION_PK");

            entity.ToTable("SELECTION");

            entity.Property(e => e.IdSelection)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_SELECTION");
            entity.Property(e => e.LibelleSelection)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LIBELLE_SELECTION");


        });

        modelBuilder.Entity<SelectionNotice>(entity =>
       {
           entity.HasKey(e => new { e.IdNotice, e.IdSelection });

           entity.ToTable("SELECTION_NOTICE");

           entity.HasIndex(e => e.IdNotice, "SELECTION_NOTICE_PK");

           entity.Property(e => e.IdNotice)
               .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
               .HasColumnName("ID_NOTICE");
           entity.Property(e => e.IdSelection)
               .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
               .HasColumnName("ID_SELECTION");

       });
        modelBuilder.Entity<SourceArticle>(entity =>
        {
            entity.HasKey(e => e.IdSourceArticle);

            entity.ToTable("SOURCE_ARTICLE");

            entity.HasIndex(e => e.DatePubArticle, "INDEX_DATE_PUB_ARTICLE");

            entity.Property(e => e.IdSourceArticle)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_SOURCE_ARTICLE");
            entity.Property(e => e.DatePubArticle)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("DATE_PUB_ARTICLE");
            entity.Property(e => e.IntervalePage)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("INTERVALE_PAGE");
            entity.Property(e => e.IssnRevue)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ISSN_REVUE");
            entity.Property(e => e.NumeroRevue)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NUMERO_REVUE");
            entity.Property(e => e.TitreSourceArticle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TITRE_SOURCE_ARTICLE");
        });

        modelBuilder.Entity<TableCdd>(entity =>
        {
            entity.HasKey(e => e.Cdd).HasName("TABLE_CDD_PK");

            entity.ToTable("TABLE_CDD");

            entity.Property(e => e.Cdd)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CDD");
            entity.Property(e => e.Libelle)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasColumnName("LIBELLE");

            entity.HasMany(t => t.Notices)
                .WithOne(n => n.TableCdd)
                .HasForeignKey(n => n.Cdd)
                .HasConstraintName("NOTICE_TABLE_CDD_FK1")
                .IsRequired(false);
        });

        modelBuilder.Entity<Terme>(entity =>
        {
            entity.HasKey(e => e.IdTerme);

            entity.ToTable("TERME");

            entity.HasIndex(e => e.Terme1, "INDEX_TERME");

            entity.Property(e => e.IdTerme)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_TERME");
            entity.Property(e => e.Terme1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TERME");
        });

        modelBuilder.Entity<TermeExact>(entity =>
        {
            entity.HasKey(e => e.IdTermeExact).HasName("TERME_EXACT_PK");

            entity.ToTable("TERME_EXACT");

            entity.Property(e => e.IdTermeExact)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_TERME_EXACT");
            entity.Property(e => e.TermeExact1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TERME_EXACT");
        });

        modelBuilder.Entity<Theme>(entity =>
        {
            entity.HasKey(e => e.IdTheme);

            entity.ToTable("THEME");

            entity.Property(e => e.IdTheme)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ID_THEME");
            entity.Property(e => e.Theme1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("THEME");
        });

        modelBuilder.Entity<TypeNotice>(entity =>
        {
            entity.HasKey(e => e.IdType);

            entity.ToTable("TYPE_NOTICE");

            entity.Property(e => e.IdType)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_TYPE");
            entity.Property(e => e.TypeNotice1)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("TYPE_NOTICE");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.Compte).HasName("UTILISATEUR_PK");

            entity.ToTable("UTILISATEUR");

            entity.Property(e => e.Compte)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("COMPTE");
            entity.Property(e => e.Column1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COLUMN1");
            entity.Property(e => e.Datecrerationcompte)
                .HasColumnType("DATE")
                .HasColumnName("DATECRERATIONCOMPTE");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Motdepasse)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MOTDEPASSE");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM");
        });

        modelBuilder.Entity<Ville>(entity =>
        {
            entity.HasKey(e => e.IdVille);

            entity.ToTable("VILLE");

            entity.Property(e => e.IdVille)
                .HasColumnType("NUMBER(38)").HasPrecision(38, 0)
                .HasColumnName("ID_VILLE");
            entity.Property(e => e.Ville1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VILLE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
