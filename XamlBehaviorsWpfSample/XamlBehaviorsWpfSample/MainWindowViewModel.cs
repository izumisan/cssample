using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Commands;

namespace XamlBehaviorsWpfSample
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
            MouseEnterCommand = new DelegateCommand( () => { AddMessage( $"{ TimeStamp } InvokeCommandAction: MouseEnter" ); } );
            MouseLeaveCommand = new DelegateCommand( () => { AddMessage( $"{ TimeStamp } InvokeCommandAction: MouseLeave" ); } );
        }

        public ObservableCollection<string> Messages { get; } = new ObservableCollection<string>();
        public string TimeStamp => DateTime.Now.ToString( "HH:mm:ss" );

        public DelegateCommand MouseEnterCommand { get; }
        public DelegateCommand MouseLeaveCommand { get; }

        public void OnMouseEnter()
        {
            AddMessage( $"{ TimeStamp } CallMethodAction: MouseEnter" );
        }

        public void OnMouseLeave()
        {
            AddMessage( $"{ TimeStamp } CallMethodAction: MouseLeave" );
        }

        private void AddMessage( string message )
        {
            Messages.Add( message );
            if ( 7 < Messages.Count )
            {
                Messages.RemoveAt( 0 );
            }
        }
    }
}
