using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Ioc;
using InjectionApp.Shared;

namespace InjectionApp.BazModule.ViewModels
{
    public class BazViewModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナそのものをインジェクション</param>
        public BazViewModel( IContainerExtension container )
        {
            // Prism.Ioc.IContainerExtensionではなく、
            // Unity.IUnityContainerもDIとして取得可能

            System.Diagnostics.Debug.Print( "BazViewModel.ctor" );

            // インジェクトされたコンテナからオブジェクトを取得する
            var messageProvider = container.Resolve<IMessageProvider>();
            Message = $"[Baz] { messageProvider.Message }";
        }

        public string Message { get; private set; } = string.Empty;
    }
}
