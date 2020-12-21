using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using ParseCSV.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace ParseCSV.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand ChooseCsvFileCommand { get; private set; }

        private string _csvFilePath;
        public string CsvFilePath
        {
            get => _csvFilePath;
            set => SetProperty(ref _csvFilePath, value);
        }

        private ObservableCollection<User> _items = new ObservableCollection<User>();
        public ObservableCollection<User> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public MainWindowViewModel()
        {
            InitializeVariable();
            InitializeCommands();
        }
        
        private void InitializeVariable()
        {
            Items = new ObservableCollection<User>();
        }

        private void InitializeCommands()
        {
            ChooseCsvFileCommand = new DelegateCommand(ChooseCsvFileCommandMethod);
        }

        private void ChooseCsvFileCommandMethod()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "csv file (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                CsvFilePath = openFileDialog.FileName;
                ParseCsvFile();
            }
        }

        private void ParseCsvFile()
        {
            if(!ValidateCsvFilePath())
            {
                return;
            }

            using (TextFieldParser parser = new TextFieldParser(CsvFilePath, Encoding.UTF8))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // 헤더값을 List에 넣지 않기 위해 첫줄을 읽도록 한다.
                parser.ReadFields();
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    User user = new User
                    {
                        Index = Int32.Parse(fields[0]),     // 번호
                        Name = fields[1],                   // 이름
                        Location = fields[2],               // 사는곳
                        Job = fields[3],                    // 직업
                    };

                    Items.Add(user);
                }
            }
        }

        /// <summary>
        /// 경로를 검증한다.
        /// true : 옳바른 경로이다.
        /// false : 부적절한 경로이다.
        /// </summary>
        private bool ValidateCsvFilePath()
        {
            if (string.IsNullOrWhiteSpace(CsvFilePath) ||
                !File.Exists(CsvFilePath))
            {
                return false;
            }
            return true;
        }
    }
}
