using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Service.performatorium;
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
                AdsPanel = new ADs();
                PopularListedPanel = new Listed(MaterialService.Get10Popular(),AlbumService.Get10Popular(), GroupService.Get10Popular(), ArtistService.Get10Popular());
                FollowingListedPanel = new Listed(MaterialRepository.getAll(),AlbumRepository.getAll(),GroupRepository.getAll(),ArtistRepository.getAll());
                AllListedPanel = new Listed(MaterialRepository.getAll(),AlbumRepository.getAll(),GroupRepository.getAll(),ArtistRepository.getAll());
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

