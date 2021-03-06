﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static SpotifyAPI.Models.SearchArtistsClass;

namespace SpotifyAPI.Models
{
    public class SpotifyNewReleasesClass
    {

        public class ExternalUrls
        {
            public string spotify { get; set; }
        }

        public class Artist
        {
            public ExternalUrls external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class ExternalUrls2
        {
            public string spotify { get; set; }
        }

        public class Image
        {
            public int height { get; set; }
            public string url { get; set; }
            public int width { get; set; }
        }

        public class Items
        {
            public string album_type { get; set; }
            public List<Artist> artists { get; set; }
            public List<string> available_markets { get; set; }
            public ExternalUrls2 external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public List<Image> images { get; set; }
            public string name { get; set; }
            public string release_date { get; set; }
            public string release_date_precision { get; set; }
            public int total_tracks { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class Albums
        {
            //public string href { get; set; }
            public List<Items> items { get; set; }
        }

        public class RootObject
        {
            public Albums albums { get; set; }
        }


    }
}
