using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.IO;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PathValidationTrial
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            DirectoryPath
                .SetValidateAttribute( () => DirectoryPath );

            FilePath
                .SetValidateAttribute( () => FilePath );
        }

        [DirectoryRequired]
        public ReactiveProperty<string> DirectoryPath { get; } = new ReactiveProperty<string>( Directory.GetCurrentDirectory() );

        [FileRequired]
        public ReactiveProperty<string> FilePath { get; } = new ReactiveProperty<string>( Assembly.GetExecutingAssembly().Location );
    }
}
