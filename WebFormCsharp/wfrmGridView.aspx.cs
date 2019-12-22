using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace WebFormCsharp
{
    public partial class wfrmGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs)) 
            {
                SqlCommand cmd = new SqlCommand("Select * from Books", con);
                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                this.GridView2.DataSource = dt;
                this.GridView2.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView2.Rows)
            {
                CheckBox chkrow = (CheckBox)row.Cells[0].FindControl("chbItem");
                if (chkrow.Checked)
                {
                    string id = row.Cells[1].Text;
                    string name = row.Cells[2].Text;
                }
            }
        }

        protected void chbItem_CheckedChanged(object sender, EventArgs e)
        {
            string ejemplo = sender.ToString();
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    break;
                case "chkbocCheck":
                    string cadena = e.CommandArgument.ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name');", true); 
                    break;
            }
                

            foreach (GridViewRow row in GridView2.Rows)
            {
                CheckBox chkrow = (CheckBox)row.Cells[0].FindControl("chbItem");
                if (chkrow.Checked)
                {
                    string id = row.Cells[1].Text;
                    string name = row.Cells[2].Text;
                }
            }
        }

        protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            foreach (GridViewRow row in GridView2.Rows)
            {
                CheckBox chkrow = (CheckBox)row.Cells[0].FindControl("chbItem");
                if (chkrow.Checked)
                {
                    string id = row.Cells[1].Text;
                    string name = row.Cells[2].Text;
                }
            }
        }
    }
}