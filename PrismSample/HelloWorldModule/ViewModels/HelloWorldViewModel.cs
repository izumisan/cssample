using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using HelloWorldModule.Models;

namespace HelloWorldModule.ViewModels
{
    class HelloWorldViewModel
    {
        [Dependency]
        public MessageProvider MessageProvider { get; set; } 
    }
}
