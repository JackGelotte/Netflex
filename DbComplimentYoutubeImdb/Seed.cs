using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            // ----------------------------------------
            // --- Rensa Db om något måste göras om ---
            // ----------------------------------------
            //
            // ct.RemoveRange(ct.MovieLinks); ct.SaveChanges();

            // -----------------------------
            // --- ImdbId från CSV filen ---
            // -----------------------------
            //
            // ImdbIdFromRawCSVFile();

            // ---------------------------------
            // --- PosterLink to MovieLinkDb ---
            // ---------------------------------
            // AddPosterLink();

            // ---------------------------------
            // --- Synopsis to MovieLinkDb ---
            // ---------------------------------
            // AddSynopsis();

            // ---------------------------------
            // --- YoutubeId to MovieLinkDb ---
            // ---------------------------------
            // AddYouTubeId();

            // ---------------------------------
            // --- TrailerLink to MovieLinkDb ---
            // ---------------------------------
            // AddTrailerLink();

        }

        public static void ImdbIdFromRawCSVFile()
        {
            // Plockar ut alla filmer från csv                  ***Hur många filmer vi tar***
            //                                                              \   /
            List<string> rawCSV = File.ReadAllLines(@".\MovieList.csv").Take(500).ToList();

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

            // Lägger till Id i första index på vår nya Db
            foreach (List<string> idTable in imdbIds)
            {
                ct.MovieLinks.Add(new MovieLink() 
                { 
                    ImdbID = idTable[0] 
                });
            }

            // Sparar Databasen
            ct.SaveChanges();

        }

        public static void AddPosterLink() { }

        public static void AddSynopsis() { }

        public static void AddYouTubeId() { }

        public static void AddTrailerLink() { }

    }
}
