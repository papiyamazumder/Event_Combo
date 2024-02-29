using EventEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventData.REPOSITORY
{
    public interface IBookingRepo
    {
        public bool Create(EventBooking eventdata);
        public bool Update(EventBooking eventdata);
        public bool Delete(int id);
        public bool Delete(string name);
        public bool Delete();       // Pending name
        public bool RemoveDataFromNameColumn();
        public bool DeleteAllEvents();
        EventBooking Get(int UserId);
        IList<EventBooking> GetAll();
    }
}
