﻿using System.ComponentModel.DataAnnotations;

namespace academica.Models {
    public class Docente {
        [Key]
        public int idDocente { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string dui { get; set; }
    }
}
