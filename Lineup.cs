class Lineup
{
    public static int                        Event;
    public static string                     EventName;
    public static List<(Team one, Team two)> Versuses;

    public Lineup(int evnt, string eventName, List<(Team, Team)> versuses)
    {
        Event     = evnt;
        EventName = eventName;
        Versuses  = versuses;
    }

    public static void CreateLineup(int e, int individualGames)
    {
        Random rand                 = new Random();
        List<Team> teams            = Database.ReadTeamsByEvent(e);
        List<(Team, Team)> versuses = new List<(Team one, Team two)>();
        (Team one, Team two) matchup;
        int                  r1;
        int                  r2;
        

        while(teams.Count > 1)
        {
    
            r1 = rand.Next(0, teams.Count);
            r2 = rand.Next(0, teams.Count);
            
            if(r1 != r2)
            {
                matchup = (teams[r1], teams[r2]);
                versuses.Add(matchup);
                teams[r1].Games += 1;
                teams[r2].Games += 1;
                if(teams[r1].Games == individualGames)
                {
                    teams.RemoveAt(r1);
                }else if(teams[r2].Games == individualGames)
                {
                    teams.RemoveAt(r2);
                }
            }
            
        }
        Console.WriteLine("Heatsheet Generated.");
        foreach((Team one, Team two) m in versuses)
        {
            Console.WriteLine($"{m.one} vs {m.two}");
        }
    }
}