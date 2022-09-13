//this class handles most of live mode

class Live
{
    public static void Interpreter()
    {
        ///<summary>
        ///Takes commands regarding live mode
        ///</summary>

        Program.ColorPrint("Welcome to Live Mode. Use the interpreter to process commands.\n", ConsoleColor.Cyan);
    
        while(true)
        {
            switch(Console.ReadLine())
            {
                default:
                    Console.WriteLine("Command not found.");
                    break;

                case "quit":
                    Program.Main(null);
                    break;
                case "match":
                    Match.NewMatch();
                    break;
                case "list":
                    Match.ListMatches();
                    break;
            }
        }

    }
}