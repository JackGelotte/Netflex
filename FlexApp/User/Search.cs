using DatabaseConnection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace FlexApp.User
{
    static class Search
    {
        //public static List<Movie> ShowResult(string input, string option, int start, int end) { }
        public static List<Movie> ShowResult(string input, string option)
        {
            using (Context ct = new Context())
            {
                switch (option)
                {
                    case "Title": return ct.Movies.Where(m => m.Title == option).ToList();
                    case "Genre": return ct.Movies.Where(m => m.Genre == option).ToList();
                    case "Year": return ct.Movies.Where(m => m.Year == Int32.Parse(option)).ToList();
                    default: return new List<Movie>();
                }
            }           
        }

    }
}
