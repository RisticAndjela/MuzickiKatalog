using System.IO;

public static class GlobalVariables
{
    private static readonly string 
        projectRoot = @"C:\Users\Aki\Desktop\MuzickiKatalog", // Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..") // couldn't figure out how to set relative path 
        mediaDir = Path.Combine(projectRoot, "Layers", "media"),
        dataDir = Path.Combine(projectRoot, "Layers", "data");

    public static readonly string membersFile = Path.Combine(dataDir, "Members.json");
    public static readonly string editorsFile = Path.Combine(dataDir, "Editors.json");
    public static readonly string adminFile = Path.Combine(dataDir, "Admin.json");
    public static readonly string artistsFile = Path.Combine(dataDir, "Artists.json");
    public static readonly string groupsFile = Path.Combine(dataDir, "Groups.json");
    public static readonly string materialsFile = Path.Combine(dataDir, "Materials.json");
    public static readonly string genresFile = Path.Combine(dataDir, "Genres.json");
    public static readonly string textsFile = Path.Combine(dataDir, "Texts.json");
    public static readonly string usersFile = Path.Combine(dataDir, "Users.json");
    public static readonly string albumsFile = Path.Combine(dataDir, "Albums.json");
    public static readonly string playListsFile = Path.Combine(dataDir, "PlayList.json");

    //images
    public static readonly string elvis_presley = Path.Combine(mediaDir, "elvis_presley.jfif");
    public static readonly string michael_jackson = Path.Combine(mediaDir, "michael_jackson.jfif");
    public static readonly string bob_dylan = Path.Combine(mediaDir, "bob_dylan.jfif");
    public static readonly string aretha_franklin = Path.Combine(mediaDir, "aretha_franklin.jfif");
    public static readonly string pink_floyd = Path.Combine(mediaDir, "pink_floyd.jfif");
    public static readonly string rolling_stones = Path.Combine(mediaDir, "rolling_stones.jfif");
    public static readonly string beatles = Path.Combine(mediaDir, "beatles.jfif");
    public static readonly string img1 = Path.Combine(mediaDir, "img1.jfif");
    public static readonly string img2 = Path.Combine(mediaDir, "img2.jfif");
    public static readonly string img3 = Path.Combine(mediaDir, "img3.jfif");
    public static readonly string img4 = Path.Combine(mediaDir, "img4.jfif");
}