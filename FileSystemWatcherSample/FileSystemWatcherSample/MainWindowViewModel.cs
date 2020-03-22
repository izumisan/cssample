using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using NLog;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace FileSystemWatcherSample
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            _logger.Info( "start..." );

            _watcher = new FileSystemWatcher
            {
                Path = Path.GetFullPath( "." ),
                Filter = "debug.log",
                NotifyFilter = NotifyFilters.LastWrite
            };

            //_reader = new StreamReader( new FileStream( "debug.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete ) );

            Observable.FromEvent<FileSystemEventHandler, FileSystemEventArgs>(
                h => ( s, e ) => h( e ),
                h => _watcher.Changed += h,
                h => _watcher.Changed -= h
                )
                .Subscribe( x =>
                {
                    System.Diagnostics.Debug.WriteLine( "changed" );

                    if ( _reader == null )
                    {
                        _reader = new StreamReader( new FileStream( "debug.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) );
                    }
                    Contents.Value += _reader.ReadToEnd();
                } )
                .AddTo( _disposables );

            Observable.Interval( TimeSpan.FromSeconds( 1.0 ) )
                .Subscribe( x => _logger.Info( $"Elapsed: { x } sec" ) )
                .AddTo( _disposables );

            _watcher.EnableRaisingEvents = true;
        }

        ~MainWindowViewModel()
        {
            _disposables.Dispose();
        }

        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        private readonly FileSystemWatcher _watcher = null;

        private StreamReader _reader = null;

        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public ReactiveProperty<string> Contents { get; } = new ReactiveProperty<string>();
    }
}
