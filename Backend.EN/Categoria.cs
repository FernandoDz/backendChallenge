using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.EN
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Nota")]
        [Required(ErrorMessage = "La nota es obligatorio")]
        [Display(Name = "Nota")]
        public int IdNota { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Nombre { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        [ValidateNever]
        public Nota Nota { get; set; }

    }
}
