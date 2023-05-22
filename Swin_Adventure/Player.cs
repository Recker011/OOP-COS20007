namespace Swin_Adventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private Location _location;


        public Player(string name, string desc, Location location) : base(new string[] { "me", "inventory" }, name, desc) => _location = location;

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            
                return this;
            
            else if (_inventory.HasItem(id))
            
                return _inventory.Fetch(id);
            
            else
                return _location.Locate(id);

        }

        public override string FullDescription => "You are " + Name + " " + base.FullDescription + "\n You are carrying: \n " + _inventory.ItemList;

        public Inventory Inventory => _inventory;

        public Location Location { get => _location; set => _location = value; }
        
    }
}
