using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DatabaseConnection;
using IMDbApiLib;
using IMDbApiLib.Models;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading;

namespace FlexApp
{
      //  ------------------------------------  \\
    // ------------------------------------------ \\
    // --- NOTE! -> MAX 100 API CALLS PER DAY --- \\
    // ------------------------------------------ \\
     //  --------------------------------------  \\

    static class ImdbApi
    {
        public const string API_KEY = Helper.ImdbAPI.APIKeyJack;

        public static List<PosterDataItem> ImdbPosters { get; set; } = new List<PosterDataItem>();

        public static async void ImdbTrailer(Movie movie)
        {
            ApiLib api = new ApiLib(API_KEY);
            var data = await api.TitleAsync($"{movie.ImdbID}");
            var result = data.Trailer;
        }

        public static async void ImdbPlot(Movie movie)
        {
            ApiLib api = new ApiLib(API_KEY);
            var data = await api.TitleAsync($"{movie.ImdbID}");
            var result = data.Plot;
        }

        public static async void Imdb(Movie movie)
        {
            ApiLib api = new ApiLib(API_KEY);
            var data = await api.TitleAsync($"{movie.ImdbID}");
            var result = data.Similars;
        }

    }
}
