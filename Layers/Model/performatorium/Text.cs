using muzickiKatalog.Layers.Repository.performatorium;


namespace muzickiKatalog.Layers.Model.performatorium
{
    //long texts such as Description for videos and biography for Artists and Groups
    public class Text
    {
        public string text;
        public Text() { }
        public Text(string _text, string id)
        {
            text = _text;
            TextRepository.save(this,id);
        }
        
    }
}
