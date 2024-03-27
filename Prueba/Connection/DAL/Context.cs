using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Connection.Dal
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context>options) : base(options){ }

        public DbSet<Asociacion> Asociacion { get; set; }
        public DbSet<Bloques> Bloque { get; set;}
        public DbSet<Caja> Caja { get; set; }
        public DbSet<DetalleCaja> DetalleCaja { get; set; }
        public DbSet<DetalleRegante> DetalleRegante { get; set; }
        public DbSet<ParametroOperacionales> ParametroOperacionales { get; set; }
        public DbSet<Parcela> Parcela { get; set; }
        public DbSet<Regantes> Regantes { get; set; }
        public DbSet<Usuarios> Usuario { get; set; }
    }
}
