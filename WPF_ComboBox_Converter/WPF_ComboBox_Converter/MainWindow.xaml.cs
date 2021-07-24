// MainWindow.xaml.cs
using System;
using System.Collections.Generic;
using System.Windows;

namespace WPF_ComboBox_Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> RandList;

        public MainWindow()
        {
            InitializeComponent();

            InitComboBox();
        }

        private void InitComboBox()
        {
            RandList = new List<int>();

            var rand = new Random();

            for (int i=0;i<10;i++)
            {
                RandList.Add(rand.Next(1, 10));
            }

            // ComboBox에 binding을 직접(명시적으로) 연결합니다.
            ComboBox1.DataContext = RandList;
        }
    }
}
