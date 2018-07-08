using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadModuleApp.FooModule.ViewModels
{
    public class FooViewModel : BindableBase
    {
        public FooViewModel()
            : base()
        {
        }

        public string Title { get; } = "FooModule";
    }
}
