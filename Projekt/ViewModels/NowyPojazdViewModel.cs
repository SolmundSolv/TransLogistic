using GalaSoft.MvvmLight.Messaging;
using Projekt.Helper;
using Projekt.Models.Entities;
using Projekt.Models.EntitiesForView;
using Projekt.Models.Validatory;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekt.ViewModels
{
    public class NowyPojazdViewModel:JedenViewModel<Pojazd>,IDataErrorInfo
    {
            
        #region Fields
        private BaseCommand _ShowKontrahenci;//poprawa
        #endregion Fields

        #region Konstruktor
        public NowyPojazdViewModel()
        {
            base.DisplayName = "Pojazd";
            item = new Pojazd();
         //   Messenger.Default.Register<PojazdForAllView>(this, getWybranyKontrahent);
        }
        #endregion Konstruktor
        #region Propoerties
        //
        //
        public ICommand ShowKontrahenci
        {
            get
            {
                if (_ShowKontrahenci == null)
                {
                    _ShowKontrahenci = new BaseCommand(() => Messenger.Default.Send("KontrahenciAll"));//poprawa
                }
                return _ShowKontrahenci;
            }
        }
        public int pojazd_id { 
            get
            {
                return item.pojazd_id;
            }

            set
            {
                if (item.pojazd_id != value)
                {
                    item.pojazd_id = value;
                    base.OnPropertyChanged(()=>pojazd_id);
                }
            }
        }
        public string Marka
        {
            get
            {
                return item.Marka;
            }
            set
            {
                if (item.Marka != value)
                {
                    item.Marka = value;
                    base.OnPropertyChanged(() => Marka);
                }
            }
        }

        public string Model
        {
            get
            {
                return item.Model;
            }
            set
            {
                if (item.Model != value)
                {
                    item.Model = value;
                    base.OnPropertyChanged(() => Model);
                }
            }
        }

        public int Ladownosc
        {
            get
            {
                return item.Ladownosc;
            }
            set
            {
                if (item.Ladownosc != value)
                {
                    item.Ladownosc = value;
                    base.OnPropertyChanged(() => Ladownosc);
                }
            }
        }

        public string VIN
        {
            get
            {
                return item.VIN;
            }
            set
            {
                if (item.VIN != value)
                {
                    item.VIN = value;
                    base.OnPropertyChanged(() => VIN);
                }
            }
        }

        //
        //public IQueryable<ComboBoxKeyAndValue> KontrahenciComboBoxItems
        //{
        //    get
        //    {
        //        return
        //            (
        //                //zapytanie pobiera 
        //                from kontrahent in fakturyEntities.Kontrahent
        //                select new ComboBoxKeyAndValue
        //                {
        //                    Key = kontrahent.IdKontrahenta,
        //                    Value = kontrahent.Kod + " " + kontrahent.Nazwa + " " + kontrahent.Nip
        //                }
        //            ).ToList().AsQueryable();
        //    }
        //}
        
        #endregion Properties
        #region  Helpers 
        public override void Save()
        {
            item.aktywnosc = true;
            item.kto_dodal = "1";
            item.kiedy_dodal = DateTime.Now;
            transLogisticEntities.Pojazd.Add(item);
            transLogisticEntities.SaveChanges();
        }
        //private void getWybranyKontrahent(KontrahentForAllView kontrahent)
        //{
        //    IdKontrahenta = kontrahent.IdKontahenta;
        //    KontrahentNazwa = kontrahent.Nazwa;
        //    KontrahentNip = kontrahent.Nip;
        //    KontrahentAdres = kontrahent.Adres;
        //}
        #endregion Heplpers
        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string name]
        {
            get
            {
                string komunikat = null;
                //if (name == "DataSprzedazy")
                //{
                //    komunikat = BiznesValidator.SprawdzDateSprzedazy(this.DataWystawienia, this.TerminPlatnosci);
                //}
                //if (name == "Rabat")
                //{
                //    komunikat = BiznesValidator.SprawdzRabat(this.Numer);
                //}
                return komunikat;
            }
        }

        public override bool IsValid()
        {
            //decydujemy ze nazwa stawkavatzakupu i sprzedazy musza być dobre aby zapisac 
            if (this["DataSprzedazy"] == null && this["Rabat"] == null)
            {
                return true;
            }
            return false;
        }

        #endregion
    }

}

