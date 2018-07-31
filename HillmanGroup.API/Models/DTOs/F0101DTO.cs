using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace HillmanGroup.API.Models.DTOs
{
    public class F0101DTO
    {
        public F0101DTO (DataRow dr)
        {

            foreach (var prop in this.GetType().GetProperties())
            {
                prop.SetValue(this, dr[prop.Name] as string);
                //Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(foo, null));
            }
        }

        public string ABAN8 { get; set; }
        public string ABALKY { get; set; }
        public string ABTAX { get; set; }
        public string ABALPH { get; set; }
        public string ABDC { get; set; }
        public string ABMCU { get; set; }
        public string ABSIC { get; set; }
        public string ABLNGP { get; set; }
        public string ABAT1 { get; set; }
        public string ABCM { get; set; }
        public string ABTAXC { get; set; }
        public string ABAT2 { get; set; }
        public string ABAT3 { get; set; }
        public string ABAT4 { get; set; }
        public string ABAT5 { get; set; }
        public string ABATP { get; set; }
        public string ABATR { get; set; }
        public string ABATPR { get; set; }
        public string ABAB3 { get; set; }
        public string ABATE { get; set; }
        public string ABSBLI { get; set; }
        public string ABEFTB { get; set; }
        public string ABAN81 { get; set; }
        public string ABAN82 { get; set; }
        public string ABAN83 { get; set; }
        public string ABAN84 { get; set; }
        public string ABAN86 { get; set; }
        public string ABAN85 { get; set; }
        public string ABAC01 { get; set; }
        public string ABAC02 { get; set; }
        public string ABAC03 { get; set; }
        public string ABAC04 { get; set; }
        public string ABAC05 { get; set; }
        public string ABAC06 { get; set; }
        public string ABAC07 { get; set; }
        public string ABAC08 { get; set; }
        public string ABAC09 { get; set; }
        public string ABAC10 { get; set; }
        public string ABAC11 { get; set; }
        public string ABAC12 { get; set; }
        public string ABAC13 { get; set; }
        public string ABAC14 { get; set; }
        public string ABAC15 { get; set; }
        public string ABAC16 { get; set; }
        public string ABAC17 { get; set; }
        public string ABAC18 { get; set; }
        public string ABAC19 { get; set; }
        public string ABAC20 { get; set; }
        public string ABAC21 { get; set; }
        public string ABAC22 { get; set; }
        public string ABAC23 { get; set; }
        public string ABAC24 { get; set; }
        public string ABAC25 { get; set; }
        public string ABAC26 { get; set; }
        public string ABAC27 { get; set; }
        public string ABAC28 { get; set; }
        public string ABAC29 { get; set; }
        public string ABAC30 { get; set; }
        public string ABGLBA { get; set; }
        public string ABPTI { get; set; }
        public string ABPDI { get; set; }
        public string ABMSGA { get; set; }
        public string ABRMK { get; set; }
        public string ABTXCT { get; set; }
        public string ABTX2 { get; set; }
        public string ABALP1 { get; set; }
        public string ABURCD { get; set; }
        public string ABURDT { get; set; }
        public string ABURAT { get; set; }
        public string ABURAB { get; set; }
        public string ABURRF { get; set; }
        public string ABUSER { get; set; }
        public string ABPID { get; set; }
        public string ABUPMJ { get; set; }
        public string ABJOBN { get; set; }
        public string ABUPMT { get; set; }
        public string ABPRGF { get; set; }
        public string ABSCCLTP { get; set; }
        public string ABTICKER { get; set; }
        public string ABEXCHG { get; set; }
        public string ABDUNS { get; set; }
        public string ABCLASS01 { get; set; }
        public string ABCLASS02 { get; set; }
        public string ABCLASS03 { get; set; }
        public string ABCLASS04 { get; set; }
        public string ABCLASS05 { get; set; }
        public string ABNOE { get; set; }
        public string ABGROWTHR { get; set; }
        public string ABYEARSTAR { get; set; }
        public string ABAEMPGP { get; set; }
        public string ABACTIN { get; set; }
        public string ABREVRNG { get; set; }
        public string ABSYNCS { get; set; }
        public string ABPERRS { get; set; }
        public string ABCAAD { get; set; }
    }
}
