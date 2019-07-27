using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace DialogServiceApp.ViewModels
{
    public class DialogViewModel : BindableBase, IDialogAware
    {
        public DialogViewModel()
            : base()
        {
            OkCommand = new DelegateCommand( () => RequestClose?.Invoke( new DialogResult( ButtonResult.OK ) ) );
        }

        private string _cntents = string.Empty;

        #region IDialogAwareの実装

        public event Action<IDialogResult> RequestClose = null;

        public string Title { get; set; } = "undefined";

        public void OnDialogOpened( IDialogParameters parameters )
        {
            Debug.WriteLine( nameof( OnDialogOpened ) );

            Title = parameters.GetValue<string>( "title" );
            Contents = parameters.GetValue<string>( "contents" );
        }

        public void OnDialogClosed()
        {
            Debug.WriteLine( nameof( OnDialogClosed ) );
        }

        public bool CanCloseDialog()
        {
            Debug.WriteLine( nameof( CanCloseDialog ) );
            return true;
        }
        #endregion

        public string Contents
        {
            get { return _cntents; }
            set { SetProperty( ref _cntents, value ); }
        }

        public DelegateCommand OkCommand { get; private set; }
    }
}
