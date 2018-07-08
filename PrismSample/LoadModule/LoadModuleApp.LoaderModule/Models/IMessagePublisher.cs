using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadModuleApp.LoaderModule.Models
{
    public interface IMessagePublisher
    {
        void publish( string message );
    }
}
