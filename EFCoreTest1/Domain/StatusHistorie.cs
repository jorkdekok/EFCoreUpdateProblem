using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest1.Domain
{
    public class StatusHistorie
    {
        public int Id { get; set; }
        public int Status { get; set; }

        public Taak Taak { get; set; }
    }
}
