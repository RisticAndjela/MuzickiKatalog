using muzickiKatalog.GUI.MVVM.ViewModel;
using muzickiKatalog.Layers.Model.performatorium;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace muzickiKatalog.GUI.MVVM.View.Controls
{
    /// <summary>
    /// Interaction logic for ReviewSection.xaml
    /// </summary>
    public partial class ReviewSection : UserControl
    {

        public ReviewSection(List<StarRating> ratings, List<Comment> comments)
        {
            InitializeComponent();
            foreach (StarRating rating in ratings) {
                Label label = new Label();
                label.Content = $"{rating.reviewer}:";
                label.Margin = new Thickness(5);
                label.FontWeight = FontWeights.Bold;
                reviewsPanel.Children.Add(label);
                Label stars = new Label();
                stars.Content = $"{new string('★', rating.rating)}({rating.rating})";
                stars.Foreground = Brushes.Gold;
                stars.FontSize = 15;
                stars.Margin = new Thickness(20, 0, 20, 0);
                reviewsPanel.Children.Add(stars);
                
            }

            foreach (Comment comment in comments)
            {
                Label label = new Label();
                label.Content = $"{comment.reviewer}:";
                label.Margin = new Thickness(5);
                label.FontWeight = FontWeights.Bold;
                reviewsPanel.Children.Add(label);
                Label c = new Label();
                c.Content = comment.comment;
                c.Foreground = Brushes.Wheat;
                c.FontWeight = FontWeights.Bold;
                c.FontSize = 12;
                c.Margin = new Thickness(20, 0, 20, 0);
                reviewsPanel.Children.Add(c);
            }
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
