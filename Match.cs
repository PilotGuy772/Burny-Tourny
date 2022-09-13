//handles making, ending, and tracking matches
//active matches hang out in the database until formally ended

class Match
{
    public int Event;
    public string? Name;
    public Team[]? Participants;
    public int[]?  ParticipantsById;

    public Match(int e, Team[] participants, string? name = "match")
    {
        Event = e;
        Name = name;
        Participants = participants;
    }   
    public Match(int e, int[] participantsByID, string? name = "match")
    {
        Event = e;
        Name = name;
        ParticipantsById = participantsByID;
    }

    public static void NewMatch()
    {
        Console.Write("Event # > ");
        int e = Convert.ToInt32(Console.ReadLine());
        
        Team[] allTeams = Database.ReadTeams().ToArray();
        //Team[] sArr = Database.ReadTeamsByEvent(e).ToArray();
        for(int f = 0; f < allTeams.Length; f++)
        {
            if(allTeams[f].Event == e)
            {
                Console.WriteLine($"{f}:    NAME: {allTeams[f].Name}; LEADER: {allTeams[f].Leader}; EVENT: {allTeams[f].Event}; SCORE: {allTeams[f].Score}");
            }
            
        }
        Console.Write("\nTeams Participating (id seperated by , no spaces) > ");

        string[] middleman = Console.ReadLine().Split(',');
        

        int[] teams = new int[middleman.Length];

        for(int i = 0; i < middleman.Length; i++)
        {
            teams[i] = Convert.ToInt32(middleman[i]);
        }

        
        Console.Write("Match Name > ");
        string name = Console.ReadLine();

        
        Database.WriteMatch(new Match(e, teams, name));
        Program.ColorPrint("Match successfully added.", ConsoleColor.Green);

    }

    public static void ListMatches()
    {
        Match[] matches = Database.PullMatches();
        Console.WriteLine("\n");

        foreach(Match m in matches)
        {
            Program.ColorPrint($"     Name: {m.Name}; Event: {m.Event}; Participating Teams:", ConsoleColor.DarkYellow);
            foreach(Team t in m.Participants)
            {
                Console.WriteLine($"          Name: {t.Name}; Leader: {t.Leader}; Score: {t.Score}");
            }
        }     
    }
}