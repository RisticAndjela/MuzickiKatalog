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
using System.Windows.Shapes;

namespace muzickiKatalog.GUI.MVVM.View.Admin
{
    /// <summary>
    /// Interaction logic for HomeAdmin.xaml
    /// </summary>
    public partial class HomeAdmin : Window
    {
        public HomeAdmin()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }


        public void ManageEditors(object sender, RoutedEventArgs e)
        {
            ManageEditorsWindow mew = new ManageEditorsWindow();
            mew.Show();
        }

        public void Voting(object sender, RoutedEventArgs e)
        {
            StartVoting sv = new StartVoting();
            sv.Show();
        }

        public void ManageTaskLists(object sender, RoutedEventArgs e)
        {
            EditorTaskList el = new EditorTaskList();
            el.Show();
        }

        public void ManageAds(object sender, RoutedEventArgs e)
        {
            ManageAds ma = new ManageAds();
            ma.Show();
        }

        protected void BtnManageMembers_Click(object sender, RoutedEventArgs e)
            => new ManageMembersWindow().Show();
    }
}
