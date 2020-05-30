using PracticeNewProject.Data;
using PracticeNewProject.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace PracticeNewProject.Controllers
{
    public class PeopleApiController2 : ApiController
    {
        private NewProjectContext db = new NewProjectContext();

        public IQueryable<Person> GetPeople()
        {
            return db.People;
        }

        [ResponseType(typeof(Person))]
        public IHttpActionResult GetPerson(int id)
        {
            Person person = db.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [ResponseType(typeof(Person))]
        public IHttpActionResult PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != person.Id)
            {
                return BadRequest();
            }
            db.Entry(person).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (db.People.Count(m => m.Id == id) < 1)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Person))]
        public IHttpActionResult PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.People.Add(person);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person); ;
        }

        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(int id)
        {
            Person person = db.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            db.People.Remove(person);
            db.SaveChanges();
            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}