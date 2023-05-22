namespace Swin_Adventure
{
    public class CommandProcessor
    {
        private readonly List<Command> _commands;


        public CommandProcessor()
        {
            _commands = new List<Command>
            {
                new LookCommand(),
                new MoveCommand()
            };
        }

        public string Execute(Player p, string[] text)
        {
            foreach (Command command in _commands)
            {
                if (command.AreYou(text[0]))
                    return command.Execute(p, text);
            }
            return "I don't know how to do that";
        }
    }
}
