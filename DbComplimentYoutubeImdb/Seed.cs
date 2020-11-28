using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using IMDbApiLib;

namespace DbComplimentYoutubeImdb
{
    class Seed
    {
        // API key 1
        public const string APIKeyJack = "k_a4fdj6tm";

        // API key 2
        public const string APIKeyRobin = "k_6f3w3pvw";

        public static ContextComplimentYoutubeImdb ct = new ContextComplimentYoutubeImdb();

        static void Main()
        {
            // 14-29 TAGNA
            int start = 14;
            int end = 29;

            // ----------------------------------------
            // --- Rensa Db om något måste göras om ---
            // ----------------------------------------
            //
            // ct.RemoveRange(ct.MovieLinks); ct.SaveChanges();

            // -----------------------------
            // --- ImdbId från CSV filen ---
            // -----------------------------
            //        ***Hur många filmer vi tar***
            //                  \   /
            // ImdbIdFromRawCSVFile(500);

            // ---------------------------------
            // --- PosterLink to MovieLinkDb ---
            // ---------------------------------
            
            #region POSTER LINKS

            // hur många vi uppdaterar åt gången -> 0(i) upp till 10

            string posterLink = "";
            for (int i = start; i < end; i++)
            {
                MovieLink entity = ct.MovieLinks.Skip(i).Take(1).First();

                // ImdbApi plockar Poster info
                var apiLib = new ApiLib(APIKeyRobin);
                var data = apiLib.PostersAsync($"tt{entity.ImdbID}");

                // Sparar poster link, sorterar efter EN
                try
                {
                    posterLink = data.Result.Posters.Where(p => p.Language == "en").First().Link;
                }
                catch 
                {
                    Console.WriteLine(Helper.DataBaseError.NoPostersFound);
                }
                // Testar så länken inte är trasig, tar nästa om trasig
                bool isBroken = true;
                int count = 1;
                while(isBroken)
                {
                    try
                    {
                        var testLink = new Uri(posterLink);
                        isBroken = false;
                    }
                    catch
                    {
                        Console.WriteLine(Helper.DataBaseError.BrokenTrailerLink);

                        posterLink = data.Result.Posters.Where(p => p.Language == "en").Skip(count).First().Link;
                        count++;
                    }
                }

                // Uppdaterar databas
                entity.PosterLink = posterLink;
                ct.MovieLinks.Update(entity);
                ct.SaveChanges();

            }

            #endregion
            

            // ---------------------------------
            // --- Synopsis to MovieLinkDb ---
            // ---------------------------------
            
            #region SYNOPSIS

            string synopsis = "";
            for (int i = start; i < end; i++)
            {
                MovieLink entity = ct.MovieLinks.Skip(i).Take(1).First();

                // ImdbApi plockar synopsis
                var apiLib = new ApiLib(APIKeyRobin);
                var data = apiLib.TitleAsync($"tt{entity.ImdbID}");

                // Sparar synopsis
                synopsis = data.Result.Plot;   

                // Uppdaterar databas
                entity.Synopsis = synopsis;
                ct.MovieLinks.Update(entity);
                ct.SaveChanges();

            }
            #endregion
            

            // ---------------------------------
            // --- YoutubeId to MovieLinkDb ---
            // ---------------------------------
            // 
            #region YOUTUBE

            string youtubeId = "";
            for (int i = start; i < end; i++)
            {
                MovieLink entity = ct.MovieLinks.Skip(i).Take(1).First();

                // ImdbApi plockar youtube info
                var apiLib = new ApiLib(APIKeyRobin);
                var data = apiLib.YouTubeTrailerAsync($"tt{entity.ImdbID}");

                // Sparar videoId
                youtubeId = data.Result.VideoId;

                // Uppdaterar databas
                entity.YoutubeId = youtubeId;
                ct.MovieLinks.Update(entity);
                ct.SaveChanges();

            }
            #endregion


        }

        public static void ImdbIdFromRawCSVFile(int recordAmt)
        {
            // Plockar ut alla filmer från csv   
            List<string> rawCSV = File.ReadAllLines(@".\MovieList.csv").Take(recordAmt).ToList();

            // Sparar endast ImdbId fältet
            // List med List<string>
            //  -> ImdbId läggs på första plats i alla listor
            //     sen lägger vi till resterande kolumner med APIn
            List<List<string>> imdbIds = new List<List<string>>();
            string temp = "";
            for (int i = 1; i < rawCSV.Count; i++)
            {
                // plockar ut id från CSV filen
                temp = rawCSV[i].Split(',').First();

                // ImdbId måste vara 7 tecken
                //  OM kortare lägger vi till 0 tills 7
                while (temp.Length < 7)
                {
                    temp = temp.Insert(0, "0");
                }

                // Samlar idn från CSV filen
                imdbIds.Add(new List<string>() { temp });

            }

            // Lägger till ImdbId som PK
            foreach (List<string> idTable in imdbIds)
            {
                try
                {
                    ct.MovieLinks.Add(new MovieLink()
                    {
                        ImdbID = idTable[0]
                    });
                }
                catch
                {
                    Console.WriteLine(Helper.DataBaseError.InvalidPrimaryKey);
                }
            }

            // Sparar Databasen
            ct.SaveChanges();

        }

    }
}
