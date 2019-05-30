using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PrismApp.FooModule.Models;

namespace PrismApp.FooModule.ViewModels
{
    public class FooViewModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="foo">DIオブジェクト（コンストラクタインジェクション）</param>
        public FooViewModel( IFoo foo )
        {
            System.Diagnostics.Debug.Print( "FooViewModel ctor." );

            Message = foo.Message;
        }

        public string Message { get; set; } = string.Empty;
    }
}
