using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TSLAssignment.Models;

namespace TSLAssignment.Data
{
    public class TSLAssignmentContext : DbContext
    {
        public TSLAssignmentContext (DbContextOptions<TSLAssignmentContext> options)
            : base(options)
        {
        }

        public DbSet<TSLAssignment.Models.TextWrapper> TextWrapper { get; set; } = default!;
    }
}
