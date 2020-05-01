using SpotifyAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;



namespace SpotifyAPI
{
    public class TokenClass
    {

        private static string _currentToken;
        public string currentToken
        {
            get { return _currentToken; }
            set { _currentToken = value; }
        }


        public string getToken()
        {

            SpotifyTokenClass token = new SpotifyTokenClass();
            string url5 = "https://accounts.spotify.com/api/token";
            var clientid = "ac2334eae23a489b98e2add0def561cb";
            var clientsecret = "4a8e15146f2c412cb8ce5de158e77522";

            //request to get the access token
            var encode_clientid_clientsecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", clientid, clientsecret)));

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url5);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization: Basic " + encode_clientid_clientsecret);

            var request = ("grant_type=client_credentials");
            byte[] req_bytes = Encoding.ASCII.GetBytes(request);
            webRequest.ContentLength = req_bytes.Length;

            Stream strm = webRequest.GetRequestStream();
            strm.Write(req_bytes, 0, req_bytes.Length);
            strm.Close();

            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            String json = "";
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(SpotifyTokenClass));
            using (Stream respStr = resp.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                {
                    //should get back a string i can then turn to json and parse for accesstoken
                    json = rdr.ReadToEnd();
                    rdr.Close();
                }
            }
            System.Text.Encoding _encodingWeb = new System.Text.UTF8Encoding();
            MemoryStream ms = new MemoryStream(_encodingWeb.GetBytes(json));
            SpotifyTokenClass oRootObject = (SpotifyTokenClass)jsonSerializer.ReadObject(ms);

            _currentToken = oRootObject.token_type + " " + oRootObject.access_token;

            return _currentToken;

        }
    }
}
