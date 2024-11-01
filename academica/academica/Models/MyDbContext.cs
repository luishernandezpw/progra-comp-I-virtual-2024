using Microsoft.EntityFrameworkCore;
using academica.Models;
namespace academica.Models {
    public class MyDbContext : DbContext{
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Materia> Materias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Alumno>().HasKey(alumno => alumno.idAlumno);
            modelBuilder.Entity<Docente>().HasKey(docente => docente.idDocente);
            modelBuilder.Entity<Materia>().HasKey(materia => materia.idMateria);
        }
    }
}
