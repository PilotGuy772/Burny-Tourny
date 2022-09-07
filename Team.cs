class Team
{
    public string   Name;
    public int      Event;
    public string   Leader;
    
    public int?     Games;
    public int?     Score;

    public Team(string name, int eVent, string leader )
    {
        Name = name;
        Event = eVent;
        Leader = leader;
        
    }

    public Team(string name, int eVent, string leader, int score )
    {
        Name = name;
        Event = eVent;
        Leader = leader;
        Score = score;
        
    }


    public static void AddTeams()
    {
        //user flow to add teams to a database

        Console.WriteLine("Team Name:");
        string? name = Console.ReadLine();

        Console.WriteLine("Discord Name of Team Leader:");
        string? leader = Console.ReadLine();

        
        

        Console.WriteLine("What even is this team registering for? \n  1: Gambit   2: Freelance Gambit   3: 3v3 Elimination   4: Freelance 3v3 Elimination\n(more events coming soon)");
        int e = Convert.ToInt32(Console.ReadLine());
        
        Team team = new Team(name, e, leader);

        Console.WriteLine($"Object created. Name: {team.Name}, Event: {team.Event}, Leader: {team.Leader}");

        Database.AddTeam(team);

        Console.WriteLine("Add another team? y/n");
        if(Console.ReadLine() == "y") {AddTeams();} else {return;}

    }
}