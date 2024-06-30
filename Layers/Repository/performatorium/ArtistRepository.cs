﻿using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.dao;

namespace muzickiKatalog.Layers.Repository.performatorium
{
    public class ArtistRepository
    {
        public static Dictionary<string,Artist> getAll()
        {
            return new Dao<Artist>(GlobalVariables.artistsFile).ReadDictionaryFromFile();
        }
    }
}
