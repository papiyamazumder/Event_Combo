using EventEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventData.REPOSITORY
{
    public interface IEventRepository
    {
        bool AddEvent(EventModel eventData);        // POST 
        bool UpdateEvent(EventModel eventData);     // PUT
        bool DeleteEvent(int id);                   // DELETE

        EventModel GetEventModel(int id);           // GET

        IList<EventModel> GetEvents();              // GET ILIST

    }
}
