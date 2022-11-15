using Microsoft.AspNetCore.Components.Routing;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Fat_DeliaGabriela_Lab2.Models
{
    public class Borrowing
    {
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public Member? Member { get; set; }
        public int? BookId { get; set; }
        public Book? Book { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}
