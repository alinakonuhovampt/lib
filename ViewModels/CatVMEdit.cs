using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class CatVMEdit : INotifyPropertyChanged
    {
        public TextBox nameTB;
        public string name
        {
            get => cat.Name;
            set => cat.Name = value;
        }

        public TextBox colorTB;
        public string color
        {
            get => cat.Color;
            set => cat.Color = value;
        }

        public TextBox ageTB;
        public string age
        {
            get => cat.Age.ToString();
            set
            {
                if (int.TryParse(value, out int a) && a > 0 && a < 50)
                    cat.Age = a;
                else
                    MessageBox.Show("Invalid age!", "Error!", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Cat cat = new Cat("Vasya", "red", 12);

        public CatVMEdit(TextBox nameTB, TextBox colorTB, TextBox ageTB)
        {
            this.nameTB = nameTB;
            this.nameTB.SetBinding(TextBox.TextProperty, new Binding("name") { Source = this });

            this.colorTB = colorTB;
            this.colorTB.SetBinding(TextBox.TextProperty, new Binding("color") { Source = this });

            this.ageTB = ageTB;
            this.ageTB.SetBinding(TextBox.TextProperty, new Binding("age") { Source = this });
        }

        public void Bind(Cat cat)
        {
            this.cat = cat;
            OnPropertyChanged("name");
            OnPropertyChanged("color");
            OnPropertyChanged("age");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
