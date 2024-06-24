using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actualizacion.Modelos
{
    public class Album
    {
        [Key]   //Indica que el siguiente campo es Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // ? indica que ese campo puede tener un valor nulo
        public string? Nombre { get; set; }
        public string? Artista { get; set; }
        public float? Precio { get; set; }
        public int? Existencia { get; set; }
    }
}
