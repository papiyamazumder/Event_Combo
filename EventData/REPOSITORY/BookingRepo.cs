using EventData.DataContext;
using EventEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventData.REPOSITORY
{
    public class BookingRepo : IBookingRepo
    {
        private readonly EventDbContext _eventDbContext;

        private readonly BookingRepo br;
        public BookingRepo(BookingRepo eventrepo)
        {
            br = eventrepo;
        }

        public BookingRepo(EventDbContext eventDbContext) 
        {
            _eventDbContext = eventDbContext;
        }

        public bool Create(EventBooking userdata)
        {
            _eventDbContext.EventBooking.Add(userdata);
            _eventDbContext.SaveChanges();
            return true;
        }

        public bool Update(EventBooking userdata)
        {
            _eventDbContext.Update(userdata);
            return true;
        }

        public bool Delete(int id)
        {
            EventBooking userdata = _eventDbContext.EventBooking.Find(id);     // select * from EventModel where id = (given ex:7)
            _eventDbContext.EventBooking.Remove(userdata);
            _eventDbContext.SaveChanges();
            return true;
        }
        public bool Delete(string input)    //Delete all rows from the EventModel table where the Name property matches the value passed in the name parameter.
        {
            var rows = _eventDbContext.EventBooking.Where(obj => obj.Status == input).ToList();
            _eventDbContext.EventBooking.RemoveRange(rows); // Remove all items at once
            _eventDbContext.SaveChanges(); // Save changes after removing all items
            return true;
        }

        public bool Delete()   //Remove all records where the Name property is "Pending", just that we are by default directly removing Pending instead of user input.
        {
            var x = _eventDbContext.EventBooking.Where(obj => obj.EventDate == "Pending").ToList();
            _eventDbContext.EventBooking.RemoveRange(x); // Remove all items at once
            _eventDbContext.SaveChanges(); // Save changes after removing all items
            return true;
        }

        // If you want to remove an entire column from your database table, you cannot directly do it through Entity Framework within your code.
        // Removing a column involves altering the table structure, which is typically done through database management tools or scripts.
        // However, if you want to remove the data from a specific column for all rows in your table(essentially setting all values in that column to null or a default value), you can do it through Entity Framework.
        public bool RemoveDataFromNameColumn()  // Remove the data from the specified column for all rows in the table.
        {
            var rows = _eventDbContext.EventBooking.ToList();
            foreach (var item in rows)
            {
                item.Status = "hello"; // or set to a default value
            }
            _eventDbContext.SaveChanges();
            return true;
        }

        public bool DeleteAllEvents()
        {
            var allEvents = _eventDbContext.EventBooking.ToList();
            _eventDbContext.EventBooking.RemoveRange(allEvents);
            _eventDbContext.SaveChanges();
            return true;
        }


        public EventBooking Get(int id)
        {
            EventBooking userdata = _eventDbContext.EventBooking.Find(id);
            return userdata;
        }

        public IList<EventBooking> GetAll()
        {
            return _eventDbContext.EventBooking.ToList();
        }
    }
}
