using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Prism.Mvvm;
using Prism.Commands;

namespace ValidateOnExceptions.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {
            FooCommand = new DelegateCommand(
                () => Debug.WriteLine( $"Input: { Input }" ),
                () => !string.IsNullOrEmpty( Input ) )
                .ObservesProperty( () => Input );

            //Input = string.Empty;
        }

        private string _input = string.Empty;

        public string Input
        {
            get { return _input; }
            set
            {
                SetProperty( ref _input, value );
                if ( string.IsNullOrEmpty( value ) )
                {
                    // デバッグ実行の場合、この例外で中断されるが、無視して続行することで
                    // TextBoxに赤枠が表示される
                    throw new ArgumentException( "無効な入力値です" );
                }
            }
        }

        public DelegateCommand FooCommand { get; private set; }
    }
}
