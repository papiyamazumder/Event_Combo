using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;       // Data Annotation: using this we can add attributes like - primary key, range, validation
using System.ComponentModel.DataAnnotations.Schema;     // Schema : Foreign Key, Unique key, etc
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEntity           
{
    public class UserModel           // DbSet<UserMode>      
    {
        [Key]               // Primary Key 

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]       // Disable Entity Field: If we want to manually set the id, we have to add this attribute.
                                                                // Otherwise, it will automatically assign key as it is primary key if we dont write this attribute or write: [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]          // => It cant be null, it must have some value
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Range(2,10)]
        public int Phone { get; set; }

    }
}
