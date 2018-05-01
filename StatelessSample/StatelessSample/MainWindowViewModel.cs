using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Threading;
using Prism.Mvvm;
using Prism.Commands;
using Stateless;

namespace StatelessSample
{
    public class MainWindowViewModel : BindableBase
    {
        private enum State
        {
            None,
            Running,
            Suspended
        }

        private enum Trigger
        {
            Play,
            Stop,
            Pause
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
            : base()
        {
            // ステートマシンの構築
            //------------------------------------------------------------------
            _stateMachine.Configure( State.None )
                .OnEntry( () =>
                {
                    _timer.Stop();
                    Count = 0;
                    Current = State.None;
                } )
                .Permit( Trigger.Play, State.Running );

            _stateMachine.Configure( State.Running )
                .OnEntry( () =>
                {
                    _timer.Start();
                    Current = State.Running;
                } )
                .Permit( Trigger.Pause, State.Suspended )
                .Permit( Trigger.Stop, State.None );

            _stateMachine.Configure( State.Suspended )
                .OnEntry( () =>
                {
                    _timer.Stop();
                    Current = State.Suspended;
                } )
                .Permit( Trigger.Play, State.Running )
                .Permit( Trigger.Stop, State.None );


            // DelegateCommandの初期化
            //------------------------------------------------------------------
            PlayCommand = new DelegateCommand(
                () => _stateMachine.Fire( Trigger.Play ),
                () => _stateMachine.CanFire( Trigger.Play ) )
                .ObservesProperty( () => Current );

            StopCommand = new DelegateCommand(
                () => _stateMachine.Fire( Trigger.Stop ),
                () => _stateMachine.CanFire( Trigger.Stop ) )
                .ObservesProperty( () => Current );

            PauseCommand = new DelegateCommand(
                () => _stateMachine.Fire( Trigger.Pause ),
                () => _stateMachine.CanFire( Trigger.Pause ) )
                .ObservesProperty( () => Current );


            _timer.Tick += ( s, e ) => ++Count;
        }

        /// <summary>
        /// ステートマシン
        /// </summary>
        private StateMachine<State, Trigger> _stateMachine = new StateMachine<State, Trigger>( State.None );

        private DispatcherTimer _timer = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(100) };

        private int _count = 0;

        private State _current = State.None;

        public DelegateCommand PlayCommand { get; private set; }

        public DelegateCommand StopCommand { get; private set; }

        public DelegateCommand PauseCommand { get; private set; }

        public int Count
        {
            get { return _count; }
            private set { SetProperty( ref _count, value ); }
        }

        private State Current
        {
            get { return _current; }
            set { SetProperty( ref _current, value ); }
        }

    }
}
