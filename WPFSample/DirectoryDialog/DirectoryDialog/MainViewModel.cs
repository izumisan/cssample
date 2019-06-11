using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Prism.Mvvm;
using Prism.Commands;

namespace DirectoryDialog
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
            : base()
        {
            OpenDirectoryCommand = new DelegateCommand( openDirectoryCommandExecute );
        }

        private string _selectedDirectory = string.Empty;

        public string SelectedDirectory
        {
            get { return _selectedDirectory; }
            set { SetProperty( ref _selectedDirectory, value ); }
        }

        public DelegateCommand OpenDirectoryCommand { get; private set; }

        private void openDirectoryCommandExecute()
        {
            var dialog = new FolderBrowserDialog
            {
                Description = "System.Windows.Forms.FolderBrowserDialogによるフォルダー選択ダイアログ",
                // 初期位置をプログラムの位置に設定する
                SelectedPath = Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location ),
                ShowNewFolderButton = true
            };
            DialogResult result = dialog.ShowDialog();
            if ( result == DialogResult.OK )
            {
                SelectedDirectory = dialog.SelectedPath;
            }
        }
    }
}
