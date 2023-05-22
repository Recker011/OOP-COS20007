

namespace NUnit_I1
{
    [TestFixture]
    public class TestLookCommand
    {
        LookCommand _look;
        Player _player;
        Item _gem;
        Location _location;
        string _gemDesc = "A bright red gem";

        [SetUp]
        public void Setup()
        {
            _look = new LookCommand();
            _location = new Location(new string[] { "tundra" }, "Tundra", "A frozen tundra");
            _player = new Player("Dude", "A regular everyday normal dude", _location);
            _gem = new Item(new string[] { "gem" }, "Gem", _gemDesc);
            _player.Inventory.Put(_gem);
        }

        [Test]
        public void TestLookAtMe()
        {
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "inventory" }), Is.EqualTo(_player.FullDescription));
        }

        [Test]
        public void TestLookAtGem()
        {
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem" }), Is.EqualTo(_gemDesc));
        }
        [Test]
        public void TestLookAtUnk()
        {
            _player.Inventory.Take("Gem");
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem" }), Is.EqualTo("I cannot find the gem"));
        }
        [Test]
        public void TestLookAtGemInMe()
        {
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem", "in", "inventory" }), Is.EqualTo(_gemDesc));
        }
        [Test]
        public void TestLookAtGeminBag()
        {
            Bag _bag1 = new(new string[] { "bag", "Storage" }, "Blacksmith's Pack", "Tool Bag");
            _player.Inventory.Put(_bag1);
            _bag1.Inventory.Put(_gem);
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo(_gemDesc));
        }
        [Test]
        public void TestLookatGeminNoBag()
        {
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo("I cannot find the bag"));
        }
        [Test]
        public void TestLookatNoGeminBag()
        {
            Bag _bag1 = new(new string[] { "bag", "Storage" }, "Blacksmith's Pack", "Tool Bag");
            _player.Inventory.Put(_bag1);
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo("I cannot find the gem"));
        }
        [Test]
        public void TestInvalidLook()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_look.Execute(_player, new string[] { "look", "around" }), Is.EqualTo("I don't know how to look like that"));
                Assert.That(_look.Execute(_player, new string[] { "find", "at", "gem", "in", "bag" }), Is.EqualTo("Error in look input"));
                Assert.That(_look.Execute(_player, new string[] { "look", "for", "gem", "in", "bag" }), Is.EqualTo("What do you want to look at?"));
                Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem", "inside", "bag" }), Is.EqualTo("What do you want to look at?"));
            });
        }
    }


}