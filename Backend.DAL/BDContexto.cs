using Backend.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.EN;

namespace Backend.DAL
{
    public class BDContexto : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public DbSet<Nota> Notas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=EnsolversBD.mssql.somee.com; Initial Catalog=EnsolversBD; User Id=userEnsolver; Pwd=Ensolver2023");
        }
    }
}