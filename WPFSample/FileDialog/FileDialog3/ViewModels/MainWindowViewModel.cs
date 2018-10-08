using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;

namespace FileDialog3.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
            : base()
        {
        }

        private string _fileName = string.Empty;

        public string FileName
        {
            get { return _fileName; }
            set { SetProperty( ref _fileName, value ); }
        }
    }
}
