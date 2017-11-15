using System;
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
        public string Get()
        {
            List<Statistics> stats = new Statistics().GetStatistics();
            String txtToString;
            String allStats = "";
            foreach (Statistics s in stats)
            {
               
                txtToString = String.Format("{0,-13} | {1,-20} | {2,4} : {3,-4} | {4,-20}", s.date.ToString(@"MM - dd HH:mm"),
                                                                                         s.name1,
                                                                                         s.score1.ToString(),
                                                                                         s.score2.ToString(),
                                                                                         s.name2);
                allStats = allStats = string.Join("\n", txtToString);
                
            }
            
            return allStats;
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
