global using System;


class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Burny Tourny Admin Center! Select your action.");
        Console.WriteLine("\n1: Sign up a new team;  2: Create a new lineup;  3: Enter Live Mode;  4: List teams;  5: Quit;  6: Clear Data; 7: Remove Team");
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
                Team[] teamsArr = Database.ReadTeams();
                for(int f = 0; f < teamsArr.Length; f++)
                {
                    Console.WriteLine($"{f}:    NAME: {teamsArr[f].Name}; LEADER: {teamsArr[f].Leader}; EVENT: {teamsArr[f].Event};");
                }
                break;
            case "5":
                Environment.Exit(0);
                break;
            case "6":
                Database.Clear();
                break;
            case "7":
                Team[] teamsArr2 = Database.ReadTeams();
                for(int f = 0; f < teamsArr2.Length; f++)
                {
                    Console.WriteLine($"{f}:    NAME: {teamsArr2[f].Name}; LEADER: {teamsArr2[f].Leader}; EVENT: {teamsArr2[f].Event};");
                }
                Console.Write("\nTeam to Remove ID> ");
                Database.DeleteTeam(Convert.ToInt32(Console.ReadLine()), teamsArr2);
                
                break;
        }

        Main(args);

    }
}