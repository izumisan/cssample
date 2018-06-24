using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace InteractionRequestApp.CustomModule.ViewModels
{
    public class CustomViewModel : BindableBase, IInteractionRequestAware
    {
        public CustomViewModel()
            : base()
        {
            OkCommand = new DelegateCommand( okCommandExecute );
        }

        private CustomNotification _notification = null;

        private string _input = string.Empty;

        #region IInteractionRequestAwareの実装

        public INotification Notification
        {
            get { return _notification; }
            set
            {
                _notification = value as CustomNotification;

                this.Input = string.Empty;
            }
        }

        public Action FinishInteraction { get; set; }

        #endregion

        public string Input
        {
            get { return _input; }
            set { SetProperty( ref _input, value ); }
        }

        public DelegateCommand OkCommand { get; private set; }

        private void okCommandExecute()
        {
            _notification.Input = Input;

            this.FinishInteraction.Invoke();
        }
    }
}
