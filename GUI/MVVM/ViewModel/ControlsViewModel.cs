using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.Layers.Controller.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Service.performatorium;
using muzickiKatalog.Layers.Model.performatorium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace muzickiKatalog.GUI.MVVM.ViewModel
{
    public class ControlsViewModel: INotifyPropertyChanged
    { 
        private UserControl ADsView;
        private UserControl popularListedView;
        private UserControl followingListedView;
        private UserControl allListedView;
        private UserControl searchView;

        public ControlsViewModel()
            {
                Dictionary<string, Material> allMaterials = MaterialRepository.getAll();
                Dictionary<string, Album> allAlbums = AlbumRepository.getAll();
                Dictionary<string, Artist> allArtists = ArtistRepository.getAll();
                Dictionary<string, Group> allGroups = GroupRepository.getAll();
                AdsPanel = new ADs();
                PopularListedPanel = new Listed(MaterialController.Get10Popular(allMaterials, allAlbums, allArtists, allGroups), AlbumController.Get10Popular(allMaterials,allAlbums,allArtists,allGroups), GroupController.Get10Popular(allMaterials, allAlbums, allArtists, allGroups), ArtistController.Get10Popular(allMaterials,allAlbums,allArtists,allGroups));
                FollowingListedPanel = new Listed(allMaterials,allAlbums,allGroups,allArtists);
                AllListedPanel = new Listed(allMaterials,allAlbums,allGroups,allArtists);
                SearchPanel = new SearchFilter();
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
            public UserControl FollowingListedPanel
            {
                get { return followingListedView; }
                set
                {
                followingListedView = value;
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

