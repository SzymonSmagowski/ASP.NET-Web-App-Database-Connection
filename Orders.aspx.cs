using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeworkApp1
{
    public partial class Orders : System.Web.UI.Page
    {
        int counter = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            counter++;
            if (counter == 1)
            {


                SqlConnection con = new SqlConnection(
                    @"Data Source=; Initial Catalog=;User ID=;Password=");
                con.Open();
                string query = "SELECT * from ORDERS";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MYSERVER.SelectCommand = query;
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    int id = r.GetInt32(0);
                    DropDownList1.Items.Add(id.ToString());
                    DropDownList2.Items.Add(id.ToString());
                }
            }
        }

        protected void ModifyButton_Click(object sender, EventArgs e)
        {
            int OrderID = Int32.Parse(DropDownList1.SelectedValue);
            DateTime date = Calendar1.SelectedDate;
            string dateC = date.Date.ToString("yyyy/MM/dd");
            int gameID;
            double discount;
            double netAmount;
            double grossAmount;
            if (TextBoxGameID.Text == string.Empty)
            {
                return;
            }
            else
            {
                gameID = Int32.Parse(TextBoxGameID.Text);
            }
            if (TextBoxNetAmount.Text == string.Empty)
            {
                return;
            }
            else
            {
                //netAmount = Double.Parse(TextBoxNetAmount.Text);
            }
            if (TextBoxDiscount.Text == string.Empty)
            {
                discount = 0;
            }
            else
            {
                //discount = Double.Parse(TextBoxDiscount.Text);
            }
            if (TextBoxGrossAmount.Text == string.Empty)
            {
                return;
            }
            else
            {
                //grossAmount = Double.Parse(TextBoxGrossAmount.Text);
            }
            SqlConnection con = new SqlConnection(
               @"Data Source=; Initial Catalog=;User ID=;Password=");
            con.Open();
            string insert = "UPDATE ORDERS set ORDER_DATE = '" + dateC.ToString() + "', GAME_ID = '" +
                gameID + "',NET_AMOUNT = '" + TextBoxNetAmount.Text + "',DISCOUNT = '" + TextBoxDiscount.Text + "',GROSS_AMOUNT = '" + TextBoxGrossAmount.Text
                + "' where ORDER_ID = " + DropDownList1.SelectedValue;
            SqlCommand com = new SqlCommand(insert, con);
            com.ExecuteNonQuery();
            MYSERVER.SelectCommand = "SELECT * FROM dbo.ORDERS";
            con.Close();
            counter++;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            int orderID = Int32.Parse(DropDownList2.SelectedValue);
            string query = "delete from ORDERS where ORDER_ID = '" + orderID + "'";
            SqlConnection con = new SqlConnection(
               @"Data Source=; Initial Catalog=;User ID=;Password=");
            con.Open();

            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            MYSERVER.SelectCommand = "SELECT * FROM dbo.ORDERS";
            con.Close();
            counter++;
        }
    }
}