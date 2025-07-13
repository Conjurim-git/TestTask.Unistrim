using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using TestTask.Unistrim.Api.Models;

namespace TestTask.Unistrim.Api.Infrustructure;

public class TransactionDbContext: DbContext
{
    public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
        : base(options)
    {
    }

    public DbSet<TransactionModel> TransactionModels { get; set; }
    public DbSet<UserModel> UserModels { get; set; }
    public DbSet<DiscountPropertiesModel> DiscountPropertiesModels { get; set; }
}