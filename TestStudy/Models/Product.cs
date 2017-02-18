using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestStudy.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Category Name")]
        public int CategoryId { get; set; }
        public int Price { get; set; }
        [Column(TypeName = "Text")]
        public string Details { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
    }
}