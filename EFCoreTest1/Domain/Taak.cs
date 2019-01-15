using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest1.Domain
{
    public class Taak
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public List<StatusHistorie> Statussen { get; set; }
    }
}
