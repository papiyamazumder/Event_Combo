using EventBusiness.Services;
using EventEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace EventAPI.Controllers;             // Controller: Handling HTTP Requests ([HttpGet], [HttpPost], [HttpPut], [HttpDelete]) ; Processing Data; Calling Business Logic; Returning Responses; Managing Application Flow

[Route("api/[controller]")]                 // Route -> Create API URL  //eg. localhost:5700/api/event      (event is the name of the controller)
[ApiController]                             // [] -> Class Attribute -> Support REST API
public class EventController : ControllerBase
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    private readonly EventService _eventService;
    public EventController(EventService eventService) 
    {
        _eventService = eventService;
    }

    [HttpPost]                              // [] -> Method Attribute
    public IActionResult AddEvent(EventModel eventData)         // IActionResult -> This interface will accept any return type, like- Json, Xml, obj, etc
    {
        _logger.Info("AddEvent Entered");
        var obj = new { status = "Inserted" };

        bool status = _eventService.AddEvent(eventData);

        _logger.Info("AddEvent Service method called...");
        _logger.Info("AddEvent service response: " + status);

        if (status)
        {
            _logger.Info("AddEvent method response: Ok");
            return Ok(obj);  //200 status -> "Ok"
        }
        else
        {
            _logger.Info("AddEvent method response: BadRequest");
            return BadRequest();    //400 status -> error
        }
    }

    [HttpPut]
    public IActionResult UpdateEvent(EventModel eventData)
    {
        bool status = _eventService.UpdateEvent(eventData);
        if (status)
        {
            return Ok("Inserted");  //200 status "Ok"
        }
        else
        {
            return BadRequest();    //400 error
        }
    }
    
    [HttpDelete]
    public IActionResult DeleteEvent(int id)
    {
        bool status = _eventService.DeleteEvent(id);
        if (status)
        {
            return Ok("Inserted");  //200 status "Ok"
        }
        else
        {
            return BadRequest();    //400 error
        }
    }

    [HttpGet("GetEventsById")]                      // Server Internal error will come if we dont distinguish each http verbs if repeated more than once
    public IActionResult GetEventModel(int id)
    {
        EventModel eventmodel = _eventService.GetEvents(id);
        if (eventmodel == null)
        { 
            return BadRequest();
        }
        else
        {
            return Ok(eventmodel);
        }
    }

    [HttpGet("GetEvents")]
    public IActionResult GetEvents()
    {
        var status = _eventService.GetAll();
        if (status == null)
        {
            return BadRequest();
        }
        else
        {
            return Ok(status);
        }
    }

    // If we return collection(IList/List/Array), it gets displayed as JSON type. But, if we return string/int/double/etc -> it gets displayed in that type only
}
