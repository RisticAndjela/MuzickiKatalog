using System.IO;

public static class GlobalVariables
{
    public static readonly string membersFile = Path.Combine("..", "..", "..", "Model", "data", "Members.json");
    public static readonly string editorsFile = Path.Combine("..", "..", "..", "Model", "data", "Editors.json");
    public static readonly string adminFile = Path.Combine("..", "..", "..", "Model", "data", "Admin.json");
    public static readonly string artistsFile = Path.Combine("..", "..", "..", "Model", "data", "Artists.json");
    public static readonly string groupsFile = Path.Combine("..", "..", "..", "Model", "data", "Groups.json");
    public static readonly string materialsFile = Path.Combine("..", "..", "..", "Model", "data", "Materials.json");
    public static readonly string genresFile = Path.Combine("..", "..", "..", "Model", "data", "Genres.json");
    public static readonly string textsFile = Path.Combine("..", "..", "..", "Model", "data", "Texts.json");
    public static readonly string usersFile = Path.Combine("..", "..", "..", "Model", "data", "Users.json");
}