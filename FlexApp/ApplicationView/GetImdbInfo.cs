using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DatabaseConnection;
using IMDbApiLib;
using IMDbApiLib.Models;

namespace FlexApp
{
      //  ------------------------------------  \\
    // ------------------------------------------ \\
    // --- NOTE! -> MAX 100 API CALLS PER DAY --- \\
    // ------------------------------------------ \\
     //  --------------------------------------  \\

    static class GetImdbInfo
    {
        public const string API_KEY = "k_6f3w3pvw"; 

        public static async Task<TrailerData> ImdbTrailer(Movie movie)
        {
            ApiLib api = new ApiLib(API_KEY);
            var data = await api.TitleAsync($"{movie.ImdbID}");
            return data.Trailer;
        }

        public static async Task<string> ImdbPlot(Movie movie)
        {
            ApiLib api = new ApiLib(API_KEY);
            var data = await api.TitleAsync($"{movie.ImdbID}");
            return data.Plot;
        }

        public static async Task<List<SimilarShort>> Imdb(Movie movie)
        {
            ApiLib api = new ApiLib(API_KEY);
            var data = await api.TitleAsync($"{movie.ImdbID}");
            return data.Similars;
        }

    }
}
