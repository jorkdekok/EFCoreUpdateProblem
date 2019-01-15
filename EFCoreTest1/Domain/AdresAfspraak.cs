using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest1.Domain
{
    public class AdresAfspraak
    {
        public string Straat { get; private set; }

        public HuisnummerType Huisnummer { get; private set; }
    }
}
