using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Albums.Modelos;

namespace Albums.Data
{
    public class AlbumsContext : DbContext
    {
        public AlbumsContext (DbContextOptions<AlbumsContext> options)
            : base(options)
        {
        }

        public DbSet<Albums.Modelos.Album> Album { get; set; } = default!;
    }
}
