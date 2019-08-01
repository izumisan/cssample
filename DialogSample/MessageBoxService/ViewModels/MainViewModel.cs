using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Prism.Mvvm;
using Prism.Commands;
using MessageBoxService.Services;

namespace MessageBoxService.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel( IMessageBoxService messageService )
            : base()
        {
            MessageBoxService = messageService;

            InformationCommand = new DelegateCommand( () =>
            {
                var result = MessageBoxService.ShowInformation( "いんふぉめーしょん" );
                Debug.WriteLine( $"selected: { result }" );
            } );

            ConfirmationCommand = new DelegateCommand( () =>
            {
                var result = MessageBoxService.ShowConfirmation( "こんふぁめーしょん" );
                Debug.WriteLine( $"selected: { result }" );
            } );
        }

        public IMessageBoxService MessageBoxService { get; private set; } = null;

        public DelegateCommand InformationCommand { get; private set; } = null;

        public DelegateCommand ConfirmationCommand { get; private set; } = null;
    }
}
