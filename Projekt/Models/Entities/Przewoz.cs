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
    
    public partial class Przewoz
    {
        public int przewoz_id { get; set; }
        public int adres_dolwozu_id { get; set; }
        public int status_przejazdu_id { get; set; }
        public int rodzaj_przejazu_id { get; set; }
        public int pracownik_id { get; set; }
        public int zamowienie_id { get; set; }
        public int pojazd_id { get; set; }
        public System.DateTime data_wyjazdu { get; set; }
        public Nullable<System.DateTime> data_przyjazdu { get; set; }
        public bool aktywnosc { get; set; }
        public string kto_dodal { get; set; }
        public System.DateTime kiedy_dodal { get; set; }
        public string kto_edytowal { get; set; }
        public Nullable<System.DateTime> kiedy_edytowal { get; set; }
        public string kto_usunal { get; set; }
        public Nullable<System.DateTime> kiedy_usunal { get; set; }
    
        public virtual Adresy Adresy { get; set; }
        public virtual Pojazd Pojazd { get; set; }
        public virtual Pracownik Pracownik { get; set; }
        public virtual RodzajPrzejazdu RodzajPrzejazdu { get; set; }
        public virtual StatusPrzejazdu StatusPrzejazdu { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
    }
}
