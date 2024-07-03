using muzickiKatalog.Layers.support;
using materialNS=muzickiKatalog.Layers.Model.performatorium;
using System.Windows.Media.Media3D;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;

namespace muzickiKatalog.Layers.Controller.performatorium
{
    public class MaterialController
    {
        public static Dictionary<string, materialNS.Material> Get10Popular()
        {

            return getRatings<materialNS.Material>.Get10Popular();

        }
        public static Dictionary<string, Tuple<string, string>> getForList(Dictionary<string,materialNS.Material> materials_)
        {
            Dictionary<string, Tuple<string, string>> allMaterials = new Dictionary<string, Tuple<string, string>>();
            foreach (KeyValuePair<string, materialNS.Material> pair in materials_)
            {
                allMaterials.Add(pair.Key, new Tuple<string, string>(pair.Value.Title, pair.Value.Media[0]));
            }
            return allMaterials;
        }
        public static Dictionary<string, Tuple<string, string>> FindMaterialsFromSameArtist(Artist artist, Dictionary<string, materialNS.Material> allMaterials)
        {
            Dictionary<string, materialNS.Material> final = new Dictionary<string, materialNS.Material>();
            foreach (KeyValuePair<string, materialNS.Material> pair in allMaterials)
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
        public static Dictionary<string, Tuple<string, string>> FindMaterialsBasedOnAlbum(Album album, Dictionary<string, materialNS.Material> allMaterials)
        {
            Dictionary<string, Artist> allArtists = ArtistRepository.getAll();

            List<Artist> artists = new List<Artist>();
            Dictionary<string, materialNS.Material> final = new Dictionary<string, materialNS.Material>();
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

            foreach (KeyValuePair<string, materialNS.Material> pair in allMaterials)
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
        public static Dictionary<string, materialNS.Material> addMaterialsBasedOnGroup(string id,Dictionary<string, materialNS.Material> final, Dictionary<string, materialNS.Material> allMaterials)
        {
            foreach(KeyValuePair<string, materialNS.Material> pair  in allMaterials)
            {
                if (allMaterials.Equals(pair.Value)) { continue; }
                if (pair.Value.Contributors.Contains(id)) { final.TryAdd(pair.Key, pair.Value); }
                }
            return final;
        }
        public static Dictionary<string, Tuple<string, string>> FindMaterialsWithSameGenre(materialNS.Material thisMaterial, Dictionary<string, materialNS.Material> allMaterials)
        {
            Dictionary<string, materialNS.Material> final = new Dictionary<string, materialNS.Material>();

            foreach (KeyValuePair<string, materialNS.Material> pair in allMaterials)
            {
                if (thisMaterial.Equals(pair.Value)) { continue; }
                if (thisMaterial.Genre.Equals(pair.Value.Genre)) { final.Add(pair.Key, pair.Value); }
            }

            return getForList(final);
        }
    }
}
