using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Albumsss.Modelos;

namespace Albumsss.Pages
{
    public class EditarModel : PageModel
    {
        private readonly AlbumContext _context;

        // Constructor que recibe el contexto de base de datos mediante inyección de dependencias
        public EditarModel(AlbumContext context)
        {
            _context = context;
        }

        // Propiedad BindProperty para el álbum que se editará, enlazada automáticamente con los datos del formulario
        [BindProperty]
        public Album Album { get; set; }

        // Método que maneja las solicitudes GET para cargar los detalles del álbum a editar
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Si no se proporciona un Id, devuelve error 404
            }

            // Busca el álbum en la base de datos según el Id proporcionado
            Album = await _context.Albums.FindAsync(id);

            if (Album == null)
            {
                return NotFound(); // Si no se encuentra el álbum, devuelve error 404
            }

            return Page(); // Muestra la página de edición con los detalles del álbum
        }

        // Método que maneja las solicitudes POST para guardar los cambios realizados en el álbum
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Si el modelo no es válido, vuelve a mostrar la página de edición con errores
            }

            _context.Attach(Album).State = EntityState.Modified; // Marca el álbum como modificado en el contexto

            try
            {
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(Album.Id))
                {
                    return NotFound(); // Si el álbum no existe, devuelve error 404
                }
                else
                {
                    throw; // Captura excepciones de concurrencia y las lanza para manejo superior
                }
            }

            return RedirectToPage("./Index"); // Redirige a la página principal de álbumes después de actualizar
        }

        // Método auxiliar para verificar la existencia de un álbum por su Id
        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.Id == id); // Devuelve true si hay algún álbum con el Id dado
        }
    }
}

