using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace muzickiKatalog.GUI.MVVM.View.Admin
{
    /// <summary>
    /// Interaction logic for EdiotrInsightsWindow.xaml
    /// </summary>
    public partial class EditorInsightsWindow : Window
    {
        public ObservableCollection<dynamic> Insights { get; set; } = [];


        public EditorInsightsWindow()
        {
            InitializeComponent();
            DataContext = this;

            Insights =
            [
                new { MaterialTitle = "Introduction to Music Theory", AverageRating = 4.2, EditorRating = 3.5, Editor = "nicole@editor.com" },
                new { MaterialTitle = "The History of Classical Music", AverageRating = 3.8, EditorRating = 4.0, Editor = "nicole@editor.com" },
                new { MaterialTitle = "Understanding Jazz Improvisation", AverageRating = 4.5, EditorRating = 5.0, Editor = "nicole@editor.com" },
                new { MaterialTitle = "Mozart's 'The Magic Flute' Opera", AverageRating = 3.2, EditorRating = 2.8, Editor = "nicole@editor.com" },
                new { MaterialTitle = "The Beatles: 'Sgt. Pepper's Lonely Hearts Club Band' Album", AverageRating = 4.0, EditorRating = 3.7, Editor = "nicole@editor.com" },
                new { MaterialTitle = "Johann Strauss II: 'The Blue Danube' Waltz", AverageRating = 3.5, EditorRating = 4.1, Editor = "nicole@editor.com" },
                new { MaterialTitle = "Any Colour You Like", AverageRating = 4.7, EditorRating = 4.9, Editor = "nicole@editor.com" },
                new { MaterialTitle = "Elvis Presley's 'Heartbreak Hotel'", AverageRating = 2.9, EditorRating = 3.3, Editor = "nicole@editor.com" }
            ];
        }
    }
}
