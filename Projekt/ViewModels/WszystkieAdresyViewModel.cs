using GalaSoft.MvvmLight.Messaging;
using Projekt.Models.Entities;
using Projekt.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModels
{
    public class WszystkieAdresyViewModel:WszystkieViewModel<AdresyForAllView>
    {
        #region Properties
        private AdresyForAllView _WybranyAdresy;
        public AdresyForAllView WybranyAdresy
        {
            get
            {
                return _WybranyAdresy;
            }
            set
            {
                if (_WybranyAdresy != value)
                {
                    //
                    _WybranyAdresy = value;
                    //
                    Messenger.Default.Send(_WybranyAdresy);
                    //i 
                    OnRequestClose();

                }
            }
        }
        #endregion

        #region  Constructor
        public WszystkieAdresyViewModel()
            : base()
        {
            base.DisplayName = "Adresy";
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
            List = new ObservableCollection<AdresyForAllView>
                (
                    //Linq => odpowiednik C# (obiektowy) SQL
                    from adres in transLogisticEntities.Adresy

                    select new AdresyForAllView
                    {
                        adresy_id = adres.adresy_id,
                        kod_pocztowy = adres.kod_pocztowy,
                        kraj = adres.kraj,
                        miasto = adres.miasto,
                        ulica = adres.ulica
                    }
                );

        }

        #endregion Helpers

    }
}