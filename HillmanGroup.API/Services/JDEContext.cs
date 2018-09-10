using IBM.EntityFrameworkCore;
using IBM.EntityFrameworkCore.Storage.Internal;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HillmanGroup.API.Models.JDEEntities
{
    public partial class JDEContext : DbContext
    {
        public virtual DbSet<F0101> F0101 { get; set; }
        public virtual DbSet<F0411z1> F0411z1 { get; set; }
        public virtual DbSet<F20103> F20103 { get; set; }
        public virtual DbSet<F0092> F0092 { get; set; }

        public JDEContext(DbContextOptions<JDEContext> options) : base(options)
        {            
        }
        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        ////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseDb2(@"server=hillpy.hillmangroup.com:446;uid=readonly;pwd=hill4read;database=hillpy" , p=>{ p.SetServerInfo(IBMDBServerType.AS400); p.UseRowNumberForPaging(); });
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<F0411z1>(entity =>
            {
                entity.HasKey(e => new { e.Vledus, e.Vledtn, e.Vledln, e.Vledbt });

                entity.ToTable("F0411Z1", "HILLDTA");

                entity.HasIndex(e => new { e.Vledus, e.Vledtn, e.Vledln, e.Vledbt })
                    .HasName("F0411Z1_PK")
                    .IsUnique();

                entity.Property(e => e.Vledus)
                    .HasColumnName("VLEDUS")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Vledtn)
                    .HasColumnName("VLEDTN")
                    .HasColumnType("graphic(22)");

                entity.Property(e => e.Vledln)
                    .HasColumnName("VLEDLN")
                    .HasColumnType("decimal(7, 0)");

                entity.Property(e => e.Vledbt)
                    .HasColumnName("VLEDBT")
                    .HasColumnType("graphic(15)");

                entity.Property(e => e.Vlaap)
                    .HasColumnName("VLAAP")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlac07)
                    .HasColumnName("VLAC07")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlacr)
                    .HasColumnName("VLACR")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vladsa)
                    .HasColumnName("VLADSA")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vladsc)
                    .HasColumnName("VLADSC")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlag)
                    .HasColumnName("VLAG")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlaid2)
                    .HasColumnName("VLAID2")
                    .HasColumnType("graphic(8)");

                entity.Property(e => e.Vlam)
                    .HasColumnName("VLAM")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlan8)
                    .HasColumnName("VLAN8")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Vlatad)
                    .HasColumnName("VLATAD")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlatxa)
                    .HasColumnName("VLATXA")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlatxn)
                    .HasColumnName("VLATXN")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlbaid)
                    .HasColumnName("VLBAID")
                    .HasColumnType("graphic(8)");

                entity.Property(e => e.Vlbalj)
                    .HasColumnName("VLBALJ")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlbcrc)
                    .HasColumnName("VLBCRC")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlcds)
                    .HasColumnName("VLCDS")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlcdsa)
                    .HasColumnName("VLCDSA")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlco)
                    .HasColumnName("VLCO")
                    .HasColumnType("graphic(5)");

                entity.Property(e => e.Vlcrc)
                    .HasColumnName("VLCRC")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlcrcd)
                    .HasColumnName("VLCRCD")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlcrr)
                    .HasColumnName("VLCRR")
                    .HasColumnType("decimal(15, 7)");

                entity.Property(e => e.Vlcrrm)
                    .HasColumnName("VLCRRM")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlctad)
                    .HasColumnName("VLCTAD")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlctam)
                    .HasColumnName("VLCTAM")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlctl)
                    .HasColumnName("VLCTL")
                    .HasColumnType("graphic(13)");

                entity.Property(e => e.Vlctry)
                    .HasColumnName("VLCTRY")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vlctxa)
                    .HasColumnName("VLCTXA")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlctxn)
                    .HasColumnName("VLCTXN")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vldct)
                    .HasColumnName("VLDCT")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Vldcta)
                    .HasColumnName("VLDCTA")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Vldd)
                    .HasColumnName("VLDD#")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vlddd)
                    .HasColumnName("VLDDD")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vlddj)
                    .HasColumnName("VLDDJ")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Vlddm)
                    .HasColumnName("VLDDM")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vlddn)
                    .HasColumnName("VLDDN#")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vlddnd)
                    .HasColumnName("VLDDND")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vlddnj)
                    .HasColumnName("VLDDNJ")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Vlddnm)
                    .HasColumnName("VLDDNM")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vlddny)
                    .HasColumnName("VLDDNY")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vlddy)
                    .HasColumnName("VLDDY")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldg)
                    .HasColumnName("VLDG#")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldgd)
                    .HasColumnName("VLDGD")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldgj)
                    .HasColumnName("VLDGJ")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Vldgm)
                    .HasColumnName("VLDGM")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldgy)
                    .HasColumnName("VLDGY")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldi)
                    .HasColumnName("VLDI#")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldic)
                    .HasColumnName("VLDIC#")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldicd)
                    .HasColumnName("VLDICD")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldicj)
                    .HasColumnName("VLDICJ")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Vldicm)
                    .HasColumnName("VLDICM")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldicy)
                    .HasColumnName("VLDICY")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldid)
                    .HasColumnName("VLDID")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldim)
                    .HasColumnName("VLDIM")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldivj)
                    .HasColumnName("VLDIVJ")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Vldiy)
                    .HasColumnName("VLDIY")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldmcd)
                    .HasColumnName("VLDMCD")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vldoc)
                    .HasColumnName("VLDOC")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Vldocm)
                    .HasColumnName("VLDOCM")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Vldrf)
                    .HasColumnName("VLDRF")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Vldsv)
                    .HasColumnName("VLDSV#")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldsvd)
                    .HasColumnName("VLDSVD")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldsvj)
                    .HasColumnName("VLDSVJ")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Vldsvm)
                    .HasColumnName("VLDSVM")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldsvy)
                    .HasColumnName("VLDSVY")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vldtxs)
                    .HasColumnName("VLDTXS")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vledan)
                    .HasColumnName("VLEDAN")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Vledct)
                    .HasColumnName("VLEDCT")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Vleddh)
                    .HasColumnName("VLEDDH")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vleddl)
                    .HasColumnName("VLEDDL")
                    .HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Vleddt)
                    .HasColumnName("VLEDDT")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Vleder)
                    .HasColumnName("VLEDER")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vledft)
                    .HasColumnName("VLEDFT")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Vledgl)
                    .HasColumnName("VLEDGL")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vledsp)
                    .HasColumnName("VLEDSP")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vledsq)
                    .HasColumnName("VLEDSQ")
                    .HasColumnType("decimal(2, 0)");

                entity.Property(e => e.Vledtc)
                    .HasColumnName("VLEDTC")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vledtr)
                    .HasColumnName("VLEDTR")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vledts)
                    .HasColumnName("VLEDTS")
                    .HasColumnType("graphic(6)");

                entity.Property(e => e.Vledty)
                    .HasColumnName("VLEDTY")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlexr1)
                    .HasColumnName("VLEXR1")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Vlexr3)
                    .HasColumnName("VLEXR3")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Vlfap)
                    .HasColumnName("VLFAP")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlfnlp)
                    .HasColumnName("VLFNLP")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlfnrt)
                    .HasColumnName("VLFNRT")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlfy)
                    .HasColumnName("VLFY")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vlgam1)
                    .HasColumnName("VLGAM1")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlgam2)
                    .HasColumnName("VLGAM2")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlgen4)
                    .HasColumnName("VLGEN4")
                    .HasColumnType("graphic(25)");

                entity.Property(e => e.Vlgen5)
                    .HasColumnName("VLGEN5")
                    .HasColumnType("graphic(25)");

                entity.Property(e => e.Vlgfl5)
                    .HasColumnName("VLGFL5")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlgfl6)
                    .HasColumnName("VLGFL6")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlglba)
                    .HasColumnName("VLGLBA")
                    .HasColumnType("graphic(8)");

                entity.Property(e => e.Vlglc)
                    .HasColumnName("VLGLC")
                    .HasColumnType("graphic(4)");

                entity.Property(e => e.Vlhcrr)
                    .HasColumnName("VLHCRR")
                    .HasColumnType("decimal(15, 7)");

                entity.Property(e => e.Vlhdg)
                    .HasColumnName("VLHDG#")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vlhdgd)
                    .HasColumnName("VLHDGD")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vlhdgj)
                    .HasColumnName("VLHDGJ")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Vlhdgm)
                    .HasColumnName("VLHDGM")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vlhdgy)
                    .HasColumnName("VLHDGY")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vlicu)
                    .HasColumnName("VLICU")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Vlicut)
                    .HasColumnName("VLICUT")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Vlitm)
                    .HasColumnName("VLITM")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Vljobn)
                    .HasColumnName("VLJOBN")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Vlkco)
                    .HasColumnName("VLKCO")
                    .HasColumnType("graphic(5)");

                entity.Property(e => e.Vllnid)
                    .HasColumnName("VLLNID")
                    .HasColumnType("decimal(6, 0)");

                entity.Property(e => e.Vlmcu)
                    .HasColumnName("VLMCU")
                    .HasColumnType("graphic(12)");

                entity.Property(e => e.Vlmcu2)
                    .HasColumnName("VLMCU2")
                    .HasColumnType("graphic(12)");

                entity.Property(e => e.Vlnetst)
                    .HasColumnName("VLNETST")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlnrta)
                    .HasColumnName("VLNRTA")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlobj)
                    .HasColumnName("VLOBJ")
                    .HasColumnType("graphic(6)");

                entity.Property(e => e.Vlodct)
                    .HasColumnName("VLODCT")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Vlodoc)
                    .HasColumnName("VLODOC")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Vlokco)
                    .HasColumnName("VLOKCO")
                    .HasColumnType("graphic(5)");

                entity.Property(e => e.Vlopsq)
                    .HasColumnName("VLOPSQ")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.Vlosfx)
                    .HasColumnName("VLOSFX")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlpdct)
                    .HasColumnName("VLPDCT")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Vlpid)
                    .HasColumnName("VLPID")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Vlpkco)
                    .HasColumnName("VLPKCO")
                    .HasColumnType("graphic(5)");

                entity.Property(e => e.Vlpn)
                    .HasColumnName("VLPN")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vlpo)
                    .HasColumnName("VLPO")
                    .HasColumnType("graphic(8)");

                entity.Property(e => e.Vlpost)
                    .HasColumnName("VLPOST")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlprgf)
                    .HasColumnName("VLPRGF")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlpst)
                    .HasColumnName("VLPST")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlptc)
                    .HasColumnName("VLPTC")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlpwpg)
                    .HasColumnName("VLPWPG")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlpye)
                    .HasColumnName("VLPYE")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Vlpyin)
                    .HasColumnName("VLPYIN")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlpywp)
                    .HasColumnName("VLPYWP")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlrf)
                    .HasColumnName("VLRF")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Vlrmk)
                    .HasColumnName("VLRMK")
                    .HasColumnType("graphic(30)");

                entity.Property(e => e.Vlrp1)
                    .HasColumnName("VLRP1")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlrp2)
                    .HasColumnName("VLRP2")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlrp3)
                    .HasColumnName("VLRP3")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlsbl)
                    .HasColumnName("VLSBL")
                    .HasColumnType("graphic(8)");

                entity.Property(e => e.Vlsblt)
                    .HasColumnName("VLSBLT")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlsfx)
                    .HasColumnName("VLSFX")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlsfxe)
                    .HasColumnName("VLSFXE")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Vlsfxo)
                    .HasColumnName("VLSFXO")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlsmmf)
                    .HasColumnName("VLSMMF")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlsnto)
                    .HasColumnName("VLSNTO")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Vlstam)
                    .HasColumnName("VLSTAM")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlsub)
                    .HasColumnName("VLSUB")
                    .HasColumnType("graphic(8)");

                entity.Property(e => e.Vltaxp)
                    .HasColumnName("VLTAXP")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vltnn)
                    .HasColumnName("VLTNN")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vltnst)
                    .HasColumnName("VLTNST")
                    .HasColumnType("graphic(20)");

                entity.Property(e => e.Vltorg)
                    .HasColumnName("VLTORG")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Vltxa1)
                    .HasColumnName("VLTXA1")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Vltxa3)
                    .HasColumnName("VLTXA3")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Vlu)
                    .HasColumnName("VLU")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlum)
                    .HasColumnName("VLUM")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Vlunit)
                    .HasColumnName("VLUNIT")
                    .HasColumnType("graphic(8)");

                entity.Property(e => e.Vlupmj)
                    .HasColumnName("VLUPMJ")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Vlupmt)
                    .HasColumnName("VLUPMT")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Vlurab)
                    .HasColumnName("VLURAB")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Vlurat)
                    .HasColumnName("VLURAT")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlurc1)
                    .HasColumnName("VLURC1")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlurdt)
                    .HasColumnName("VLURDT")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Vlurrf)
                    .HasColumnName("VLURRF")
                    .HasColumnType("graphic(15)");

                entity.Property(e => e.Vluser)
                    .HasColumnName("VLUSER")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Vlvinv)
                    .HasColumnName("VLVINV")
                    .HasColumnType("graphic(25)");

                entity.Property(e => e.Vlvod)
                    .HasColumnName("VLVOD")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Vlvr01)
                    .HasColumnName("VLVR01")
                    .HasColumnType("graphic(25)");

                entity.Property(e => e.Vlwtad)
                    .HasColumnName("VLWTAD")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlwtaf)
                    .HasColumnName("VLWTAF")
                    .HasColumnType("decimal(15, 0)");

                entity.Property(e => e.Vlyc01)
                    .HasColumnName("VLYC01")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlyc02)
                    .HasColumnName("VLYC02")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlyc03)
                    .HasColumnName("VLYC03")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlyc04)
                    .HasColumnName("VLYC04")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlyc05)
                    .HasColumnName("VLYC05")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlyc06)
                    .HasColumnName("VLYC06")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlyc07)
                    .HasColumnName("VLYC07")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlyc08)
                    .HasColumnName("VLYC08")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlyc09)
                    .HasColumnName("VLYC09")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Vlyc10)
                    .HasColumnName("VLYC10")
                    .HasColumnType("graphic(3)");
            });

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

            modelBuilder.Entity<F20103>(entity =>
            {
                entity.HasKey(e => e.Epemployid);

                entity.ToTable("F20103", "HILLDTA");

                entity.HasIndex(e => e.Epemployid)
                    .HasName("F20103_PK")
                    .IsUnique();

                entity.Property(e => e.Epemployid)
                    .HasColumnName("EPEMPLOYID")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Epappreqd)
                    .HasColumnName("EPAPPREQD")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Epeftj)
                    .HasColumnName("EPEFTJ")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Epemplref)
                    .HasColumnName("EPEMPLREF")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Epemsdate1)
                    .HasColumnName("EPEMSDATE1")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Epemsflag1)
                    .HasColumnName("EPEMSFLAG1")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Epemsflag2)
                    .HasColumnName("EPEMSFLAG2")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Epemsnum10)
                    .HasColumnName("EPEMSNUM10")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Epemsstr10)
                    .HasColumnName("EPEMSSTR10")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Epemsstr40)
                    .HasColumnName("EPEMSSTR40")
                    .HasColumnType("graphic(40)");

                entity.Property(e => e.Epgrpprof)
                    .HasColumnName("EPGRPPROF")
                    .HasColumnType("graphic(5)");

                entity.Property(e => e.Ephmcusrce)
                    .HasColumnName("EPHMCUSRCE")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Epjobn)
                    .HasColumnName("EPJOBN")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Epmgrid)
                    .HasColumnName("EPMGRID")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Epmonempl)
                    .HasColumnName("EPMONEMPL")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Epmultiemp)
                    .HasColumnName("EPMULTIEMP")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Epostp)
                    .HasColumnName("EPOSTP")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Eppid)
                    .HasColumnName("EPPID")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Epreimcrcy)
                    .HasColumnName("EPREIMCRCY")
                    .HasColumnType("graphic(3)");

                entity.Property(e => e.Epreimmeth)
                    .HasColumnName("EPREIMMETH")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Epupmj)
                    .HasColumnName("EPUPMJ")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Epupmt)
                    .HasColumnName("EPUPMT")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Epuser)
                    .HasColumnName("EPUSER")
                    .HasColumnType("graphic(10)");
            });

            modelBuilder.Entity<F0092>(entity =>
            {
                entity.HasKey(e => e.Uluser);

                entity.ToTable("F0092", "SY900");

                entity.HasIndex(e => e.Uluser)
                    .HasName("F0092_PK")
                    .IsUnique();

                entity.Property(e => e.Uluser)
                    .HasColumnName("ULUSER")
                    .HasColumnType("graphic(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ulan8)
                    .HasColumnName("ULAN8")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Ulclib)
                    .HasColumnName("ULCLIB")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulcmde)
                    .HasColumnName("ULCMDE")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Ulfstp)
                    .HasColumnName("ULFSTP")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Ulipgm)
                    .HasColumnName("ULIPGM")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Uljobq)
                    .HasColumnName("ULJOBQ")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Uljsp)
                    .HasColumnName("ULJSP")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Ulllvl)
                    .HasColumnName("ULLLVL")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Ullmsg)
                    .HasColumnName("ULLMSG")
                    .HasColumnType("graphic(7)");

                entity.Property(e => e.Ullod)
                    .HasColumnName("ULLOD")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Ullsev)
                    .HasColumnName("ULLSEV")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Ulmni)
                    .HasColumnName("ULMNI")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulmska)
                    .HasColumnName("ULMSKA")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Ulmskd)
                    .HasColumnName("ULMSKD")
                    .HasColumnType("graphic(2)");

                entity.Property(e => e.Ulmskf)
                    .HasColumnName("ULMSKF")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Ulmskj)
                    .HasColumnName("ULMSKJ")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Ulmskk)
                    .HasColumnName("ULMSKK")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Ulmtvl)
                    .HasColumnName("ULMTVL")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Uloutp)
                    .HasColumnName("ULOUTP")
                    .HasColumnType("graphic(1)");

                entity.Property(e => e.Uloutq)
                    .HasColumnName("ULOUTQ")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulpid)
                    .HasColumnName("ULPID")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulprtl)
                    .HasColumnName("ULPRTL")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulugrp)
                    .HasColumnName("ULUGRP")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul01)
                    .HasColumnName("ULUL01")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul02)
                    .HasColumnName("ULUL02")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul03)
                    .HasColumnName("ULUL03")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul04)
                    .HasColumnName("ULUL04")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul05)
                    .HasColumnName("ULUL05")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul06)
                    .HasColumnName("ULUL06")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul07)
                    .HasColumnName("ULUL07")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul08)
                    .HasColumnName("ULUL08")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul09)
                    .HasColumnName("ULUL09")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul10)
                    .HasColumnName("ULUL10")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul11)
                    .HasColumnName("ULUL11")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul12)
                    .HasColumnName("ULUL12")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul13)
                    .HasColumnName("ULUL13")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul14)
                    .HasColumnName("ULUL14")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul15)
                    .HasColumnName("ULUL15")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul16)
                    .HasColumnName("ULUL16")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul17)
                    .HasColumnName("ULUL17")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul18)
                    .HasColumnName("ULUL18")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul19)
                    .HasColumnName("ULUL19")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul20)
                    .HasColumnName("ULUL20")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul21)
                    .HasColumnName("ULUL21")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul22)
                    .HasColumnName("ULUL22")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul23)
                    .HasColumnName("ULUL23")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul24)
                    .HasColumnName("ULUL24")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulul25)
                    .HasColumnName("ULUL25")
                    .HasColumnType("graphic(10)");

                entity.Property(e => e.Ulutyp)
                    .HasColumnName("ULUTYP")
                    .HasColumnType("graphic(10)");
            });
        }
    }
}
