﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpotifyAPI.Models;
using static SpotifyAPI.Models.CategoryClass;

namespace SpotifyAPI.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public Categories getNewReleases()
        {
            TokenClass _Token = new TokenClass();

            string token = _Token.getToken();

            string url = "https://api.spotify.com/v1/browse/categories?country=SE&locale=sv_SE&limit=48&offset=5";
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

            var categories = JsonConvert.DeserializeObject<RootObject>(json).categories;

            return categories;

        }
    }
}