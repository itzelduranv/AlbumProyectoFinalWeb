﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Albumsss.Modelos
{
    public class Album
    {
        // Clave primaria del álbum
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Nombre del álbum
        public string Nombre { get; set; }

        // Nombre del artista o banda que creó el álbum
        public string Artista { get; set; }

        // Precio del álbum
        public float Precio { get; set; }

        // Cantidad en existencia del álbum
        // Puede ser nulo si la existencia no está especificada
        public int? Existencia { get; set; }
    }
}

