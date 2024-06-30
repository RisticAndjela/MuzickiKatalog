using System.Windows;
using mn=muzickiKatalog.Layers.Model.contributors;

namespace muzickiKatalog.GUI.MVVM.View.Member
{
    public partial class HomeMember : Window
    {
        mn.Member thisMember;
        public HomeMember(mn.Member member)
        {
            thisMember = member;
            InitializeComponent();
        }
        private void InfoHandler(object sender, RoutedEventArgs e)
        {
            contentPanelSearch.Visibility = Visibility.Hidden;
            contentPanelCategories.Visibility = Visibility.Hidden;
            InfoPanel.Visibility = Visibility.Visible;
            Reviews.Visibility = Visibility.Hidden;

            name.Content = thisMember.name;
            lastname.Content=thisMember.lastName;
            birthday.Content = thisMember.birthday;
            gender.Content = thisMember.gender.ToString();

        }
        private void FollowingHandler(object sender, RoutedEventArgs e)
        {
            contentPanelCategories.Visibility = Visibility.Visible;
            contentPanelSearch.Visibility = Visibility.Hidden;
            InfoPanel.Visibility = Visibility.Hidden;

        }
        private void SuggestedHandler(object sender, RoutedEventArgs e)
        {
            contentPanelCategories.Visibility = Visibility.Visible;
            contentPanelSearch.Visibility = Visibility.Hidden;
            InfoPanel.Visibility = Visibility.Hidden;

        }
        private void SearchHandler(object sender, RoutedEventArgs e)
        {
            contentPanelSearch.Visibility = Visibility.Visible;
            contentPanelCategories.Visibility = Visibility.Hidden;
            InfoPanel.Visibility = Visibility.Hidden;
        }
        private void PopularHandler(object sender, RoutedEventArgs e)
        {
            contentPanelSearch.Visibility = Visibility.Hidden;
            contentPanelCategories.Visibility = Visibility.Visible;
            InfoPanel.Visibility = Visibility.Hidden;
        }
        private void RatingsHandler(object sender, RoutedEventArgs e)
        {
            Reviews.Visibility = Visibility.Visible;
        }
        private void CommentsHandler(object sender, RoutedEventArgs e)
        {
            Reviews.Visibility = Visibility.Visible;
        }

    }
}
