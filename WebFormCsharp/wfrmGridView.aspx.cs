using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;


namespace WebFormCsharp
{
    public partial class wfrmGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            //{
            //    Response.Write(ci.Name + " => " + ci.DisplayName + "<br />");
            //}
            //return;
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

        protected void GridView7_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //DataFormatString="{0:c}"
            //evento se dispara al llenarse el gridview
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[8].Visible = false;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[8].Visible = false;
            }
            else
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal salary;
                //salary = Convert.ToDecimal(e.Row.Cells[4].Text);
                salary = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AnnualSalary"));
                if (salary >  30000)
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
                string Culture = e.Row.Cells[8].Text;
                string formattedString1 = string.Format(new System.Globalization.CultureInfo(Culture), "{0:c}", salary);
                e.Row.Cells[4].Text = formattedString1;
                e.Row.Cells[8].Visible = false;
                //switch (e.Row.Cells[7].Text)
                //{
                //    case "VE":
                //        string formattedString1 = string.Format(new System.Globalization.CultureInfo("es-VE"), "{0:c}", salary);
                //        e.Row.Cells[4].Text = formattedString1;
                //        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: Luis');", true);
                //        break;
                //    case "PE":
                //        string formattedString2 = string.Format(new System.Globalization.CultureInfo("es-PE"), "{0:c}", salary);
                //        e.Row.Cells[4].Text = formattedString2;//ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: Luis');", true);
                //        break;
                //    case "ES":
                //        string formattedString3 = string.Format(new System.Globalization.CultureInfo("es-ES"), "{0:c}", salary);
                //        e.Row.Cells[4].Text = formattedString3;//ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: Luis');", true);
                //        break;
                //}
            }
        }

        protected void GridView10_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Control control = e.Row.Cells[0].Controls[0];
                if (control is LinkButton)
                {
                    ((LinkButton)control).OnClientClick = "return confirm('Are you want to delete? this cannot be undone.')";
                }
            }
        }
    }
}