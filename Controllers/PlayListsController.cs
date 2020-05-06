using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpotifyAPI.Models;
using static SpotifyAPI.Models.PlayListsClass;

namespace SpotifyAPI.Controllers
{
    [Route("playlists")]
    [ApiController]
    public class PlayListsController : ControllerBase
    {
        public Playlists getPlayLists()
        {
            TokenClass _Token = new TokenClass();

            string token = _Token.getToken();

            string url = "https://api.spotify.com/v1/browse/featured-playlists?country=US&locale=sv_US&timestamp=2020-05-01T09%3A00%3A00&limit=10";
            var Authorization = _Token.currentToken;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization:" + _Token.currentToken);
            webRequest.ContentLength = 0;
            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            String json = "";
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(PlayListsClass));
            using (Stream respStr = resp.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                {
                    json = rdr.ReadToEnd();
                    rdr.Close();
                }
            }

            var playlists = JsonConvert.DeserializeObject<PlayList>(json).playlists;

            return playlists;

        }
    }
}