﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpeerkMobileApp;
using WindowsFormsApp1;

namespace SpeerkWebServices.Controllers
{
    public class MatchController : ApiController
    {
        // GET: api/Match
        public IEnumerable<string> Get()
        {
            return new string[] { "Match1", "Match2" };
        }

        // GET: api/Match/5
        public string Get(string name)
        {
            Statistics match = new Statistics();
            return match.getName1();
        }

        // POST: api/Match
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Match/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Match/5
        public void Delete(int id)
        {
        }
    }
}