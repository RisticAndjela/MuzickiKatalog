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

namespace muzickiKatalog.GUI.MVVM.View.Admin
{
    /// <summary>
    /// Interaction logic for EditorTaskList.xaml
    /// </summary>
    public partial class EditorTaskList : Window
    {
        public EditorTaskList()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            var editorTasks = new List<EditorTask>
            {
                new EditorTask { Email = "editor1@example.com", Name = "John", Surname = "Doe", Task = "Review article" },
                new EditorTask { Email = "editor2@example.com", Name = "Jane", Surname = "Smith", Task = "Edit photos" },
                new EditorTask { Email = "editor3@example.com", Name = "Michael", Surname = "Brown", Task = "Write summary" },
                new EditorTask { Email = "editor4@example.com", Name = "Emily", Surname = "Johnson", Task = "Proofread text" },
                new EditorTask { Email = "editor5@example.com", Name = "Chris", Surname = "Davis", Task = "Fact check" }
            };

            EditorTaskDataGrid.ItemsSource = editorTasks;
        }
    }

    public class EditorTask
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Task { get; set; }
    }
}
