using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cw13.Models
{
    public partial class s18625Context : DbContext
    {
        public s18625Context()
        {
        }

        public s18625Context(DbContextOptions<s18625Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<WyrobCukierniczy> WyrobCukierniczy { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }
        public virtual DbSet<ZamowienieWyrobCukierniczy> ZamowienieWyrobCukierniczy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s18625;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKleint)
                    .HasName("Klient_pk");

                entity.Property(e => e.IdKleint).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownik)
                    .HasName("Pracownik_pk");

                entity.Property(e => e.IdPracownik).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WyrobCukierniczy>(entity =>
            {
                entity.HasKey(e => e.IdWyrobCukierniczy)
                    .HasName("WyrobCukierniczy_pk");

                entity.Property(e => e.IdWyrobCukierniczy).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Typ)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienie).ValueGeneratedNever();

                entity.Property(e => e.DataRealizacji).HasColumnType("date");

                entity.Property(e => e.DataZamowienia)
                    .HasColumnName("dataZamowienia")
                    .HasColumnType("date");

                entity.Property(e => e.KlientIdKleint).HasColumnName("Klient_IdKleint");

                entity.Property(e => e.PracownikIdPracownik).HasColumnName("Pracownik_IdPracownik");

                entity.Property(e => e.Uwagi)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.KlientIdKleintNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.KlientIdKleint)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Klient");

                entity.HasOne(d => d.PracownikIdPracownikNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.PracownikIdPracownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pracownik");
            });

            modelBuilder.Entity<ZamowienieWyrobCukierniczy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Zamowienie_WyrobCukierniczy");

                entity.Property(e => e.Uwagi)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.WyrobCukierniczyIdWyrobCukierniczy).HasColumnName("WyrobCukierniczy_IdWyrobCukierniczy");

                entity.Property(e => e.ZamowienieIdZamowienie).HasColumnName("Zamowienie_IdZamowienie");

                entity.HasOne(d => d.WyrobCukierniczyIdWyrobCukierniczyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.WyrobCukierniczyIdWyrobCukierniczy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_wyrobCukierniczy_WyrobCukierniczy");

                entity.HasOne(d => d.ZamowienieIdZamowienieNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ZamowienieIdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_wyrobCukierniczy_Zamowienie");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
