using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Sql
    {
        public static readonly string constring = "Data Source=192.168.0.30;Initial Catalog=Ashish_db;User ID=User5;Password=CDev005#8;";
        public static readonly string selectAllLoginDetails = @"SELECT * from Login_Details;";
        public static string selectWithUsername = @"SELECT UserName,Password FROM Login_Details WHERE UserName = @UserName;";
    }
}
