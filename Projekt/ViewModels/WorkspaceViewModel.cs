﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projekt.Helper;
using System.Windows.Input;

namespace Projekt.ViewModels
{
    //to ...
    public abstract class WorkspaceViewModel : BaseViewModel
    {
        //kaz...
        #region Fields
        private BaseCommand _CloseCommand;
        #endregion 

        #region Constructor
        public WorkspaceViewModel()
        {
        }
        #endregion 

        #region CloseCommand
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new BaseCommand(() => this.OnRequestClose());
                return _CloseCommand;
            }
        }
        #endregion 

        #region RequestClose [event]
        public event EventHandler RequestClose;
        protected void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion 
    }
}
