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
    /// Interaction logic for pgDifficultyLevel.xaml
    /// </summary>
    public partial class pgDifficultyLevel : Page
    {
        private string input; //Game mode and operator from previous page
        private string difficultyLevel; //difficulty level from level 1 to level 6

        public pgDifficultyLevel()
        {
            InitializeComponent();
        }

        public pgDifficultyLevel(string v)
        {
            InitializeComponent();
            input = v;

            //To test the value recieved from previous page
            //textBox1.Text = Convert.ToString(input);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService navService = NavigationService.GetNavigationService(this);
            difficultyLevel = "1";
            pgQuestions pg = new pgQuestions(input + " " + difficultyLevel);
            //pgGameMode pg = new pgGameMode();
            //this.Content = pg;
            this.NavigationService.Navigate(pg);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            difficultyLevel = "2";
            pgQuestions pg = new pgQuestions(input + " " + difficultyLevel);
            this.NavigationService.Navigate(pg);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            difficultyLevel = "3";
            pgQuestions pg = new pgQuestions(input + " " + difficultyLevel);
            this.NavigationService.Navigate(pg);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            difficultyLevel = "4";
            pgQuestions pg = new pgQuestions(input + " " + difficultyLevel);
            this.NavigationService.Navigate(pg);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            difficultyLevel = "5";
            pgQuestions pg = new pgQuestions(input + " " + difficultyLevel);
            this.NavigationService.Navigate(pg);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            difficultyLevel = "6";
            pgQuestions pg = new pgQuestions(input + " " + difficultyLevel);
            this.NavigationService.Navigate(pg);

        }
    }
}
