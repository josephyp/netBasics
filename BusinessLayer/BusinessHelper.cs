using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;

namespace BusinessLayer
{
    public class BusinessLayer
    {
        SQLHelper dataLayer = new SQLHelper();
        public BusinessLayer()
        {
        }
        public void ManageProduct(Product product)
        {
            this.dataLayer.ManageProduct(product);
        }
        public List<Product> GetProducts()
        {

            return this.dataLayer.GetProducts();

        }
        public Product GetProduct(int productId)
        {

            return this.dataLayer.GetProduct(productId);

        }
    }
}
