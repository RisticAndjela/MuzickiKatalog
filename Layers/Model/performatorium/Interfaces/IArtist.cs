using muzickiKatalog.Layers.support;

namespace muzickiKatalog.Layers.Model.performatorium.Interfaces
{
    public interface IArtist : IAdditional
    {
        string Editor { get; set; }
        artistType Type { get; set; }
        List<string> Genres { get; set; }
        List<string> Groups { get; set; }
    }
}
