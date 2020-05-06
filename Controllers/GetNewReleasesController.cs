using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpotifyAPI.Models;
using static SpotifyAPI.Models.SpotifyNewReleasesClass;

namespace SpotifyAPI.Controllers
{
    [Route("releases")]
    [ApiController]
    public class GetNewReleasesController : ControllerBase
    {


        public Albums getNewReleases()
        {
            TokenClass _Token = new TokenClass();

            string token = _Token.getToken();

            string url = "https://api.spotify.com/v1/browse/new-releases?limit=48";
            var Authorization = _Token.currentToken;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization:" + _Token.currentToken);
            webRequest.ContentLength = 0;
            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            String json = "";
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(SpotifyNewReleasesClass));
            using (Stream respStr = resp.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                {
                    json = rdr.ReadToEnd();
                    rdr.Close();
                }
            }

            var album = JsonConvert.DeserializeObject<RootObject>(json).albums;

            return album;

            }
    }

}
