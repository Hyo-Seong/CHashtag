using Prism.Mvvm;

namespace ParseCSV.Models
{
    public class User : BindableBase
    {
        private int _index;
        public int Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _location;
        public string Location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }

        private string _job;
        public string Job
        {
            get => _job;
            set => SetProperty(ref _job, value);
        }
    }
}
