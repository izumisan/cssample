﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Markup;

namespace MarkupExtensionSample
{
    public class FooMarkupExtension : MarkupExtension
    {
        public override object ProvideValue( IServiceProvider serviceProvider )
        {
            return "はじめてのマークアップ拡張";
        }
    }
}
