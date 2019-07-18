using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Prism.Mvvm;
using Prism.Commands;

namespace ErrorContainerSample.ViewModels
{
    public class MainWindowViewModel : BindableBase, INotifyDataErrorInfo
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {
            // ErrorContainerのコンストラクタにErrorsChangedイベントを発火するデリゲートを指定する
            // (SetErrors時、ErrorsChangedイベントを発火する）
            _errorsContainer = new ErrorsContainer<string>( OnErrorChanged );

            FooCommand = new DelegateCommand(
                () => Debug.WriteLine( $"Input: { Input }" ),
                () => !_errorsContainer.GetErrors( nameof( Input ) ).Any() )
                .ObservesProperty( () => Input );


            // 初期値の検証
            ValidateProperty( Input, nameof( Input ) );
        }

        private ErrorsContainer<string> _errorsContainer = null;

        private string _input = string.Empty;

        #region INotifyDataErrorInfoの実装

        // ErrorsChangedイベント
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = null;

        // ErrorContainerを利用して、HasErrorsプロパティ、GetErrorsメソッドを実装する

        public bool HasErrors
        {
            get { return _errorsContainer.HasErrors; }
        }

        System.Collections.IEnumerable INotifyDataErrorInfo.GetErrors( string propertyName )
        {
            return this.GetErrors( propertyName );
        }
        #endregion

        // ジェネリック版
        public IEnumerable<string> GetErrors( string propertyName )
        {
            return _errorsContainer.GetErrors( propertyName );
        }

        // RequiredAttributeによる検証
        [Required( ErrorMessage = "必須項目" )]
        public string Input
        {
            get { return _input; }
            set
            {
                SetProperty( ref _input, value, () => ValidateProperty( value ) );
            }
        }

        public DelegateCommand FooCommand { get; private set; }

        private void OnErrorChanged( [CallerMemberName] string propertyName = "" )
        {
            this.ErrorsChanged?.Invoke( this, new DataErrorsChangedEventArgs( propertyName ) );
        }

        // プロパティの検証
        protected void ValidateProperty( object value, [CallerMemberName] string propertyName = "" )
        {
            // Validatorを用いて、ValidationAttributeによる検証結果をErrorContainerに反映する

            var context = new ValidationContext( this ) { MemberName = propertyName };
            var validationErrors = new List<ValidationResult>();
            if ( !Validator.TryValidateProperty( value, context, validationErrors ) )
            {
                _errorsContainer.SetErrors( propertyName, validationErrors.Select( x => x.ErrorMessage ) );
            }
            else
            {
                _errorsContainer.ClearErrors( propertyName );
            }
        }
    }
}
