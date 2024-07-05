using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.Layers.Controller.performatorium;
using muzickiKatalog.Layers.Controller.contributors;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Repository.contributors;
using muzickiKatalog.Layers.Service.performatorium;
using muzickiKatalog.Layers.Model.performatorium;
using contributor=muzickiKatalog.Layers.Model.contributors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using muzickiKatalog.Layers.Model.contributors;
using System.Collections.ObjectModel;

namespace muzickiKatalog.GUI.MVVM.ViewModel
{
    public class ControlsViewModel: INotifyPropertyChanged
    { 
        private UserControl ADsView;
        private UserControl popularListedView;
        private List<UserControl> followingListedView=new List<UserControl>();
        private UserControl allListedView;
        private UserControl searchView;
        private List<UserControl> playlistPanels = new List<UserControl>();

        private Dictionary<string, Material> allMaterials= MaterialRepository.getAll() ;
        private Dictionary<string, Album> allAlbums= AlbumRepository.getAll() ;
        private Dictionary<string, Artist> allArtists= ArtistRepository.getAll();
        private Dictionary<string, Group> allGroups= GroupRepository.getAll() ;
      
        public ControlsViewModel()
        {
            string user = "guest";
            ViewModel(user);
            PopularListedPanel = new Listed(MaterialController.Get10Popular(allMaterials, allAlbums, allArtists, allGroups), AlbumController.Get10Popular(allMaterials, allAlbums, allArtists, allGroups), GroupController.Get10Popular(allMaterials, allAlbums, allArtists, allGroups), ArtistController.Get10Popular(allMaterials, allAlbums, allArtists, allGroups));
            AllListedPanel = new Listed(allMaterials, allAlbums, allGroups, allArtists);
        }
         public ControlsViewModel(contributor.Editor editor)
        {
            string user = "editor";
            ViewModel(user);
            PopularListedPanel = new Listed(editor, MaterialController.Get10Popular(allMaterials, allAlbums, allArtists, allGroups), AlbumController.Get10Popular(allMaterials, allAlbums, allArtists, allGroups), GroupController.Get10Popular(allMaterials, allAlbums, allArtists, allGroups), ArtistController.Get10Popular(allMaterials, allAlbums, allArtists, allGroups));
            AllListedPanel = new Listed(editor, allMaterials, allAlbums, allGroups, allArtists);
        }
         public ControlsViewModel(contributor.Member member)
         {
            string user = "member";
            ViewModel(user);
            
            PopularListedPanel = new Listed(member,MaterialController.Get10Popular(allMaterials, allAlbums, allArtists, allGroups), AlbumController.Get10Popular(allMaterials, allAlbums, allArtists, allGroups), GroupController.Get10Popular(allMaterials, allAlbums, allArtists, allGroups), ArtistController.Get10Popular(allMaterials, allAlbums, allArtists, allGroups));
            
            (Dictionary<string, Tuple<string, string>> artists, Dictionary<string, Tuple<string, string>> groups) = MemberController.followingArtistsAndGroups(member,allArtists,allGroups);
            FollowingListedPanel.Add(new OneList(member, artists, "Artist"));
            FollowingListedPanel.Add(new OneList(member, groups, "Group"));
            
            AllListedPanel = new Listed(member, allMaterials, allAlbums, allGroups, allArtists);
            
            foreach (PlayList playlist in PlayListService.getAllPlayLists(member))
            {
                playlistPanels.Add(new PlayListUserControl(playlist, member));
            }
            PlayListPanels = new ObservableCollection<UserControl>(playlistPanels);
         }
        public void ViewModel(string user)
        {
            AdsPanel = new ADs();
            SearchPanel = new SearchFilter();
        }
        public ObservableCollection<UserControl> PlayListPanels
        {
            get { return new ObservableCollection<UserControl>(playlistPanels); }
            set
            {
                playlistPanels = new List<UserControl>(value);
                OnPropertyChanged();
            }
        }
       
        public ObservableCollection<UserControl> FollowingListedPanel
        {
            get { return new ObservableCollection<UserControl>(followingListedView); }
            set
            {
            followingListedView  = new List<UserControl>(value);
                OnPropertyChanged();
            }
        }
        public UserControl AdsPanel
        {
            get { return ADsView; }
            set
            {
                ADsView = value;
                OnPropertyChanged();
            }
        }
       
        public UserControl PopularListedPanel
            {
            get { return popularListedView; }
            set
            {
                popularListedView = value;
                OnPropertyChanged();
            }
        }
        public UserControl AllListedPanel
        {
            get { return allListedView; }
            set
            {
                allListedView = value;
                OnPropertyChanged();
            }
        }
        public UserControl SearchPanel
        {
                get { return searchView; }
                set
                {
                    searchView = value;
                    OnPropertyChanged();
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

