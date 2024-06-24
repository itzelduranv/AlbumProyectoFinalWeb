using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Albumsss.Modelos;

namespace Albumsss.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly AlbumContext _context;

        // Constructor que recibe el contexto de la base de datos mediante inyección de dependencias
        public DeleteModel(AlbumContext context)
        {
            _context = context;
        }

        // Propiedad BindProperty para el álbum que se eliminará, enlazada automáticamente con los datos del formulario
        [BindProperty]
        public Album Album { get; set; }

        // Método que maneja las solicitudes GET para la página de eliminación
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Si no se proporciona un Id, devuelve error 404
            }

            // Busca el álbum en la base de datos según el Id proporcionado
            Album = await _context.Albums.FirstOrDefaultAsync(m => m.Id == id);

            if (Album == null)
            {
                return NotFound(); // Si no se encuentra el álbum, devuelve error 404
            }

            return Page(); // Muestra la página de eliminación con los detalles del álbum
        }

        // Método que maneja las solicitudes POST para confirmar la eliminación del álbum
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Si no se proporciona un Id, devuelve error 404
            }

            // Busca el álbum en la base de datos según el Id proporcionado
            Album = await _context.Albums.FindAsync(id);

            if (Album != null)
            {
                _context.Albums.Remove(Album); // Elimina el álbum de la base de datos
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
            }

            return RedirectToPage("./Index"); // Redirecciona a la página de lista de álbumes después de la eliminación
        }
    }
}
