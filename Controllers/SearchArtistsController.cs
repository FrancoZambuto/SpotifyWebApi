using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Models;

namespace SpotifyAPI.Controllers
{
    [Route("search/{artists}")]
    [ApiController]
    public class SearchArtistsController : ControllerBase
    {

        public string getArtists(string artists)
        {
            string searchArtist = string.Empty;

            TokenClass _Token = new TokenClass();

            string token = _Token.getToken();

            try
            {

                string url = "https://api.spotify.com/v1/search?q=";
                var Authorization = _Token.currentToken;

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url + artists + "&type=artist&limit=15");

                webRequest.Method = "GET";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Accept = "application/json";
                webRequest.Headers.Add("Authorization:" + _Token.currentToken);

                webRequest.ContentLength = 0;

                HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                String json = "";
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(SearchArtistsClass));
                using (Stream respStr = resp.GetResponseStream())
                {
                    using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                    {
                        json = rdr.ReadToEnd();
                        rdr.Close();
                    }
                }

                searchArtist = json;

                return searchArtist;

            }
            catch (WebException ex)
            {
                return ex.Message;
            }

        }

    }
}