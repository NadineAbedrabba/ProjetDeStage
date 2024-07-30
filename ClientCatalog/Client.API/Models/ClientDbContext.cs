using Microsoft.EntityFrameworkCore;
using Client.API.Models;
using System.Collections.Generic;

public class ClientDbContext : DbContext
{
    public ClientDbContext(DbContextOptions<ClientDbContext> options)
    : base(options)
    {
    }

    public DbSet<ClientClass> Clients { get; set; }
}
