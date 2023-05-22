namespace Tests
{
    [TestFixture]
    public class TestLocation
    {
        LookCommand _look;
        Player _player;
        Item _gem;
        Location _location;
        Path _path;
        string _gemDesc = "Soul Gem";

        [SetUp]
        public void Setup()
        {
            _look = new LookCommand();
            _location = new Location(new string[] { "tundra" }, "Frozen Tundra", "A frozen wasteland");
            _player = new Player("Dude", "Random Dude", _location);
            _gem = new Item(new string[] { "gem" }, "Gem", _gemDesc);
            _path = new Path(new string[] { "north" }, "North", "You trek through the wasteland", _location);

        }

        [Test]
        public void TestLookAtMe()
        {

            Assert.That(_look.Execute(_player, new string[] { "look" }), Is.EqualTo(_player.Location.FullDescription));
        }

        [Test]
        public void TestLocationFullDescription()
        {
            _location.Inventory.Put(_gem);
            _location.Paths.Add(_path);
            Assert.That(_location.FullDescription, Is.EqualTo($"You are in {_location.Name}\nA frozen wasteland\nThere are exits to the north.\nIn this room you can see: \n" + _location.Inventory.ItemList));
        }

        [Test]
        public void TestLocationSelfIdentify()
        {
            Assert.IsTrue(_location.AreYou("tundra"));
        }

        [Test]
        public void TestLocationIdentifyItem()
        {
            _location.Inventory.Put(_gem);
            Assert.That(_location.Locate("gem"), Is.EqualTo(_gem));
        }

        [Test]
        public void TestPlayerIdentifyItemInLocation()
        {
            _location.Inventory.Put(_gem);
            Assert.That(_player.Locate("gem"), Is.EqualTo(_gem));
        }

        [Test]
        public void TestInvalidLookLocation()
        {
            Assert.That(_look.Execute(_player, new string[] { "seek" }), Is.EqualTo("Error in look input"));
        }
    }
}
