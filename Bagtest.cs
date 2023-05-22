namespace Tests
{
    [TestFixture]
    public class BagTest
    {
        Bag _bag1, _bag2;
        Item _sword, _apple, _shoes;

        [SetUp]
        public void Setup()
        {
            _bag1 = new Bag(new string[] { "Bag1", "secondarystorage" }, "Fanny pack", "Fanny pack");
            _bag2 = new Bag(new string[] { "Bag2", "primarystorage" }, "Blacksmith's backpack", "Backpack to suit all your smithing");
            _sword = new Item(new string[] { "sword" }, "Sword", "a sword made by a blacksmith");
            _shoes = new Item(new string[] { "shoes" }, "Sandals", "Flax sandals");
            _apple = new Item(new string[] { "apple" }, "Apple", "Fruit");
            _bag1.Inventory.Put(_apple);
            _bag2.Inventory.Put(_sword);
            _bag1.Inventory.Put(_bag2);
        }

        [Test]
        public void TestBagLocatesItems()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_bag1.Locate("apple"), Is.EqualTo(_apple));
                Assert.That(_bag1.Inventory.HasItem("apple"), Is.True);
            });
        }

        [Test]
        public void TestBagLocatesItself()
        {
            Assert.That(_bag1.Locate("Bag1"), Is.EqualTo(_bag1));
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.That(_bag1.Locate("shoes"), Is.EqualTo(null));
        }

        [Test]
        public void TestBagFullDescription()
        {
            Assert.That(_bag1.FullDescription, Is.EqualTo($"In the Fanny pack you can see: {_bag1.Inventory.ItemList}"));
        }

        [Test]
        public void TestBaginBag()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_bag1.Locate("Bag2"), Is.EqualTo(_bag2));
                Assert.That(_bag1.Locate("apple"), Is.EqualTo(_apple));
                Assert.That(_bag1.Locate("sword"), Is.EqualTo(null));
            });
        }
    }
}