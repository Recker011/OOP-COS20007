namespace Swin_Adventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory = new Inventory();

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {

        }

        public GameObject Locate(string id)
        {
            {
                if (this.AreYou(id))
                    return this;


                if (!_inventory.HasItem(id))
                    return null;

                else
                    return _inventory.Fetch(id);
            }
        }

        public override string FullDescription => "In the " + this.Name + " you can see: " + _inventory.ItemList;


        public Inventory Inventory => _inventory;
    }
}
