using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using ( var stream = new MemoryStream() )
            {
                // リソース画像（System.Drawing.Bitmap）を
                // System.Windows.Control.ImageのSourceに設定できる型
                // (System.Windows.Media.BitmapFrameやBitmapImage）に変換する
                Bitmap bitmap = Properties.Resources.metalupa;
                bitmap.Save( stream, ImageFormat.Bmp );
                stream.Seek( 0, SeekOrigin.Begin );
                image.Source = BitmapFrame.Create( stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad );
            }
        }
    }
}
