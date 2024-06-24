using DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<AlbumContext>(options=>

    options.UseSqlServer(builder.Configuration.GetConnectionString("AlbumConnection"))
);


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var Context = scope.ServiceProvider.GetService <AlbumContext>();
    Context.Database.Migrate();
}





// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



   

