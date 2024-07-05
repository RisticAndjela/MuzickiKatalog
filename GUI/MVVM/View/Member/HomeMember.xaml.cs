using System.Windows;
using mn=muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.GUI.MVVM.ViewModel;
using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.Model.performatorium;

namespace muzickiKatalog.GUI.MVVM.View.Member
{
    public partial class HomeMember : Window
    {
        mn.Member thisMember;
        ControlsViewModel viewModel;
        public HomeMember(mn.Member member)
        {
            InitializeComponent();
            thisMember = member;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            viewModel = new ControlsViewModel(member);
            DataContext=viewModel;
            if(viewModel.FollowingListedPanel.Count>0)following.Children.Add(viewModel.FollowingListedPanel[0]);
            if (viewModel.FollowingListedPanel.Count > 1) following.Children.Add(viewModel.FollowingListedPanel[1]);
           }
        private void InfoHandler(object sender, RoutedEventArgs e)
        {
            playlists.Children.Clear();
            following.Visibility = Visibility.Hidden;
            contentPanelSearch.Visibility = Visibility.Hidden;
            contentPanelPopular.Visibility = Visibility.Hidden;
            InfoPanel.Visibility = Visibility.Visible;
            Reviews.Visibility = Visibility.Hidden;
            playlists.Visibility = Visibility.Hidden;

            name.Content = thisMember.Name;
            lastname.Content=thisMember.LastName;
            birthday.Content = thisMember.Birthday;
            gender.Content = thisMember.GenderProp.ToString();

        }
        private void FollowingHandler(object sender, RoutedEventArgs e)
        {
            playlists.Children.Clear();
            following.Visibility = Visibility.Visible;
            contentPanelPopular.Visibility = Visibility.Hidden;
            contentPanelSearch.Visibility = Visibility.Hidden;
            InfoPanel.Visibility = Visibility.Hidden;
            playlists.Visibility = Visibility.Hidden;
        }
        private void PlaylistHandler(object sender, RoutedEventArgs e)
        {
            foreach (var userControl in viewModel.PlayListPanels)
            {
                playlists.Children.Add(userControl);
            }
            following.Visibility = Visibility.Hidden;
            contentPanelPopular.Visibility = Visibility.Hidden;
            contentPanelSearch.Visibility = Visibility.Hidden;
            InfoPanel.Visibility = Visibility.Hidden;
            playlists.Visibility = Visibility.Visible;
           
        }
        private void SearchHandler(object sender, RoutedEventArgs e)
        {
            playlists.Children.Clear();
            following.Visibility = Visibility.Hidden;
            contentPanelSearch.Visibility = Visibility.Visible;
            contentPanelPopular.Visibility = Visibility.Hidden;
            InfoPanel.Visibility = Visibility.Hidden;
            playlists.Visibility = Visibility.Hidden;
        }
        private void PopularHandler(object sender, RoutedEventArgs e)
        {
            playlists.Children.Clear();
            following.Visibility = Visibility.Hidden;
            contentPanelSearch.Visibility = Visibility.Hidden;
            contentPanelPopular.Visibility = Visibility.Visible;
            InfoPanel.Visibility = Visibility.Hidden;
            playlists.Visibility = Visibility.Hidden;
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
