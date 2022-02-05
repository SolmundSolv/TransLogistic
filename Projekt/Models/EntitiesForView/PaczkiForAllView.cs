using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models.EntitiesForView
{
    public partial class PaczkiForAllView
    {
        public int paczka_id { get; set; }
        public byte rozmiar_paczki_id { get; set; }
        public int rodzaj_paczki_id { get; set; }
        public string rodzaj_paczki_name { get; set; } 
        public int rozmiar_paczki_wys_od { get; set; }
        public int rozmiar_paczki_wys_do { get; set; }
        public int rozmiar_paczki_szer_od { get; set; }
        public int rozmiar_paczki_szer_do { get; set; }
        public int rozmiar_paczki_dlug_od { get; set; }
        public int rozmiar_paczki_dlug_do { get; set; }
    }
}
