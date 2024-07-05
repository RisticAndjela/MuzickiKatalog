using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;
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
using enums = muzickiKatalog.Layers.support;
using contributor = muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.GUI.MVVM.View.General;

namespace muzickiKatalog.GUI.MVVM.View.UserControls
{
    /// <summary>
    /// Interaction logic for MakeArtist.xaml
    /// </summary>
    public partial class MakeArtist : UserControl
    {
        private contributor.Editor editor;
        private MakePerson mp = new MakePerson();

        public MakeArtist(contributor.Editor editor)
        {
            InitializeComponent();
            panelPerson.Content = mp;
            foreach (var genre in GenreRepository.getAll().Keys)
            {
                this.genres.Items.Add(genre);
            }
            foreach (var type in Enum.GetValues(typeof(enums.artistType)))
            {
                this.artistType.Items.Add(type);
            }
        }
        private void doneButton(object sender, RoutedEventArgs e)
        {
            List<string> selectedGenres = new List<string>();
            foreach (var item in genres.SelectedItems)
            {
                selectedGenres.Add(item.ToString());
            }
            Enum.TryParse(artistType.SelectedItem.ToString(), out enums.artistType artistTypeResult);
            //new Artist(editor.Username, mp.GetName(), mp.GetLastName(), mp.GetGender(), mp.GetBirthday(), biography.Text, artistTypeResult, selectedGenres, null);
            MessageWindow mw = new MessageWindow("succesful", "made artist");
            mw.Show();
        }
    }
}
