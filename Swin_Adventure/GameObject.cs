namespace Swin_Adventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private readonly string? _description;
        private readonly string? _name;


        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _description = desc;
            _name = name;
        }

        public GameObject() { }
        

        public string? Name => _name;


        public string ShortDescription => $"a {_name } ({FirstID})";

        public virtual string? FullDescription => _description;


    }
}
