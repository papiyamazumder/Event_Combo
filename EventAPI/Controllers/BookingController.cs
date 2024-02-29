using EventBusiness.Services;
using EventEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;
       private readonly EventController _eventController;
        public BookingController(BookingService bookingService, EventController eventController) 
        {
            _bookingService = bookingService;
            _eventController = eventController;
        }

        [HttpPost]
        public IActionResult Create(EventBooking userData)
        {
            bool status = _bookingService.AddEvent(userData);
            
            if (status)
            {
                return Ok("Created");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Update(EventBooking userdata)
        {
            var status = _bookingService.UpdateEvent(userdata);
            if (status)
            {
                return Ok("Updated");  
            }
            else
            {
                return BadRequest();    
            }
        }

        [HttpDelete("DeleteId")]
        public IActionResult DeleteId(int id)
        {
            bool status = _bookingService.DeleteEvent(id);
            if (status)
            {
                return Ok("Inserted");  
            }
            else
            {
                return BadRequest();    
            }
        }
        
        [HttpDelete("DeleteName")]
        public IActionResult DeleteName(string name)
        {
            bool status = _bookingService.DeleteEvent(name);
            if (status)
            {
                return Ok("Inserted");  
            }
            else
            {
                return BadRequest();    
            }
        }
        
        [HttpDelete("DeletePending")]
        public IActionResult DeletePending()        // Pending name
        {
            bool status = _bookingService.DeleteEvent();
            if (status)
            {
                return Ok("Inserted");  
            }
            else
            {
                return BadRequest();    
            }
        }
        
        [HttpDelete("DeleteCoulmnData")]
        public IActionResult DeleteCoulmnData()        
        {
            bool status = _bookingService.RemoveDataFromNameColumn();
            if (status)
            {
                return Ok("Inserted");  
            }
            else
            {
                return BadRequest();    
            }
        }
        
        [HttpDelete("DeleteAllEvents")]
        public IActionResult DeleteAllEvents()        
        {
            bool status = _bookingService.DeleteAllEvents();
            if (status)
            {
                return Ok("Deleted All");  
            }
            else
            {
                return BadRequest();    
            }
        }

        [HttpGet("GetEventsById")]
        public IActionResult GetId(int id)
        {
            EventBooking book = _bookingService.GetEvents(id);
            if (book == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(book);
            }
        }
        
        [HttpGet("GetEvents")]          
        public IActionResult GetAll()
        {
            var book = _bookingService.GetAll();
            if (book == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(book);
            }
        }

    }
}
