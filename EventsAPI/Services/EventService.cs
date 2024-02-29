using EventData.REPOSITORY;
using EventEntity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;


namespace EventBusiness.Services
{
    public class EventService
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly IEventRepository _eventRepository;     // _eventRepository is property name of type: IEventRepository class of property EventService class
        public EventService(IEventRepository eventRepository)   // eventRepository -> is an obj of EventRepository class, not IEventRepository class; bcs interface cant create object, instead obj gets created for the class in which the Interface is implemented.
                                                                // Here -> EventRepository is implementing IEventRepository, so obj of EventRepository is created which is assigned/injected to IEventRepository
        {
            _eventRepository = eventRepository;
        }

        public bool AddEvent(EventModel eventData)
        {

            bool status = _eventRepository.AddEvent(eventData);
            return status;
        }

        public bool UpdateEvent(EventModel eventData)
        {
            bool status = _eventRepository.UpdateEvent(eventData);
            return status;
        }

        public bool DeleteEvent(int id)
        {
            bool status = _eventRepository.DeleteEvent(id);
            return status;
        }

        public EventModel GetEvents(int id)
        {
            EventModel eventModel = _eventRepository.GetEventModel(id);
            return eventModel;
        }

        public IList<EventModel> GetAll()
        {
            return _eventRepository.GetEvents();
        }
    }
}
