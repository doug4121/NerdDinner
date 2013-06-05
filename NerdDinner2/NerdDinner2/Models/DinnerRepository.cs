using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner2.Models
{
    public class DinnerRepository
    {
        private NerdDinnerDataContext db = new NerdDinnerDataContext();

        // queries
        public IQueryable<Dinner> FindAllDinners()
        {
            return db.Dinners;
        }

        public IQueryable<Dinner> FindUpcomingDinners()
        {
            return from dinner in db.Dinners
                   where dinner.EventDate > DateTime.Now
                   orderby dinner.EventDate
                   select dinner;
        }

        public Dinner GetDinner(int id)
        {
            return db.Dinners.SingleOrDefault(d => d.DinnerID == id);
        }

        // insert
        public void Add(Dinner dinner)
        {
            // inserts the dinner into db
            db.Dinners.InsertOnSubmit(dinner);
        }

        // delete
        public void Delete(Dinner dinner)
        {
            // delete from rsvps
            db.RSVPs.DeleteAllOnSubmit(dinner.RSVPs);
            
            // delete from dinners
            db.Dinners.DeleteOnSubmit(dinner);
        }

        // Persistence
        public void Save()
        {
            // saves
            db.SubmitChanges();
        }
}
}