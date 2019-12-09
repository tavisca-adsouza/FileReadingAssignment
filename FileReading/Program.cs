using System;
using System.Data;
using System.Linq;
using MySql;
using MySql.Data.MySqlClient;


namespace FileReading
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/adsouza/source/repos/FileReading/PointOfInterestCoordinatesList.txt";
            string query = "LOAD DATA LOCAL INFILE 'Files/PointOfInterestCoordinatesList.txt' INTO TABLE placedetails FIELDS TERMINATED BY '|' LINES TERMINATED BY '\n' (@col1,@col2,@col3, @col4, @col5, @col6) set RegionID=@col1,RegionName=@col2, RegionNameLong=@col3,Latitude =@col4,Longitude =@col5, SubClassification=@col6;";
            

            using (MySqlConnection conn = new MySqlConnection(@"Server=localhost;Database=sys;UID=root;Password=peterparker;Allow User Variables=True; AllowLoadLocalInfile = True;"))
            {
                
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    
                }
                using (MySqlCommand cmd = new MySqlCommand("SET GLOBAL local_infile = 1;", conn))
                {
                    //cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    //cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }



        }
    }
}
