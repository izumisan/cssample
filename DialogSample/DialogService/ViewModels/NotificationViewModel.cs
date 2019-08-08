using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace DialogService.ViewModels
{
    public class NotificationViewModel : BindableBase, IDialogAware
    {
        public NotificationViewModel()
            : base()
        {
            OkCommand = new DelegateCommand( () => RequestClose?.Invoke( new DialogResult( ButtonResult.OK ) ) );
        }

        #region IDialogAwareの実装

        public event Action<IDialogResult> RequestClose = null;

        public string Title { get; } = "Notification";

        public void OnDialogOpened( IDialogParameters parameters )
        {
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }
        #endregion

        public DelegateCommand OkCommand { get; private set; } = null;
    }
}
