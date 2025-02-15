using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ShareItems_WebApp.Models
{
    public class UserDetails
    {
        [Key]
        [MaxLength(500, ErrorMessage = "Only 500 characters are allowed")]
        public string? code {  get; set; }

        [MaxLength(50000, ErrorMessage = "Only 50000 characters are allowed")]
        public string? matter { get; set; }
        public int? secondaryPassord { get; set; }
    }
}
