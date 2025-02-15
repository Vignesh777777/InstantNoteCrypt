using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ShareItems_WebApp.Entities
{
    [Index(nameof(code), IsUnique = true)]
    public class UserCredential
    {
        [Key]
        [MaxLength(500, ErrorMessage = "Only 500 characters are allowed")]
        public string? code { get; set; }

        [MaxLength(50000, ErrorMessage = "Only 50000 characters are allowed")]
        public string? matter { get; set; }
        public string? secondaryPassword { get; set; }
        public List<DateTime> dateTimes { get; set; }

    }
}
