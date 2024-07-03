﻿using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.Model.performatorium;
using groupNS=muzickiKatalog.Layers.Model.performatorium;
using System.Text.RegularExpressions;
using muzickiKatalog.Layers.support.IDparser;

namespace muzickiKatalog.Layers.Controller.performatorium
{
    public class GroupController
    {
        public static Dictionary<string, groupNS.Group> Get10Popular()
        {
            return getRatings<groupNS.Group>.Get10Popular();
        }
        public static Dictionary<string, Tuple<string, string>> getForList(Dictionary<string, groupNS.Group> groups_)
        {
            Dictionary<string, Tuple<string, string>> allGroups = new Dictionary<string, Tuple<string, string>>();
            foreach (KeyValuePair<string, groupNS.Group> pair in groups_)
            {
                allGroups.Add(pair.Key, new Tuple<string, string>(pair.Value.Name, pair.Value.Media[0]));
            }
            return allGroups;
        }
        public static Dictionary<string, Tuple<string, string>> FindSimilarGroupsByArtists(groupNS.Group thisGroup, Dictionary<string, groupNS.Group> allGroups)
        {
            Dictionary<string, groupNS.Group> final = new Dictionary<string, groupNS.Group>();
            List<Artist> artists = new List<Artist>();
            foreach (string artistString in thisGroup.Artists)
            {
                artists.Add(GetFromIDs<Artist>.get(artistString, GlobalVariables.artistsFile).Item2);

            }
            foreach (KeyValuePair<string, groupNS.Group> pair in allGroups)
            {
                if (thisGroup.Equals(pair.Value)) { continue; }
                foreach (string artistString in pair.Value.Artists) {
                    Artist artist = GetFromIDs<Artist>.get(artistString, GlobalVariables.artistsFile).Item2;
                    if(artists.Contains(artist)) { final.Add(pair.Key, pair.Value); break; }
                }
            }
            return getForList(final);
        }
        
        
    }
}
