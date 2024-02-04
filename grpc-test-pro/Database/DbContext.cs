using grpc.test.pro;
using grpc.test.pro.Entities;
using grpc.test.pro.Exceptions;
using Grpc.Core;
using System.Collections.Generic;

namespace grpctestpro.Database
{
    public class DbContext
    {

        public List<ProductsEntity> Products { get; set; }
        public int counter = 10;
        public DbContext()
        {
            Products = new List<ProductsEntity>();
            Products.AddRange(
                [
                    new ProductsEntity
                    {
                        Id = 1,
                        Name = "p1"
                    },
                    new ProductsEntity
                    {
                        Id = 2,
                        Name = "p2"
                    },
                    new ProductsEntity
                    {
                        Id = 3,
                        Name = "p3"
                    },
                    new ProductsEntity
                    {
                        Id = 4,
                        Name = "p4"
                    },
                    new ProductsEntity
                    {
                        Id = 5,
                        Name = "p5"
                    },
                    new ProductsEntity
                    {
                        Id = 6,
                        Name = "p6"
                    },
                    new ProductsEntity
                    {
                        Id = 7,
                        Name = "p7"
                    },
                    new ProductsEntity
                    {
                        Id = 8,
                        Name = "p8"
                    },
                    new ProductsEntity
                    {
                        Id = 9,
                        Name = "p9"
                    },

                ]
            );
        }
        public void AddProduct(Product request)
        {
            Products.Add(new ProductsEntity
            {
                Name = request.Name,
                Id = counter++
            });
        }

        public void DeleteProduct(Id request)
        {
            ProductsEntity? product = Products.Where(product => product.Id == request.Id_).FirstOrDefault();
            if (product == null)
            {
                throw new NotFoundException("The product was not find.");
            }
            Products.Remove(product);
        }
        public void UpdateProduct(ProductUpdate request)
        {
            ProductsEntity? product = Products.Where((product => product.Id == request.Id.Id_)).FirstOrDefault();
            if (product == null)
            {
                throw new NotFoundException("The product was not find.");
            }
            product.Name = request.Product.Name;
        }

        public ProductResponseList GetProducts(Page request)
        {
            int page = request.Page_;
            int start = (page - 1) * 2;
            int end = start + 2;
            var response = new ProductResponseList();
            for (int i = start; i < end; i++)
            {
                response.Products.Add(new ProductResponse
                {
                    Id = Products[i].Id,
                    Name = Products[i].Name
                });
            }
            return response;
        }
        public ProductsEntity GetProductById(Id request)
        {
            ProductsEntity? product = Products.Where((product) => product.Id == request.Id_).FirstOrDefault();
            if (product == null)
            {
                throw new NotFoundException("The product was not find.");
            }
            return product;
        }
    }
}
