class Lineup
{
    public static int                        Event;
    public static string                     EventName;
    public static List<(Team one, Team two)> Versuses;

    public Lineup(int evnt, string eventName, List<(Team, Team)> versuses)
    {
        Event = evnt;
        EventName = eventName;
        Versuses = versuses;
    }

    public static void CreateLineup(int e, int individualGames)
    {
        List<Team> teams = Database.ReadTeamsByEvent(e);

        while(teams.Count > 1)
        {
            
        }
    }
}