using Projekt.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModels
{
    public partial class WszystkieRodzajPaczkiViewModel:WszystkieViewModel<RodzajePaczkiForAllView>
    {
        #region  Constructor
        public WszystkieRodzajPaczkiViewModel()
            : base()
        {
            base.DisplayName = "Rodzaje paczek";
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
            List = new ObservableCollection<RodzajePaczkiForAllView>
                (
                    //Linq => odpowiednik C# (obiektowy) SQL
                    from rodzpacz in transLogisticEntities.RodzajPaczki

                    select new RodzajePaczkiForAllView
                    {
                        rodzaj_paczki_id = rodzpacz.rodzaj_paczki_id,
                        nazwa = rodzpacz.nazwa,
                        opis = rodzpacz.opis,
                    }
                );
        }
        #endregion Helpers
    }
}
