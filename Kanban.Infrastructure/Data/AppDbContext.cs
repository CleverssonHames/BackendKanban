using KanBan.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Quadro> Quadros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            connectionString:
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=kanban;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        base.OnConfiguring(optionsBuilder);
    }
}