using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.SaleManagement.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category Name is required.")]
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
