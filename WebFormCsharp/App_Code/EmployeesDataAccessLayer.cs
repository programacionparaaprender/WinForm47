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