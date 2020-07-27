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
    /// Interaction logic for pgOperators.xaml
    /// </summary>
    public partial class pgOperators : Page
    {
        private string input; //Game mode from previous page
        private string oper; //operator chosen from this page

        /*public pgOperators(string[] args)
        {
            //InitializeComponent();

            try
            {
                //Application.Run(new LiveView(args[0]));
                InitializeComponent(args[0]);
            }
            catch
            {
                InitializeComponent();
            }
        }*/

        public pgOperators()
        {
            InitializeComponent();
        }

        public pgOperators(string v)
        {
            InitializeComponent();
            input = v;

            //To test the value recieved from previous page
            //textBox1.Text = Convert.ToString(input);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            oper = "Add";
            pgDifficultyLevel pg = new pgDifficultyLevel(input + " " + oper);
            this.NavigationService.Navigate(pg);
        }

        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            oper = "Sub";
            pgDifficultyLevel pg = new pgDifficultyLevel(input + " " + oper);
            this.NavigationService.Navigate(pg);
        }

        private void btnMul_Click(object sender, RoutedEventArgs e)
        {
            oper = "Mul";
            pgDifficultyLevel pg = new pgDifficultyLevel(input + " " + oper);
            this.NavigationService.Navigate(pg);
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            oper = "Div";
            pgDifficultyLevel pg = new pgDifficultyLevel(input + " " + oper);
            this.NavigationService.Navigate(pg);
        }

    }
}
