using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Bantu
{
    class Koneksics
    {
        public static string ConnParamPostgreSQL()
        {
            string host = "localhost";
            string database = "pbo tugas";
            string username = "postgres";
            string password = "Tartaglia";
            string port = "5432";
            string PooLing = "true";
            return $"Host={host};Database={database};Username={username};Password={password};Port={port}";
        }
        
    }
}
