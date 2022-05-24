using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using phu_kien_may_tinh.Models;

namespace phu_kien_may_tinh.Data
{
    public class phu_kien_may_tinhContext : DbContext
    {
        public phu_kien_may_tinhContext (DbContextOptions<phu_kien_may_tinhContext> options)
            : base(options)
        {
        }

        public DbSet<phu_kien_may_tinh.Models.phukien> phukien { get; set; }
    }
}
