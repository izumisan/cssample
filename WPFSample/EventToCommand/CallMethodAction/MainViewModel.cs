using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Reactive.Bindings;

namespace CallMethodAction
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Label = new ReactiveProperty<string>("CallMethodActionにより、任意のイベント時にメソッドを呼び出す");
        }

        public ReactiveProperty<string> Label { get; private set; } = null;

        public void OnMouseEnter()
        {
            Label.Value = "MouseEnter";
        }

        public void OnMouseLeave()
        {
            Label.Value = "MouseLeave";
        }
    }
}
