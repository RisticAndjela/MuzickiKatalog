﻿using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.GUI.MVVM.ViewModel.supportClasses
{
    public class ConvertSupport<T> where T : IAdditional
    {
        public static Dictionary<string, Tuple<string, string>> getGalleryImages(T from)
        {
            Dictionary<string, Tuple<string, string>> final = new Dictionary<string, Tuple<string, string>>();
            foreach (string s in from.Media)
            {
                final.Add(s, Tuple.Create("", s));
            }
            return final;
        }
        public static Dictionary<string, Tuple<string,string>> eraseFromSimilar(string erase, Dictionary<string, Tuple<string,string>> all)
        {
            if (all.ContainsKey(erase))
            {
                all.Remove(erase);
            }
            return all;
        }

    }
}
