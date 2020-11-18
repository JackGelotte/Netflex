using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConnection
{
    static class Seed
    {
        public static string[] MovieCsv = File.ReadAllLines(@".\MovieList.csv");

        static void Main()
        {
            using(Context ct = new Context())
            {

            }
        }
    }
}
