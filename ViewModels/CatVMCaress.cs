using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class CatVMCaress : INotifyPropertyChanged
    {
        private readonly Button button;

        public Cat cat = new Cat("Vasya", "red", 12);

        public event PropertyChangedEventHandler PropertyChanged;
        public string text => "Погладить! (уже " + cat.AmountOfСaress + " раз(а))";

        public CatVMCaress(Button button)
        {
            this.button = button;
            this.button.SetBinding(Button.ContentProperty, new Binding("text") { Source = this });
        }

        public void Bind(Cat cat)
        {
            this.cat = cat;
            this.cat.PropertyChanged += (object sender, PropertyChangedEventArgs e) => OnPropertyChanged("text");
            OnPropertyChanged("text");
        }

        public void Caress()
        {
            cat.AmountOfСaress++;
            OnPropertyChanged("text");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
