using GalaSoft.MvvmLight.Messaging;
using Projekt.Models.Entities;
using Projekt.Models.EntitiesForViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModels
{
    public class WszystkieMagazynyViewModel:WszystkieViewModel<MagazynyForAllView>
    {
        #region Properties
        private MagazynyForAllView _WybranyMagazyny;
        public MagazynyForAllView WybranyMagazyny
        {
            get
            {
                return _WybranyMagazyny;
            }
            set
            {
                if (_WybranyMagazyny != value)
                {
                    //
                    _WybranyMagazyny = value;
                    //
                    Messenger.Default.Send(_WybranyMagazyny);
                    //i 
                    OnRequestClose();

                }
            }
        }
        #endregion
        #region  Constructor
        public WszystkieMagazynyViewModel()
            : base()
        {
            base.DisplayName = "Magazyny";
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
            List = new ObservableCollection<MagazynyForAllView>
                (
                    //Linq => odpowiednik C# (obiektowy) SQL
                    from magazyn in transLogisticEntities.Magazyn

                    select new MagazynyForAllView
                    {
                        magazyn_id = magazyn.magazyn_id,
                        nazwa = magazyn.nazwa,
                        ladownosc = magazyn.ladownosc,
                        adresy_id = magazyn.adresy_id,
                        miasto = magazyn.Adresy.miasto,
                        ulica = magazyn.Adresy.ulica
                    }
                );

        }

        #endregion Helpers


    }
}
