using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data;
using System.Windows;


namespace HomeworkApp1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            
            DateTime date = Calendar1.SelectedDate;
            if (Score.Text == string.Empty)
            {
                Score.Text = "8";
            }
            try
            {
                 Int32.Parse(GameID.Text);
            }
            catch(InvalidCastException)
            {
                return;
            }
            try
            {
                GameName.Text.ToString();
            }
            catch (InvalidCastException)
            {
                return;
            }
            
            try
            {
                 //Double.Parse(Score.Text);
            }
            catch (InvalidCastException)
            {
                return;
            }
            try
            {
                 //Double.Parse(Price.Text);
            }
            catch (InvalidCastException)
            {
                return;
            }
            if (GameID.Text == string.Empty || GameName.Text == string.Empty || Price.Text == string.Empty || Calendar1.VisibleDate==null)
            {
                return;
            }
            SqlConnection con = new SqlConnection(
                @"Data Source=; Initial Catalog=;User ID=;Password=");
            con.Open();
            if (con == null)
            {
                return;
            }

            string dateConvert = date.Date.ToString("yyyy/MM/dd");
            
               
            String query = @"INSERT INTO GAMES(GAME_ID,GAME_NAME,RELEASE_DATE,PRICE,SCORE) VALUES("+ 
                GameID.Text+",'"+ GameName.Text+"','"+dateConvert.ToString()+"',"+Price.Text+","+Score.Text+")";
            SqlCommand command = new SqlCommand(query, con);

            command.ExecuteNonQuery();
            MYSERVER.SelectCommand = "SELECT * FROM dbo.GAMES;";
            con.Close();
        }

        protected void filteringButton_Click(object sender, EventArgs e)
        {
            DateTime d2 = Calendar2.SelectedDate;
            DateTime d3 = Calendar3.SelectedDate;
            SqlConnection con = new SqlConnection(
                @"Data Source=; Initial Catalog=;User ID=;Password="); 
            con.Open();
            int minimumScore;
            if (MinimumScoreFilter.Text == string.Empty)
            {
                minimumScore = 0;
            }
            else
            {
                minimumScore = Convert.ToInt32(MinimumScoreFilter.Text);
            }
            String gameFilter;
            if (GameNameFilter.Text == string.Empty)
            {
                if (d2 > d3)
                {

                }
                else
                {
                    string dateConvert = d2.Date.ToString("yyyy/MM/dd");
                    string dateConvert2 = d3.Date.ToString("yyyy/MM/dd");
                    string query = "SELECT GAME_ID,GAME_NAME,RELEASE_DATE,SCORE,PRICE FROM dbo.GAMES " +
                        "WHERE RELEASE_DATE >= '"
                        + dateConvert + "' and RELEASE_DATE <= '" + dateConvert2 + "' and SCORE >= '"
                        + minimumScore + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MYSERVER.SelectCommand = query;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        int id = r.GetInt32(0);
                        
                        DropDownList1.Items.Add(id.ToString());
                        
                    }
                }
            }
            else
            {
                gameFilter = GameNameFilter.Text;
                if (d2 > d3)
                {

                }
                else
                {
                    string dateConvert = d2.Date.ToString("yyyy/MM/dd");
                    string dateConvert2 = d3.Date.ToString("yyyy/MM/dd");
                    string query = "SELECT GAME_ID,GAME_NAME,RELEASE_DATE,SCORE,PRICE FROM dbo.GAMES " +
                        "WHERE RELEASE_DATE >= '"
                        + dateConvert + "' and RELEASE_DATE <= '" + dateConvert2 + "' and SCORE >= '"
                        + minimumScore + "' and CHARINDEX('" + gameFilter + "', GAME_NAME) > 0 ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MYSERVER.SelectCommand = query;
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        int id = r.GetInt32(0);
                        
                        DropDownList1.Items.Add(id.ToString());
                        
                    }
                }
            }
            DropDownList1.Visible = true;
            con.Close();
        }

        protected void BuyButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(
                @"Data Source=; Initial Catalog=;User ID=;Password=");
            con.Open();
            if (con == null)
            {
                return;
            }
            int gameID = 0;
            Decimal gamePrice = 0;
            gameID = Int32.Parse(DropDownList1.SelectedValue);
            string price = "select price from GAMES where GAME_ID = " + gameID;
            SqlCommand com2 = new SqlCommand(price, con);
            SqlDataReader r = com2.ExecuteReader();
            string net;
            
            while (r.Read())
            {
                net = r["PRICE"].ToString();
                gamePrice = Convert.ToDecimal(net);
                gamePrice = Decimal.Divide(gamePrice, 100);
                gamePrice = Decimal.Round(gamePrice, 2);
                
            }
            r.Close();
            string releaseDate = "select RELEASE_DATE from GAMES where GAME_ID = " + gameID;
            SqlCommand com3 = new SqlCommand(releaseDate, con);
            DateTime rDate = DateTime.Now;
            SqlDataReader readeData = com3.ExecuteReader();
            while (readeData.Read())
            {
                string date = readeData["RELEASE_DATE"].ToString();
                rDate = Convert.ToDateTime(date);
            }
            readeData.Close();
            
            DateTime threeYearsAgo = DateTime.Today.AddYears(-3);
            DateTime gameRelease = rDate;
            double discount = 0;
            if (threeYearsAgo > gameRelease)
            {
                discount = 20;
            }
            
            decimal procent = 1.23m;
            decimal discountD;
            
            if (discount == 20)
            {
                discountD = 0.8m;
            }
            else
            {
                discountD = 1m;
            }
            decimal grossAmount = Decimal.Multiply(gamePrice, discountD);
            grossAmount = Decimal.Multiply(grossAmount, procent);
            grossAmount = Decimal.Round(grossAmount, 2);
            grossAmount = Decimal.Divide(grossAmount, 100);
            string uniqueID = "SELECT max(ORDER_ID) FROM dbo.ORDERS";
            SqlCommand command = new SqlCommand(uniqueID, con);
            int orderID = (Int32)command.ExecuteScalar();
            orderID++;
            string today = DateTime.Now.ToString("yyyy/MM/dd");

            String query = @"INSERT INTO ORDERS(ORDER_ID,ORDER_DATE,GAME_ID,NET_AMOUNT,DISCOUNT,GROSS_AMOUNT) VALUES('" +
                orderID + "','" + today + "','" + gameID + "','" + gamePrice + "','" + discount + "','"+grossAmount+"')";
            SqlCommand command2 = new SqlCommand(query, con);
            command2.ExecuteNonQuery();
            con.Close();
        }  
    }
}