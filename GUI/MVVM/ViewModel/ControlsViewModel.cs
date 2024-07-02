using muzickiKatalog.GUI.MVVM.View.Controls;
using muzickiKatalog.Layers.Repository.performatorium;
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
        private UserControl listedView;
        private UserControl searchView;

        public ControlsViewModel()
            {
                AdsPanel = new ADs();
                ListedPanel = new Listed(MaterialRepository.getAll(),AlbumRepository.getAll(),GroupRepository.getAll(),ArtistRepository.getAll());
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
             public UserControl ListedPanel
             {
                get { return listedView; }
                set
                {
                    listedView = value;
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

