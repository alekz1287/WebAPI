using IBM.EntityFrameworkCore;
using IBM.EntityFrameworkCore.Storage.Internal;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HillmanGroup.API.HillpyEntities
{
    public partial class HILLPYContext : DbContext
    {
        public virtual DbSet<F0101> F0101 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseDb2(@"server=hillpy.hillmangroup.com:446;uid=readonly;pwd=hill4read;database=hillpy" , p=>{ p.SetServerInfo(IBMDBServerType.AS400); p.UseRowNumberForPaging(); });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<F0101>(entity =>
            {
                entity.HasKey(e => e.Aban8);

                entity.ToTable("F0101", "HILLDTA");

                entity.HasIndex(e => e.Aban8)
                    .HasName("F0101_PK")
                    .IsUnique();

                entity.Property(e => e.Aban8)
                    .HasColumnName("ABAN8")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Abab3)
                    .HasColumnName("ABAB3")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Abac01)
                    .HasColumnName("ABAC01")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac02)
                    .HasColumnName("ABAC02")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac03)
                    .HasColumnName("ABAC03")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac04)
                    .HasColumnName("ABAC04")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac05)
                    .HasColumnName("ABAC05")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac06)
                    .HasColumnName("ABAC06")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac07)
                    .HasColumnName("ABAC07")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac08)
                    .HasColumnName("ABAC08")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac09)
                    .HasColumnName("ABAC09")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac10)
                    .HasColumnName("ABAC10")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac11)
                    .HasColumnName("ABAC11")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac12)
                    .HasColumnName("ABAC12")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac13)
                    .HasColumnName("ABAC13")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac14)
                    .HasColumnName("ABAC14")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac15)
                    .HasColumnName("ABAC15")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac16)
                    .HasColumnName("ABAC16")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac17)
                    .HasColumnName("ABAC17")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac18)
                    .HasColumnName("ABAC18")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac19)
                    .HasColumnName("ABAC19")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac20)
                    .HasColumnName("ABAC20")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac21)
                    .HasColumnName("ABAC21")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac22)
                    .HasColumnName("ABAC22")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac23)
                    .HasColumnName("ABAC23")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac24)
                    .HasColumnName("ABAC24")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac25)
                    .HasColumnName("ABAC25")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac26)
                    .HasColumnName("ABAC26")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac27)
                    .HasColumnName("ABAC27")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac28)
                    .HasColumnName("ABAC28")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac29)
                    .HasColumnName("ABAC29")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abac30)
                    .HasColumnName("ABAC30")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abactin)
                    .HasColumnName("ABACTIN")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Abaempgp)
                    .HasColumnName("ABAEMPGP")
                    .HasColumnType("graphic(5)");

                entity.Property(e => e.Abalky)
                    .HasColumnName("ABALKY")
                    .HasColumnType("graphic(20)");

                entity.Property(e => e.Abalp1)
                    .HasColumnName("ABALP1")
                    .HasColumnType("graphic(40)");

                entity.Property(e => e.Abalph)
                    .HasColumnName("ABALPH")
                    .HasColumnType("graphic(40)");

                entity.Property(e => e.Aban81)
                    .HasColumnName("ABAN81")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Aban82)
                    .HasColumnName("ABAN82")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Aban83)
                    .HasColumnName("ABAN83")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Aban84)
                    .HasColumnName("ABAN84")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Aban85)
                    .HasColumnName("ABAN85")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Aban86)
                    .HasColumnName("ABAN86")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Abat1)
                    .HasColumnName("ABAT1")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abat2)
                    .HasColumnName("ABAT2")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Abat3)
                    .HasColumnName("ABAT3")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Abat4)
                    .HasColumnName("ABAT4")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Abat5)
                    .HasColumnName("ABAT5")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Abate)
                    .HasColumnName("ABATE")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Abatp)
                    .HasColumnName("ABATP")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Abatpr)
                    .HasColumnName("ABATPR")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Abatr)
                    .HasColumnName("ABATR")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Abcaad)
                    .HasColumnName("ABCAAD")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Abclass01)
                    .HasColumnName("ABCLASS01")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abclass02)
                    .HasColumnName("ABCLASS02")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abclass03)
                    .HasColumnName("ABCLASS03")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abclass04)
                    .HasColumnName("ABCLASS04")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abclass05)
                    .HasColumnName("ABCLASS05")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Abcm)
                    .HasColumnName("ABCM")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Abdc)
                    .HasColumnName("ABDC")
                    .HasColumnType("graphic(40)");

                entity.Property(e => e.Abduns)
                    .HasColumnName("ABDUNS")
                    .HasColumnType("graphic(13)");

                entity.Property(e => e.Abeftb)
                    .HasColumnName("ABEFTB")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Abexchg)
                    .HasColumnName("ABEXCHG")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Abglba)
                    .HasColumnName("ABGLBA")
                    .HasColumnType("graphic(8)");

                entity.Property(e => e.Abgrowthr)
                    .HasColumnName("ABGROWTHR")
                    .HasColumnType("decimal(8, 0)");

                entity.Property(e => e.Abjobn)
                    .HasColumnName("ABJOBN")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ablngp)
                    .HasColumnName("ABLNGP")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Abmcu)
                    .HasColumnName("ABMCU")
                    .HasColumnType("graphic(12)");

                entity.Property(e => e.Abmsga)
                    .HasColumnName("ABMSGA")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Abnoe)
                    .HasColumnName("ABNOE")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Abpdi)
                    .HasColumnName("ABPDI")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Abperrs)
                    .HasColumnName("ABPERRS")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Abpid)
                    .HasColumnName("ABPID")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Abprgf)
                    .HasColumnName("ABPRGF")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Abpti)
                    .HasColumnName("ABPTI")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Abrevrng)
                    .HasColumnName("ABREVRNG")
                    .HasColumnType("graphic(5)");

                entity.Property(e => e.Abrmk)
                    .HasColumnName("ABRMK")
                    .HasColumnType("graphic(30)");

                entity.Property(e => e.Absbli)
                    .HasColumnName("ABSBLI")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Absccltp)
                    .HasColumnName("ABSCCLTP")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Absic)
                    .HasColumnName("ABSIC")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Absyncs)
                    .HasColumnName("ABSYNCS")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Abtax)
                    .HasColumnName("ABTAX")
                    .HasColumnType("graphic(20)");

                entity.Property(e => e.Abtaxc)
                    .HasColumnName("ABTAXC")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Abticker)
                    .HasColumnName("ABTICKER")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Abtx2)
                    .HasColumnName("ABTX2")
                    .HasColumnType("graphic(20)");

                entity.Property(e => e.Abtxct)
                    .HasColumnName("ABTXCT")
                    .HasColumnType("graphic(20)");

                entity.Property(e => e.Abupmj)
                    .HasColumnName("ABUPMJ")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Abupmt)
                    .HasColumnName("ABUPMT")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Aburab)
                    .HasColumnName("ABURAB")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Aburat)
                    .HasColumnName("ABURAT")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Aburcd)
                    .HasColumnName("ABURCD")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Aburdt)
                    .HasColumnName("ABURDT")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Aburrf)
                    .HasColumnName("ABURRF")
                    .HasColumnType("graphic(15)");

                entity.Property(e => e.Abuser)
                    .HasColumnName("ABUSER")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Abyearstar)
                    .HasColumnName("ABYEARSTAR")
                    .HasColumnType("graphic(15)");
            });
        }
    }
}
