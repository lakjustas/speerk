using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace API.Controllers
{
    public class MatchController : ApiController
    {
        speerkEntities db = new speerkEntities();
        
        // GET: api/Match
        [HttpGet]
        public IEnumerable<Match> Get()
        {
            db.Database.Connection.Open();
            return db.Matches.ToList();
        }

        // GET: api/Match/5
  
        [HttpGet, Route("api/Match/{name}")]
        public IEnumerable<Match> Get(string name)
        {
            db.Database.Connection.Open();
            List<Match> matches = db.Matches.ToList();

            var query = from a in matches
                        where a.teamOne == name || a.teamTwo == name
                        select a;
            return query;

        }

        // POST: api/Match
        [HttpPost]
        public void Post([FromBody]Match match)
        {
            using (speerkEntities entities = new speerkEntities())
            {

                db.Database.Connection.Open();

                db.Matches.Add(match);


                try
                {
                    db.SaveChanges();
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
