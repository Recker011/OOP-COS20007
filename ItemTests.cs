namespace Tests
{
    [TestFixture]
    public class TestItem
    {
        Item item;

        [SetUp]
        public void Setup()
        {
            string[] teststring = new string[] { "sword" };
            string name = "Daedric Sword";
            string description = "Weapon of the daedra";
            item = new Item(teststring, name, description);
        }



        [Test]
        public void TestItemIdentifiable()
        {
            Assert.IsTrue(item.AreYou("sword"));
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.That(item.ShortDescription, Is.EqualTo("a Daedric Sword (sword)"));
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.That(item.FullDescription, Is.EqualTo("Weapon of the daedra"));
        }
    }
}





