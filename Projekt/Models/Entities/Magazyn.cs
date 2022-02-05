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
    
    public partial class Magazyn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Magazyn()
        {
            this.PrzyjecieZewnetrzne = new HashSet<PrzyjecieZewnetrzne>();
            this.WydanieZewnetrzne = new HashSet<WydanieZewnetrzne>();
        }
    
        public int magazyn_id { get; set; }
        public string nazwa { get; set; }
        public int adresy_id { get; set; }
        public int ladownosc { get; set; }
        public bool aktywnosc { get; set; }
        public string kto_dodal { get; set; }
        public System.DateTime kiedy_dodal { get; set; }
        public string kto_edytowal { get; set; }
        public Nullable<System.DateTime> kiedy_edytowal { get; set; }
        public string kto_usunal { get; set; }
        public Nullable<System.DateTime> kiedy_usunal { get; set; }
    
        public virtual Adresy Adresy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrzyjecieZewnetrzne> PrzyjecieZewnetrzne { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WydanieZewnetrzne> WydanieZewnetrzne { get; set; }
    }
}