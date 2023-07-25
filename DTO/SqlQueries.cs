namespace DTO
{
    public class SqlQueries
    {
        public static readonly string constring = "Data Source=192.168.0.30;Initial Catalog=Ashish_db;User ID=User5;Password=CDev005#8;";
        public static readonly string selectAllLoginDetails = @"SELECT * from Login_Details;";
        public static readonly string selectWithUsername = @"SELECT UserName,Password FROM Login_Details WHERE UserName = @UserName;";
    }
}
