using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebFormCsharp.App_Code
{
    public class Employees
    {
        public int EmployeesId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }
    public class EmployeesDataAccessLayer
    {
        public static DataTable GetDataEmplyees(int DepartmentId)
        {
            DataTable dt = new DataTable();
            string cs = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployeesByDepartmentId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@DepartmentId", DepartmentId));
                con.Open();
                dt.Load(cmd.ExecuteReader());

            }
            return dt;
        }
        public static List<Employees> GetAllObjectEmplyees()
        {
            List<Employees> listProducts = new List<Employees>();
            string cs = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlParameter parameter = new SqlParameter("@DepartmentId", DepartmentId);
                //cmd.Parameters.Add(parameter);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employees department = new Employees();
                    department.EmployeesId = Convert.ToInt32(rdr["EmployeeId"]);
                    department.EmployeeName = rdr["EmployeeName"].ToString();
                    //department.DepartmentName = rdr["DepartmentName"].ToString();
                    department.Gender = rdr["Gender"].ToString();
                    department.City = rdr["City"].ToString();
                    //product.Description = rdr["Description"].ToString();
                    listProducts.Add(department);
                }

            }
            return listProducts;
        }
        public static List<Employees> PutObjectEmplyees(int EmployeesId, 
            string EmployeeName, string DepartmentName, string Gender, string City)
        {
            List<Employees> listProducts = new List<Employees>();
            string cs = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            if (DepartmentName == null)
            {
                DepartmentName = "";
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_updateEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter1 = new SqlParameter("@EmployeesId", EmployeesId);
                cmd.Parameters.Add(parameter1);
                SqlParameter parameter2 = new SqlParameter("@EmployeeName", EmployeeName);
                cmd.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@DepartmentName", DepartmentName);
                cmd.Parameters.Add(parameter3);
                SqlParameter parameter4 = new SqlParameter("@Gender", Gender);
                cmd.Parameters.Add(parameter4);
                SqlParameter parameter5 = new SqlParameter("@City", City);
                cmd.Parameters.Add(parameter5);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return listProducts;
        }
        public static void DeleteEmplyeesById(int EmployeesId)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmplyeesById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@EmployeeId", EmployeesId);
                cmd.Parameters.Add(parameter);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static List<Employees> GetAllEmplyees(int DepartmentId)
        {
            List<Employees> listProducts = new List<Employees>();
            string cs = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployeesByDepartmentId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@DepartmentId", DepartmentId);
                cmd.Parameters.Add(parameter);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employees department = new Employees();
                    department.EmployeesId = Convert.ToInt32(rdr["DepartmentId"]);
                    department.EmployeeName = rdr["EmployeeName"].ToString();
                    department.DepartmentName = rdr["DepartmentName"].ToString();
                    //product.Description = rdr["Description"].ToString();
                    listProducts.Add(department);
                }

            }
            return listProducts;
        }
    }
}