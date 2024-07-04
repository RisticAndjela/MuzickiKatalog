using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;
using System.Linq;

namespace muzickiKatalog.Layers.Controller.performatorium
{
    public class MaterialController
    {
        public static Dictionary<string, Material> Get10Popular(Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {

            return getRatings<Material>.Get10Popular(allMaterials, allAlbums, allArtists, allGroups);

        }
        public static Dictionary<string, Tuple<string, string>> getForList(Dictionary<string,Material> materials_)
        {
            Dictionary<string, Tuple<string, string>> allMaterials = new Dictionary<string, Tuple<string, string>>();
            foreach (KeyValuePair<string, Material> pair in materials_)
            {
                allMaterials.Add(pair.Key, new Tuple<string, string>(pair.Value.Title, pair.Value.Media[0]));
            }
            return allMaterials;
        }
        public static Dictionary<string, Tuple<string, string>> FindMaterialsFromSameArtist(Artist artist, Dictionary<string, Material> allMaterials)
        {
            Dictionary<string, Material> final = new Dictionary<string, Material>();
            foreach (KeyValuePair<string, Material> pair in allMaterials)
            {
                if (allMaterials.Equals(pair.Value)) { continue; }
                foreach (string s in pair.Value.Contributors)
                {
                    Artist artistInAll = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile).Item2;
                    if (artist.Equals(artistInAll)){ final.Add(pair.Key,pair.Value); }
                }
            }
            return getForList(final);
        }
        public static Dictionary<string, Tuple<string, string>> FindMaterialsBasedOnAlbum(Album album, Dictionary<string, Material> allMaterials,Dictionary<string, Artist> allArtists)
        {

            List<Artist> artists = new List<Artist>();
            Dictionary<string, Material> final = new Dictionary<string, Material>();
            foreach (string materialString in album.AllMaterials)
            {
                foreach (string artistString in allMaterials[materialString].Contributors)
                {
                    if (allArtists.ContainsKey(artistString))
                    {
                        artists.Add(allArtists[artistString]);
                    }
                    else { final=addMaterialsBasedOnGroup(artistString, final, allMaterials); }
                }
            }

            foreach (KeyValuePair<string, Material> pair in allMaterials)
            {
                if (allMaterials.Equals(pair.Value)) { continue; }
                foreach (string s in pair.Value.Contributors)
                {
                    Artist artistInAll = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile).Item2;
                    if (artists.Contains(artistInAll)) { final.Add(pair.Key, pair.Value); }
                }
            }
            return getForList(final);
        }
        public static Dictionary<string, Material> addMaterialsBasedOnGroup(string id,Dictionary<string, Material> final, Dictionary<string,Material> allMaterials)
        {
            foreach(KeyValuePair<string, Material> pair  in allMaterials)
            {
                if (allMaterials.Equals(pair.Value)) { continue; }
                if (pair.Value.Contributors.Contains(id)) { final.TryAdd(pair.Key, pair.Value); }
                }
            return final;
        }
        public static Dictionary<string, Tuple<string, string>> FindMaterialsWithSameGenre(Material thisMaterial, Dictionary<string, Material> allMaterials)
        {
            Dictionary<string, Material> final = new Dictionary<string, Material>();

            foreach (KeyValuePair<string, Material> pair in allMaterials)
            {
                if (thisMaterial.Equals(pair.Value)) { continue; }
                if (thisMaterial.Genres.Any(one=>pair.Value.Genres.Contains(one))) { final.Add(pair.Key, pair.Value); }
            }

            return getForList(final);
        }
        public static Dictionary<string, Tuple<string, string>> allMaterialsForSameArtists(Material material,  Dictionary<string, Artist> allArtists, Dictionary<string, Material> allMaterials)
        {
            Dictionary<string, Material> final = new Dictionary<string, Material>();

            foreach (KeyValuePair<string, Material> materialCompare in allMaterials)
            {
                if (material.Title.Equals(materialCompare.Value.Title)) { continue; }
                foreach (string artistString in material.Contributors)
                {
                    if (materialCompare.Value.Contributors.Any(one=> material.Contributors.Contains(one))){ if(!final.ContainsKey(materialCompare.Key)) final.Add(materialCompare.Key, materialCompare.Value); }
                }
            }

            return getForList(final);
        }
    }
}
