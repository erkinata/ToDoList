using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ToDoList.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public int MemberNumber { get; set; }
        public string Adress {  get; set; }
    }
}
