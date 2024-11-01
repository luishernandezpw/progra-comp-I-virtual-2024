using System.ComponentModel.DataAnnotations;

namespace academica.Models {
    public class Materia {
        [Key]
        public int idMateria { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public Int16 uv { get; set; }
    }
}
