using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Entities;
using DataAccess.DAO;
using Repositories.Repositories.Interface;

namespace Repositories.Repositories.Implement
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product product) => ProductDAO.DeleteProduct(product);
        public void SaveProduct(Product product) => ProductDAO.SaveProduct(product);    
        public void UpdateProduct(Product product) => ProductDAO.UpdateProduct(product);
        public List<Product> GetAllProducts() => ProductDAO.GetProducts();
        public List<Category> GetAllCategories() => CategoryDAO.GetCategories();
        public Product GetProductById(int productId) => ProductDAO.FindProductById(productId);

    }
}
