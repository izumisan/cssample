using Prism.Commands;
using Prism.Mvvm;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DIContainerApp.DoubleModule.Models;

namespace DIContainerApp.DoubleModule.ViewModels
{
    public class DoubleModuleViewModel : BindableBase
    {
        public DoubleModuleViewModel()
        {
            UpdateCommand = new DelegateCommand( () => RaisePropertyChanged( nameof( Value ) ) );
        }

        /// <summary>
        /// Dependency属性を利用してModelをDI（プロパティインジェクション）
        /// </summary>
        [Dependency]
        public IDoubleCounter DoubleCounter { get; set; }

        public string Title
        {
            get { return "DoubleModuleView"; }
        }

        public double Value
        {
            get { return DoubleCounter.Value; }
        }

        public DelegateCommand UpdateCommand { get; private set; }
    }
}
