namespace muzickiKatalog.Layers.Model.performatorium.Interfaces
{
    public interface IAlbum : IDocumentation
    {
        string Name { get; set; }
        string Description { get; set; }
        string Genre { get; set; }
    }
}
