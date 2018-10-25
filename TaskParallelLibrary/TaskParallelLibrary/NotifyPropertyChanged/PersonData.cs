namespace TaskParallelLibrary.NotifyPropertyChanged
{
    public class PersonData : NotifyPropertyChanged
    {
        private int _age;

        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    }
}