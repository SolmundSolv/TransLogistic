using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models.EntitiesForView
{
    public partial class PojazdForAllView
    {
        public int pojazd_id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Ladownosc { get; set; }
        public string VIN { get; set; }
    }
}
