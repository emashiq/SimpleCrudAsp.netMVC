using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestStudy.Models
{
    public class Category
    {   [Key]
        public int Id { get; set; }
        [Display(Name="Category Name")]
        [Required]
        public string Name { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        
    }
}