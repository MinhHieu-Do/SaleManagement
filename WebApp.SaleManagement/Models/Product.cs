using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.SaleManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        public int Quantity { get; set; }
        public string Image { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        public int BrandId { get; set; }
        
        public Brand Brand { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
