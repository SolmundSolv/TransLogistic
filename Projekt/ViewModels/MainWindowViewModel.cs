using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Projekt.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Projekt.ViewModels;

namespace Projekt.ViewModels
{
    //to jest 
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        //to jest 
        private ReadOnlyCollection<CommandViewModel> _Commands;
        //to jest 
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        //
        //
        private BaseCommand _NowyTowarCommand;
        //public ICommand NowyTowarCommand
        //{
        //    get
        //    {
        //        if (_NowyTowarCommand == null)
        //            _NowyTowarCommand = new BaseCommand(() => CreateView(new NowyTowarViewModel()));//
        //        return _NowyTowarCommand;
        //    }
        //}
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            //to jest 
            Messenger.Default.Register<string>(this, open);
            return new List<CommandViewModel>
                {
                    //tu
                    new CommandViewModel(
                        "Pojazd",
                        new BaseCommand(() => this.CreateView(new NowyPojazdViewModel()))),

            //        new CommandViewModel(
            //            "Towar",
            //            new BaseCommand(() => this.CreateView(new NowyTowarViewModel()))),

                        new CommandViewModel(
                            "Pojazdy",
                            new BaseCommand(() => this.ShowAllPojazdy())),

                         new CommandViewModel(
                            "Adresy",
                            new BaseCommand(() => this.ShowAllAdresy())),

                        new CommandViewModel(
                            "Adres",
                            new BaseCommand(() => this.CreateView(new NowyAdresViewModel()))),

                         new CommandViewModel(
                            "Dane Wysyłki",
                            new BaseCommand(() => this.CreateView(new NoweDaneWysylkiViewModel()))),

                          new CommandViewModel(
                            "Magazyny",
                            new BaseCommand(() => this.ShowAllMagazyny())),

                         new CommandViewModel(
                            "Rodzaje paczek",
                            new BaseCommand(() => this.ShowAllRodzajePaczek())),

                //        new CommandViewModel(
                //            "ADC",
                //            new BaseCommand(() => this.CreateView(new ADCViewModel()))),

            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers
        private void open(string name) //w argumencie name jest zapisana treść komunikatu odebrana przez Messanger
        {
            if (name == "PojazdyAdd")
                this.CreateView(new NowyPojazdViewModel());
            //if (name == "TowaryAdd")
            //    this.CreateView(new NowyTowarViewModel());
            if (name == "AdresyAll")
                this.ShowAllAdresy();
            if (name == "AdresyAdd")
                this.ShowAllAdresy();
        }
        //
        //
        private void CreateView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllPojazdy()
        {
            WszystkiePojazdyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkiePojazdyViewModel) 
                as WszystkiePojazdyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePojazdyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }private void ShowAllAdresy()
        {
            if (!(this.Workspaces.FirstOrDefault(vm => vm is WszystkieAdresyViewModel) is WszystkieAdresyViewModel workspace))
            {
                workspace = new WszystkieAdresyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
    private void ShowAllPaczki()
        {
            if (!(this.Workspaces.FirstOrDefault(vm => vm is WszystkiePaczkiViewModel) is WszystkiePaczkiViewModel workspace))
            {
                workspace = new WszystkiePaczkiViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
    

        private void ShowAllMagazyny()
        {
            if (!(this.Workspaces.FirstOrDefault(vm => vm is WszystkieMagazynyViewModel) is WszystkieMagazynyViewModel workspace))
            {
                workspace = new WszystkieMagazynyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllRodzajePaczek()
        {
            if (!(this.Workspaces.FirstOrDefault(vm => vm is WszystkieRodzajPaczkiViewModel) is WszystkieRodzajPaczkiViewModel workspace))
            {
                workspace = new WszystkieRodzajPaczkiViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }


        //
        private void ShowAllTowar()
        {
            //WszystkieTowaryViewModel workspace =
            //    this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel)
            //    as WszystkieTowaryViewModel;
            //if (workspace == null)
            //{
            //    workspace = new WszystkieTowaryViewModel();
            //    this.Workspaces.Add(workspace);
            //}

            //this.SetActiveWorkspace(workspace);
        }
        //
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion
    }
}
