using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest1.Domain
{
    public class Afspraak
    {
        public Afspraak()
        {

        }
        public Afspraak(DateTime beginDatum, AdresAfspraak adres)
        {
            BeginDatum = beginDatum;
            Adres = adres;
        }

        public int Id { get; set; }
        public DateTime BeginDatum { get; set;  }
        public AdresAfspraak Adres { get; set; }
    }
}
