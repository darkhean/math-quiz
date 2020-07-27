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
using WpfApplication2;
using WpfApplication2.Leaderboard;

namespace Maths_Quiz_App.Quiz
{
    /// <summary>
    /// Interaction logic for pgStart.xaml
    /// </summary>
    public partial class pgStart : Page
    {
        public pgStart()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //MainActivity main=new MainActivity();
            pgGameMode pg = new pgGameMode();
            this.NavigationService.Navigate(pg);
            //main.Content = new pgGameMode();
        }

        private void btnLeaderboard_Click(object sender, RoutedEventArgs e)
        {
            leaderboard_home leaderboard = new leaderboard_home();
            this.NavigationService.Navigate(leaderboard);
        }
        
    }
}
