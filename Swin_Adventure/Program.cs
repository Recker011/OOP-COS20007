namespace Swin_Adventure;
class Program
{
    static void Main(string[] args)
    {


        Console.WriteLine("SWINADVENTURE\nPress Enter to Start");
        Console.ReadLine();
        Console.WriteLine("Welcome to Swin Adventure!.\n");
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();

        Console.WriteLine("\nWhat is your title?");
        string description = Console.ReadLine();


        Location peaks = new Location(new string[] { "peaks" }, "a Mountain Peak", "A Gigantic mountain");
        Location fields = new Location(new string[] { "fields" }, "a Field", "A Lush green field");
        Location swamp = new(new string[] { "swamp" }, "a Swamp", "Toxic Sludge");

        Path tofields = new Path(new string[] { "north" }, "North", "You go through a gate.", fields);
        Path topeaks = new(new string[] { "south" }, "South", "You drag your heavy feet up a gruelling road", peaks);
        Path toswamp = new(new string[] { "west" }, "West", "Muddy boots", swamp);
        Player me = new Player(name, description, peaks);


        Item sword = new Item(new string[] { "sword" }, "Nord ", "A plain sword");
        Item helmet = new Item(new string[] { "helmet" }, "Helmet", "A basic helmet");


        Console.WriteLine($"Equipping {me.Name} with weapons and armor...\n");
        Console.WriteLine($"You have arrived in {peaks.Name}\n");

        me.Inventory.Put(sword);
        me.Inventory.Put(helmet);



        peaks.Paths.Add(tofields);
        fields.Paths.Add(topeaks);
        peaks.Paths.Add(toswamp);

        Bag bag = new Bag(new string[] { "satchel", "Storage" }, "Fabric satchel", "An ordinary satchel bag");
        me.Inventory.Put(bag);

        Item bread = new Item(new string[] { "bread" }, "Bread", "Warm Bread");
        bag.Inventory.Put(bread);

        Item chicken = new Item(new string[] { "chicken" }, "Chicken", "A chicken named NACHO");
        peaks.Inventory.Put(chicken);


        CommandProcessor command = new CommandProcessor();

        string input;


        while (true)
        {
            Console.Write(">>");
            input = Console.ReadLine();

            if (input.ToLower() != "quit")
            {

                Console.WriteLine(command.Execute(me, input.Split()));
            }
            else
            {
                Console.WriteLine("Exiting the game");
                break;
            }
        }
    }
}
