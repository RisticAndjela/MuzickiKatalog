using System.Collections.Generic;
using System.Windows;

namespace muzickiKatalog.GUI.MVVM.View.Admin
{
    /// <summary>
    /// Interaction logic for ManageEditors.xaml
    /// </summary>
    public partial class ManageEditorsWindow : Window
    {
        private List<Editor> allEditors; 

        public ManageEditorsWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            
            allEditors = new List<Editor>
            {
                new Editor { Username = "nicole@editor.com", Name = "nicole", Surname = "julius", Gender = "Female", BirthDate = "1879-03-14", Genres = "jazz" },
                new Editor { Username = "john@editor.com", Name = "John", Surname = "Doe", Gender = "Male", BirthDate = "1980-05-20", Genres = "rock" },
                new Editor { Username = "anna@editor.com", Name = "Anna", Surname = "Smith", Gender = "Female", BirthDate = "1990-08-15", Genres = "pop" }
            };

            EditorsDataGrid.ItemsSource = allEditors;
        }

        private void AddEditor(object sender, RoutedEventArgs e)
        {
           
        }

        private void UpdateEditor(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteEditor(object sender, RoutedEventArgs e)
        {
            
        }


        private void BtnEditorReviewInsights_Click(object sender, RoutedEventArgs e) 
            => new EditorInsightsWindow().ShowDialog();
    }

    public class Editor
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string Genres {  get; set; }






    }
}
