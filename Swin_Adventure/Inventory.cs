namespace Swin_Adventure
{
    public class Inventory
    {
        private readonly List<Item> _items = new();

        public Inventory() { }
        

        public bool HasItem(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                
                    return true;
                
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item? Take(string id)
        {
            Item itm = Fetch(id);
            if (itm is not null)
            {
                _items.Remove(itm);
                return itm;
            }
            return null;
        }

        public Item? Fetch(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                
                    return itm;
                
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string ItemList = "";
                foreach (Item itm in _items)
                {
                    ItemList += "\t" + itm.ShortDescription + "\n";
                }
                return ItemList;
            }

        }
    }
}
