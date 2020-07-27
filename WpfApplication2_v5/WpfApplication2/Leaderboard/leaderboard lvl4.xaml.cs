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
    /// Interaction logic for leaderboard_lvl4.xaml
    /// </summary>
    public partial class leaderboard_lvl4 : Page
    {
        MySqlConnection con;
        //string connectionString;

        public string Name { get; private set; }
        public string ConnectionString { get; private set; }

        public leaderboard_lvl4(string name)
        {
            InitializeComponent();
            Name = name;
            ConnectionString = ConfigurationManager.AppSettings[Name].ToString();
            //connectionString = ConfigurationManager.ConnectionStrings["Leaderboard.Properties.Settings.scoreDBConnectionString"].ConnectionString;
            showScore();
        }

        public void showScore()
        {

            con = new MySqlConnection(ConnectionString);
            con.Open();

            int x = 1;
            using (MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM leaderboard WHERE lvl = 4 ORDER BY score desc", con))
            {
                DataTable scoreTable = new DataTable();
                adp.Fill(scoreTable);
                int score = scoreTable.Rows.Count;


                for (int i = 0; i < score; i++)
                {
                    if (scoreTable.Rows[i] != null)
                    {
                        object name = Layout.FindName("lblname" + x.ToString());
                        object sco = Layout.FindName("lblscore" + x.ToString());

                        Label lbl = (Label)name;
                        Label lbls = (Label)sco;

                        lbl.Content = scoreTable.Rows[i]["name"].ToString();
                        lbls.Content = scoreTable.Rows[i]["score"].ToString();
                        x += 1;
                    }
                }
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
