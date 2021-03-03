using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace gestion_des_étudiants.Models
{
    public class EtudiantDbContext : DbContext
    {
        public EtudiantDbContext(DbContextOptions<EtudiantDbContext> options):base(options)
        {

        }
        public DbSet<Etudiant> Etudiantt { get; set; }
    }
    
}
