using System;
using System.ComponentModel.DataAnnotations;

namespace FreelanceCRM.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string Company { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
