using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InjectionApp.Shared;

namespace InjectionApp.FooModule.ViewModels
{
    public class FooViewModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="messageProvider">コンストラクタインジェクションオブジェクト</param>
        public FooViewModel( IMessageProvider messageProvider )
        {
            System.Diagnostics.Debug.Print( "FooViewModel.ctor" );

            Message = $"[Foo] { messageProvider.Message }";
        }

        public string Message { get; private set; } = string.Empty;
    }
}
