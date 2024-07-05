using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace muzickiKatalog.GUI.MVVM.ViewModel.supportClasses
{
    public class ButtonLabelManipulation
    {
        public static void fillDescription(string descriptionString, StackPanel main, FrameworkElement resourceSource,int size=90)
        {
            int length = descriptionString.Length;
            int i = 0;
            int back = 0;
            while (i < length)
            {
                string content = descriptionString.Substring(i, Math.Min(size, length - i));
                back = 0;
                while (content.Length > 0 && (content.Last() != ' ' && content.Last() != '.' && content.Last() != '!' && content.Last() != '?'))
                {
                    content = content.Substring(0, content.Length - 1);
                    back++;
                }

                Label description = new Label
                {
                    Style = (Style)resourceSource.FindResource("regularLabel"),
                    Content = content
                };
                main.Children.Add(description);
                i += size - back;
               
            }
        }

        public static void AddButtonToPanel(Panel panel, string content, RoutedEventHandler clickHandler, FrameworkElement resourceSource)
        {
            Button button = new Button
            {
                Style = (Style)resourceSource.FindResource("LabelLikeButton"),
                Content = content
            };
            button.Click += clickHandler;
            panel.Children.Add(button);
        }
    }

}
