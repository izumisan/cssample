using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace InteractionRequestDialog2.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
            FooDialogCommand = new DelegateCommand( () =>
            {
                FooDialogRequest.Raise( 
                    new FooDialogContent { Title = "たいとる", Content = "Please select item." },
                    ( c ) => Debug.WriteLine( $"selected: { c.SelectedItem }" ) );
            } );
        }

        public DelegateCommand FooDialogCommand { get; private set; } = null;
        public InteractionRequest<FooDialogContent> FooDialogRequest { get; } = new InteractionRequest<FooDialogContent>();
    }
}
