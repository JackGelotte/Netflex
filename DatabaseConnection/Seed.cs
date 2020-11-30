using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using IMDbApiLib;


namespace DatabaseConnection
{
    static class Seed
    {
        public const string API_KEY = "k_6f3w3pvw";
        public static List<string> ImdbPosters { get; set; } = new List<string>();




        static void Main() {
            //ct.RemoveRange(ct.Rentals, ct.Customers, ct.Logins, ct.Movies);
           // ct.SaveChanges();
            Read(File.ReadAllLines(@".\MovieList.csv").Skip(5000).Take(200).ToArray());



            /*
            var list = ct.Movies.ToList();
            string imdbId = $"";

            for (int i = 0; i < list.Count; i++)
            {
                imdbId = $"{list[0].ImdbID}";
                while ( imdbId.Length < 7) imdbId = imdbId.Insert(0, "0");

                var apiLib = new ApiLib(API_KEY);
                var data = apiLib.PostersAsync($"tt{imdbId}");
                try { ImdbPosters.Add($"{data.Result.Posters.First().Link}"); }
                catch { }

            }

            Console.ReadKey();
            */

        }

        public static Context ct = new Context();

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
                movieSort.Add(movieRaw[4].Replace('|', ' '));

                movieSort.Add(movieRaw[0]);

                string imdbId = $"{movieRaw[0]}";
                while (imdbId.Length < 7) imdbId = imdbId.Insert(0, "0");
                /*
                var apiLib = new ApiLib(API_KEY);
                var data = apiLib.PostersAsync($"tt{imdbId}");
                try { movieSort.Add($"{data.Result.Posters.Where(l=>l.Language == "en").First().Link}"); }
                catch { }
                */
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
                        ImdbID = Int32.Parse(movie[4]),
                        PosterLink = null
                    };
                    ct.Add(m);
                    ct.SaveChanges();
                }
                catch { }
            }
        }
    }
}
