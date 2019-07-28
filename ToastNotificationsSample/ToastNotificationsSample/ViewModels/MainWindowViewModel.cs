using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Threading;
using Prism.Mvvm;
using Prism.Commands;
using ToastNotifications;
using ToastNotifications.Core;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Lifetime.Clear;

namespace ToastNotificationsSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
            _wbcNotifier = new Notifier( cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider( Application.Current.MainWindow, Corner.BottomCenter, 0.0, 0.0 );
                cfg.LifetimeSupervisor = new CountBasedLifetimeSupervisor( MaximumNotificationCount.FromCount( 3 ) );
                cfg.Dispatcher = Application.Current.Dispatcher;
                cfg.DisplayOptions.TopMost = true;
            } );

            _wtrNotifier = new Notifier( cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider( Application.Current.MainWindow, Corner.TopRight, 0.0, 0.0 );
                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor( TimeSpan.FromSeconds( 5.0 ), MaximumNotificationCount.FromCount( 5 ) );
                cfg.Dispatcher = Application.Current.Dispatcher;
                cfg.DisplayOptions.TopMost = true;
            } );

            _sbrNotifier = new Notifier( cfg =>
            {
                cfg.PositionProvider = new PrimaryScreenPositionProvider( Corner.BottomRight, 0.0, 0.0 );
                cfg.LifetimeSupervisor = new CountBasedLifetimeSupervisor( MaximumNotificationCount.UnlimitedNotifications() );
                cfg.Dispatcher = Application.Current.Dispatcher;
                cfg.DisplayOptions.TopMost = true;
            } );

            WindowBottomCenterCommand = new DelegateCommand( WindowBottomCenterCommandExecute );
            WindowTopRightCommand = new DelegateCommand( WindowTopRightCommandExecute );
            ScreenBottomRightCommand = new DelegateCommand( ScreenBottomRightCommandExecute );

            ClearCommand = new DelegateCommand( () =>
            {
                _wbcNotifier.ClearMessages( new ClearAll() );
                _wtrNotifier.ClearMessages( new ClearAll() );
                _sbrNotifier.ClearMessages( new ClearAll() );
            } );
        }

        ~MainWindowViewModel()
        {
            //_wbcNotifier.Dispose();
            //_wtrNotifier.Dispose();
            //_sbrNotifier.Dispose();
        }

        private Notifier _wbcNotifier = null;
        private Notifier _wtrNotifier = null;
        //private Notifier _ctrNotifier = null;
        private Notifier _sbrNotifier = null;

        private int _count = 0;

        public DelegateCommand WindowBottomCenterCommand { get; private set; } = null;
        public DelegateCommand WindowTopRightCommand { get; private set; } = null;
        //public DelegateCommand ControlTopRightCommand { get; private set; } = null;
        public DelegateCommand ScreenBottomRightCommand { get; private set; } = null;

        public DelegateCommand ClearCommand { get; private set; } = null;

        private void WindowBottomCenterCommandExecute()
        {
            _wbcNotifier.ShowInformation( $"{ ++_count } information" );
        }

        private void WindowTopRightCommandExecute()
        {
            _wtrNotifier.ShowWarning( $"{ ++_count } warning", new MessageOptions
            {
                ShowCloseButton = false,
                FreezeOnMouseEnter = true,
                UnfreezeOnMouseLeave = true
            } );
        }

        private void ScreenBottomRightCommandExecute()
        {
            _sbrNotifier.ShowError( $"{ ++_count } error", new MessageOptions
            {
                ShowCloseButton = false,
                FreezeOnMouseEnter = true,
                UnfreezeOnMouseLeave = true,
                NotificationClickAction = ( n ) =>
                {
                    n.Close();
                    System.Diagnostics.Debug.WriteLine( "clicked." );
                }
            } );
        }
    }
}
