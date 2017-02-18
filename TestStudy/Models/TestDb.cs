using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestStudy.Models
{
    public class TestDb : DbContext
    {
        public TestDb() : base("name=TestDb")
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductImage> productsimages { get; set; }
    }
}