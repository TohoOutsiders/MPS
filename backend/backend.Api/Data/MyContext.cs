using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Core.Entities;

namespace backend.Api.Data
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
