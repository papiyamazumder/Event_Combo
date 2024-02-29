using EventData.REPOSITORY;
using EventEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusiness.Services
{
    public class BookingService
    {
        private readonly IBookingRepo _bookingRepo;
        public BookingService(IBookingRepo bookingRepo) 
        {
            _bookingRepo = bookingRepo;
        }

        public bool AddEvent(EventBooking eventData)
        {
            bool status = _bookingRepo.Create(eventData);
            return status;
        }

        public bool UpdateEvent(EventBooking eventData)
        {
            bool status = _bookingRepo.Update(eventData);
            return status;
        }

        public bool DeleteEvent(int id)
        {
            return _bookingRepo.Delete(id);
        }

        public bool DeleteEvent(string input)
        {
            return _bookingRepo.Delete(input);
        }

        public bool DeleteEvent()       // Pending name
        {
            return _bookingRepo.Delete();
        }

        public bool RemoveDataFromNameColumn()
        {
            return _bookingRepo.RemoveDataFromNameColumn();
        }
        public bool DeleteAllEvents()       
        {
            return _bookingRepo.DeleteAllEvents();
        }

        public EventBooking GetEvents(int id)
        {
            return _bookingRepo.Get(id);
        }

        public IList<EventBooking> GetAll()
        {
            return _bookingRepo.GetAll();
        }
    }
}
