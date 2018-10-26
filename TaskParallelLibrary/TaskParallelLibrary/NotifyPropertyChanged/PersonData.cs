using System;

namespace TaskParallelLibrary.NotifyPropertyChanged
{
    public class PersonData : NotifyPropertyChanged
    {
        private readonly Action _onPropertyChanged;

        public PersonData()
        {
            
        }
        
        public PersonData(int withAction, Action onPropertyChanged)
        {
            WithAction = withAction;
            _onPropertyChanged = onPropertyChanged;
        }
        
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

        private int _withAction;
        public int WithAction
        {
            get => _withAction;
            set => SetProperty(ref _withAction, value, _onPropertyChanged);
        }
    }
}