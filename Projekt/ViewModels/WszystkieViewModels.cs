using GalaSoft.MvvmLight.Messaging;
using Projekt.Helper;
using Projekt.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Projekt.ViewModels
{
    //
    //
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        //to jest
        protected readonly TransLogisticEntities transLogisticEntities;
        //
        private BaseCommand _LoadCommand;
        //to jest 
        private BaseCommand _AddCommand;
        //
        private ObservableCollection<T> _List;
        #endregion Fields
        #region Properties
        //ta komenda wywołuje metodę load
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => load());
                }
                return _LoadCommand;
            }
        }
        //
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => add());
                }
                return _AddCommand;
            }
        }
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null) load();//jeżeli lista jest pusta, to wywołujemy metodę load
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion Properties

        #region  Constructor
        public WszystkieViewModel()
        {
            transLogisticEntities = new TransLogisticEntities();
        }
        #endregion  Constructor

        #region Sortowanie i filtrowanie
        // te komendy podlczymy pod przyciski na interfejsie
        private BaseCommand _SortCommand;
        private BaseCommand _FindCommand;
        private BaseCommand _TypeCommand;

        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }

        public string SortField { get; set; }
        //to jest properties ktory posluszy do wypelnenia comboboxa po czym sortowac
        public List<string> SortComboboxItems
        {
            get
            {
                return GetComboboxSortList();
            }
        }
        public abstract void Sort();
        public abstract List<string> GetComboboxSortList();

        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                {
                    _FindCommand = new BaseCommand(() => Find());
                }
                return _FindCommand;
            }
        }
        //to jest properties ktory posluszy do wypelnenia comboboxa po czym filtrowac
        public List<string> FindComboboxItems
        {
            get
            {
                return GetComboboxFindList();
            }
        }
        public List<string> TypeOfSearchComboboxItems
        {
            get
            {
                return new List<string> { "Zawiera", "Zaczyna się" };
            }
        }

        public abstract void Find();
        public abstract List<string> GetComboboxFindList();

        public string FindField { get; set; }
        public string TypeField { get; set; }
        public string FindTextbox { get; set; }


        #endregion
        #region Helpers
        //metoda load 
        public abstract void load();
        private void add()
        {
            //zadanie 
            //mess
            Messenger.Default.Send(DisplayName + "Add");
        }
        #endregion Helpers
    }
}
