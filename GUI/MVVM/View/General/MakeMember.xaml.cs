using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.Layers.support;
using memberNS= muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.support.IDparser;
using System.Windows;
using muzickiKatalog.GUI.MVVM.View.Member;

namespace muzickiKatalog.GUI.MVVM.View.General
{
    /// <summary>
    /// Interaction logic for MakeMember.xaml
    /// </summary>
    public partial class MakeMember : Window
    {
        MakePerson personUC;
        MakeUser userUC;
        public MakeMember()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            personUC = new MakePerson();
            panelPerson.Content = personUC;
            userUC = new MakeUser("member");
            panelUser.Content = userUC;
        }

        private void doneButton(object sender, RoutedEventArgs e)
        { 
            string name = personUC.GetName();
            string lastName = personUC.GetLastName();
            Gender gender = personUC.GetGender();
            DateOnly birthday=personUC.GetBirthday();
            string username=userUC.getUsername();
            string password= userUC.getPassword();
            (bool success,string reason)= Validation.ValidateAndMakeMember(username,password,name,lastName,gender,birthday);
            if (!success)
            {
                MessageWindow mw = new MessageWindow("ERROR", reason);
                mw.Show();
            }
            else
            {
                (_,memberNS.Member member)=GetFromIDs<memberNS.Member>.get(username, GlobalVariables.membersFile);
                new HomeMember(member).Show();
                this.Close();
            }
        }
        }
}
