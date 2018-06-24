using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Interactivity.InteractionRequest;

namespace InteractionRequestApp.CustomModule.ViewModels
{
    public class CustomNotification : Notification
    {
        public string Input { get; set; } = string.Empty;
    }
}
