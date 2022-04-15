using Dapper;

namespace Discount.Api.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Entites.Coupon> GetCoupon(string productName)
        {
            var connection = new Npgsql.NpgsqlConnection(_configuration.GetValue<string>("DatabaseSetting:Default"));

            var coupon = await connection.QueryFirstOrDefaultAsync<Entites.Coupon>("SELECT * FROM COUPON WHERE PRODUCTNAME=@ProductNaame", new { ProductNaame = productName });

            return coupon;
        }

        public async Task<bool> CreateCoupon(Entites.Coupon coupon)
        {
            var connection = new Npgsql.NpgsqlConnection(_configuration.GetValue<string>("DatabaseSetting:Default"));

            var affectedItems = await connection.ExecuteAsync("INSERT INTO COUPON (PRODUCTNAME, DESCRIPTION, AMOUNT) VALUES (@ProductName, @Description, @Amount)", new
            {
                ProductName = coupon.ProductName,
                Description = coupon.Description,
                Amount = coupon.Amount
            });

            if (affectedItems == 0)
                return false;
            return true;
        }

        public async Task<bool> UpdateCoupon(Entites.Coupon coupon)
        {
            var connection = new Npgsql.NpgsqlConnection(_configuration.GetValue<string>("DatabaseSetting:Default"));

            var affectedItems = await connection.ExecuteAsync("UPDATE COUPON SET PRODUCTNAME=@ProductName, DESCRIPTION=@Description, AMOUNT=@Amount where Id=@Id", new
            {
                Id = coupon.Id,
                ProductName = coupon.ProductName,
                Description = coupon.Description,
                Amount = coupon.Amount
            });

            if (affectedItems == 0)
                return false;
            return true;
        }

        public async Task<bool> DeleteProduct(string productName)
        {
            var connection = new Npgsql.NpgsqlConnection(_configuration.GetValue<string>("DatabaseSetting:Default"));

            var affectedItems = await connection.ExecuteAsync("DELETE FROM COUPON WHERE PRODUCTNAME=@ProductName", new
            {
                ProductName = productName
            });

            if (affectedItems == 0)
                return false;
            return true;
        }
    }
}
