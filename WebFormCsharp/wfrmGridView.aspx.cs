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
            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Name"), new DataColumn("Country") });
                dt.Rows.Add(1, "John Hammond", "United States");
                dt.Rows.Add(2, "Mudassar Khan", "India");
                dt.Rows.Add(3, "Suzanne Mathews", "France");
                dt.Rows.Add(4, "Robert Schidner", "Russia");
                GridView3.DataSource = dt;
                GridView3.DataBind();
            }
            else
            {
                //string chbItem = Request.QueryString["Id"].ToString();
                foreach (GridViewRow row in GridView2.Rows)
                {
                    CheckBox chkrow = (CheckBox)row.Cells[0].FindControl("chbItem");
                    chkrow.Checked = ((CheckBox)GridView2.HeaderRow.FindControl("chkTodos")).Checked;
                }
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
            //< asp:Image id = "Image1" runat = "server"
            //               CommandName = "imageCheck"
            //               CommandArgument = "<%# Container.DataItemIndex %>"
            //               AlternateText = "Image text"
            //               ImageAlign = "left"
            //               ImageUrl = "images/animacion1.png" />
            switch (e.CommandName)
            {
                
                case "Edit":
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
        protected void chkStudentStatus_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckBox)sender;
            var studentID = chk.Attributes["xyz"];


        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView2.Rows)
            {
                CheckBox chkrow = (CheckBox)row.Cells[0].FindControl("chbItem");
                chkrow.Checked = ((CheckBox)GridView2.HeaderRow.FindControl("chkTodos")).Checked;
            }
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

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridView3.Rows[rowIndex];

                //Fetch value of Name.
                string name = (row.FindControl("txtName") as TextBox).Text;

                //Fetch value of Country
                string country = row.Cells[1].Text;

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nCountry: " + country + "');", true);
            }
        }

        protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
        {

        }

        
    }
}