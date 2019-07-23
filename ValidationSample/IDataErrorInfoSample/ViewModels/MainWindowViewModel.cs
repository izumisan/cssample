using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using Prism.Mvvm;
using Prism.Commands;

namespace IDataErrorInfoSample.ViewModels
{
    public class MainWindowViewModel : BindableBase, IDataErrorInfo
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
            : base()
        {
            FooCommand = new DelegateCommand(
                () => Debug.WriteLine( $"Input: { Input }" ),
                () => string.IsNullOrEmpty( this[nameof( Input )] ) )
                .ObservesProperty( () => HasError );

            // 初期値の検証
            Input = string.Empty;
        }

        // エラーメッセージ { key: プロパティ名, value: エラーメッセージ }
        private Dictionary<string, string> _errors = new Dictionary<string, string>();

        private string _input = null;

        #region 実際には、この部分はViewModelBaseとして実装しておく

        #region IDataErrorInfoインタフェースの実装
        public string this[string columnName]
        {
            get { return _errors.Where( x => x.Key == columnName ).Select( x => x.Value ).FirstOrDefault(); }
        }
        public string Error
        {
            get { return _errors.Any() ? "エラー項目があります" : string.Empty; }
        }
        #endregion

        public bool HasError
        {
            get { return _errors.Any(); }
        }

        protected void SetError( string errorMessage, [CallerMemberName] string propertyName = "" )
        {
            if ( !string.IsNullOrEmpty( propertyName ) )
            {
                _errors[propertyName] = errorMessage;
                RaisePropertyChanged( nameof( HasError ) );
            }
        }

        protected void ClearError( [CallerMemberName] string propertyName = "" )
        {
            if ( _errors.ContainsKey( propertyName ) )
            {
                _errors.Remove( propertyName );
                RaisePropertyChanged( nameof( HasError ) );
            }
        }
        #endregion

        public string Input
        {
            get { return _input; }
            set
            {
                SetProperty( ref _input, value, () =>
                {
                    if ( string.IsNullOrEmpty( value ) )
                    {
                        SetError( "必須項目です" );
                    }
                    else
                    {
                        ClearError();
                    }
                } );
            }
        }

        public DelegateCommand FooCommand { get; private set; }
    }
}
