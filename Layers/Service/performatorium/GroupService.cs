﻿using muzickiKatalog.Layers.Model.performatorium;
using performatoriumNS=muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.Layers.Service.performatorium.Interfaces;
using muzickiKatalog.Layers.support;

namespace muzickiKatalog.Layers.Service.performatorium
{
    public class GroupService:IGroupService
    {
        public static void visited(Group group)
        {
            group.Visits++;
            GroupRepository.save(group);
        }
        public static void addMaterial(Group group, performatoriumNS.Material material)
        {
            string id=MakeIDs.makeMaterialID(material);
            if(!group.AllMaterials.Contains(id)) group.AllMaterials.Add(id);
            GroupRepository.save(group);
            foreach (string s in group.Artists)
            {
                (_, Artist artist) = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile);
                ArtistService.AddMaterialInfo(artist, material);
            }
        }
        public static void addAlbum(Group group, Album album)
        {
            string id= MakeIDs.makeAlbumID(album);
            if(!group.AllMaterials.Contains(id))group.AllMaterials.Add(id);
            GroupRepository.save(group);
            foreach (string s in group.Artists)
            {
                (_, Artist artist) = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile);
                ArtistService.AddAlbumInfo(artist,album);
            }
        }
        public static void addComment(Group group, Comment comment)
        {
            group.AllComments.Add(comment);
            GroupRepository.save(group);
        }
        public static void addRating(Group group, StarRating stars)
        {
            group.AllStarRatings.Add(stars);
            GroupRepository.save(group);
        }

        public static string getDescription(Group group) {
            return TextService.getTextByID(MakeIDs.makeGroupID(group)).text;
        }

    }
}
