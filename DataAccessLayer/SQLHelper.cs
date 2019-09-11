using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace DataAccessLayer
{
    public class SQLHelper
    {

        private string _conString;// = @"data source=.\SQLEXPRESS;initial catalog=POC;integrated security=True;";
        SqlConnection _connection;
        public SQLHelper()
        {
            //_conString = @"data source=.\SQLEXPRESS;initial catalog=POC;integrated security=True;";
            _conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new SqlConnection(_conString);
        }

         // (ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public void ManageProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                string insertQuery = @"INSERT INTO Product(Name, Description, SKU, Vendor, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) 
                                VALUES('" + product.Name + "','" + product.Description + "','" + product.SKU
                                    + "','" + product.Vendor + "','Admin','" + DateTime.Now
                                    + "','Admin','" + DateTime.Now + "')";
                SqlDataAdapter adapter = new SqlDataAdapter(insertQuery, _connection);
                DataTable products = new DataTable();
                adapter.Fill(products);
            }
            else if(product.IsDeleted)
            {
                string deleteQuery = string.Format("UPDATE P SET UpdatedBy = 'Admin', UpdatedOn = '{0}', DeletedBy = 'Admin', DeletedOn = '{0}' FROM Product P WHERE ProductID = {1}"
                                                , DateTime.Now, product.ProductId);
                SqlDataAdapter adapter = new SqlDataAdapter(deleteQuery, _connection);
                DataTable products = new DataTable();
                adapter.Fill(products);
            }
            else
            {

                string updateQuery = string.Format("UPDATE P SET Name = '{0}', Description = '{1}', SKU = '{2}', Vendor = '{3}', UpdatedBy = 'Admin', UpdatedOn = '{4}' FROM Product P WHERE ProductID = {5}"
                                                ,product.Name, product.Description, product.SKU, product.Vendor, DateTime.Now, product.ProductId);
                SqlDataAdapter adapter = new SqlDataAdapter(updateQuery, _connection);
                DataTable products = new DataTable();
                adapter.Fill(products);
            }
        }
        public List<Product> GetProducts()
        {
            string selectQuery = @"SELECT ProductID, Name, Description, SKU, Vendor, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, DeletedBy, DeletedOn FROM Product WHERE DeletedBy IS NULL";
            SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, _connection);
            DataTable products = new DataTable();
            adapter.Fill(products);
            var productList = new List<Product>();
            foreach(DataRow datarow in products.Rows)
            {
                var product = new Product();
                product.ProductId = int.Parse(datarow["ProductID"].ToString());
                product.Name = datarow["Name"].ToString();
                product.Description = datarow["Description"].ToString();
                product.SKU = datarow["SKU"].ToString();
                product.Vendor = datarow["Vendor"].ToString();

                productList.Add(product);
            }
            return productList;
            
        }

        public Product GetProduct(int id)
        {
            string selectQuery = @"SELECT ProductID, Name, Description, SKU, Vendor, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, DeletedBy, DeletedOn FROM Product WHERE ProductId = " + id;
            SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, _connection);
            DataTable products = new DataTable();
            adapter.Fill(products);
            
            var product = new Product();
            product.ProductId = int.Parse(products.Rows[0]["ProductID"].ToString());
            product.Name = products.Rows[0]["Name"].ToString();
            product.Description = products.Rows[0]["Description"].ToString();
            product.SKU = products.Rows[0]["SKU"].ToString();
            product.Vendor = products.Rows[0]["Vendor"].ToString();

            return product;

        }

    }
}
