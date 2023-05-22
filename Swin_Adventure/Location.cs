namespace Swin_Adventure
{
    public class Location : GameObject, IHaveInventory
    {

        private Inventory _inventory;
        private List<Path> _paths;
        
        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
            
        }

        public GameObject? Locate(string id)
        {
            if (AreYou(id))
            
                return this;
            
            return _inventory.Fetch(id);
        }

        public Inventory Inventory => _inventory;


        public List<Path> Paths => _paths;



        public Path? GetPath(string ids)
        {
            foreach (Path path in _paths)
            {
                if (path.AreYou(ids))
                
                    return path;
                
            }
            return null;
        }

        public string ShowPaths()
        {
            string p = "";
            if (_paths.Count == 1)
                return _paths[0].FirstID;
            else
            {
                for (int i = 0; i < _paths.Count; i++)
                    p += $"{_paths[i].FirstID}\n";       
            }
            return p;
        }



        public override string FullDescription
        {
            get
            {
                return "You are in " + Name + "\n" + base.FullDescription + "." + "\nIn this room you can see: \n" + _inventory.ItemList + "There are paths to the " + "\n" + ShowPaths();
            }
        }
    }
}
