using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectStudents.Models.Entities
{
    [Table("User")]
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        public string Role { get; set; } = "Student";

    }
}
