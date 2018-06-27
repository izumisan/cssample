using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DIContainerApp.CountModule.Models;

namespace DIContainerApp.CountModule.ViewModels
{
    public class CountModuleViewModel : BindableBase
    {
        /// <summary>
        /// コンストラクタ
        /// 
        /// ModelをDI（コンストラクタインジェクション）
        /// </summary>
        public CountModuleViewModel( ICounter counter )
        {
            _counter = counter;

            UpdateCommand = new DelegateCommand( () => RaisePropertyChanged( nameof( Count ) ) );
        }

        private ICounter _counter = null;

        public string Title
        {
            get { return "CountModuleView"; }
        }

        public int Count
        {
            get { return _counter.Count; }
        }

        public DelegateCommand UpdateCommand { get; private set; }
    }
}
