using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.EntitiesForView;

namespace Projekt.ViewModels
{
    public class WszystkiePaczkiViewModel:WszystkieViewModel<PaczkiForAllView>
    {
        #region  Constructor
        public WszystkiePaczkiViewModel()
            : base()
        {
            base.DisplayName = "Paczki";
        }
        #endregion  Constructor
        #region Sortowanie i Filrt

        public override void Sort()
        {

        }
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Model", "Marka" };
        }
        public override void Find()
        {
            load();

        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Model", "Marka" };

        }
        #endregion

        #region Helpers
        public override void load()
        {
            //za pomoca 
            //
            List = new ObservableCollection<PaczkiForAllView>
                (
                    //Linq => odpowiednik C# (obiektowy) SQL
                    from paczka in transLogisticEntities.Paczka

                    select new PaczkiForAllView
                    {
                        paczka_id = paczka.paczka_id,
                        rodzaj_paczki_id = paczka.rodzaj_paczki_id,
                        rozmiar_paczki_id = paczka.rozmiar_paczki_id,
                        rodzaj_paczki_name = paczka.RodzajPaczki.nazwa,
                        rozmiar_paczki_wys_od = paczka.RozmiarPaczki.wysokosc_od,
                        rozmiar_paczki_wys_do = paczka.RozmiarPaczki.wysokosc_do,
                        rozmiar_paczki_szer_od = paczka.RozmiarPaczki.szerokosc_do,
                        rozmiar_paczki_szer_do = paczka.RozmiarPaczki.szerokosc_do,
                        rozmiar_paczki_dlug_od = paczka.RozmiarPaczki.dlugosc_do,
                        rozmiar_paczki_dlug_do = paczka.RozmiarPaczki.dlugosc_do,
                    }
                );

        }

        #endregion Helpers


    }
}
