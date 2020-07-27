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

namespace Maths_Quiz_App.Quiz
{
    /// <summary>
    /// Interaction logic for pgGameMode.xaml
    /// </summary>
    public partial class pgGameMode : Page
    {
        private string input; //input from previous page
        private string GM; //Game mode chosen from this page

        public pgGameMode()
        {
            InitializeComponent();
        }

        
        public pgGameMode(string v)
        {
            InitializeComponent();
            input = v;

            //To test the value recieved from previous page
            //textBox1.Text = Convert.ToString(input);
        }

        private void btnNormal_Click(object sender, RoutedEventArgs e)
        {
            GM = "Nor All";
            //Nor = normal game mode which skips the operator page as it uses all operators
            pgDifficultyLevel pg = new pgDifficultyLevel(input + " " + GM);
            this.NavigationService.Navigate(pg);
        }

        private void btnOperator_Click(object sender, RoutedEventArgs e)
        {
            GM = "ope";
            //Ope = uses only 1 operator so goes to operator page to select operator
            pgOperators pg = new pgOperators(input + " " + GM);
            this.NavigationService.Navigate(pg);
        }
    }
}
