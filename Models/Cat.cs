using System.ComponentModel;

namespace WpfApp1.Models
{
    class Cat : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get => name; set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string color;
        public string Color
        {
            get => color; set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }

        private int age;
        public int Age
        {
            get => age; set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }
        private int amountOfСaress;
        public int AmountOfСaress
        {
            get => amountOfСaress; set
            {
                amountOfСaress = value;
                OnPropertyChanged("AmountOfСaress");
            }
        }

        public Cat(string name, string color, int age)
        {
            Name = name;
            Color = color;
            Age = age;
            AmountOfСaress = 0;
        }
        public Cat()
            : this("", "", 0)
        { }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
