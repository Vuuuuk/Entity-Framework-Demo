using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IFZA_Auto_Skola.Models
{
    public partial class AutoSkolaContext : DbContext
    {
        public AutoSkolaContext()
        {
        }

        public AutoSkolaContext(DbContextOptions<AutoSkolaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AutoSkola> AutoSkolas { get; set; } = null!;
        public virtual DbSet<Automatik> Automatiks { get; set; } = null!;
        public virtual DbSet<Instruktor> Instruktors { get; set; } = null!;
        public virtual DbSet<Ispit> Ispits { get; set; } = null!;
        public virtual DbSet<KategorijaA> KategorijaAs { get; set; } = null!;
        public virtual DbSet<KategorijaB> KategorijaBs { get; set; } = null!;
        public virtual DbSet<Klijent> Klijents { get; set; } = null!;
        public virtual DbSet<Manuelni> Manuelnis { get; set; } = null!;
        public virtual DbSet<Nastavnik> Nastavniks { get; set; } = null!;
        public virtual DbSet<Poligon> Poligons { get; set; } = null!;
        public virtual DbSet<Pripadum> Pripada { get; set; } = null!;
        public virtual DbSet<Radnik> Radniks { get; set; } = null!;
        public virtual DbSet<Rutum> Ruta { get; set; } = null!;
        public virtual DbSet<TeorijskaObuka> TeorijskaObukas { get; set; } = null!;
        public virtual DbSet<Vozilo> Vozilos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["AutoSkolaConnectionString"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutoSkola>(entity =>
            {
                entity.HasKey(e => e.AId)
                    .HasName("AUTO_SKOLA_PK");

                entity.ToTable("AUTO_SKOLA");

                entity.HasIndex(e => e.AIme, "UQ__AUTO_SKO__6CA45BDB2E6EFFAC")
                    .IsUnique();

                entity.Property(e => e.AId).HasColumnName("a_id");

                entity.Property(e => e.AAdresa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("a_adresa");

                entity.Property(e => e.AIme)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("a_ime");
            });

            modelBuilder.Entity<Automatik>(entity =>
            {
                entity.HasKey(e => e.VId)
                    .HasName("AUTOMATIK_PK");

                entity.ToTable("AUTOMATIK");

                entity.Property(e => e.VId)
                    .ValueGeneratedNever()
                    .HasColumnName("v_id");

                entity.HasOne(d => d.VIdNavigation)
                    .WithOne(p => p.Automatik)
                    .HasForeignKey<Automatik>(d => d.VId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AUTOMATIK__v_id__6477ECF3");
            });

            modelBuilder.Entity<Instruktor>(entity =>
            {
                entity.HasKey(e => e.RaId)
                    .HasName("INSTRUKTOR_PK");

                entity.ToTable("INSTRUKTOR");

                entity.Property(e => e.RaId)
                    .ValueGeneratedNever()
                    .HasColumnName("ra_id");

                entity.HasOne(d => d.Ra)
                    .WithOne(p => p.Instruktor)
                    .HasForeignKey<Instruktor>(d => d.RaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INSTRUKTO__ra_id__5AEE82B9");
            });

            modelBuilder.Entity<Ispit>(entity =>
            {
                entity.HasKey(e => e.IId)
                    .HasName("ISPIT_PK");

                entity.ToTable("ISPIT");

                entity.Property(e => e.IId).HasColumnName("i_id");

                entity.Property(e => e.ITip)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("i_tip");

                entity.Property(e => e.ITrajanje).HasColumnName("i_trajanje");
            });

            modelBuilder.Entity<KategorijaA>(entity =>
            {
                entity.HasKey(e => e.IId)
                    .HasName("KATEGORIJA_A_PK");

                entity.ToTable("KATEGORIJA_A");

                entity.Property(e => e.IId)
                    .ValueGeneratedNever()
                    .HasColumnName("i_id");

                entity.HasOne(d => d.IIdNavigation)
                    .WithOne(p => p.KategorijaA)
                    .HasForeignKey<KategorijaA>(d => d.IId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KATEGORIJA__i_id__4E88ABD4");

                entity.HasMany(d => d.VIds)
                    .WithMany(p => p.IIds)
                    .UsingEntity<Dictionary<string, object>>(
                        "Vozi",
                        l => l.HasOne<Automatik>().WithMany().HasForeignKey("VId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__VOZI__v_id__7B5B524B"),
                        r => r.HasOne<KategorijaA>().WithMany().HasForeignKey("IId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__VOZI__i_id__7A672E12"),
                        j =>
                        {
                            j.HasKey("IId", "VId").HasName("VOZI_PK");

                            j.ToTable("VOZI");

                            j.IndexerProperty<int>("IId").HasColumnName("i_id");

                            j.IndexerProperty<int>("VId").HasColumnName("v_id");
                        });
            });

            modelBuilder.Entity<KategorijaB>(entity =>
            {
                entity.HasKey(e => e.IId)
                    .HasName("KATEGORIJA_B_PK");

                entity.ToTable("KATEGORIJA_B");

                entity.Property(e => e.IId)
                    .ValueGeneratedNever()
                    .HasColumnName("i_id");

                entity.HasOne(d => d.IIdNavigation)
                    .WithOne(p => p.KategorijaB)
                    .HasForeignKey<KategorijaB>(d => d.IId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KATEGORIJA__i_id__5165187F");

                entity.HasMany(d => d.VIds)
                    .WithMany(p => p.IIds)
                    .UsingEntity<Dictionary<string, object>>(
                        "Koristi",
                        l => l.HasOne<Manuelni>().WithMany().HasForeignKey("VId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__KORISTI__v_id__7F2BE32F"),
                        r => r.HasOne<KategorijaB>().WithMany().HasForeignKey("IId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__KORISTI__i_id__7E37BEF6"),
                        j =>
                        {
                            j.HasKey("IId", "VId").HasName("KORISTI_PK");

                            j.ToTable("KORISTI");

                            j.IndexerProperty<int>("IId").HasColumnName("i_id");

                            j.IndexerProperty<int>("VId").HasColumnName("v_id");
                        });
            });

            modelBuilder.Entity<Klijent>(entity =>
            {
                entity.HasKey(e => e.KId)
                    .HasName("KLIJENT_PK");

                entity.ToTable("KLIJENT");

                entity.Property(e => e.KId).HasColumnName("k_id");

                entity.Property(e => e.IId).HasColumnName("i_id");

                entity.Property(e => e.KIme)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("k_ime");

                entity.Property(e => e.KPrezime)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("k_prezime");

                entity.Property(e => e.ToId).HasColumnName("to_id");

                entity.HasOne(d => d.IIdNavigation)
                    .WithMany(p => p.Klijents)
                    .HasForeignKey(d => d.IId)
                    .HasConstraintName("FK__KLIJENT__i_id__06CD04F7");

                entity.HasOne(d => d.To)
                    .WithMany(p => p.Klijents)
                    .HasForeignKey(d => d.ToId)
                    .HasConstraintName("FK__KLIJENT__to_id__05D8E0BE");
            });

            modelBuilder.Entity<Manuelni>(entity =>
            {
                entity.HasKey(e => e.VId)
                    .HasName("MANUELNI_PK");

                entity.ToTable("MANUELNI");

                entity.Property(e => e.VId)
                    .ValueGeneratedNever()
                    .HasColumnName("v_id");

                entity.Property(e => e.VBrb).HasColumnName("v_brb");

                entity.HasOne(d => d.VIdNavigation)
                    .WithOne(p => p.Manuelni)
                    .HasForeignKey<Manuelni>(d => d.VId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MANUELNI__v_id__6A30C649");
            });

            modelBuilder.Entity<Nastavnik>(entity =>
            {
                entity.HasKey(e => e.RaId)
                    .HasName("NASTAVNIK_PK");

                entity.ToTable("NASTAVNIK");

                entity.Property(e => e.RaId)
                    .ValueGeneratedNever()
                    .HasColumnName("ra_id");

                entity.HasOne(d => d.Ra)
                    .WithOne(p => p.Nastavnik)
                    .HasForeignKey<Nastavnik>(d => d.RaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NASTAVNIK__ra_id__5DCAEF64");

                entity.HasMany(d => d.Tos)
                    .WithMany(p => p.Ras)
                    .UsingEntity<Dictionary<string, object>>(
                        "Izvrsava",
                        l => l.HasOne<TeorijskaObuka>().WithMany().HasForeignKey("ToId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__IZVRSAVA__to_id__02FC7413"),
                        r => r.HasOne<Nastavnik>().WithMany().HasForeignKey("RaId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__IZVRSAVA__ra_id__02084FDA"),
                        j =>
                        {
                            j.HasKey("RaId", "ToId").HasName("IZVRSAVA_PK");

                            j.ToTable("IZVRSAVA");

                            j.IndexerProperty<int>("RaId").HasColumnName("ra_id");

                            j.IndexerProperty<int>("ToId").HasColumnName("to_id");
                        });
            });

            modelBuilder.Entity<Poligon>(entity =>
            {
                entity.HasKey(e => new { e.PId, e.AId })
                    .HasName("POLIGON_PK");

                entity.ToTable("POLIGON");

                entity.Property(e => e.PId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("p_id");

                entity.Property(e => e.AId).HasColumnName("a_id");

                entity.Property(e => e.PAdresa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("p_adresa");

                entity.Property(e => e.PVelicina).HasColumnName("p_velicina");

                entity.HasOne(d => d.AIdNavigation)
                    .WithMany(p => p.Poligons)
                    .HasForeignKey(d => d.AId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__POLIGON__a_id__4222D4EF");
            });

            modelBuilder.Entity<Pripadum>(entity =>
            {
                entity.HasKey(e => new { e.PId, e.AId, e.RuId })
                    .HasName("PRIPADA_PK");

                entity.ToTable("PRIPADA");

                entity.Property(e => e.PId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("p_id");

                entity.Property(e => e.AId).HasColumnName("a_id");

                entity.Property(e => e.RuId).HasColumnName("ru_id");

                entity.HasOne(d => d.AIdNavigation)
                    .WithMany(p => p.Pripada)
                    .HasForeignKey(d => d.AId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRIPADA__a_id__48CFD27E");

                entity.HasOne(d => d.Ru)
                    .WithMany(p => p.Pripada)
                    .HasForeignKey(d => d.RuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRIPADA__ru_id__49C3F6B7");
            });

            modelBuilder.Entity<Radnik>(entity =>
            {
                entity.HasKey(e => e.RaId)
                    .HasName("RADNIK_PK");

                entity.ToTable("RADNIK");

                entity.Property(e => e.RaId).HasColumnName("ra_id");

                entity.Property(e => e.AId).HasColumnName("a_id");

                entity.Property(e => e.RaIme)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ra_ime");

                entity.Property(e => e.RaPlata).HasColumnName("ra_plata");

                entity.Property(e => e.RaPrezime)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ra_prezime");

                entity.Property(e => e.RaTip)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ra_tip");

                entity.HasOne(d => d.AIdNavigation)
                    .WithMany(p => p.Radniks)
                    .HasForeignKey(d => d.AId)
                    .HasConstraintName("FK__RADNIK__a_id__5812160E");
            });

            modelBuilder.Entity<Rutum>(entity =>
            {
                entity.HasKey(e => e.RuId)
                    .HasName("RUTA_PK");

                entity.ToTable("RUTA");

                entity.Property(e => e.RuId).HasColumnName("ru_id");

                entity.Property(e => e.RuKilometraza).HasColumnName("ru_kilometraza");

                entity.HasMany(d => d.IIds)
                    .WithMany(p => p.Rus)
                    .UsingEntity<Dictionary<string, object>>(
                        "JeDeo",
                        l => l.HasOne<Ispit>().WithMany().HasForeignKey("IId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__JE_DEO__i_id__5535A963"),
                        r => r.HasOne<Rutum>().WithMany().HasForeignKey("RuId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__JE_DEO__ru_id__5441852A"),
                        j =>
                        {
                            j.HasKey("RuId", "IId").HasName("JE_DEO_PK");

                            j.ToTable("JE_DEO");

                            j.IndexerProperty<int>("RuId").HasColumnName("ru_id");

                            j.IndexerProperty<int>("IId").HasColumnName("i_id");
                        });
            });

            modelBuilder.Entity<TeorijskaObuka>(entity =>
            {
                entity.HasKey(e => e.ToId)
                    .HasName("TEORIJSKA_OBUKA_PK");

                entity.ToTable("TEORIJSKA_OBUKA");

                entity.Property(e => e.ToId).HasColumnName("to_id");

                entity.Property(e => e.ToBrk).HasColumnName("to_brk");

                entity.Property(e => e.ToFond).HasColumnName("to_fond");
            });

            modelBuilder.Entity<Vozilo>(entity =>
            {
                entity.HasKey(e => e.VId)
                    .HasName("VOZILO_PK");

                entity.ToTable("VOZILO");

                entity.Property(e => e.VId).HasColumnName("v_id");

                entity.Property(e => e.AId).HasColumnName("a_id");

                entity.Property(e => e.RaId).HasColumnName("ra_id");

                entity.Property(e => e.VKilometraza).HasColumnName("v_kilometraza");

                entity.Property(e => e.VProizvodjac)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("v_proizvodjac");

                entity.Property(e => e.VTip)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("v_tip");

                entity.HasOne(d => d.AIdNavigation)
                    .WithMany(p => p.Vozilos)
                    .HasForeignKey(d => d.AId)
                    .HasConstraintName("FK__VOZILO__a_id__60A75C0F");

                entity.HasOne(d => d.Ra)
                    .WithMany(p => p.Vozilos)
                    .HasForeignKey(d => d.RaId)
                    .HasConstraintName("FK__VOZILO__ra_id__619B8048");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
