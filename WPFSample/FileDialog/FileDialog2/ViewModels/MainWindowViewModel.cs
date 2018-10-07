using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace FileDialog2.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
            : base()
        {
        }

        private string _fileName = string.Empty;
        private DelegateCommand _selectCommand = null;

        public InteractionRequest<Notification> FileSelectRequest { get; } = new InteractionRequest<Notification>();

        public string FileName
        {
            get { return _fileName; }
            set { SetProperty( ref _fileName, value ); }
        }

        public DelegateCommand SelectCommand
        {
            get { return _selectCommand ?? ( _selectCommand = new DelegateCommand( selectCommandExecute ) ); }
        }

        private void selectCommandExecute()
        {
            this.FileName = string.Empty;

            FileSelectRequest.Raise(
                new Notification { Title = "ファイルを選択してください" },
                ( c ) => this.FileName = c.Content as string );
        }
    }
}
