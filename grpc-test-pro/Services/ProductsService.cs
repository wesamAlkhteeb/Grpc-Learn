using grpc.test.pro.Entities;
using Grpc.Core;
using grpctestpro.Database;

namespace grpc.test.pro.Services
{
    public class ProductsService : Products.ProductsBase
    {
        private readonly DbContext db;

        
        public ProductsService(DbContext db)
        {
            this.db = db;
        }
        public async override Task<ProductResponseList> GetProducts(Page request, ServerCallContext context)
        {
            
            return await Task.FromResult(db.GetProducts(request));
        }

        public override Task<ProductResponse> GetProductById(Id request, ServerCallContext context)
        {
            ProductsEntity product = db.GetProductById(request);
            return Task.FromResult(new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
            });
        }

        public override Task<MessageStatus> AddProduct(Product request, ServerCallContext context)
        {
            db.AddProduct(request);
            return Task.FromResult(new MessageStatus
            {
                Message = "Added successfully"
            });
        }

        public override async Task<MessageStatus> DeleteProduct(Id request, ServerCallContext context)
        {
            db.DeleteProduct(request);
            return await Task.FromResult(new MessageStatus
            {
                Message = "Removed successfully"
            });
        }
        public override Task<MessageStatus> UpdateProduct(ProductUpdate request, ServerCallContext context)
        {
            db.UpdateProduct(request);
            return Task.FromResult(new MessageStatus
            {
                Message = "Update successfully"
            });
        }
    }
}
