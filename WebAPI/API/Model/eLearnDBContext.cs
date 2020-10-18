using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace API.Model
{
    public partial class eLearnDBContext : DbContext
    {
        public eLearnDBContext()
        {
        }
        private string connectionString;
        public eLearnDBContext(DbContextOptions<eLearnDBContext> options)
            : base(options)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            connectionString = configuration.GetConnectionString("DefaultConnection").ToString();
        }

        public virtual DbSet<Egzaminy> Egzaminies { get; set; }
        public virtual DbSet<Klasy> Klasies { get; set; }
        public virtual DbSet<KlasyNauczycieli> KlasyNauczycielis { get; set; }
        public virtual DbSet<Nauczyciele> Nauczycieles { get; set; }
        public virtual DbSet<Oceny> Ocenies { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<PrzedNauczycieli> PrzedNauczycielis { get; set; }
        public virtual DbSet<Przedmioty> Przedmioties { get; set; }
        public virtual DbSet<Rodzice> Rodzices { get; set; }
        public virtual DbSet<Szkoly> Szkolies { get; set; }
        public virtual DbSet<SzkolyNauczycieli> SzkolyNauczycielis { get; set; }
        public virtual DbSet<Uczen> Uczens { get; set; }
        public virtual DbSet<WOcena> WOcenas { get; set; }
        public virtual DbSet<ZrealizowaneEgzaminy> ZrealizowaneEgzaminies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
                //optionsBuilder.UseSqlServer("Server=elearnapp.database.windows.net;Database=eLearnDB;user id=elearnAdmin;password=PASSWORD;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Egzaminy>(entity =>
            {
                entity.HasKey(e => e.EgzaminId);

                entity.ToTable("egzaminy");

                entity.Property(e => e.EgzaminId).HasColumnName("egzamin_id");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(50)
                    .HasColumnName("nazwa");
            });

            modelBuilder.Entity<Klasy>(entity =>
            {
                entity.HasKey(e => e.KlasaId);

                entity.ToTable("Klasy");

                entity.Property(e => e.KlasaId).HasColumnName("klasa_id");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(50)
                    .HasColumnName("nazwa");

                entity.Property(e => e.SzkolaId).HasColumnName("szkola_id");
            });

            modelBuilder.Entity<KlasyNauczycieli>(entity =>
            {
                entity.HasKey(e => e.KnId);

                entity.ToTable("klasy_nauczycieli");

                entity.Property(e => e.KnId).HasColumnName("kn_id");

                entity.Property(e => e.CzyWych).HasColumnName("czy_wych");

                entity.Property(e => e.KlasaId).HasColumnName("klasa_id");

                entity.Property(e => e.NauczycielId).HasColumnName("nauczyciel_id");

                entity.HasOne(d => d.Klasa)
                    .WithMany(p => p.KlasyNauczycielis)
                    .HasForeignKey(d => d.KlasaId)
                    .HasConstraintName("FK_klasy_nauczycieli_Klasy");

                entity.HasOne(d => d.Nauczyciel)
                    .WithMany(p => p.KlasyNauczycielis)
                    .HasForeignKey(d => d.NauczycielId)
                    .HasConstraintName("FK_klasy_nauczycieli_Nauczyciele");
            });

            modelBuilder.Entity<Nauczyciele>(entity =>
            {
                entity.HasKey(e => e.NauczycielId);

                entity.ToTable("Nauczyciele");

                entity.Property(e => e.NauczycielId).HasColumnName("nauczyciel_id");

                entity.Property(e => e.Adres)
                    .HasMaxLength(50)
                    .HasColumnName("adres");

                entity.Property(e => e.CzyDyr).HasColumnName("czy_dyr");

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnType("date")
                    .HasColumnName("data_urodzenia")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Imie)
                    .HasMaxLength(50)
                    .HasColumnName("imie");

                entity.Property(e => e.KnId).HasColumnName("kn_id");

                entity.Property(e => e.KodPocztowy)
                    .HasMaxLength(6)
                    .HasColumnName("kod_pocztowy");

                entity.Property(e => e.LoginId).HasColumnName("login_id");

                entity.Property(e => e.Miasto)
                    .HasMaxLength(50)
                    .HasColumnName("miasto");

                entity.Property(e => e.Nazwisko)
                    .HasMaxLength(50)
                    .HasColumnName("nazwisko");

                entity.Property(e => e.Pesel).HasColumnName("pesel");

                entity.Property(e => e.PrzedmiotId).HasColumnName("przedmiot_id");

                entity.Property(e => e.SzkolaId).HasColumnName("szkola_id");
            });

            modelBuilder.Entity<Oceny>(entity =>
            {
                entity.HasKey(e => e.OcenaId);

                entity.ToTable("Oceny");

                entity.Property(e => e.OcenaId).HasColumnName("ocena_id");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(20)
                    .HasColumnName("nazwa");

                entity.Property(e => e.Wartosc).HasColumnName("wartosc");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.ProfilId);

                entity.ToTable("profile");

                entity.Property(e => e.ProfilId).HasColumnName("profil_id");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(50)
                    .HasColumnName("nazwa");
            });

            modelBuilder.Entity<PrzedNauczycieli>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("przed_nauczycieli");

                entity.Property(e => e.NauczycielId).HasColumnName("nauczyciel_id");

                entity.Property(e => e.PrzedmiotId).HasColumnName("przedmiot_id");

                entity.HasOne(d => d.Nauczyciel)
                    .WithMany()
                    .HasForeignKey(d => d.NauczycielId)
                    .HasConstraintName("FK_przed_nauczycieli_Nauczyciele");

                entity.HasOne(d => d.Przedmiot)
                    .WithMany()
                    .HasForeignKey(d => d.PrzedmiotId)
                    .HasConstraintName("FK_przed_nauczycieli_przedmioty");
            });

            modelBuilder.Entity<Przedmioty>(entity =>
            {
                entity.HasKey(e => e.PrzedmiotId);

                entity.ToTable("przedmioty");

                entity.Property(e => e.PrzedmiotId).HasColumnName("przedmiot_id");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(50)
                    .HasColumnName("nazwa");
            });

            modelBuilder.Entity<Rodzice>(entity =>
            {
                entity.HasKey(e => e.RodzicId)
                    .HasName("PK_rodzic_id");

                entity.ToTable("rodzice");

                entity.Property(e => e.RodzicId).HasColumnName("rodzic_id");

                entity.Property(e => e.Adres)
                    .HasMaxLength(50)
                    .HasColumnName("adres");

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnType("date")
                    .HasColumnName("data_urodzenia")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.DzieckoId).HasColumnName("dziecko_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Imie)
                    .HasMaxLength(50)
                    .HasColumnName("imie");

                entity.Property(e => e.KodPocztowy)
                    .HasMaxLength(6)
                    .HasColumnName("kod_pocztowy");

                entity.Property(e => e.LoginId).HasColumnName("login_id");

                entity.Property(e => e.Miasto)
                    .HasMaxLength(50)
                    .HasColumnName("miasto");

                entity.Property(e => e.Nazwisko)
                    .HasMaxLength(50)
                    .HasColumnName("nazwisko");

                entity.HasOne(d => d.Dziecko)
                    .WithMany(p => p.Rodzices)
                    .HasForeignKey(d => d.DzieckoId)
                    .HasConstraintName("FK_rodzic_id_Uczen");
            });

            modelBuilder.Entity<Szkoly>(entity =>
            {
                entity.HasKey(e => e.SzkolaId);

                entity.ToTable("szkoly");

                entity.Property(e => e.SzkolaId).HasColumnName("szkola_id");

                entity.Property(e => e.DataZalozenia)
                    .HasMaxLength(50)
                    .HasColumnName("data_zalozenia");

                entity.Property(e => e.DyrId).HasColumnName("dyr_id");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(50)
                    .HasColumnName("nazwa");

                entity.Property(e => e.Opis)
                    .HasColumnType("text")
                    .HasColumnName("opis")
                    .HasAnnotation("Relational:ColumnType", "text");

                entity.Property(e => e.ProfilId).HasColumnName("profil_id");

                entity.HasOne(d => d.Profil)
                    .WithMany(p => p.Szkolies)
                    .HasForeignKey(d => d.ProfilId)
                    .HasConstraintName("FK_szkoly_profile");
            });

            modelBuilder.Entity<SzkolyNauczycieli>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("szkoly_nauczycieli");

                entity.Property(e => e.NauczycielId).HasColumnName("nauczyciel_id");

                entity.Property(e => e.SzkolaId).HasColumnName("szkola_id");

                entity.HasOne(d => d.Nauczyciel)
                    .WithMany()
                    .HasForeignKey(d => d.NauczycielId)
                    .HasConstraintName("FK_szkoly_nauczycieli_Nauczyciele");

                entity.HasOne(d => d.Szkola)
                    .WithMany()
                    .HasForeignKey(d => d.SzkolaId)
                    .HasConstraintName("FK_szkoly_nauczycieli_szkoly");
            });

            modelBuilder.Entity<Uczen>(entity =>
            {
                entity.ToTable("Uczen");

                entity.Property(e => e.UczenId).HasColumnName("uczen_id");

                entity.Property(e => e.Adres)
                    .HasMaxLength(50)
                    .HasColumnName("adres");

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnType("date")
                    .HasColumnName("data_urodzenia")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Imie)
                    .HasMaxLength(50)
                    .HasColumnName("imie");

                entity.Property(e => e.KlasaId).HasColumnName("klasa_id");

                entity.Property(e => e.KodPocztowy)
                    .HasMaxLength(6)
                    .HasColumnName("kod_pocztowy");

                entity.Property(e => e.LoginId).HasColumnName("login_id");

                entity.Property(e => e.Miasto)
                    .HasMaxLength(50)
                    .HasColumnName("miasto");

                entity.Property(e => e.Nazwisko)
                    .HasMaxLength(50)
                    .HasColumnName("nazwisko");

                entity.Property(e => e.Pesel).HasColumnName("pesel");

                entity.Property(e => e.SzkolaId).HasColumnName("szkola_id");

                entity.HasOne(d => d.Klasa)
                    .WithMany(p => p.Uczens)
                    .HasForeignKey(d => d.KlasaId)
                    .HasConstraintName("FK_Uczen_Klasy");

                entity.HasOne(d => d.Szkola)
                    .WithMany(p => p.Uczens)
                    .HasForeignKey(d => d.SzkolaId)
                    .HasConstraintName("FK_Uczen_szkoly");
            });

            modelBuilder.Entity<WOcena>(entity =>
            {
                entity.HasKey(e => e.WoId);

                entity.ToTable("w_ocena");

                entity.Property(e => e.WoId).HasColumnName("wo_id");

                entity.Property(e => e.DataWystawienia)
                    .HasColumnType("date")
                    .HasColumnName("data_wystawienia")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.NauczycielId).HasColumnName("nauczyciel_id");

                entity.Property(e => e.OcenaId).HasColumnName("ocena_id");

                entity.Property(e => e.PrzedmiotId).HasColumnName("przedmiot_id");

                entity.Property(e => e.UczenId).HasColumnName("uczen_id");

                entity.HasOne(d => d.Nauczyciel)
                    .WithMany(p => p.WOcenas)
                    .HasForeignKey(d => d.NauczycielId)
                    .HasConstraintName("FK_w_ocena_Nauczyciele");

                entity.HasOne(d => d.Ocena)
                    .WithMany(p => p.WOcenas)
                    .HasForeignKey(d => d.OcenaId)
                    .HasConstraintName("FK_w_ocena_Oceny");

                entity.HasOne(d => d.Przedmiot)
                    .WithMany(p => p.WOcenas)
                    .HasForeignKey(d => d.PrzedmiotId)
                    .HasConstraintName("FK_w_ocena_przedmioty");

                entity.HasOne(d => d.Uczen)
                    .WithMany(p => p.WOcenas)
                    .HasForeignKey(d => d.UczenId)
                    .HasConstraintName("FK_w_ocena_Uczen");
            });

            modelBuilder.Entity<ZrealizowaneEgzaminy>(entity =>
            {
                entity.HasKey(e => e.EzId);

                entity.ToTable("zrealizowane_egzaminy");

                entity.Property(e => e.EzId).HasColumnName("ez_id");

                entity.Property(e => e.Data)
                    .HasColumnType("date")
                    .HasColumnName("data")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.EgzaminId).HasColumnName("egzamin_id");

                entity.Property(e => e.UczenId).HasColumnName("uczen_id");

                entity.HasOne(d => d.Egzamin)
                    .WithMany(p => p.ZrealizowaneEgzaminies)
                    .HasForeignKey(d => d.EgzaminId)
                    .HasConstraintName("FK_zrealizowane_egzaminy_egzaminy");

                entity.HasOne(d => d.Uczen)
                    .WithMany(p => p.ZrealizowaneEgzaminies)
                    .HasForeignKey(d => d.UczenId)
                    .HasConstraintName("FK_zrealizowane_egzaminy_Uczen");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
