using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.Layers.Model.contributors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace muzickiKatalog.GUI.MVVM.ViewModel.supportClasses
{
    public class InsertOneListBasedOnUser
    {
        private string user;
        private Editor editor;
        private Member member;
        public InsertOneListBasedOnUser()
        {
            user = "guest";
        }
        public InsertOneListBasedOnUser(Editor editor)
        {
            user = "editor";
            this.editor = editor;
        }
        public InsertOneListBasedOnUser(Member member)
        {
            user = "member";
            this.member = member;
        }
        public void insert(ContentControl contentControl, Dictionary<string, Tuple<string, string>> dict,string str, Label label)
        {
            switch (user)
            {
                case "guest":
                    if(dict.Count>0)
                    { contentControl.Content = new OneList(dict, str); }
                    else { if( label!=null )label.Visibility = Visibility.Hidden; }
                    break;
                case "member":
                    if (dict.Count > 0)
                    { contentControl.Content = new OneList(member,dict, str); }
                    else { if (label != null) label.Visibility = Visibility.Hidden; }
                    break;
                case "editor":
                    if (dict.Count > 0)
                    { contentControl.Content = new OneList(editor,dict, str); }
                    else { if (label != null) label.Visibility = Visibility.Hidden; }
                    break;
            }
        }

    }
}
