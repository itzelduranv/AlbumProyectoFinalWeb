
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Albums.Modelos;

namespace Albums.Pages
{
    public class AlbumModel : PageModel
    {
		private readonly DBAContext _context;

		public List<Album> Albums { get; set; } = new List<Album>();

		[BindProperty]
        public Album NuevoAlbum { get; set; }

		public AlbumModel(DBAContext context)
		{
			_context = context;
		}

		public void OnGet()
		{
			//traeme de la tabla de usuarios todos los registro.
			Albums = _context.Albums.ToList();
		}
		public IActionResult OnPost()
		{
			_context.Albums.Add(NuevoAlbum);
			_context.SaveChanges();
			return RedirectToPage();
		}

		public async Task<IActionResult> OnPostDeleteAsync(int id)
		{
			var album = await _context.Albums.FindAsync(id);
			if (album != null)
			{
				_context.Albums.Remove(album);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage();
		}


	}
}
