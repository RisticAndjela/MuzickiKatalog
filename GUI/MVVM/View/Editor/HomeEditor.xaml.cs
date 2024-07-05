using muzickiKatalog.Layers.Controller.contributors;
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
using contributor=muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.View.General;
using muzickiKatalog.Layers.Controller.performatorium;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;
using muzickiKatalog.GUI.MVVM.ViewModel.supportClasses;
using muzickiKatalog.Layers.support.IDparser;

namespace muzickiKatalog.GUI.MVVM.View.Editor
{
    /// <summary>
    /// Interaction logic for HomeEditor.xaml
    /// </summary>
    public partial class HomeEditor : Window
    {
        private contributor.Editor editor;
        private MakeArtist ma;
        private MakeGroup mg;
        private MakeAlbum mab;
        private MakeMaterial mm;

        private Dictionary<string, Material> allMaterials = MaterialRepository.getAll();
        private Dictionary<string, Album> allAlbums = AlbumRepository.getAll();
        private Dictionary<string, Artist> allArtists = ArtistRepository.getAll();
        private Dictionary<string, Group> allGroups = GroupRepository.getAll();

        public HomeEditor(contributor.Editor editor)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.editor = editor;
        }
        private void ApproveReviewsHandler(object sender, RoutedEventArgs e) {
            hideAll();
            ApproveReviewsPanel.Visibility = Visibility.Visible;
            reviews.Children.Add(new ReviewList(editor, EditorController.getReviews(editor),"Review"));
        }
        private void TaskReviewsHandler(object sender, RoutedEventArgs e)
        {
            hideAll();
            reviewsTasks.Visibility= Visibility.Visible;
            (Dictionary<string, Tuple<string, string>> materials, Dictionary<string, Tuple<string, string>> albums, Dictionary<string, Tuple<string, string>> artists, Dictionary<string, Tuple<string, string>> groups)=EditorController.getTasks(editor,allMaterials,allAlbums,allArtists,allGroups);
            reviewsTasks.Children.Add(new ReviewList(editor, materials, "Material"));
            reviewsTasks.Children.Add(new ReviewList(editor, albums, "Album"));
            reviewsTasks.Children.Add(new ReviewList(editor, artists, "Artist"));
            reviewsTasks.Children.Add(new ReviewList(editor, groups, "Group"));
        }
        private void myInfoHandler(object sender, RoutedEventArgs e)
        {
            hideAll();
            InfoPanel.Visibility = Visibility.Visible;
            name.Content = editor.Name;
            lastname.Content = editor.LastName;
            gender.Content = editor.GenderProp.ToString();
            birthday.Content = editor.Birthday.ToString();
            foreach (string genreID in editor.genres)
            {
                Genre genre = GetFromIDs<Genre>.get(genreID, GlobalVariables.genresFile).Item2;
                ButtonLabelManipulation.AddButtonToPanel(specializedForGenres, genre.Name, (sender, e) => new OpenViewBasedOnUser(editor).OpenGenreView("editor", genre, allMaterials, allAlbums, allArtists, allGroups), this);
            }
        }
        private void seeAllAlbumsHandler(object sender, RoutedEventArgs e)
        {
            hideAll();
            ListShow.Children.Add(new OneList(editor, AlbumController.getForList(AlbumRepository.getAll()), "Album"));
        }
        private void seeAllMaterialsHandler(object sender, RoutedEventArgs e)
        {
            hideAll();
            ListShow.Children.Add(new OneList(editor,MaterialController.getForList(MaterialRepository.getAll()), "Material")) ;
        }
        private void seeAllGroupsHandler(object sender, RoutedEventArgs e)
        {
            hideAll();
            ListShow.Children.Add(new OneList(editor, GroupController.getForList(GroupRepository.getAll()), "Group"));

        }
        private void seeAllArtistsHandler(object sender, RoutedEventArgs e)
        {
            hideAll();
            ListShow.Children.Add(new OneList(editor, ArtistController.getForList(ArtistRepository.getAll()), "Artist"));

        }
        private void TopListsHandler(object sender, RoutedEventArgs e)
        {
            hideAll();
            new MessageWindow("WE ARE SORRY","NO AVALIABLE TOP LISTS").Show();
        }
        private void makeAlbumHandler(object sender, RoutedEventArgs e)
        {
            hideAll();
            make.Visibility = Visibility.Visible;
            mab = new MakeAlbum(editor);
            make.Children.Add(mab);
        }
        private void makeMaterialHandler(object sender, RoutedEventArgs e)
        {
            hideAll();
            make.Visibility = Visibility.Visible;
            mm = new MakeMaterial(editor);
            make.Children.Add(mm);
        }
        private void makeGroupHandler(object sender, RoutedEventArgs e)
        {
            hideAll();
            make.Visibility = Visibility.Visible;
            mg = new MakeGroup(editor);
            make.Children.Add(mg);
        }
        private void makeArtistHandler(object sender, RoutedEventArgs e)
        {
            hideAll();
            make.Visibility = Visibility.Visible;
            ma = new MakeArtist(editor);
            make.Children.Add(ma);

        }
       


        private void hideAll()
        {
            make.Visibility = Visibility.Hidden;
            InfoPanel.Visibility= Visibility.Hidden;
            make.Children.Clear();
            ListShow.Children.Clear();
            reviews.Children.Clear();
            reviewsTasks.Children.Clear();
            ApproveReviewsPanel.Visibility = Visibility.Hidden;
        }

        private void approve(object sender, RoutedEventArgs e)
        {
            MessageWindow message = new MessageWindow("SUCCESFUL", "APPROVED");
            message.Show();
        }
        private void disapprove(object sender, RoutedEventArgs e)
        {
            MessageWindow message = new MessageWindow("SUCCESFUL", "DISAPPROVED");
            message.Show();
        }
         

    }
}
