using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Prism.Mvvm;

namespace ValidationAttributeSample.ViewModels
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

        private string _rangeValidationValue = string.Empty;
        private string _regularExpressionValidationValue = string.Empty;
        private string _minLengthValidationValue = string.Empty;
        private string _maxLengthValidationValue = string.Empty;
        private string _minMaxLengthValidationValue = string.Empty;
        private string _stringLengthValidationValue = string.Empty;
        private int _customValidationValue = 0;

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
        [Range( 1.0, 10.0, ErrorMessage = "{0} must be between {1} and {2}." )]
        public string RangeValidationValue
        {
            get { return _rangeValidationValue; }
            set { SetProperty( ref _rangeValidationValue, value, () => ValidateProperty( value ) ); }
        }

        [Required( ErrorMessage = "{0} is required." )]
        [RegularExpression( "foo+", ErrorMessage = "{0}'s pattern must be {1}" )]
        public string RegularExpressionValidationValue
        {
            get { return _regularExpressionValidationValue; }
            set { SetProperty( ref _regularExpressionValidationValue, value, () => ValidateProperty( value ) ); }
        }

        [Required( ErrorMessage = "{0} is required." )]
        [MinLength( 5, ErrorMessage = "{0}'s length must be >= {1}." )]
        public string MinLengthValidationValue
        {
            get { return _minLengthValidationValue; }
            set { SetProperty( ref _minLengthValidationValue, value, () => ValidateProperty( value ) ); }
        }

        [Required( ErrorMessage = "{0} is required." )]
        [MaxLength( 5, ErrorMessage = "{0}'s length must be <= {1}." )]
        public string MaxLengthValidationValue
        {
            get { return _maxLengthValidationValue; }
            set { SetProperty( ref _maxLengthValidationValue, value, () => ValidateProperty( value ) ); }
        }

        [Required( ErrorMessage = "{0} is required." )]
        [MinLength( 2, ErrorMessage = "{0}'s length must be >= {1}." )]
        [MaxLength( 5, ErrorMessage = "{0}'s length must be <= {1}." )]
        public string MinMaxLengthValidationValue
        {
            get { return _minMaxLengthValidationValue; }
            set { SetProperty( ref _minMaxLengthValidationValue, value, () => ValidateProperty( value ) ); }
        }

        [Required( ErrorMessage = "{0} is required." )]
        [StringLength( 5, MinimumLength = 2, ErrorMessage = "{0}'s length must be between {2} and {1}." )]
        public string StringLengthValidationValue
        {
            get { return _stringLengthValidationValue; }
            set { SetProperty( ref _stringLengthValidationValue, value, () => ValidateProperty( value ) ); }
        }

        /// <summary>
        /// CustomValidationAttributeのサンプル
        /// 
        /// 引数1で、Validationメソッドが定義されている型を指定する
        /// 引数2で、Validationメソッドを指定する
        /// </summary>
        [Required( ErrorMessage = "{0} is required." )]
        [CustomValidation( typeof( MainWindowViewModel ), nameof( CustomValidate ), ErrorMessage = "{0} must be multiple of 3." )]
        public int CustomValidationValue
        {
            get { return _customValidationValue; }
            set { SetProperty( ref _customValidationValue, value, () => ValidateProperty( value ) ); }
        }

        // public staticメソッドとしてCustomValidationAttributeから指定するvalidationメソッドを定義する
        public static ValidationResult CustomValidate( int value, ValidationContext context )
        {
            var ret = ValidationResult.Success;
            if ( value % 3 != 0 )
            {
                ret = new ValidationResult( null );  // nullを指定することで、CustomValidationAttributeのErrorMessageが使用される
            }
            return ret;
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
