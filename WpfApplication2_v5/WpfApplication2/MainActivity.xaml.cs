using Maths_Quiz_App.Quiz;
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
using WpfApplication2.Leaderboard;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainActivity : Window
    {
        public MainActivity()
        {
            InitializeComponent();

            pgStart pg = new pgStart();
            Main.NavigationService.Navigate(pg);
        }

        //private void Main_Navigated(object sender, NavigationEventArgs e)
        //{

        //}

        //private void btnStart_Click(object sender, RoutedEventArgs e)
        //{
        //    //MainActivity main = new MainActivity();
        //    pgGameMode pg = new pgGameMode();
        //    Main.NavigationService.Navigate(pg);
        //}
    }
}
