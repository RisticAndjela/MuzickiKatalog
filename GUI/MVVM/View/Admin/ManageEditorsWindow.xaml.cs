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
                new Editor { Username = "nicole@editor.com", Name = "nicole", Surname = "julius" },
                
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
    }

    public class Editor
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }






    }
}
