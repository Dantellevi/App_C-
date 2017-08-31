using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project_DB_Remont.Model
{
  public  class EFContext:DbContext
    {
        public EFContext():base("DefaultConnection"){}

        public DbSet<Remout> remonts { get; set; }


    }
}
