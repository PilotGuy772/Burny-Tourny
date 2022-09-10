global using System;


class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Burny Tourny Admin Center! Select your action.");
        Console.WriteLine("\n1: Sign up a new team;  2: Create a new lineup;  3: Enter Live Mode;  4: List teams;  5: Quit;  6: Clear Data;");
        Database.Setup();
        
        switch(Console.ReadLine())
        {
            default:
                Console.WriteLine("??? What is that?? try again loser. :(\n\n");
                Main(args);
                break;
            
            case "1":
                Team.AddTeams();
                break;
            case "2":
                Console.Write("Event: ");
                int e = Convert.ToInt32(Console.ReadLine());
                Console.Write("Individual Games: ");
                int g = Convert.ToInt32(Console.ReadLine());
                Lineup.CreateLineup_Standard1v1(e, g);
                break;
            case "3":
                break;
            case "4":
                break;
            case "5":
                Environment.Exit(0);
                break;
            case "6":
                Database.Clear();
                break;
        }

        Main(args);

    }
}