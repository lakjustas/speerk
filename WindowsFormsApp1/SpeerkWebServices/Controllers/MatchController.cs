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
using MatchDataAccess;
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
    }
}
