using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Product>? products { get; set; }
    public DbSet<Comment>? comments { get; set; }
    public DbSet<Cart>? carts { get; set; }
}
