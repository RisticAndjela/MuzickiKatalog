using muzickiKatalog.GUI.MVVM.View.Controls;
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
    public class OneListViewModel : INotifyPropertyChanged
    {
        private UserControl listViewMaterials;
        private UserControl listViewAlbums;
        private UserControl listViewArtists;
        private UserControl listViewGroups;

        public OneListViewModel(Dictionary<string, Material> materials_, Dictionary<string, Album> albums_, Dictionary<string, Group> groups_, Dictionary<string, Artist> artists_)
        {
            Dictionary<string, Tuple<string, string>> allMaterials = new Dictionary<string, Tuple<string, string>>();
            foreach (KeyValuePair<string,Material> pair in materials_) 
            {
                allMaterials.Add(pair.Key, new Tuple<string, string>(pair.Value.title, pair.Value.media[0]));
            }
            ListShowMaterials = new OneList(allMaterials);
            Dictionary<string, Tuple<string, string>> allAlbums = new Dictionary<string, Tuple<string, string>>();
            foreach(KeyValuePair<string,Album> pair in albums_)
            {
                allAlbums.Add(pair.Key,new Tuple<string, string>(pair.Value.name, pair.Value.media[0]));  
            }
            ListShowAlbums = new OneList(allAlbums);
            Dictionary<string, Tuple<string, string>> allArtists = new Dictionary<string, Tuple<string, string>>();
            foreach(KeyValuePair<string,Artist> pair in artists_)
            {
                allArtists.Add(pair.Key,new Tuple<string,string>($"{pair.Value.name} {pair.Value.lastName}", pair.Value.media[0]));
            }
            ListShowArtists = new OneList(allArtists);
            Dictionary<string, Tuple<string, string>> allGroups = new Dictionary<string, Tuple<string, string>>();
            foreach(KeyValuePair<string, Group> pair in groups_)
            {
                allGroups.Add(pair.Key, new Tuple<string, string>(pair.Value.name, pair.Value.media[0]));
            }
            ListShowGroups = new OneList(allGroups);

        }

        public UserControl ListShowMaterials
        {
            get { return listViewMaterials; }
            set
            {
                listViewMaterials = value;
                OnPropertyChanged();
            }
        }
        public UserControl ListShowAlbums
        {
            get { return listViewAlbums; }
            set
            {
                listViewAlbums = value;
                OnPropertyChanged();
            }
        }
        public UserControl ListShowArtists
        {
            get { return listViewArtists; }
            set
            {
                listViewArtists = value;
                OnPropertyChanged();
            }
        }
        public UserControl ListShowGroups
        {
            get { return listViewGroups; }
            set
            {
                listViewGroups = value;
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