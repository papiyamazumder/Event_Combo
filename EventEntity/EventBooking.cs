using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;     
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEntity
{
    //create table t1(id......)
    public class EventBooking           // Reference key in table; 
    {
        public int Id { get; set; }     // pk



        [ForeignKey("eventModel")]
        public int EventId { get; set; }    //fk
        public EventModel? eventModel { get; set; } //ref table which acts as a property here   //? => it is nullable



        [ForeignKey("usermodel")]
        public int UserId { get; set; }
        public UserModel? usermodel { get; set; }



        public string EventDate { get; set; }
        public string Status { get; set; }

    }
}
