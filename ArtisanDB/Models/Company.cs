using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ArtisanDB.Models
{
    public class Company
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime incorpDate { get; set; }
        public string stockname { get; set; }
        public decimal price { get; set; }
    }

    public class ArtisanDBContext : DbContext
    {
        public DbSet <Company> Companies { get; set; }
    }
}