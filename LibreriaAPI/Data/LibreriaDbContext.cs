using LibreriaAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibreriaAPI.Data
{
    public class LibreriaDbContext:DbContext
    {
        public LibreriaDbContext(DbContextOptions dbContextOptions): base(dbContextOptions) 
        {
                
        }

        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Documento> Documenti { get; set; }

        public DbSet<Marchio> Marchi { get; set; }

        public DbSet<Stato> Stati { get; set; }

        public DbSet<Tipologia> Tipologie { get; set; }

    }
}
