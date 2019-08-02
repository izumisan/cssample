using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;

namespace MessageBoxService.Extensions
{
    public static class MessageBoxResultExtension
    {
        public static MessageBoxResult None( this MessageBoxResult self, Action action )
        {
            if ( self == MessageBoxResult.None )
            {
                action?.Invoke();
            }
            return self;
        }

        public static MessageBoxResult OK( this MessageBoxResult self, Action action )
        {
            if ( self == MessageBoxResult.OK )
            {
                action?.Invoke();
            }
            return self;
        }

        public static MessageBoxResult Cancel( this MessageBoxResult self, Action action )
        {
            if ( self == MessageBoxResult.Cancel )
            {
                action?.Invoke();
            }
            return self;
        }

        public static MessageBoxResult Yes( this MessageBoxResult self, Action action )
        {
            if ( self == MessageBoxResult.Yes )
            {
                action?.Invoke();
            }
            return self;
        }

        public static MessageBoxResult No( this MessageBoxResult self, Action action )
        {
            if ( self == MessageBoxResult.No )
            {
                action?.Invoke();
            }
            return self;
        }
    }
}
