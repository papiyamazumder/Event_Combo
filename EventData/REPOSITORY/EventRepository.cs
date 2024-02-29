using EventData.DataContext;
using EventEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EventData.REPOSITORY
{
    public class EventRepository : IEventRepository
    {
        private readonly EventDbContext _eventDbContext;

        //Here, we created field to allocate resources of 1 class to another class (EventDbContext has connected to the tables of sql but its empty, we need to add values to it, so here we create field thr which we are adding values to it)
        //After connecting database to this project, now we want to add data in the database using code, so need to craete field in this class so that we can add values to the field which is getting added to the database.



        public EventRepository(EventDbContext eventDbContext)   // using Constructor only, we can access instance of a class in the api project         //pass class -> (Eventdbcontext) & its reference -> (_eventDbContext) to constructor to associate the EventRepository with its Eventdbcontext, so tat EventRepository class can have all the methods/prop/etc of Eventdbcontext class inside its own class.
        {
            _eventDbContext = eventDbContext;
        }

        // Dependency Injection: This constructor follows the principle of dependency injection.
        // Instead of creating an instance of EventDbContext within the EventRepository class, the instance is provided from outside, i.e. external source (Dependency folder of ASP.NET Core dependency injection container -> responsible for instantiating and providing dependencies to the classes that need them.). 
        // Injection Point: The dependency is injected into the dependent class (e.g., EventRepository) at a specific injection point, usually through a constructor parameter or a property setter.The dependent class doesn't create the dependency itself; instead, it declares that it needs the dependency to function properly.
        // This promotes loose coupling (Decoupling) between the EventRepository class and the EventDbContext class, making the EventRepository class more flexible, easier to test, and independent of specific implementations of EventDbContext.

        // Decoupling: By having dependencies provided from outside, the dependent class becomes decoupled from the specific implementation details of its dependencies.
        // In the case of the EventRepository class, it doesn't need to know how the EventDbContext instance is created or initialized; it only relies on the fact that it will receive a valid instance when needed.





        // CRUD DATABASE OPERATIONS ARE PERFORMED HERE: 
        public bool AddEvent(EventModel eventData)      // eventData -> data which we are entering in the api, which gets stored into columns/properties
        {
            // insert into EventModel Values ('','','')
            _eventDbContext.EventModel.Add(eventData);
            // execute sql statement
            _eventDbContext.SaveChanges();
            return true;
        }

        public bool UpdateEvent(EventModel eventData)
        {
            _eventDbContext.Entry(eventData).State = EntityState.Modified;
            //OR
            //_eventDbContext.Update(eventData);  
            _eventDbContext.SaveChanges();
            return true;
        }
        public bool DeleteEvent(int id) 
        {
            EventModel eventModel = _eventDbContext.EventModel.Find(id);     // select * from EventModel where id = (given ex:7)
            _eventDbContext.EventModel.Remove(eventModel);
            _eventDbContext.SaveChanges();
            return true;          
        }

        public EventModel GetEventModel(int id)
        {
            EventModel eventModel = _eventDbContext.EventModel.Find(id);     // select * from EventModel where id = (given ex:7)
            return eventModel;
        }

        public IList<EventModel> GetEvents()
        {
            IList<EventModel>list =_eventDbContext.EventModel.ToList();     // select * from EventModel
            return list;
        }

    }
}
