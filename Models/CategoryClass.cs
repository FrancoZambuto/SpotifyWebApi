using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyAPI.Models
{
    public class CategoryClass
    {

        public class Icon
        {
            public int? height { get; set; }
            public string url { get; set; }
            public int? width { get; set; }
        }

        public class Item
        {
            public string href { get; set; }
            public IList<Icon> icons { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Categories
        {
            public IList<Item> items { get; set; }
        }

        public class RootObject
        {
            public Categories categories { get; set; }
        }


    }
}
