namespace Tests
{
    [TestFixture]
    public class TestPath
    {

        Player _player;
        Location _loc1, _loc2;
        Path _path;


        [SetUp]
        public void Setup()
        {
            _loc1 = new Location(new string[] { "peaks" }, "a Mountain Peak", "A cavernous cave");
            _loc2 = new Location(new string[] { "tundra" }, "a Tundra", "A frozen wasteland");
            _player = new Player("Dude", "Regular everyday normal dude", _loc1);
            _path = new Path(new string[] { "north" }, "North", "You drag your feet through a frozen wasteland", _loc2);

        }

        [Test]
        public void TestPathMovePlayer()
        {
            _path.MovePlayer(_player);
            Assert.That(_player.Location, Is.EqualTo(_loc2));
        }

        [Test]
        public void TestGetPath()
        {
            _loc1.Paths.Add(_path);
            Assert.That(_loc1.GetPath("North"), Is.EqualTo(_path));
        }




    }
}
