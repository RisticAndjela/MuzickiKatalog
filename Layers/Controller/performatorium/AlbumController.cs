using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Controller.performatorium
{
    public class AlbumController
    {
        public static Dictionary<string, Album> Get10Popular(Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            return getRatings<Album>.Get10Popular(allMaterials,allAlbums,allArtists,allGroups);
        }
        public static Dictionary<string, Tuple<string, string>> allAlbumsForArtist(Artist artist, Dictionary<string,Album> allAlbums,Dictionary<string, Artist> allArtists,Dictionary<string, Material> allMaterials)
        {
            Dictionary<string, Album> final = new Dictionary<string, Album>();
            
            foreach (KeyValuePair<string, Album> pair in allAlbums)
            {
                foreach (string materialString in pair.Value.AllMaterials)
                {
                    Material material = allMaterials[materialString];
                    foreach (string artistString in material.Contributors)
                    {
                        if (allArtists.ContainsKey(artistString))
                        {
                        if (artist.Equals(allArtists[artistString])) { final.Add(pair.Key, pair.Value); }
                        }
                    }
                }
            }
            return getForList(final);
        }
        public static Dictionary<string, Tuple<string, string>> FindAlbumsFromSameArtist(Album thisAlbum, Dictionary<string, Album> allAlbums,Dictionary<string, Artist> allArtists, Dictionary<string, Material> allMaterials)
        {
            
            List<Artist> artists = new List<Artist>();

            foreach (string materialString in thisAlbum.AllMaterials) { 
                foreach(string artistString in allMaterials[materialString].Contributors)
                {
                    if (allArtists.ContainsKey(artistString))
                    {
                        artists.Add(allArtists[artistString]);
                    }
                }
            }

            Dictionary<string, Album> final = new Dictionary<string, Album>();

            foreach (KeyValuePair<string, Album> pair in allAlbums)
            {
                if(thisAlbum.Equals(pair.Value)) { continue;}
                foreach(string materialString in pair.Value.AllMaterials)
                {
                    Material material = allMaterials[materialString];
                    if (material.Albums.Equals(MakeIDs.makeAlbumID(thisAlbum))){ continue;}
                    foreach(string artistString in material.Contributors)
                    {
                        if (artists.Contains(allArtists[artistString])){final.Add(pair.Key, pair.Value); }
                    }
                }
            }
            return getForList(final);
        }
        public static Dictionary<string, Tuple<string, string>> FindAlbumsWithSameGenre(Album thisAlbum, Dictionary<string, Album> allAlbums)
        {
            Dictionary<string, Album> final =new Dictionary<string, Album>();

            foreach (KeyValuePair<string, Album> pair in allAlbums)
            {
                if (thisAlbum.Equals(pair.Value)) { continue; }
                if (thisAlbum.Genre.Equals(pair.Value.Genre)) { final.Add(pair.Key, pair.Value); }
            }
            return getForList(final) ;
        }
        public static Dictionary<string, Tuple<string, string>> getForList(Dictionary<string, Album> albums_)
        {
            Dictionary<string, Tuple<string, string>> allAlbums = new Dictionary<string, Tuple<string, string>>();
            foreach (KeyValuePair<string, Album> pair in albums_)
            {
                allAlbums.Add(pair.Key, new Tuple<string, string>(pair.Value.Name, pair.Value.Media[0]));
            }
            return allAlbums;
        }

        public static Dictionary<string, Tuple<string, string>> allAlbumsForSameArtists(Material material, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Material> allMaterials)
        {
            Dictionary<string, Album> final = new Dictionary<string, Album>();
            
            foreach (KeyValuePair<string,Album> pair in allAlbums)
            {
                if (pair.Value.AllMaterials.Contains(MakeIDs.makeMaterialID(material))) { continue; }
                foreach (string materialsString in pair.Value.AllMaterials)
                {
                    Material materialCompare=GetFromIDs<Material>.get(materialsString,GlobalVariables.materialsFile).Item2;
                    if (materialCompare.Contributors.Any(one=> material.Contributors.Contains(one)))
                    {
                        final.Add(pair.Key,pair.Value);
                    }
                }
            }


            return getForList(final);
        }
    }
}
