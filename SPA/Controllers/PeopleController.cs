using SPA.Data;
using SPA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SPA.Controllers
{
    public class PeopleController : ApiController
    {
        SPAContext db = new SPAContext();
        public IEnumerable<Person> GetPeople()
        {
            return db.People;
        }
        public Person GetByID(int id)
        {
            return db.People.Find(id);
        }
        public void PostPerson(Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
        }
        public void PutPerson(int id, Person person)
        {
            if (id == person.PersonID)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void DeletePerson(int id)
        {
            var person = GetByID(id);
            db.Entry(person).State = EntityState.Deleted;
            db.SaveChanges();

        }
    }
}
