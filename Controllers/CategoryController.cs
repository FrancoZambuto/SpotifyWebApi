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
    [Route("category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public string getNewReleases()
        {
            string categories = string.Empty;

            TokenClass _Token = new TokenClass();

            string token = _Token.getToken();

            try
            {

                string url = "https://api.spotify.com/v1/browse/categories?country=US&locale=sv_us&offset=5&limit=40";
                var Authorization = _Token.currentToken;

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

                webRequest.Method = "GET";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Accept = "application/json";
                webRequest.Headers.Add("Authorization:" + _Token.currentToken);

                webRequest.ContentLength = 0;

                HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                String json = "";
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(CategoryClass));
                using (Stream respStr = resp.GetResponseStream())
                {
                    using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                    {
                        json = rdr.ReadToEnd();
                        rdr.Close();
                    }
                }

                categories = json;

                return categories;

            }
            catch (WebException ex)
            {
                return ex.Message;
            }

        }
    }
}