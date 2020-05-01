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

namespace SpotifyAPI.Controllers
{
    [Route("AccessToken")]
    [ApiController]
    public class SpotifyServicesTokenController : ControllerBase
    {
        [HttpGet]
        public string getSpotifyToken()
        {
            TokenClass _Token = new TokenClass();
            string token = _Token.getToken();

            return token;
        }
    }
}