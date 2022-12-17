using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.Entity
{
    public class ApplicationContext : IdentityDbContext<CustomUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
