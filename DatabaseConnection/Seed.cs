using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConnection
{
    static class Seed
    {
        static void Main() {
            ct.RemoveRange(ct.Movies);
            ct.SaveChanges();
            Read(File.ReadAllLines(@".\MovieList.csv").Take(500).ToArray()); }

        public static Context ct = new Context();

        public static int ToEnum(this string value)
        {
            if (value == "Sci-Fi") value = "SciFi";
            if (value == "Film Noir") value = "FilmNoir";
            try { return (int)Enum.Parse(typeof(Genre), value, true); }
            catch { return 24; }
        }

        public static string FindGenre(string s) => String.Join(", ", s.Split('|').Select(g => ToEnum(g)));

        public static void Read(string[] movies)
        {
            for (int i = 1; i < movies.Length; i++)
            {
                var movieRaw = movies[i].Split(',').ToList();
                var movieSort = new List<string>();

                if (movieRaw[2].Contains('(')) {
                    movieSort.Add(movieRaw[2]
                        .Substring(0, movieRaw[2].IndexOf('('))
                        .Trim());

                    movieSort.Add(movieRaw[2]
                        .Substring(movieRaw[2].IndexOf('(') + 1, 4)
                        .Trim());
                }
                else {
                    movieSort.Add(movieRaw[2]);
                    movieSort.Add("0");
                }
                movieSort.Add(movieRaw[3]);
                movieSort.Add(FindGenre(movieRaw[4]));
                movieSort.Add(movieRaw[0]);

                Write(movieSort);
            }
        }

        public static void Write(List<string> movie)
        {
            if (movie[2].Length <= 3)
            {
                try
                {
                    Movie m = new Movie()
                    {
                        Title = movie[0],
                        Year = Int32.Parse(movie[1]),
                        Rating = movie[2],
                        Genre = movie[3],
                        ImdbID = Int32.Parse(movie[4])
                    };
                    ct.Add(m);
                    ct.SaveChanges();
                }
                catch { }
            }
        }
    }
}
