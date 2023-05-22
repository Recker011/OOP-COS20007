namespace Tests
{
    public class TestCommandProcessor
    {
        MoveCommand _move;
        LookCommand _look;
        CommandProcessor _command;
        Player _player;
        Location _location;


        [SetUp]
        public void Setup()
        {
            _command = new CommandProcessor();
            _location = new Location(new string[] { "cavern" }, "a Cavern", "Dark wet humid cavern");
            _player = new Player("Dude", "Regular everyday normal dude", _location);

        }

        [Test]
        public void TestCommandProcessMove()
        {
            Assert.That(_command.Execute(_player, new string[] { "move", "North" }), Is.EqualTo("That path is blocked"));
        }

        [Test]
        public void TestCommandProcessLook()
        {
            Assert.That(_command.Execute(_player, new string[] { "look", "at", "inventory" }), Is.EqualTo(_player.FullDescription));
        }

        [Test]
        public void TestCommandProcessInvalid()
        {
            Assert.That(_command.Execute(_player, new string[] { "run" }), Is.EqualTo("I don't know how to do that"));
        }
    }
}
