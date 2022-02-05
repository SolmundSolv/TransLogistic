using GalaSoft.MvvmLight.Messaging;
using Projekt.Helper;
using Projekt.Models.Entities;
using Projekt.Models.EntitiesForView;
using Projekt.Models.Validatory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekt.ViewModels
{
    public class NoweDaneWysylkiViewModel:JedenViewModel<DaneWysylki>,IDataErrorInfo
    {
        
            #region Fields
            private BaseCommand _ShowAdresy;
            #endregion Fields

            #region Konstruktor
            public NoweDaneWysylkiViewModel()
            {
                base.DisplayName = "Dane Wysyłki";
                item = new DaneWysylki();
                Messenger.Default.Register<AdresyForAllView>(this, getWybranyAdres);
            }
        #endregion Konstruktor
        #region Propoerties
        //
        public ICommand ShowAdresy
        {
            get
            {
                if (_ShowAdresy == null)
                {
                    _ShowAdresy = new BaseCommand(() => Messenger.Default.Send("AdresyAll"));
                }
                return _ShowAdresy;
            }
        }
        public string imie
        {
            get
            {
                return item.imie;
            }
            set
            {
                if (item.imie != value)
                {
                    item.imie = value;
                    base.OnPropertyChanged(() => imie);
                }
            }
        }

        public string nazwisko
        {
            get
            {
                return item.nazwisko;
            }
            set
            {
                if (item.nazwisko != value)
                {
                    item.nazwisko = value;
                    base.OnPropertyChanged(() => nazwisko);
                }
            }
        }

        public string nr_tel
        {
            get
            {
                return item.nr_tel;
            }
            set
            {
                if (item.nr_tel != value)
                {
                    item.nr_tel = value;
                    base.OnPropertyChanged(() => nr_tel);
                }
            }
        }

        public string e_mail
        {
            get
            {
                return item.e_mail;
            }
            set
            {
                if (item.e_mail != value)
                {
                item.e_mail = value;
                base.OnPropertyChanged(() => e_mail);
                }
            }
        }

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

        private string _AdresMiasto;
        public string AdresMiasto
        {
            get
            {
                return _AdresMiasto;
            }
            set
            {
                if (_AdresMiasto != value)
                {
                    _AdresMiasto = value;
                    base.OnPropertyChanged(() => AdresMiasto);
                }
            }
        }

        private int _AdresKod;
        public int AdresKod
        {
            get
            {
                return _AdresKod;
            }
            set
            {
                if (_AdresKod != value)
                {
                    _AdresKod = value;
                    base.OnPropertyChanged(() => AdresKod);
                }
            }
        }

        private string _AdresUlica;
        public string AdresUlica
        {
            get
            {
                return _AdresUlica;
            }
            set
            {
                if (_AdresUlica != value)
                {
                    _AdresUlica = value;
                    base.OnPropertyChanged(() => AdresUlica);
                }
            }
        }


        //
        public IQueryable<ComboBoxKeyAndValue> KontrahenciComboBoxItems
        {
            get
            {
                return
                    (
                        //zapytanie pobiera 
                        from adres in transLogisticEntities.Adresy
                        select new ComboBoxKeyAndValue
                        {
                            Key = adres.adresy_id,
                            Value = adres.miasto + " " + adres.kod_pocztowy + " " + adres.ulica
                        }
                    ).ToList().AsQueryable();
            }
        }
        #endregion Properties
        #region  Helpers 
        public override void Save()
        {
            item.aktywnosc = true;
            item.kto_dodal = "1";
            item.kiedy_dodal = DateTime.Now;
            transLogisticEntities.DaneWysylki.Add(item);
            transLogisticEntities.SaveChanges();
        }
        private void getWybranyAdres(AdresyForAllView item)
        {
            adresy_id = item.adresy_id;
            AdresMiasto = item.miasto;
            AdresKod = item.kod_pocztowy;
            AdresUlica = item.ulica;
        }
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
