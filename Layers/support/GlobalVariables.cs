using System.IO;

public static class GlobalVariables
{
    public static readonly string membersFile = Path.Combine("..", "..", "..", "Layers", "data", "Members.json");
    public static readonly string editorsFile = Path.Combine("..", "..", "..", "Layers", "data", "Editors.json");
    public static readonly string adminFile = Path.Combine("..", "..", "..", "Layers", "data", "Admin.json");
    public static readonly string artistsFile = Path.Combine("..", "..", "..", "Layers", "data", "Artists.json");
    public static readonly string groupsFile = Path.Combine("..", "..", "..", "Layers", "data", "Groups.json");
    public static readonly string materialsFile = Path.Combine("..", "..", "..", "Layers", "data", "Materials.json");
    public static readonly string genresFile = Path.Combine("..", "..", "..", "Layers", "data", "Genres.json");
    public static readonly string textsFile = Path.Combine("..", "..", "..", "Layers", "data", "Texts.json");
    public static readonly string usersFile = Path.Combine("..", "..", "..", "Layers", "data", "Users.json");
    public static readonly string albumsFile = Path.Combine("..", "..", "..", "Layers", "data", "Albums.json");
}