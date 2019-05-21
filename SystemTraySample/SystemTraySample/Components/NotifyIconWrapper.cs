using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTraySample.Components
{
    public partial class NotifyIconWrapper : Component
    {
        public NotifyIconWrapper()
        {
            InitializeComponent();

            menuItem1.Click += ( s, e ) =>
            {
                Debug.Print( "item1 clicked" );

                var window1 = new Window1();
                window1.Show();
            };

            menuItem2.Click += ( s, e ) =>
            {
                Debug.Print( "item2 clicked" );

                var window2 = new Window2();
                window2.Show();
            };

            menuItem3.Click += ( s, e ) =>
            {
                Debug.Print( "item3 clicked" );

                // トースト通知（Toast Notification）
                notifyIcon.ShowBalloonTip( 10000 /*10sec*/, "タイトル", "テキスト", System.Windows.Forms.ToolTipIcon.Info );
            };

            quitMenuItem.Click += ( s, e ) =>
            {
                Debug.Print( "quit clicked" );

                System.Windows.Application.Current.Shutdown();
            };
        }

        public NotifyIconWrapper( IContainer container )
        {
            container.Add( this );

            InitializeComponent();
        }
    }
}
