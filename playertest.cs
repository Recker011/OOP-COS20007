namespace Tests
{
    [TestFixture]
    public class TestPlayer
    {
        Player _player;
        Item _sword;
        Item _apple;
        Location _location;

        [SetUp]
        public void Setup()
        {
            _sword = new Item(new string[] { "sword" }, "Ebony sword", "a sword made by a daedric blacksmith");
            _apple = new Item(new string[] { "apple" }, "Apple", "A fruit");
            _location = new Location(new string[] { "Fields" }, "Fields", "A lush green field");
            _player = new Player("Dude", "a regular everyday normal dude", _location);
            _player.Inventory.Put(_sword);
            _player.Inventory.Put(_apple);

        }

        [Test]
        public void TestPlayerIdentifiable()
        {
            Assert.IsTrue(_player.AreYou("me"));
            Assert.IsTrue(_player.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocateItem()
        {
            Assert.That(_player.Locate("sword"), Is.EqualTo(_sword));
            Assert.IsTrue(_player.Inventory.HasItem("sword"));
        }

        [Test]
        public void TestPlayerSelfLocate()
        {
            Assert.That(_player.Locate("me"), Is.EqualTo(_player));
            Assert.That(_player.Locate("inventory"), Is.EqualTo(_player));
        }

        [Test]
        public void TestPlayerNullLocate()
        {
            Assert.That(_player.Locate("potion"), Is.EqualTo(null));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            Assert.That(_player.FullDescription, Is.EqualTo($"You are {_player.Name} a regular everyday normal dude\n You are carrying: \n {_player.Inventory.ItemList}"));
        }

    }

}
