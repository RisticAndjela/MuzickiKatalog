using muzickiKatalog.GUI.MVVM.View.General;
using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Model.contributors.Interfaces;
using muzickiKatalog.Layers.Repository.contributors;
using muzickiKatalog.Layers.Service.contributors;
using muzickiKatalog.Layers.support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
    /// Interaction logic for ManageMembersWindow.xaml
    /// </summary>
    public partial class ManageMembersWindow : Window
    {
        public ObservableCollection<MemberDTO> Members { get; set; }



        public ManageMembersWindow()
        {
            InitializeComponent();
            DataContext = this;
            Members = new(GetMembers());
        }

        
        // TODO move to cotroller
        private IEnumerable<MemberDTO> GetMembers()
        {
            var membersSupplier = MemberService.GetAll;
            var profilesSupplier = UserService.GetAll;

            var members = from member in membersSupplier()
                          join profile in profilesSupplier() on member.username equals profile.username
                          select new MemberDTO(profile, member);

            return members;
        }



        private void BtnAdd_Click(object sender, RoutedEventArgs e) 
            => new MakeMember().ShowDialog();
    }


    public class MemberDTO(User profile, IPerson member)
    {
        public string Name { get; set; } = member.Name;
        public string Surname { get; set; } = member.LastName;
        public Gender Gender { get; set; } = member.GenderProp;
        public DateOnly BirthDay { get; set; } = member.Birthday;

        public string Username { get; set; } = profile.username;
        public bool IsActive { get; set; } = profile.isActive;
    }
}
