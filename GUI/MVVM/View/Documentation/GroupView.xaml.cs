using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.ViewModel;
using muzickiKatalog.GUI.MVVM.ViewModel.supportClasses;
using muzickiKatalog.Layers.Controller.performatorium;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;
using muzickiKatalog.Layers.Service.performatorium;
using muzickiKatalog.Layers.support.IDparser;
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

namespace muzickiKatalog.GUI.MVVM.View.Documentation
{
    /// <summary>
    /// Interaction logic for GroupView.xaml
    /// </summary>
    public partial class GroupView : Window
    {
        private ReviewSection reviewSection;
        private Group group;
        public Dictionary<string, Material> allMaterials;
        public Dictionary<string, Album> allAlbums;
        public Dictionary<string, Artist> allArtists;
        public Dictionary<string, Group> allGroups;
        public GroupView(Group group, Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            InitializeComponent();
            this.group = group;
            this.allMaterials = allMaterials;
            this.allAlbums = allAlbums;
            this.allArtists = allArtists;
            this.allGroups = allGroups;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content = group.Name;
            reviewSection = new ReviewSection(group.AllStarRatings, group.AllComments);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            panelr.Content = reviewSection;
            fillContents();
        }
        public void fillContents()
        {
            string id = MakeIDs.makeGroupID(group);
            Dictionary<string, Tuple<string, string>> similarDict = ConvertSupport<Group>.eraseFromSimilar(id, GroupController.FindSimilarGroupsByArtists(group, allGroups));
            Dictionary<string, Tuple<string, string>> fromArtistDict = GroupController.FindMaterialsFromGroupArtists(group, allMaterials);
            _ = similarDict.Count > 0 ? similarGroups.Content = new OneList(similarDict, "Group") : similarLabel.Visibility = Visibility.Hidden;
            _ = fromArtistDict.Count > 0 ? materialsMembers.Content = new OneList(fromArtistDict, "Material") : materialMembersLabel.Visibility = Visibility.Hidden;
            fillMain();
            Dictionary<string, Tuple<string, string>> galleryDict = ConvertSupport<Group>.getGalleryImages(group);
            _ = galleryDict.Count > 0 ? gallery.Content = new OneList(galleryDict, "none") : galleryLabel.Visibility = Visibility.Hidden;

        }
        public void fillMain()
        {
            main.Children.Clear();
            ButtonLabelManipulation.fillDescription(GroupService.getDescription(group), main, this);
            ButtonLabelManipulation.fillDescription($"STARTED:  {group.Started.ToString()} ", main, this);
            ButtonLabelManipulation.fillDescription($"ACTIVE:  {(group.isActive ? "present " : "not ")}", main, this);
            List<Material> allAcceptableMaterials = new List<Material>();
            List<Artist> artists = new List<Artist>();
            if (group.AllMaterials.Count > 0)
            {
                foreach (string materialString in group.AllMaterials)
                {
                    Material material = GetFromIDs<Material>.get(materialString, GlobalVariables.materialsFile).Item2;
                    if(material == null) {
                        Material materialLast=new Material();
                        Album album = GetFromIDs<Album>.get(materialString, GlobalVariables.albumsFile).Item2;
                        foreach (string materialString2 in album.AllMaterials)
                        {
                            Material material2 = GetFromIDs<Material>.get(materialString2, GlobalVariables.materialsFile).Item2;
                            ButtonLabelManipulation.AddButtonToPanel(column1, material2.Title, (sender, e) => new MaterialView(material2, allMaterials, allAlbums, allArtists, allGroups).Show(), this);
                            materialLast=material2;
                        }
                        foreach(string contribute in materialLast.Contributors) { 
                            if (allArtists.ContainsKey(contribute)) {AddArtistIfNotExists(artists, allArtists[contribute]);}
                            else if (allGroups.ContainsKey(contribute))
                            {
                                IEnumerable<Artist> groupArtists = allGroups[contribute].Artists
                                    .Select(value => GetFromIDs<Artist>.get(value, GlobalVariables.artistsFile).Item2);

                                foreach (Artist artistToAdd in groupArtists)
                                {
                                    AddArtistIfNotExists(artists, artistToAdd);
                                }
                            }
                        }
                    }
                    else { 
                        foreach (string contribute in material.Contributors)
                        {
                            if (allArtists.ContainsKey(contribute))
                            {
                                AddArtistIfNotExists(artists, allArtists[contribute]);
                            }
                            else if (allGroups.ContainsKey(contribute))
                            {
                                IEnumerable<Artist> groupArtists = allGroups[contribute].Artists
                                    .Select(value => GetFromIDs<Artist>.get(value, GlobalVariables.artistsFile).Item2);

                                foreach (Artist artistToAdd in groupArtists)
                                {
                                    AddArtistIfNotExists(artists, artistToAdd);
                                }
                            }
                        }
                        ButtonLabelManipulation.AddButtonToPanel(column1, material.Title, (sender, e) => new MaterialView(material, allMaterials, allAlbums, allArtists, allGroups).Show(), this);

                    }
                }
               
            }

            else
            {
                ButtonLabelManipulation.fillDescription("none record yet", column1, this);
            }
        
        }
            void AddArtistIfNotExists(List<Artist> artists, Artist artistToAdd)
            {
                if (!artists.Any(a => $"{a.Name} {a.LastName}" == $"{artistToAdd.Name} {artistToAdd.LastName}"))
                {
                    artists.Add(artistToAdd);
                    ButtonLabelManipulation.AddButtonToPanel(column2, $"{artistToAdd.Type}: {artistToAdd.Name} {artistToAdd.LastName}", (sender, e) => new ArtistView(artistToAdd, allMaterials, allAlbums, allArtists, allGroups).Show(), this);
                }
            }
        }
    }

