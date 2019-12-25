using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace WebFormCsharp
{
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class ProductDataAccessLayer
    {
        public static List<Product> GetAllProducts() 
        {
            List<Product> listProducts = new List<Product>();
            string cs = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from Products", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(rdr["Id"]);
                    product.Name = rdr["Name"].ToString();
                    product.Description = rdr["Description"].ToString();
                    listProducts.Add(product);
                }
                
            }
            return listProducts;
        }
        public static DataTable GetDataProducts()
        {
            DataTable dt = new DataTable();
            string cs = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from Products", con);
                con.Open();
                dt.Load(cmd.ExecuteReader());

            }
            return dt;
        }
    }
}