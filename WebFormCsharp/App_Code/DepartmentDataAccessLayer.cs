using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebFormCsharp.App_Code
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
    public class DepartmentDataAccessLayer
    {
        public static List<Department> GetAllDepartments()
        {
            List<Department> listProducts = new List<Department>();
            string cs = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_GetDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure; 
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Department department = new Department();
                    department.DepartmentId = Convert.ToInt32(rdr["DepartmentId"]);
                    department.DepartmentName = rdr["Name"].ToString();
                    //product.Description = rdr["Description"].ToString();
                    listProducts.Add(department);
                }

            }
            return listProducts;
        }
        public static DataTable GetDataDepartments()
        {
            DataTable dt = new DataTable();
            string cs = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_GetDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dt.Load(cmd.ExecuteReader());

            }
            return dt;
        }
    }
}