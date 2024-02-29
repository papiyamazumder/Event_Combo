using EventBusiness.Services;
using EventEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventLogging;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService) 
        { 
            _userService = userService;   
        }

        [HttpPost]
        public IActionResult Create (UserModel userData)
        {
           // EventLogger eventLogger = new EventLogger();
           //  eventLogger.Info("");

            bool status = _userService.AddUser(userData);
            if (status)
            {
                return Ok("Created");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            UserModel userModel = _userService.GetUser(id);
            if (userModel == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(userModel);
            }
        }

        [HttpPut]
        public IActionResult Put()
        {
            var status = _userService.GetUsers();
            if (status == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(status);
            }
        }
    }
}
