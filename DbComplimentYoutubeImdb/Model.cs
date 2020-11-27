using System;
using System.Collections.Generic;
using System.Text;

namespace DbComplimentYoutubeImdb
{
    public class MovieLink
    {
        public int Id { get; set; }
        public string ImdbID { get; set; }
        public string PosterLink { get; set; }
        public string Synopsis { get; set; }
        public string YoutubeId { get; set; }
        public string TrailerLink { get; set; }
    }

}
