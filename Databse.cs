using System.Data.SQLite;


class Database
{
    
        private static SQLiteConnection con = new SQLiteConnection();
        private static SQLiteCommand    cmd = new SQLiteCommand();

    
        
    
    public static void Setup()
    {
        string dir = @"URI=file:main.db";

        con = new SQLiteConnection(dir);
        con.Open();

        cmd = new SQLiteCommand(con);

        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS teams(id INTEGER PRIMARY KEY, name TEXT, leader TEXT, event INTEGER, score INTEGER)";
        cmd.ExecuteNonQuery();
        //creates a table for all of the teams
    }
    
    public static void AddTeam(Team team)
    {
        cmd.CommandText = $"INSERT INTO teams(name, leader, event, score) VALUES('{team.Name}','{team.Leader}',{team.Event},{team.Score})";
        cmd.ExecuteNonQuery();
    }
    public static List<Team> ReadTeamsByEvent(int eVent)
    {
        cmd.CommandText = $"SELECT * FROM teams WHERE event IS {eVent}";
        SQLiteDataReader rdr = cmd.ExecuteReader();
        List<Team> output = new List<Team>();
        Team temp;

        while (rdr.Read())
        {
            temp = new Team(rdr.GetString(1), rdr.GetInt32(3), rdr.GetString(2), rdr.GetInt32(4));
            output.Add(temp);
        }

        rdr.Close();

        return output;
    }
    public static Team[] ReadTeams()
    {
        ///<summary>
        ///reads all teams from the database and returns them in an array
        ///</summary>
        
        
        cmd.CommandText = "SELECT * FROM teams";
        SQLiteDataReader rdr = cmd.ExecuteReader();
        List<Team> output = new List<Team>();
        Team temp;

        while (rdr.Read())
        {
            temp = new Team(rdr.GetString(1), rdr.GetInt32(3), rdr.GetString(2), rdr.GetInt32(4));
            output.Add(temp);
        }

        rdr.Close();

        return output.ToArray();
    }
    public static void Clear()
    {
        cmd.CommandText = "DROP TABLE IF EXISTS teams";
        cmd.ExecuteNonQuery();

        Setup();
    }
    public static void DeleteTeam(int index, Team[] teamsArray)
    {
        cmd.CommandText = $"DELETE FROM teams WHERE id IS {index + 1}";
        cmd.ExecuteNonQuery();
        Console.WriteLine($"Team '{teamsArray[index].Name}' deleted.");
    }
}