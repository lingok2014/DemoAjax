using Demo.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data
{
  public  class NhanVienDbContext : DbContext

    {
        public NhanVienDbContext() : base("NhanVienConnectionString")
        {

        }
        public DbSet<NhanVien> NhanVien { get; set; }
    }
}
