using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;

namespace FileDialog1.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// FileSelectRequestイベント
        /// </summary>
        public event EventHandler<FileSelectRequestEventArgs> FileSelectRequest = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
            : base()
        {
        }

        private string _fileName = string.Empty;
        private DelegateCommand _selectCommand = null;

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

            var args = new FileSelectRequestEventArgs
            {
                Title = "ファイルを選択してください",
                Callback = ( selectedFile ) => this.FileName = selectedFile
            };
            this.FileSelectRequest?.Invoke( this, args );  // FileSelectRequestイベントの発行
        }
    }
}
