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
    
    public partial class Pojazd
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pojazd()
        {
            this.Przewoz = new HashSet<Przewoz>();
        }
    
        public int pojazd_id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Ladownosc { get; set; }
        public string VIN { get; set; }
        public bool aktywnosc { get; set; }
        public string kto_dodal { get; set; }
        public System.DateTime kiedy_dodal { get; set; }
        public string kto_edytowal { get; set; }
        public Nullable<System.DateTime> kiedy_edytowal { get; set; }
        public string kto_usunal { get; set; }
        public Nullable<System.DateTime> kiedy_usunal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Przewoz> Przewoz { get; set; }
    }
}