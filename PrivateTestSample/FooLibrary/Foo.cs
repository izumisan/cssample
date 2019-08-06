using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooLibrary
{
    public class Foo
    {
        public Foo()
        {
        }

        private int _value = 32;
        private string _foo = "private property";
        private string FooProperty
        {
            get { return _foo; }
            set { _foo = value; }
        }
        private int FooMethod( int x, int y )
        {
            return x + y;
        }

        private static int _staticValue = 168;
        private static string _staticFoo = "private static property";
        private static string StaticFooProperty
        {
            get { return _staticFoo; }
            set { _staticFoo = value; }
        }
        private static int StaticFooMethod( int x, int y )
        {
            return x * y;
        }
    }
}
