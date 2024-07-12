using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Data;
using TakeAway.Discount.Entities;

namespace TakeAway.Discount.Context
{
    public class DiscountContext:DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DiscountContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public DbSet<Coupon> Coupons { get; set; }
    }
}
