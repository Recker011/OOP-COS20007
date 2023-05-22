namespace Swin_Adventure
{
    public class Path : GameObject
    {

        private readonly Location _destination;

        public Path(string[] ids, string name, string desc, Location Destination) : base(ids, name, desc) => _destination = Destination;

        public Path() { }


        public void MovePlayer(Player p) => p.Location = _destination;


        public override string FullDescription => "You head " + Name + "\n" + base.FullDescription + "\nYou have arrived in " + _destination.Name;
    }
}
