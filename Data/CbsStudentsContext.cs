using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cbsStudents.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CbsStudents.Data
{
    public class CbsStudentsContext : DbContext
    {
        public CbsStudentsContext(DbContextOptions<CbsStudentsContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}