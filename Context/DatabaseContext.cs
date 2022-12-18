using JueriOnlineShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JueriOnlineShop.Context
{
    public class DatabaseContext :IdentityDbContext<IdentityUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions ):base(dbContextOptions){ }

        public DbSet<Cantitate> CantitateFinala { get; set; }

        public DbSet<Categorie> CategorieFinala { get; set; }

        public DbSet<Comanda> ComandaFinala { get; set; }

        public DbSet<Cos> CosFinal { get; set; }

        public DbSet<Produs> ProdusFinal { get; set; }

        public DbSet<Review> ReviewFinal { get; set; }

        public DbSet<User> UserFinal { get; set; }

        }
    }
