using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using MessageBoxSample.Components;

namespace MessageBoxSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
            InformationCommand = new DelegateCommand( () =>
            {
                MessageBoxRequest.Raise(
                    new MessageBoxContents
                    {
                        Title = "タイトル",
                        Body = "メッセージ",
                        Image = System.Windows.MessageBoxImage.Information,
                        Button = System.Windows.MessageBoxButton.OK
                    } );
            } );

            ConfirmationCommand = new DelegateCommand( () =>
            {
                MessageBoxRequest.Raise(
                    new MessageBoxContents
                    {
                        Title = "タイトル",
                        Body = "メッセージ",
                        Image = System.Windows.MessageBoxImage.Question,
                        Button = System.Windows.MessageBoxButton.OKCancel
                    },
                    ( c ) =>
                    {
                        if ( c.Result == System.Windows.MessageBoxResult.OK )
                        {
                            Message = "Accepted.";
                        }
                        else
                        {
                            Message = "Canceled.";
                        }
                    } );
            } );
        }

        private string _message = string.Empty;

        public MessageBoxRequest MessageBoxRequest { get; } = new MessageBoxRequest();

        public DelegateCommand InformationCommand { get; }

        public DelegateCommand ConfirmationCommand { get; }

        public string Message
        {
            get => _message;
            set => SetProperty( ref _message, value );
        }
    }
}
