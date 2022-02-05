using GalaSoft.MvvmLight.Messaging;
using Projekt.Helper;
using Projekt.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekt.ViewModels
{
    public class NowyAdresViewModel:JedenViewModel<Adresy>
    {

        #region Fields
        private BaseCommand _ShowKontrahenci;//poprawa
        #endregion Fields

        #region Konstruktor
        public NowyAdresViewModel()
        {
            base.DisplayName = "Adres";
            item = new Adresy();
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

        public int adresy_id
        {
            get
            {
                return item.adresy_id;
            }
            set
            {
                if (item.adresy_id != value)
                {
                    item.adresy_id = value;
                    base.OnPropertyChanged(() => adresy_id);
                }
            }
        }

        public int kod_pocztowy
        {
            get
            {
                return item.kod_pocztowy;
            }
            set
            {
                if (item.kod_pocztowy != value)
                {
                    item.kod_pocztowy = value;
                    base.OnPropertyChanged(() => kod_pocztowy);
                }
            }
        }

        public string kraj
        {
            get
            {
                return item.kraj;
            }
            set
            {
                if (item.kraj != value)
                {
                    item.kraj = value;
                    base.OnPropertyChanged(() => kraj);
                }
            }
        }

        public string miasto
        {
            get
            {
                return item.miasto;
            }
            set
            {
                if (item.miasto != value)
                {
                    item.miasto = value;
                    base.OnPropertyChanged(() => miasto);
                }
            }
        }

        public string ulica
        {
            get
            {
                return item.ulica;
            }
            set
            {
                if (item.ulica != value)
                {
                    item.ulica = value;
                    base.OnPropertyChanged(() => ulica);
                }
            }
        }


        #endregion Properties
        #region  Helpers 
        public override void Save()
        {
            item.aktywnosc = true;
            item.kto_dodal = "1";
            item.kiedy_dodal = DateTime.Now;
            transLogisticEntities.Adresy.Add(item);
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
        //#region Validation
        //public string Error
        //{
        //    get
        //    {
        //        return null;
        //    }
        //}

        //public string this[string name]
        //{
        //    get
        //    {
        //        string komunikat = null;
        //        if (name == "DataSprzedazy")
        //        {
        //            komunikat = BiznesValidator.SprawdzDateSprzedazy(this.DataWystawienia, this.TerminPlatnosci);
        //        }
        //        if (name == "Rabat")
        //        {
        //            komunikat = BiznesValidator.SprawdzRabat(this.Numer);
        //        }
        //        return komunikat;
        //    }
        //}

        //public override bool IsValid()
        //{
        //    //decydujemy ze nazwa stawkavatzakupu i sprzedazy musza być dobre aby zapisac 
        //    if (this["DataSprzedazy"] == null && this["Rabat"] == null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion
    }

}


