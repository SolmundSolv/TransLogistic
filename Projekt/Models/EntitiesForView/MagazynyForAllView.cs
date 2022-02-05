using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models.EntitiesForViews
{
    public partial class MagazynyForAllView
    {
        public int magazyn_id { get; set; }
        public string nazwa { get; set; }
        public int adresy_id { get; set; }
        public int ladownosc { get; set; }
        public bool aktywnosc { get; set; }
        public string miasto { get; set; }
        public string ulica { get; set; } 
    }
}
