using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsOracle11g
{
    public partial class Form1 : Form
    {
        private OracleConnection ora = new OracleConnection("DATA SOURCE = localhost:1521/orcl; PASSWORD=hr; USER ID=hr;");

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = get_datos();
            dataGridView1.DataSource = dt;
            //OracleConnection ora = new OracleConnection("DATA SOURCE = localhost:1521/orcl; PASSWORD=hr; USER ID=hr;");
            //ora.Open();
            //MessageBox.Show("Conexión abierta.");
            //ora.Close();
        }

        [Obsolete]
        private DataTable get_datos()
        {
            DataTable dt = new DataTable();
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("spObtenerEmpleados", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
                dt.Load(comando.ExecuteReader());
                //OracleDataAdapter adaptador = new OracleDataAdapter();
                //adaptador.SelectCommand = comando;
                //adaptador.Fill(dt);
                ora.Close();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return dt;
        }
    

    [Obsolete]
    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("spInsertarEmpleado", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("EMPLOYEE_ID1", OracleType.Number).Value = 300;
            comando.Parameters.Add("FIRST_NAME1", OracleType.VarChar).Value = "Manuel";
            comando.Parameters.Add("LAST_NAME1", OracleType.VarChar).Value = "Olgin";
            comando.Parameters.Add("EMAIL1", OracleType.VarChar).Value = "alberto13711@gmail.com";
            comando.Parameters.Add("PHONE_NUMBER1", OracleType.VarChar).Value = "+51973626345";
            comando.Parameters.Add("HIRE_DATE1", OracleType.DateTime).Value = DateTime.Now;
            comando.Parameters.Add("JOB_ID1", OracleType.VarChar).Value = "AD_VP";
            comando.Parameters.Add("SALARY1", OracleType.Number).Value = 10000;
            comando.Parameters.Add("COMMISSION_PCT1", OracleType.Number).Value = "0.1";
            comando.Parameters.Add("MANAGER_ID1", OracleType.Number).Value = "207";
            comando.Parameters.Add("DEPARTMENT_ID1", OracleType.Number).Value = "10";
            comando.ExecuteNonQuery();
            ora.Close();
        }
        catch(Exception ex)
        {

        }
    }
    }
}
