using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpotifyAPI.Models;
using static SpotifyAPI.Models.RecommendationsClass;

namespace SpotifyAPI.Controllers
{
    [Route("recommendations")]
    [ApiController]
    public class RecommendationsController : ControllerBase
    {
        public List<Track> getNewReleases()
        {
            TokenClass _Token = new TokenClass();
            string token = _Token.getToken();

            string url = "https://api.spotify.com/v1/recommendations?limit=40&market=US&seed_genres=rock%2C%20pop%2C%20indie";
            var Authorization = _Token.currentToken;
            
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization:" + _Token.currentToken);
            webRequest.ContentLength = 0;
            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            String json = "";
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(RecommendationsClass));
            using (Stream respStr = resp.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                {
                    json = rdr.ReadToEnd();
                    rdr.Close();
                }
            }

             var recommendations = JsonConvert.DeserializeObject<Recommendation>(json).tracks;

            return recommendations;

        }
    }
}