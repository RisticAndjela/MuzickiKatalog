using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using muzickiKatalog.GUI.MVVM.View.Guest;
using muzickiKatalog.GUI.MVVM.View.Admin;
using muzickiKatalog.GUI.MVVM.View.Member;
using muzickiKatalog.GUI.MVVM.View.Editor;
using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.Layers.support;
using nm=muzickiKatalog.Layers.Model.contributors;
using System.ComponentModel;

namespace muzickiKatalog.GUI.MVVM.View.General
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {

        public LogIn()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }
        private void GuestCommand(object sender, RoutedEventArgs e)
        {
            HomeGuest home= new HomeGuest();
            home.Show();
            this.Close();
        }
         private void SignInCommand(object sender, RoutedEventArgs e)
        {
            MakeMember makeMember = new MakeMember();
            makeMember.Show();
        } 
         private void LogInCommand(object sender, RoutedEventArgs e)
        {
            ChoicePanel.Visibility=Visibility.Hidden;
            LogInPanel.Visibility=Visibility.Visible;
            
        }
        private void DoneCommand(object sender, RoutedEventArgs e)
        {
            string usernameText = username.Text;
            (bool have, nm.User user) = GetFromIDs<nm.User>.get(usernameText, GlobalVariables.usersFile);
            if (have)
            {
                
                if(user.password== password.Text)
                {
                    switch (user.type)
                    {
                        case personType.member:
                            new HomeMember(GetFromIDs<nm.Member>.get(usernameText, GlobalVariables.membersFile).Item2).Show();
                            this.Close();
                            break;
                        case personType.editor:
                            new HomeEditor().Show();
                            this.Close();
                            break;
                        case personType.admin:
                            new HomeAdmin().Show();
                            this.Close();
                            break;
                        default:
                            wrongUsername.Visibility = Visibility.Visible;
                            wrongPassword.Visibility = Visibility.Visible;
                            break;
                    }
                }
                else
                {
                    wrongUsername.Visibility = Visibility.Hidden;
                    wrongPassword.Visibility=Visibility.Visible;
                }
            }
            else
            {
                wrongUsername.Visibility=Visibility.Visible;
            }
        }
        
    }
}
