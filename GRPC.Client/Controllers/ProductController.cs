using grpc.test.pro;
using Grpc.Net.Client;
using GRPC.Client.Model;
using Microsoft.AspNetCore.Mvc;

namespace GRPC.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController:ControllerBase
    {
        private Products.ProductsClient _client;
        public ProductController()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5257");
            _client = new Products.ProductsClient(channel);
        }

        [HttpGet]
        public async Task<List<ProductModel>> GetProducts([FromQuery] int page)
        {
            List<ProductModel> response = new List<ProductModel>();
            ProductResponseList products = await _client.GetProductsAsync(new Page
            {
                Page_ = page
            });
            foreach (var item in products.Products)
            {
                response.Add(new ProductModel
                {
                    Name = item.Name,
                    Id = item.Id,
                    
                });
            }
            return response;
        }

        [HttpPost]
        public async Task<string> AddProducts([FromBody] ProductAddModel product)
        {
            MessageStatus message = await _client.AddProductAsync(new Product
            {
                Name = product.Name
            });
            return message.Message;
        }

        [HttpPut]
        public async Task<string> UpdateProducts([FromBody] ProductUpdateModel product)
        {
            MessageStatus message = await _client.UpdateProductAsync(new ProductUpdate
            {
                Id = new Id
                {
                    Id_ = product.Id
                },
                Product = new Product
                {
                    Name = product.Name
                }
            });
            return message.Message;
        }

        [HttpDelete]
        public async Task<string> DeleteProducts([FromQuery] int id)
        {
            MessageStatus message = await _client.DeleteProductAsync(new Id
            {
                Id_ = id
            });
            return message.Message;
        }

        [HttpGet("by/Id")]
        public async Task<ProductModel> GetProductById([FromQuery] int id)
        {
            ProductResponse product = await _client.GetProductByIdAsync(new Id
            {
                Id_ = id
            });
            return new ProductModel
            {
                Name = product.Name,
                Id = product.Id
            };
        }

    }
}
