namespace Tests
{
    [TestFixture]
    public class TestIdentifiableObject

    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestAreYou()
        {

            IdentifiableObject testid = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.Multiple(() =>
            {
                Assert.That(testid.AreYou("fred"), Is.True);
                Assert.That(testid.AreYou("bob"), Is.True);
            });

        }

        [Test]
        public void TestNotAreYou()
        {
            IdentifiableObject testid = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.Multiple(() =>
            {
                Assert.That(testid.AreYou("wilma"), Is.False);
                Assert.That(testid.AreYou("tom"), Is.False);
            });
        }

        [Test]

        public void TestCaseSensitive()
        {
            IdentifiableObject testid = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.Multiple(() => { Assert.That(testid.AreYou("bOB"), Is.True); Assert.That(testid.AreYou("FRED"), Is.True); });
        }


        [Test]

        public void TestFirstID()
        {
            IdentifiableObject testid = new IdentifiableObject(new string[] { "fred", "bob" });
            StringAssert.AreEqualIgnoringCase("fred", testid.FirstID);
        }


        [Test]

        public void FirstIDNoID()
        {
            IdentifiableObject testid = new IdentifiableObject(new string[] { });
            StringAssert.AreEqualIgnoringCase("", testid.FirstID);
        }


        [Test]

        public void TestAddID()
        {
            IdentifiableObject testid = new IdentifiableObject(new string[] { "fred", "bob" });
            testid.AddIdentifier("wilma");
            Assert.Multiple(() =>
            {
                Assert.That(testid.AreYou("fred"), Is.True);
                Assert.That(testid.AreYou("wilma"), Is.True);
                Assert.That(testid.AreYou("bob"), Is.True);
            });
        }
    }

}