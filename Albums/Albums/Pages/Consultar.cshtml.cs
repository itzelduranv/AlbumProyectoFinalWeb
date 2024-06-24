using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Albums.Data;
using Albums.Modelos;

namespace Albums.Pages
{
    public class ConsultarModel : PageModel
    {
        private readonly DBAContext _context;

        // Constructor que recibe el contexto de la base de datos mediante inyección de dependencias
        public ConsultarModel(DBAContext context)
        {
            _context = context;
        }

        // Propiedades BindProperty para almacenar los criterios de búsqueda (SupportsGet = true permite el enlace desde la consulta GET)
        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; } // Nombre del álbum a buscar

        [BindProperty(SupportsGet = true)]
        public string SearchArtist { get; set; } // Nombre del artista a buscar

        public IList<Album> Albums { get; set; } // Lista de álbumes que coinciden con la búsqueda

        // Método que se ejecuta cuando se realiza una solicitud GET a la página
        public async Task OnGetAsync()
        {
            // Query inicial que representa todos los álbumes en la base de datos
            var query = _context.Albums.AsQueryable();

            // Filtra la query si se proporciona un nombre de álbum en la búsqueda
            if (!string.IsNullOrEmpty(SearchName))
            {
                query = query.Where(a => a.Nombre.Contains(SearchName)); // Filtra por nombre de álbum que contiene la cadena de búsqueda
            }

            // Filtra la query si se proporciona un nombre de artista en la búsqueda
            if (!string.IsNullOrEmpty(SearchArtist))
            {
                query = query.Where(a => a.Artista.Contains(SearchArtist)); // Filtra por nombre de artista que contiene la cadena de búsqueda
            }

            // Ejecuta la query y obtiene los resultados en una lista de álbumes
            Albums = await query.ToListAsync();
        }
    }
}
