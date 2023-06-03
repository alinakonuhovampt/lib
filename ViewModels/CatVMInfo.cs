using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class CatVMInfo : INotifyPropertyChanged
    {
        private readonly TextBlock textBlock;

        public Cat cat = new Cat("Vasya", "red", 12);

        public event PropertyChangedEventHandler PropertyChanged;
        public string info => cat.Name + ": " + cat.Color + ", " + cat.Age + " лет. Поглажен(а) " + cat.AmountOfСaress + " раз(а).";

        public CatVMInfo(TextBlock info)
        {
            this.textBlock = info;
            this.textBlock.SetBinding(TextBlock.TextProperty, new Binding("info") { Source = this });
        }

        public void Bind(Cat cat)
        {
            this.cat = cat;
            this.cat.PropertyChanged += (object sender, PropertyChangedEventArgs e) => OnPropertyChanged("info");
            OnPropertyChanged("info");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}