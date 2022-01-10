using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.SaleManagement.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        public string BrandName { get; set; }
        public string BrandDesc { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
