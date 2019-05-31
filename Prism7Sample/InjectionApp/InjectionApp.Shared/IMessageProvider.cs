using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionApp.Shared
{
    public interface IMessageProvider
    {
        string Message { get; }
    }
}
