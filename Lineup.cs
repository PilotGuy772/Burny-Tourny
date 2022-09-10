

class Lineup
{
    public static string[] Events = new string[] {"Gambit", "3v3 Elimination", "Raid Race: VoG", "Raid Race: LW", "Raid Race: DSC", "Raid Race: KF", "Raid Race: VotD", "Raid Race: GoS"};

    public static void CreateLineup_Standard1v1(int e, int individualGames)
    {
        ///<summary>
        ///Creates a randomly generated lineup based on the event and # of individual games each team should play
        ///</summary>
        
        
        
        //teams master list
        Team[]   teamsBackup= Database.ReadTeamsByEvent(e).ToArray();
        //working teams list
        List<Team>   teams  = teamsBackup.ToList();
        //rng yay
        Random       random = new Random();
        List<Team[]> versuses = new List<Team[]>();
        
        //random numbers
        int          r1;
        int          r2;
        
        Console.WriteLine("\nTeams Participating:");
        foreach(Team t in teamsBackup)
        {
            Console.WriteLine("   " + t.Name);
        }
        Console.WriteLine("   ---\n");

        if(teams.Count % 2 != 0)
        {
            throw new Exception("Even number of teams required.");
        }

        
        
        //main loop
        for(int i = 0; i <= individualGames; i++)
        {
            
            while(teams.Count > 0)
            {
                Console.WriteLine("-----");
                //initialize rng mode yeehaw
                r1 = random.Next(0, teams.Count);
                Thread.Sleep(900);
                r2 = random.Next(0, teams.Count);
                
                Console.WriteLine($"#1: {r1}, #2: {r2}");
                                
                if(r1 != r2)
                {
                    Console.WriteLine($"Match chosen: {teams[r1].Name} VS {teams[r2].Name}");
                    //add the teams selected to the versuses list
                    versuses.Add ( new Team [2] { teams[r1], teams[r2] } );
                    
                    try
                    {
                        teams.RemoveAt(r1);
                        teams.RemoveAt(r2);

                    }catch
                    {
                        break;
                    }
                    //remove those teams form the list
                    
                }
                
            }

            //reset the teams list
            teams = teamsBackup.ToList();

        }//aaaand repeat
        
        //display teams lineup

        
        SaveLineup(versuses, e);

    }

    private static void SaveLineup(List<Team[]> versuses, int e)
    {
        
        ///<summary>
        ///Saves a List of Arrays to a text file
        ///</summary>
        
        
        
        int n = 1;
        foreach(Team[] m in versuses)
        {
            Console.WriteLine($"   H{n}:  {m[1].Name} VS {m[2].Name}");
            n++;
        }
        
        Console.WriteLine("Lineup completed. Write to .txt file?");

        if(Console.ReadLine() == "yes")
        {
            string name = $@"heatsheets\heatsheet_event_{e}";
            
            
            List<string> middleman = new List<string>();
            string[] body;
            int i = 1;
            Console.Write("File Path > ");
            string file = @"" + Console.ReadLine();

            foreach(Team[] m in versuses)
            {
                middleman.Add($"H{i}   {m[1].Name} VS {m[2].Name}");
                i++;
            }

            body = middleman.ToArray();

            //foreach(string lineH in intro)
            //{
                
            //}foreach(string lineB in body)
            //{
                File.WriteAllLines(file, body);
            

        }
    }
}