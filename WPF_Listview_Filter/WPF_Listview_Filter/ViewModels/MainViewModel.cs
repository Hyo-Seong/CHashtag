using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WPF_Listview_Filter.Models;

namespace WPF_Listview_Filter.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        private string _filter;
        public string Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                OnFilterChanged();
            }
        }

        private ObservableCollection<Student> StudentFilter { get; set; }
        private CollectionViewSource StudentCollectionViewSource { get; set; }
        public ICollectionView StudentCollection
        {
            get { return StudentCollectionViewSource.View; }
        }
        #endregion

        public MainViewModel()
        {
            StudentFilter = new ObservableCollection<Student>();

            AddDummyData();

            StudentCollectionViewSource = new CollectionViewSource();
            StudentCollectionViewSource.Source = this.StudentFilter;
            StudentCollectionViewSource.Filter += ApplyFilter;
        }

        private void AddDummyData()
        {
            StudentFilter.Add(new Student { Age = 20, Country = "Korea", Name = "Henry" });
            StudentFilter.Add(new Student { Age = 22, Country = "United States", Name = "James" });
            StudentFilter.Add(new Student { Age = 24, Country = "Japan", Name = "Dami" });
            StudentFilter.Add(new Student { Age = 21, Country = "Russia", Name = "Cad" });
            StudentFilter.Add(new Student { Age = 18, Country = "China", Name = "이효성" });
            StudentFilter.Add(new Student { Age = 17, Country = "China", Name = "Tim" });
            StudentFilter.Add(new Student { Age = 17, Country = "Japan", Name = "Jane" });
            StudentFilter.Add(new Student { Age = 17, Country = "Japan", Name = "Kiru" });
        }

        private void OnFilterChanged()
        {
            StudentCollectionViewSource.View.Refresh();
        }

        void ApplyFilter(object sender, FilterEventArgs e)
        {
            Student svm = (Student)e.Item;

            if (string.IsNullOrWhiteSpace(this.Filter) || this.Filter.Length == 0)
            {
                e.Accepted = true;
            }
            else
            {
                // 대소문자 구분없이 찾기 위함
                e.Accepted = svm.Name.ToLower().Contains(Filter.ToLower());
            }
        }
    }
}
