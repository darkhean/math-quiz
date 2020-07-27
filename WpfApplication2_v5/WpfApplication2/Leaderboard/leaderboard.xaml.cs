using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Maths_Quiz_App.Quiz;

namespace WpfApplication2.Leaderboard
{
    /// <summary>
    /// Interaction logic for leaderboard.xaml
    /// </summary>
    public partial class leaderboard : Page
    {
        MySqlConnection con;
        //string connectionString;

        public string Name { get; private set; }
        public string ConnectionString { get; private set; }

        public leaderboard(string name)
        {
            InitializeComponent();
            Name = name;
            ConnectionString = ConfigurationManager.AppSettings[Name].ToString();
            //connectionString = ConfigurationManager.ConnectionStrings["Leaderboard.Properties.Settings.scoreDBConnectionString"].ConnectionString;
            showScore();
        }

        //public virtual System.Web.UI.Control FindControl(string id);

        public void showScore()
        {

            con = new MySqlConnection(ConnectionString);
            con.Open();

            int x = 1;
            using (MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM leaderboard WHERE lvl = 1 ORDER BY score desc", con))
            {
                DataTable scoreTable = new DataTable();
                adp.Fill(scoreTable);
                int score=scoreTable.Rows.Count;


                for (int i = 0; i < score; i++)
                {
                    if (scoreTable.Rows[i] != null)
                    {
                        object name = Layout.FindName("lblname" + x.ToString());
                        object sco = Layout.FindName("lblscore" + x.ToString());

                        Label lbl = (Label)name;
                        Label lbls = (Label)sco;
                        //lbl.Name = "lblname" + x.ToString();
                        //Label lbl.Name= new Label();

                        //Control myControl1 = FindControl("TextBox2");

                        //lbls.Name = "lblscore" + x.ToString();

                        lbl.Content = scoreTable.Rows[i]["name"].ToString();
                        lbls.Content = scoreTable.Rows[i]["score"].ToString();
                        //lblname1.Content=scoreTable.Rows[i]["name"].ToString();
                        x += 1;
                        //Label laballba =("");
                    }
                }
                //lblname2.Content = scoreTable.Rows[1]["name"].ToString();
                //lblscore2.Content = scoreTable.Rows[1]["score"].ToString().DefaultIfEmpty();
                //lblname3.Content = scoreTable.Rows[2]["name"].ToString().DefaultIfEmpty();
                //lblscore3.Content = scoreTable.Rows[2]["score"].ToString().DefaultIfEmpty();
                //lblname4.Content = scoreTable.Rows[3]["name"].ToString().DefaultIfEmpty();
                //lblscore4.Content = scoreTable.Rows[3]["score"].ToString().DefaultIfEmpty();
                //lblname5.Content = scoreTable.Rows[4]["name"].ToString().DefaultIfEmpty();
                //lblscore5.Content = scoreTable.Rows[4]["score"].ToString().DefaultIfEmpty();
            }



            con.Close();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            pgStart pg = new pgStart();
            this.NavigationService.Navigate(pg);
        }
    }
}
