namespace DTO
{
    /// <summary>
    /// The sql queries.
    /// </summary>
    public class SqlQueries
    {
        public static readonly string Constring = "Data Source=192.168.0.30;Initial Catalog=Ashish_db;User ID=User5;Password=CDev005#8;";
        public static readonly string SelectAllLoginDetails = @"SELECT * from Login_Details;";
        public static readonly string SelectWithUsername = @"SELECT UserName,Password FROM Login_Details WHERE UserName = @UserName;";
        public static readonly string SelectWithEmail = @"SELECT UserName,EMAIL,otp FROM Login_Details WHERE EMAIL = @email;";
    }
}
