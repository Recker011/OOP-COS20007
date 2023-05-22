namespace Swin_Adventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {

        }

        public override string Execute(Player p, string[] text)
        {

            if (text.Length != 2)
            
                return "I don't know how to move like that";
            

            if (text[0].ToLower() != "move" && text[0].ToLower() != "go" && text[0].ToLower() != "head" && text[0].ToLower() != "leave")
            
                return "Error in move command";
            


            Location CurrentLocation = p.Location;

            Path MovePath = CurrentLocation.GetPath(text[1].ToLower());

            if (MovePath == null)
            
                return "That path is blocked";
            
            else
            
                MovePath.MovePlayer(p);
                return MovePath.FullDescription;
            
        }
    }
}
