namespace Swin_Adventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {

        }
        
        public override string Execute(Player p, string[] text)
        {
            IHaveInventory container;
            string itemID;

            
            if (text.Length!= 3 && text.Length!= 5 && text.Length!= 1)
            {
                return "I don't know how to look like that";
            }


            if (text.Length == 1)
            {
                if (text[0].ToLower() == "look")
                {
                    return p.Location.FullDescription;
                }
            }
            if (text[0].ToLower() != "look")
            {
                return "Error in look input";
            }
            if (text[1] != "at")
            {
                return "What do you want to look at?";
            }
            if (text.Length == 5)
            {
                if (text[3] != "in")
                {
                    return "What do you want to look at?";
                }
            }
            

            if (text.Length == 3)
            {
                container = p;
            }
            else
            {
                container = FetchContainer(p, text[4]);
            }
            if (container is null)
            {
                return $"I cannot find the {text[4]}";
            }
            itemID = text[2];
            return LookAtIn(itemID, container);
        }

        public static IHaveInventory? FetchContainer(Player p, string containerID)
        {
            return p.Locate(containerID) as IHaveInventory;
        }

        public static string LookAtIn(string thingID, IHaveInventory container)
        {
            if (container.Locate(thingID) is null)
            {
                return $"I cannot find the {thingID}";
            }
            else
            {
                return container.Locate(thingID).FullDescription;
            }
        }
    }
}
