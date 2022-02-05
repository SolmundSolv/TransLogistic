using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.EntitiesForView;

namespace Projekt.ViewModels
{
    public class WszystkiePojazdyViewModel:WszystkieViewModel<PojazdForAllView>
    {
        #region  Constructor
        public WszystkiePojazdyViewModel()
            : base()
        {
            base.DisplayName = "Pojazdy";
        }

        #endregion  Constructor

        #region Sortowanie i Filrt

        public override void Sort()
        {
            if (SortField == "Model")
            {
                List = new ObservableCollection<PojazdForAllView>(List.OrderBy(item => item.Model));
            }
            if (SortField == "Marka")
            {
                List = new ObservableCollection<PojazdForAllView>(List.OrderBy(item => item.Model));
            }
        }
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Model", "Marka" };
        }
        public override void Find()
        {
            load();
            if (FindField == "Model")
            {
                if (TypeField == "Zaczyna się")
                {
                    List = new ObservableCollection<PojazdForAllView>(List.Where(item => item.Model != null && item.Model.ToUpper().StartsWith(FindTextbox.ToUpper())));
                }
                if (TypeField == "Zawiera")
                {
                    List = new ObservableCollection<PojazdForAllView>(List.Where(item => item.Model != null && item.Model.ToUpper().Contains(FindTextbox.ToUpper())));
                }
            }
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
            List = new ObservableCollection<PojazdForAllView>
                (
                    //Linq => odpowiednik C# (obiektowy) SQL
                    from pojazd in transLogisticEntities.Pojazd

                    select new PojazdForAllView
                    {
                        pojazd_id = pojazd.pojazd_id,
                        Marka = pojazd.Marka,
                        Model = pojazd.Model,
                        Ladownosc = pojazd.Ladownosc,
                        VIN = pojazd.VIN
                    }
                );

        }

        #endregion Helpers

    }
}
