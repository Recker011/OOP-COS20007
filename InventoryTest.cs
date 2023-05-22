namespace Tests
{
    [TestFixture]

    public class TestInventory
    {
        Inventory _inventory;
        Item _sword;
        Item _armor;
        Item _apple;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
            _sword = new Item(new string[] { "sword" }, "Sword", "Blood Bane");
            _armor = new Item(new string[] { "armor" }, "Armor", "Daedric Armor from kajiit");
            _apple = new Item(new string[] { "apple" }, "Apple", "Fruit");
            _inventory.Put(_sword);
            _inventory.Put(_apple);
        }


        [Test]
        public void TestFindItem()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_inventory.HasItem("sword"), Is.True);
                Assert.That(_inventory.HasItem("apple"), Is.True);
            });
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_inventory.HasItem("armor"), Is.False);
                Assert.That(_inventory.HasItem("broadsword"), Is.False);
            });
        }

        [Test]
        public void TestFetchItem()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_inventory.Fetch("sword"), Is.EqualTo(_sword));
                Assert.That(_inventory.Fetch("apple"), Is.EqualTo(_apple));
            });
            Assert.That(_inventory.HasItem("sword"), Is.True);
        }

        [Test]
        public void TestTakeItem()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_inventory.Take("sword"), Is.EqualTo(_sword));
                Assert.That(_inventory.Take("apple"), Is.EqualTo(_apple));
            });
            Assert.That(_inventory.HasItem("sword"), Is.False);
        }

        [Test]
        public void TestItemList() => Assert.That(_inventory.ItemList, Is.EqualTo("\ta Sword (sword)\n\ta Apple (apple)\n"));

    }



}

