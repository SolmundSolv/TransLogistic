using Projekt.Helper;
using Projekt.Models.Entities;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekt.ViewModels
{
    public abstract class JedenViewModel<T> : WorkspaceViewModel //
    {
        #region  Fields
        protected TransLogisticEntities transLogisticEntities ;
        protected T item;
        private BaseCommand _SaveCommand;
        #endregion Fields
        #region  Constructor
        public JedenViewModel()
            : base()
        {
            transLogisticEntities = new TransLogisticEntities();
        }
        #endregion  Constructor

        #region  Command
        public ICommand SaveCommand
        {
            get
            {

                if (_SaveCommand == null)
                {
                    _SaveCommand = new BaseCommand(() => saveAndClose());
                }
                return _SaveCommand;
            }
        }
        #endregion Command
        #region  Helpers 
        public abstract void Save();
        private void saveAndClose()
        {
            if (IsValid())
            {
                //zapisujemy obiekt
                Save();
                //zamykamy zakładkę
                base.OnRequestClose();

            }
            else
            {
                ShowMessageBox("Formularz zawiera błędy");
            }
        }
        //funkcja ...
        public virtual bool IsValid()
        {
            return true;
        }
        #endregion Heplpers
    }
}
