using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpeerkMobileApp;
using WindowsFormsApp1;
using MatchDataAccess;

namespace SpeerkWebServices.Controllers
{
    public class MatchController : ApiController
    {
        // GET: api/Match
        public IEnumerable<Match> Get()
        {
            using (databaseSpeerkEntities entities = new databaseSpeerkEntities())
            {
                return entities.Matches.ToList();
            
            }
 
        }

        // GET: api/Match/5
        public Match Get(int id)
        {
            using (databaseSpeerkEntities entities = new databaseSpeerkEntities())
            {
                return entities.Matches.FirstOrDefault(m => m.id == id);
            }

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
