//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projekt.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class PrzyjecieZewnetrznePozycje
    {
        public int przyjecie_zewnetrzne_pozycje_id { get; set; }
        public int przyjecie_zewnetrzne_id { get; set; }
        public int paczka_id { get; set; }
        public int numer { get; set; }
        public bool aktywnosc { get; set; }
        public string kto_dodal { get; set; }
        public System.DateTime kiedy_dodal { get; set; }
        public string kto_edytowal { get; set; }
        public Nullable<System.DateTime> kiedy_edytowal { get; set; }
        public string kto_usunal { get; set; }
        public Nullable<System.DateTime> kiedy_usunal { get; set; }
    
        public virtual Paczka Paczka { get; set; }
        public virtual PrzyjecieZewnetrzne PrzyjecieZewnetrzne { get; set; }
    }
}
