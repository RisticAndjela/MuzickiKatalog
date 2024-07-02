using muzickiKatalog.GUI.MVVM.View.General;
using muzickiKatalog.Layers.support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace muzickiKatalog.GUI.MVVM.View.UserControls
{
    /// <summary>
    /// Interaction logic for MakePerson.xaml
    /// </summary>
    public partial class MakePerson : UserControl
    {
        public Gender gender;
        public MakePerson()
        {
            InitializeComponent();
        }
        public Gender GetGender() { return gender; }
        public string GetName(){ return name.Text; }
        public string GetLastName() { return lastName.Text;}
        public DateOnly GetBirthday()
        {
            DateTime? selectedDate = birthday.SelectedDate;
            if (selectedDate.HasValue)
            {
                return DateOnly.FromDateTime(selectedDate.Value);
            }
            return DateOnly.FromDateTime(DateTime.Now);
        }
        private void genderButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Name == "male")
                {
                    ((Button)FindName("male")).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFBBD"));
                    ((Button)FindName("female")).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E6AA68"));
                    gender = Gender.male;
                }
                else
                {
                    ((Button)FindName("female")).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFBBD"));
                    ((Button)FindName("male")).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E6AA68"));
                    gender= Gender.female;
                }
            }
        }
    }
}
