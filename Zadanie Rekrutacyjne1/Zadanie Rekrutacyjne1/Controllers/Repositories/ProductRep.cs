using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zadanie_Rekrutacyjne.Controllers.Repositories;
using Zadanie_Rekrutacyjne.Models;

namespace Zadanie_Rekrutacyjne.Repositories
{
    public class ProductRep : IProductRep
    {
        private List<Product> ProductList;

        public ProductRep()
        {
            ProductList = new List<Product>();
        }

        public void Add(Product product)
        {
            ProductList.Add(product);
        }

        public void Delete(int ProductID)
        {
            var product = ProductList.FirstOrDefault(p => p.ID == ProductID);
            if (product != null)
            {
                ProductList.Remove(product);
            }    
        }

        public IEnumerable<Product> GetAll()
        {
            return ProductList;
        }

        public Product GetByID(int ProductID)
        {
            return ProductList.FirstOrDefault(p => p.ID == ProductID);
        }

        public void Update(Product product)
        {
            var ExistingProduct = ProductList.FirstOrDefault(p => p.ID == product.ID);
            if(ExistingProduct != null)
            {
                ExistingProduct.Name = product.Name;
                ExistingProduct.Price = product.Price;
            }
        }
    }
}