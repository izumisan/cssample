using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace InteractionRequestDialog2.ViewModels
{
    public class FooDialogViewModel : BindableBase, IInteractionRequestAware
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FooDialogViewModel()
            : base()
        {
            System.Diagnostics.Debug.WriteLine( "FooDialogViewModel ctor." );

            OkCommand = new DelegateCommand( () =>
            {
                if ( Item1Checked )
                {
                    _fooDialogContent.SelectedItem = "item 1";
                }
                else
                {
                    _fooDialogContent.SelectedItem = "item 2";
                }

                // コールバックの実行
                FinishInteraction.Invoke();
            } );
        }

        private FooDialogContent _fooDialogContent = null;
        private string _label = string.Empty;
        private bool _item1Checked = true;

        #region IInteractionRequestAwareの実装

        public INotification Notification
        {
            get { return _fooDialogContent; }
            set
            {
                // PopupWindowActionにより、InteractionRequestのコンテキストがセットされる
                System.Diagnostics.Debug.WriteLine( "set Notification" );

                _fooDialogContent = value as FooDialogContent;
                Label = _fooDialogContent.Content as string;
            }
        }

        public Action FinishInteraction { get; set; }
        #endregion

        public string Label
        {
            get { return _label; }
            set { SetProperty( ref _label, value ); }
        }

        public bool Item1Checked
        {
            get { return _item1Checked; }
            set { SetProperty( ref _item1Checked, value ); }
        }

        public DelegateCommand OkCommand { get; private set; } = null;
    }
}
