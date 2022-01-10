using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.SaleManagement.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }
        public string Password { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
