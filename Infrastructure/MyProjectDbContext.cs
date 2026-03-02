using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class MyProjectDbContext : DbContext
{
    public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; } = null!;
}
