using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Attributes;
using InjectionApp.Shared;

namespace InjectionApp.BarModule.ViewModels
{
    public class BarViewModel
    {
        public BarViewModel()
        {
            System.Diagnostics.Debug.Print( "BarViewModel.ctor" );
        }

        /// <summary>
        /// プロパティインジェクションオブジェクト
        /// </summary>
        [Dependency]
        public IMessageProvider MessageProvider { get; set; }

        public string Message
        {
            get { return $"[Bar] { MessageProvider?.Message }"; }
        }
    }
}
