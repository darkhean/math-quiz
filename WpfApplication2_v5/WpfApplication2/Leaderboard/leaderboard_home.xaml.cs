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

namespace WpfApplication2.Leaderboard
{
    /// <summary>
    /// Interaction logic for leaderboard_home.xaml
    /// </summary>
    public partial class leaderboard_home : Page
    {
        public leaderboard_home()
        {
            InitializeComponent();
        }

        private void btnlvl1_Click_1(object sender, RoutedEventArgs e)
        {
            leaderboard lead = new leaderboard("GameConnstring");
            //lead.ShowDialog();
            lead.showScore();
            this.NavigationService.Navigate(lead);
        }

        private void btnlvl2_Click(object sender, RoutedEventArgs e)
        {
            leaderboard_lvl2 l2 = new leaderboard_lvl2("GameConnstring");
            //l2.ShowDialog();
            this.NavigationService.Navigate(l2);
        }

        private void btnlvl3_Click(object sender, RoutedEventArgs e)
        {
            leaderboard_lvl3 l3 = new leaderboard_lvl3("GameConnstring");
            //l3.ShowDialog();
            this.NavigationService.Navigate(l3);
        }

        private void btnlvl4_Click(object sender, RoutedEventArgs e)
        {
            leaderboard_lvl4 l4 = new leaderboard_lvl4("GameConnstring");
            //l3.ShowDialog();
            this.NavigationService.Navigate(l4);
        }

        private void btnlvl5_Click(object sender, RoutedEventArgs e)
        {
            leaderboard_lvl5 l5 = new leaderboard_lvl5("GameConnstring");
            //l3.ShowDialog();
            this.NavigationService.Navigate(l5);
        }

        private void btnlvl6_Click(object sender, RoutedEventArgs e)
        {
            leaderboard_lvl6 l6 = new leaderboard_lvl6("GameConnstring");
            //l3.ShowDialog();
            this.NavigationService.Navigate(l6);
        }
    }
}
