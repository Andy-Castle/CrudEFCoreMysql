using System.ComponentModel.DataAnnotations;

namespace CrudEFCoreMysql.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50)]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "La descripción es requerida")]
        [MaxLength(500)]
        public string Descripcion { get; set; }

        public double Precio { get; set; }

    }
}
