using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpeerkMobileApp;
using WindowsFormsApp1;
using MatchDataAccess;
using System.Diagnostics;
using System.Data.Entity.Validation;


namespace SpeerkWebServices.Controllers
{
    public class MatchController : ApiController
    {
        // GET: api/Match

        public IEnumerable<MatchTbl> Get()
        {
            using (databaseSpeerkEntities entities = new databaseSpeerkEntities())
            {
                return entities.MatchTbls.ToList();

            
            }
            //return Make();
 
        }

        // GET: api/Match/5

        public MatchTbl Get(int id)
        {
            using (databaseSpeerkEntities entities = new databaseSpeerkEntities())
            {
                return entities.MatchTbls.FirstOrDefault(m => m.id == id);

            }

        }

        // POST: api/Match
        public void Post([FromBody] MatchTbl match)
        {
            using (databaseSpeerkEntities entities = new databaseSpeerkEntities())
            {

                entities.MatchTbls.Add(match);


                try
                {
                    entities.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Debug.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }

                var message = Request.CreateResponse(HttpStatusCode.Created, match);
            }

        }

        // PUT: api/Match/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Match/5
        public void Delete(int id)
        {
        }

        public List<Match> Make()
        {
            Match match1 = new Match() { id = 1, teamOne = "Pirma", teamTwo = "Antra", scoreOne = 2, scoreTwo = 3 };
            Match match2 = new Match() { id = 2, teamOne = "melyna", teamTwo = "zalia", scoreOne = 4, scoreTwo = 7 };
            Match match3 = new Match() { id = 3, teamOne = "Sunys", teamTwo = "Katinai", scoreOne = 5, scoreTwo = 0 };
            List<Match> list = new List<Match>();
            list.Add(match1);
            list.Add(match2);
            list.Add(match3);
            return list;
        }
    }
}
