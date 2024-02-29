using EventEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventData.DataContext                     // dBCONTEXT: CONNECT THE PROJECT TO SQL SERVER AS DATA DEALS WITH SQL DATA
{
    public class EventDbContext : DbContext         // Sql statements, having all the data stored in a database, modifying it
    {
        // Connection Establishment
        // DbSet configure

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)     // It represents options that can be used to configure the behavior of the EventDbContext. These options might include things like the connection string to the database, logging options, and other settings.
        {
            // Connection Establishment
        }

        //A DbSet is typically used to interact with a specific table in the database.
        public DbSet<EventModel> EventModel{ get; set; }    //It allows you to query and manipulate the events stored in the corresponding database table using Entity Framework Core.

        public DbSet<UserModel> UserModel { get; set; }

        public DbSet<EventBooking> EventBooking { get; set; }
    }
}
