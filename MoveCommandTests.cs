namespace Tests
{
    [TestFixture]
    public class TestMoveCommand
    {
        MoveCommand _move;
        Player _player;

        Location _loc1, _loc2;
        Path _path1, _path2;


        [SetUp]
        public void Setup()
        {
            _move = new MoveCommand();
            _loc1 = new Location(new string[] { "Peaks" }, "a Mountain Peak", "A snowcapped mountain");
            _loc2 = new Location(new string[] { "tundra" }, "a Tundra", "A frozen tundra");
            _player = new Player("dude", "regular everyday normal dude", _loc1);
            _path1 = new Path(new string[] { "north" }, "North", "You drag your feet through the frozen ground", _loc2);
            _path2 = new Path(new string[] { "south" }, "South", "You scale a large mountain side", _loc1);

        }

        [Test]
        public void TestMove()
        {
            _loc1.Paths.Add(_path1);
            Assert.That(_move.Execute(_player, new string[] { "move", "North" }), Is.EqualTo(_path1.FullDescription));
        }

        [Test]

        public void TestLeave()
        {
            _loc1.Paths.Add(_path1);
            _loc2.Paths.Add(_path2);
            _move.Execute(_player, new string[] { "Move", "North" });
            Assert.That(_move.Execute(_player, new string[] { "leave", "south" }), Is.EqualTo(_path2.FullDescription));
        }

        [Test]
        public void TestNoPath()
        {
            _loc1.Paths.Add(_path1);
            Assert.Multiple(() =>
            {
                Assert.That(_move.Execute(_player, new string[] { "go", "south" }), Is.EqualTo("That path is blocked"));
                Assert.That(_player.Location, Is.EqualTo(_loc1));
            });
        }

        [Test]
        public void TestNoMove()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_move.Execute(_player, new string[] { "move" }), Is.EqualTo("I don't know how to move like that"));
                Assert.That(_player.Location, Is.EqualTo(_loc1));
            });
        }
    }
}