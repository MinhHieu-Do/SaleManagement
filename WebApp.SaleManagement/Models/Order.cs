using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.SaleManagement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public string AdminName { get; set; }
    }
    public enum Status
    {
        PendingReview,
        PendingShipment,
        Complete
    }
}
