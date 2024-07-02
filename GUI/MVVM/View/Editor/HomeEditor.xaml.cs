using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace muzickiKatalog.GUI.MVVM.View.Editor
{
    /// <summary>
    /// Interaction logic for HomeEditor.xaml
    /// </summary>
    public partial class HomeEditor : Window
    {
        public HomeEditor()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }
        private void ApproveReviewsHandler(object sender, RoutedEventArgs e) {
            ApproveReviewsPanel.Visibility = Visibility.Visible;
            TaskListPanel.Visibility = Visibility.Hidden;

        }
        private void TaskReviewsHandler(object sender, RoutedEventArgs e)
        {
            ApproveReviewsPanel.Visibility = Visibility.Hidden;
            TaskListPanel.Visibility = Visibility.Visible;
        }
        private void Star_Click(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton button)
            {
                string starName = button.Name;
                int starNumber = int.Parse(starName.Substring(4)); // Extracts the numeric part from the name

                // Update stars based on clicked star number
                for (int i = 1; i <= 5; i++)
                {
                    ToggleButton star = FindName($"Star{i}") as ToggleButton;
                    if (star != null)
                    {
                        star.IsChecked = i <= starNumber;
                    }
                }
            }
        }



    }
}
