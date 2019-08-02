using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Interactivity.InteractionRequest;

namespace InteractionRequestDialog2.ViewModels
{
    public class FooDialogContent : Notification
    {
        public string SelectedItem { get; set; } = string.Empty;
    }
}
