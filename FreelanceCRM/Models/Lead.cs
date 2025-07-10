using System;

namespace FreelanceCRM.Models
{
    public class Lead
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; } //  New, In Progress, Closed
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
