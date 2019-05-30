using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.FooModule.Models
{
    public class Foo : IFoo
    {
        public Foo()
        {
            System.Diagnostics.Debug.Print("Foo ctor.");
        }

        public string Message { get; set; } = "Foo Message.";
    }
}
