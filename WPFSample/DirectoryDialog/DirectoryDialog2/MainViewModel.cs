using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System.Reflection;
using Prism.Mvvm;
using Prism.Commands;

namespace DirectoryDialog2
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
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,  // フォルダー選択ダイアログモード
                Title = "たいとる",
                InitialDirectory = Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location )
            };

            if ( dialog.ShowDialog() == CommonFileDialogResult.Ok )
            {
                SelectedDirectory = dialog.FileName;
            }
        }
    }
}
