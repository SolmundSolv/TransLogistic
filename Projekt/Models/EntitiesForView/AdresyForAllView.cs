using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models.EntitiesForView
{
    public partial class AdresyForAllView
    {
        public int adresy_id { get; set; }
        public string ulica { get; set; }
        public string miasto { get; set; }
        public int kod_pocztowy { get; set; }
        public string kraj { get; set; }
    }
}
