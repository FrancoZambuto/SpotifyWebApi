using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpotifyAPI.Models;

namespace SpotifyAPI.Controllers
{
    [Route("releases")]
    [ApiController]
    public class GetNewReleasesController : ControllerBase
    {


        public string getNewReleases()
        {
            string newReleases = string.Empty;
            //SpotifyNewReleasesClass releases = new SpotifyNewReleasesClass();
            TokenClass _Token = new TokenClass();

            string token = _Token.getToken();

            //try
            //{

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

            System.Text.Encoding _encodingWeb = new System.Text.UTF8Encoding();
            MemoryStream ms = new MemoryStream(_encodingWeb.GetBytes(json));
            SpotifyNewReleasesClass oRootObjetc = (SpotifyNewReleasesClass)jsonSerializer.ReadObject(ms);

           string  releases = JsonConvert.SerializeObject(json, Formatting.Indented);
            //var result = json;
            //var spotifyResponse = JsonConvert.DeserializeObject<SpotifyNewReleasesClass>(json);

            newReleases = releases;

            return newReleases;

            }
            //catch (WebException ex)
            //{
            //    return ex.Message;
            //}

        //}

    }

}
