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
                // filter text가 변경되면 검색 조건이 변한 것이므로 필터를 refresh하여 데이터를 다시 검색하도록 합니다.
                OnFilterChanged();
            }
        }

        /// <summary>
        /// Data의 변경 사항이 View에도 Notify되어야 하기 때문에 Source는 ObservableCollection이여야 합니다.
        /// </summary>
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
            // Refresh하게되면 CollectionViewSource의 Source로 지정된 StudentFilter가 차례로 ApplyFilter의 FilterEventArgs로 들어가게 됩니다.
            StudentCollectionViewSource.View.Refresh();
        }

        /// <summary>
        /// 조건에 부합한다면 e.Accepted 에 true를, 그렇지 않다면 e.Accepted에 false를 넣어주면 됩니다.
        /// </summary>
        void ApplyFilter(object sender, FilterEventArgs e)
        {
            Student svm = (Student)e.Item;

            // Filter Text 가 비어있다면 필터를 적용하지 않고 모든 콘텐츠를 보여주어야 하기때문에 true를 대입합니다.
            if (string.IsNullOrWhiteSpace(this.Filter) || this.Filter.Length == 0)
            {
                e.Accepted = true;
            }
            else
            {
                // 대소문자 구분없이 찾기 위해 모두 소문자로 변경하여 검색하도록 합니다.
                // 또한 완전 일치가 아닌 함유하고 있어도 찾기 위하여 Equals가 아닌 Contains를 사용하였습니다.
                e.Accepted = svm.Name.ToLower().Contains(Filter.ToLower());
            }
        }
    }
}
