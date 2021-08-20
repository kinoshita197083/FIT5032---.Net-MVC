using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FIT5032_CodeFirst_HD.Models
{
    public class StudentUnitContext: DbContext
    {
         public DbSet<Student> Students { get; set;}
         public DbSet<Unit> Unit { get; set; }
    }
}