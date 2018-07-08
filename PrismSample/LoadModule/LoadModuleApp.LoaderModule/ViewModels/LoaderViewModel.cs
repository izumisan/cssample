using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Modularity;
using Microsoft.Practices.Unity;

namespace LoadModuleApp.LoaderModule.ViewModels
{
    public class LoaderViewModel : BindableBase
    {
        public LoaderViewModel()
        {
            LoadFooCommand = new DelegateCommand( loadFooCommandExecute );
        }

        [Dependency]
        public IModuleManager ModuleManager { get; set; }

        public DelegateCommand LoadFooCommand { get; private set; }

        private void loadFooCommandExecute()
        {
            this.ModuleManager.LoadModule( "FooModule" );
        }
    }
}
