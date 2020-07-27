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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MathGame_DAL.DAL.MathGame;
using MathGame_Models.Models;
using MathGame_BLL.BLL.MathGame;
using Maths_Quiz_App.Quiz;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //MySQLHelper.EstablishConnection();
        }

        private void button_log_in_Click(object sender, RoutedEventArgs e)
        {
            // get username and password from the textboxes
            string username = textbox_username.Text;
            string password = textbox_password.Password;

            // handling empty fields
            if (username.Equals(""))
            {
                MessageBox.Show("Please enter your username.", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (password.Equals(""))
            {
                MessageBox.Show("Please enter your password.", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // log in the account with username and password
            MathGameBLL mathgame = new MathGameBLL();
            List<RegisterModel> userinput = mathgame.GetUserInformation(username, password);
            
            if (userinput.Count() == 1)
            {
                // insert the user information into the game
                GetCUser model = new GetCUser();
                model.user = username;
                mathgame.InsertCUserData(model);

                // hide Login window
                this.Hide();
                
                // open main activity window
                new MainActivity().Show();
            }
            else
            {
                MessageBox.Show("Incorrect username or password. \nPlease try again.", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void button_reg_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Register regwindow = new Register();
            regwindow.Show();
        }
    }
}
