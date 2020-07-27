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
using MathGame_DAL.DAL.MathGame;
using MathGame_Models.Models;
using MathGame_BLL.BLL.MathGame;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button_log_in_Click(object sender, RoutedEventArgs e)
        {
            // hide this activity
            this.Hide();

            // going back to login activity
            MainWindow window = new MainWindow();
            window.Show();
        }

        private void button_signup_click(object sender, RoutedEventArgs e)
        {
            MathGameBLL mathgame = new MathGameBLL();
            // get all required information
            string firstname = textbox_firstname.Text;
            string lastname = textbox_lastname.Text;
            string email = textbox_email.Text;
            string username = textbox_username.Text;
            string password = textbox_password.Password;

            // if one of the fields was empty, notifiy user
            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname) || 
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || 
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill up all the field.", "Register", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // proceed registration
                RegisterModel model = new RegisterModel();
                model.first_name = firstname;
                model.last_name = lastname;
                model.email = email;
                model.username = username;
                model.password = password;
                mathgame.InsertUserData(model);

                MessageBox.Show("Successfully registered", "Done", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                
                // hide this activity, going back to login activity
                this.Hide();
                MainWindow window = new MainWindow();
                window.Show();
            }
        }
    }
}
