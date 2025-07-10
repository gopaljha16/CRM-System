using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceCRM.Models
{
    public class SalesReport
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
