using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyAPI.Models
{
    public class ArtistsTopTracksClass
    {
        public partial class Temperatures
        {
            public Album Album { get; set; }
        }

        public partial class Album
        {
            public string AlbumType { get; set; }

            public Artist[] Artists { get; set; }

            public ExternalUrls ExternalUrls { get; set; }

            public Uri Href { get; set; }

            public string Id { get; set; }

            public Image[] Images { get; set; }

            public string Name { get; set; }

            public DateTimeOffset ReleaseDate { get; set; }

            public string ReleaseDatePrecision { get; set; }

            public long TotalTracks { get; set; }

            public string Type { get; set; }

            public string Uri { get; set; }
        }

        public partial class Artist
        {
            public ExternalUrls ExternalUrls { get; set; }

            public Uri Href { get; set; }

            public string Id { get; set; }

            public string Name { get; set; }

            public string Type { get; set; }

            public string Uri { get; set; }
        }

        public partial class ExternalUrls
        {
            public Uri Spotify { get; set; }
        }

        public partial class Image
        {
            public long Height { get; set; }

            public Uri Url { get; set; }

            public long Width { get; set; }
        }
    }
}
