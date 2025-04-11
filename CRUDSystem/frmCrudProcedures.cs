using CRUDSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;



namespace CRUDSystem
{
    public partial class frmCrudProcedures : Form
    {
        // Obtener la cadena de conexión desde el archivo de configuración (app.config o web.config)
        string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString2"].ConnectionString;
        List<Detail> listDetails = new List<Detail>();
        static int id = 0;
        public frmCrudProcedures()
        {
            InitializeComponent();
            listarDetails();

        }

        private void listarDetails()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();
                    listDetails = new List<Detail>();
                    // Crear el comando para ejecutar el procedimiento almacenado
                    using (SqlCommand cmd = new SqlCommand("sp_details", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Ejecutar el lector de datos
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Leer y mostrar los datos
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["ID"]}, " +
                                                  $"Nombre: {reader["Fname"]}, " +
                                                  $"Apellido: {reader["Lname"]}, " +
                                                  $"Edad: {reader["Age"]}, " +
                                                  $"Dirección: {reader["Address"]}, " +
                                                  $"Fecha de Nacimiento: {reader["DOB"]}");
                                Detail detail = new Detail();
                                detail.ID = int.Parse(reader["ID"].ToString());
                                detail.Fname = reader["Fname"].ToString();
                                detail.Lname = reader["Lname"].ToString();
                                detail.Age = int.Parse(reader["Age"].ToString());
                                detail.Address = reader["Address"].ToString();
                                detail.DOB = DateTime.Parse(reader["DOB"].ToString());
                                listDetails.Add(detail);

                            }
                            this.dataGridView1.DataSource = listDetails;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Datos de ejemplo
            string fname = txtfName.Text;
            string lname = txtlName.Text;
            int age = int.Parse(txtAge.Text);
            string address = txtAddress.Text;
            DateTime dob = DateTime.Parse(dtpDOB.Text);

            InsertDetails(fname, lname, age, address, dob);
            listarDetails();
        }

        static void InsertDetails(string fname, string lname, int age, string address, DateTime dob)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString2"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_details", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros
                    cmd.Parameters.AddWithValue("@Fname", fname);
                    cmd.Parameters.AddWithValue("@Lname", lname);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@DOB", dob);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Datos guardados correctamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al guardar los datos: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dgvrow = this.dataGridView1.Rows[e.RowIndex];

                id = Convert.ToInt32(dgvrow.Cells[0].Value);

                Detail detail = listDetails.FirstOrDefault(temp => temp.ID == id);

                if (detail != null)
                {
                    this.txtfName.Text = detail.Fname;
                    this.txtlName.Text = detail.Lname;
                    this.txtAge.Text = detail.Age.ToString();
                    this.txtAddress.Text = detail.Address;
                    this.dtpDOB.Value = detail.DOB;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string fname = txtfName.Text;
            string lname = txtlName.Text;
            int age = int.Parse(txtAge.Text);
            string address = txtAddress.Text;
            DateTime dob = DateTime.Parse(dtpDOB.Text);

            UpdateDetails(fname, lname, age, address, dob);
            listarDetails();
        }

        static void UpdateDetails(string fname, string lname, int age, string address, DateTime dob)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString2"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_details", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Fname", fname);
                    cmd.Parameters.AddWithValue("@Lname", lname);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@DOB", dob);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Datos guardados correctamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al guardar los datos: " + ex.Message);
                    }
                }
            }
        }

    }
}
