using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Prism.Mvvm;
using ValidationAttributeSample2.ValidationAttributes;

namespace ValidationAttributeSample2.ViewModels
{
    public class MainWindowViewModel : BindableBase, INotifyDataErrorInfo
    {
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
            : base()
        {
            _errorsContainer = new ErrorsContainer<string>( OnErrorsChanged );

            ValidateAllProperties();
        }

        private ErrorsContainer<string> _errorsContainer = null;

        private string _fooValidationValue = string.Empty;
        private string _fooValidationValue2 = string.Empty;

        #region INotifyDataErrorInfoの実装

        public bool HasErrors
        {
            get { return _errorsContainer.HasErrors; }
        }

        System.Collections.IEnumerable INotifyDataErrorInfo.GetErrors( string propertyName )
        {
            return this.GetErrors( propertyName );
        }

        public IEnumerable<string> GetErrors( string propertyName )
        {
            return _errorsContainer.GetErrors( propertyName );
        }
        #endregion

        [Required( ErrorMessage = "{0} is required." )]
        [Foo( ErrorMessage = "{0} must be multiple of 3." )]
        public string FooValidationValue
        {
            get { return _fooValidationValue; }
            set { SetProperty( ref _fooValidationValue, value, () => ValidateProperty( value ) ); }
        }

        [Required( ErrorMessage = "{0} is required." )]
        [Foo2( ErrorMessage = "{0} must be multiple of 3." )]
        public string FooValidationValue2
        {
            get { return _fooValidationValue2; }
            set { SetProperty( ref _fooValidationValue2, value, () => ValidateProperty( value ) ); }
        }

        private void OnErrorsChanged( [CallerMemberName] string propertyName = "" )
        {
            ErrorsChanged?.Invoke( this, new DataErrorsChangedEventArgs( propertyName ) );
        }

        private void ValidateProperty( object value, [CallerMemberName] string propertyName = "" )
        {
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

        private void ValidateAllProperties()
        {
            var context = new ValidationContext( this );
            var validationErrors = new List<ValidationResult>();
            if ( !Validator.TryValidateObject( this, context, validationErrors ) )
            {
                foreach ( var error in validationErrors.GroupBy( x => x.MemberNames.FirstOrDefault() ) )
                {
                    _errorsContainer.SetErrors( error.Key, error.Select( x => x.ErrorMessage ) );
                }
            }
            else
            {
                _errorsContainer.ClearErrors();
            }
        }
    }
}
