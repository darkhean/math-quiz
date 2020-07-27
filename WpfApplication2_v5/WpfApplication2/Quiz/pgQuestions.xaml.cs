using MathGame_BLL.BLL.MathGame;
using MathGame_DAL.DAL.MathGame;
using MathGame_Models.Models;
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
using System.Windows.Threading;
using WpfApplication2;

namespace Maths_Quiz_App.Quiz
{
    /// <summary>
    /// Interaction logic for pgQuestions.xaml
    /// GameMode: Nor uses all operators
    /// GameMode: ope uses only 1 specific operator
    /// Operator: All uses all operators
    /// Operator: Add uses only addition
    /// Operator: Sub uses only subtraction
    /// Operator: Mul uses only multiplication
    /// Operator: Div uses only division
    /// </summary>
    public partial class pgQuestions : Page
    {
        private string input; //input (Game mode, operator and difficulty level) from previous page
        string equation;
        double ans = 0;
        double userAns = 0;
        double n1 = 0;
        double n2 = 0;
        double n3 = 0;
        double n4 = 0;
        int score = 0;
        //System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();

        //string me = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        DispatcherTimer timer;
        TimeSpan time;


        public pgQuestions()
        {
            InitializeComponent();
        }

        public pgQuestions(string v)
        {
            InitializeComponent();
            input = v;

            //To start timer
            countdownTimer(input);

            

            //To test the value recieved from previous page
            //textBox1.Text = Convert.ToString(input);

            //To split the passed info into a string array
            string[] parts = input.Split(new string[] { " " }, StringSplitOptions.None);
            //parts[1] = Gamemode
            //parts[2] = Operator
            //parts[3] = Difficulty level
            string GM = parts[1];
            string ope = parts[2];
            string DL = parts[3];

            //Test output of string array
            /*
            textBox2.Text = Convert.ToString(parts[1]); //Gamemode info
            textBox3.Text = Convert.ToString(parts[2]); //Operator info
            textBox4.Text = Convert.ToString(parts[3]); //Difficulty Level Info
            */

            //To generate random variables
            variableGenerator(input);

            //To determine game mode
            gameMode(input);
            /*
            switch (GM)
            {
                case "Nor":
                    //code
                    equationGenerator(input);
                    break;

                case "ope":
                    //code
                    singleOperatorEquationGenerator(input);
                    break;

            }
            */

            //Test random number generator
            /*       
           textBox2.Text = Convert.ToString(n1);
           textBox3.Text = Convert.ToString(n2);
           textBox4.Text = Convert.ToString(n3);
           textBox5.Text = Convert.ToString(n4);
           */

            
        }

        //function to generate random numbers for variables
        public void variableGenerator(string settings)
        {
            //To split the passed info into a string array
            string[] parts = settings.Split(new string[] { " " }, StringSplitOptions.None);
            string DL = parts[3];

            /*
            Random rand = new Random();
            n1 = rand.Next(0, 500);
            n2 = rand.Next(0, 500);
            n3 = rand.Next(0, 500);
            n4 = rand.Next(0, 500);
            */

            switch(DL)
            {
                case "1":
                    //Difficulty level 1
                    Random rand1 = new Random();
                    n1 = rand1.Next(50, 100);
                    n2 = rand1.Next(0, 100);
                    //n3 = rand1.Next(0, 100);
                    //n4 = rand1.Next(0, 100);
                    break;

                case "2":
                case "3":
                    //Difficulty level 2 and 3
                    Random rand2 = new Random();
                    n1 = rand2.Next(500, 1000);
                    n2 = rand2.Next(0, 500);
                    n3 = rand2.Next(0, 250);
                    //n4 = rand2.Next(0, 1000);
                    break;

                case "4":
                case "5":
                    //Difficulty level 4 and 5
                    Random rand3 = new Random();
                    n1 = rand3.Next(5000, 10000);
                    n2 = rand3.Next(0, 5000);
                    n3 = rand3.Next(0, 500);
                    n4 = rand3.Next(0, 50);
                    break;

                case "6":
                    //Difficulty level 6
                    Random rand4 = new Random();
                    n1 = rand4.Next(60000, 100000);
                    n2 = rand4.Next(0, 40000);
                    n3 = rand4.Next(0, 1000);
                    n4 = rand4.Next(0, 100);
                    break;
            }

        }

        //function to determine game mode
        public void gameMode(string settings)
        {
            //To split the passed info into a string array
            string[] parts = input.Split(new string[] { " " }, StringSplitOptions.None);
            string GM = parts[1];
           
            switch (GM)
            {
                case "Nor":
                    //code
                    equationGenerator(input);
                    break;

                case "ope":
                    //code
                    singleOperatorEquationGenerator(input);
                    break;
            }
        }

        #region Single Operator Equations

        /// <summary>
        /// Required functions for single operator equation generation and answer
        /// </summary>
        /// <param name="settings"></param>

        //function to generate equation with single operator
        public void singleOperatorEquationGenerator(string settings)
        {
            //To split the passed info into a string array
            string[] parts = settings.Split(new string[] { " " }, StringSplitOptions.None);
            string ope = parts[2];

            //To determine which single operator
            switch (ope)
            {
                case "Add":
                    //code
                    addEquation(settings);
                    break;

                case "Sub":
                    //code
                    subEquation(settings);
                    break;

                case "Mul":
                    //code
                    mulEquation(settings);
                    break;

                case "Div":
                    //code
                    divEquation(settings);
                    break;
            }
        }

        //Only addition equations
        public void addEquation(string settings)
        {
            //To split the passed info into a string array
            string[] parts = settings.Split(new string[] { " " }, StringSplitOptions.None);
            string DL = parts[3];

            switch (DL)
            {
                case "1":
                case "2":
                    //Difficulty level 1 & 2
                    //Display equation
                    equation = n1 + " + " + n2 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 + n2;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case "3":
                case "4":
                    //Difficulty level 3 & 4
                    //Display equation
                    equation = n1 + " + " + n2 + " + " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 + n2 + n3;
                    break;

                case "5":
                case "6":
                    //Difficulty level 5 & 6
                    //Display equation
                    equation = n1 + " + " + n2 + " + " + n3 + " + " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 + n2 + n3 + n4;
                    break;
            }
        }

        //Only subtraction equations
        public void subEquation(string settings)
        {
            //To split the passed info into a string array
            string[] parts = settings.Split(new string[] { " " }, StringSplitOptions.None);
            string DL = parts[3];

            switch (DL)
            {
                case "1":
                case "2":
                    //Difficulty level 1 & 2
                    //Display equation
                    equation = n1 + " - " + n2 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 - n2;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case "3":
                case "4":
                    //Difficulty level 3 & 4
                    //Display equation
                    equation = n1 + " - " + n2 + " - " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 - n2 - n3;
                    break;

                case "5":
                case "6":
                    //Difficulty level 5 & 6
                    //Display equation
                    equation = n1 + " - " + n2 + " - " + n3 + " - " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 - n2 - n3 - n4;
                    break;
            }
        }

        //Only multiplication equations
        public void mulEquation(string settings)
        {
            //To split the passed info into a string array
            string[] parts = settings.Split(new string[] { " " }, StringSplitOptions.None);
            string DL = parts[3];

            switch (DL)
            {
                case "1":
                case "2":
                    //Difficulty level 1 & 2
                    //Display equation
                    equation = n1 + " * " + n2 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 * n2;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case "3":
                case "4":
                    //Difficulty level 3 & 4
                    //Display equation
                    equation = n1 + " * " + n2 + " * " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 * n2 * n3;
                    break;

                case "5":
                case "6":
                    //Difficulty level 5 & 6
                    //Display equation
                    equation = n1 + " * " + n2 + " * " + n3 + " * " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 * n2 * n3 * n4;
                    break;
            }
        }

        //Only division equations
        public void divEquation(string settings)
        {
            //To split the passed info into a string array
            string[] parts = settings.Split(new string[] { " " }, StringSplitOptions.None);
            string DL = parts[3];

            switch (DL)
            {
                case "1":
                case "2":
                    //Difficulty level 1 & 2
                    //Display equation
                    equation = n1 + " / " + n2 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 / n2;
                    ans = Math.Round(ans, 5);

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case "3":
                case "4":
                    //Difficulty level 3 & 4
                    //Display equation
                    equation = n1 + " / " + n2 + " / " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 / n2 / n3;
                    ans = Math.Round(ans, 6);

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case "5":
                case "6":
                    //Difficulty level 5 & 6
                    //Display equation
                    equation = n1 + " / " + n2 + " / " + n3 + " / " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 / n2 / n3 / n4;
                    ans = Math.Round(ans, 10);

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;
            }
        }

        #endregion

        #region Multiple Operator Equations

        /// <summary>
        /// Required functions for multiple operators equation generation and answer
        /// </summary>
        /// <param name="settings"></param>

        //function to create equation with multiple operators
        public void equationGenerator(string settings)
        {
            //To split the passed info into a string array
            string[] parts = settings.Split(new string[] { " " }, StringSplitOptions.None);
            string DL = parts[3];

            //Use random number generator to decide between operators and switch cases

            switch (DL)
            {
                case "1":
                    //Difficulty level 1
                    lvl1n2Equation(settings);
                    break;

                case "2":
                    //Difficulty level 2
                    lvl1n2Equation(settings);
                    break;

                case "3":
                    //Difficulty level 3
                    lvl3Equation(settings);
                    break;

                case "4":
                    //Difficulty level 4
                    lvl4Equation(settings);
                    break;

                case "5":
                    //Difficulty level 5
                    lvl5Equation(settings);
                    break;

                case "6":
                    //Difficulty level 6
                    lvl6Equation(settings);
                    break;
            }
        }

        //function for level 1 and level 2 multiple operator equation
        public void lvl1n2Equation(string settings)
        {
            //To split the passed info into a string array
            string[] parts = settings.Split(new string[] { " " }, StringSplitOptions.None);
            string DL = parts[3];

            //To determine which equations to use
            Random rand = new Random();
            int choice = rand.Next(0, 4);

            switch (choice)
            {
                case 1: //Addition
                    //code
                    //Display equation
                    equation = n1 + " + " + n2 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 + n2;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 2: //Subtraction
                    //code
                    //Display equation
                    equation = n1 + " - " + n2 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 - n2;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 3: //Multiplication
                    //code
                    //Display equation
                    equation = n1 + " * " + n2 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 * n2;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 4: //Division
                    //code
                    //Display equation
                    equation = n1 + " / " + n2 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 / n2;
                    ans = Math.Round(ans, 5);

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;
            }
        }

        //function for level 3 multiple operator equation
        public void lvl3Equation(string settings)
        {
            //To split the passed info into a string array
            string[] parts = settings.Split(new string[] { " " }, StringSplitOptions.None);
            string DL = parts[3];

            //To determine which equations to use
            Random rand = new Random();
            int choice = rand.Next(0, 4);

            switch (choice)
            {
                case 1: //Addition
                    //code
                    //Display equation
                    equation = n1 + " + " + n2 + " + " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 + n2 + n3;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 2: //Subtraction
                    //code
                    //Display equation
                    equation = n1 + " - " + n2 + " - " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 - n2 - n3;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 3: //Multiplication
                    //code
                    //Display equation
                    equation = n1 + " * " + n2 + " * " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 * n2 * n3;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 4: //Division
                    //code
                    //Display equation
                    equation = n1 + " / " + n2 + " / " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 / n2 / n3;
                    ans = Math.Round(ans, 6);

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;
            }
        }

        //function for level 4 multiple operator equation
        public void lvl4Equation(string settings)
        {
            //To split the passed info into a string array
            string[] parts = settings.Split(new string[] { " " }, StringSplitOptions.None);
            string DL = parts[3];

            //To determine which equations to use
            Random rand = new Random();
            int choice = rand.Next(0, 16); //16 choices

            switch (choice)
            {
                case 1: //Addition only
                    //code
                    //Display equation
                    equation = n1 + " + " + n2 + " + " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 + n2 + n3;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 2: //Subtraction only
                    //code
                    //Display equation
                    equation = n1 + " - " + n2 + " - " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 - n2 - n3;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 3: //Multiplication only
                    //code
                    //Display equation
                    equation = n1 + " * " + n2 + " * " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 * n2 * n3;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 4: //Division only
                    //code
                    //Display equation
                    equation = n1 + " / " + n2 + " / " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 / n2 / n3;
                    ans = Math.Round(ans, 6);

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 5: // add sub
                    //code
                    //Display equation
                    equation = n1 + " + " + n2 + " - " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 + n2 - n3;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 6: // add mul
                    //code
                    //Display equation
                    equation = n1 + " + " + n2 + " * " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 + n2 * n3;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 7: // add div
                    //code
                    //Display equation
                    equation = n1 + " + " + n2 + " / " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 + n2 / n3;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 8: // sub add
                    //code
                    //Display equation
                    equation = n1 + " - " + n2 + " + " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 - n2 + n3;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 9: // sub mul
                    //code
                    //Display equation
                    equation = n1 + " - " + n2 + " * " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 - n2 * n3;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 10: // sub div
                    //code
                    //Display equation
                    equation = n1 + " - " + n2 + " / " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 - n2 / n3;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 11: //mul add
                    //code
                    //Display equation
                    equation = n1 + " * " + n2 + " + " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 * n2 + n3;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 12: //mul sub
                    //code
                    //Display equation
                    equation = n1 + " * " + n2 + " - " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 * n2 - n3;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 13: //mul div
                    //code
                    //Display equation
                    equation = n1 + " * " + n2 + " / " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 * n2 / n3;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 14: //div add
                    //code
                    //Display equation
                    equation = n1 + " / " + n2 + " + " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 / n2 + n3;
                    ans = Math.Round(ans, 6);

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 15: //div sub
                    //code
                    //Display equation
                    equation = n1 + " / " + n2 + " - " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 / n2 - n3;
                    ans = Math.Round(ans, 6);

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 16: //div mul
                    //code
                    //Display equation
                    equation = n1 + " / " + n2 + " * " + n3 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 / n2 * n3;
                    ans = Math.Round(ans, 6);

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;
            }
        }

        //function for level 5 multiple operator equation
        public void lvl5Equation(string settings)
        {
            //To split the passed info into a string array
            string[] parts = settings.Split(new string[] { " " }, StringSplitOptions.None);
            string DL = parts[3];

            //To determine which equations to use
            //Limiting the amount of choices here as it is impractical to have all choices
            Random rand = new Random();
            int choice = rand.Next(0, 12); //12 choices

            switch (choice)
            {
                case 1: //++-
                    //code
                    //Display equation
                    equation = n1 + " + " + n2 + " + " + n3 + " - " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 + n2 + n3 - n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 2: //++*
                    //code
                    //Display equation
                    equation = n1 + " + " + n2 + " + " + n3 + " * " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 + n2 + n3 * n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 3: //++/
                    //code
                    //Display equation
                    equation = n1 + " + " + n2 + " + " + n3 + " / " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 + n2 + n3 / n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 4: //--+
                    //code
                    //Display equation
                    equation = n1 + " - " + n2 + " - " + n3 + " + " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 - n2 - n3 + n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 5: //--*
                    //code
                    //Display equation
                    equation = n1 + " - " + n2 + " - " + n3 + " * " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 - n2 - n3 * n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 6: //--/
                    //code
                    //Display equation
                    equation = n1 + " - " + n2 + " - " + n3 + " / " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 - n2 - n3 / n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 7: //**+
                    //code
                    //Display equation
                    equation = n1 + " * " + n2 + " * " + n3 + " + " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 * n2 * n3 + n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 8: //**-
                    //code
                    //Display equation
                    equation = n1 + " * " + n2 + " * " + n3 + " - " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 * n2 * n3 - n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 9: //**/
                    //code
                    //Display equation
                    equation = n1 + " * " + n2 + " * " + n3 + " / " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 * n2 * n3 / n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 10: // //+
                    //code
                    //Display equation
                    equation = n1 + " / " + n2 + " / " + n3 + " + " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 / n2 / n3 + n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 11: // //-
                    //code
                    //Display equation
                    equation = n1 + " / " + n2 + " / " + n3 + " - " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 / n2 / n3 - n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 12: // //*
                    //code
                    //Display equation
                    equation = n1 + " / " + n2 + " / " + n3 + " * " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 / n2 / n3 * n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;
            }
        }

        public void lvl6Equation(string settings)
        {
            //To split the passed info into a string array
            string[] parts = settings.Split(new string[] { " " }, StringSplitOptions.None);
            string DL = parts[3];

            //To determine which equations to use
            //Limiting the amount of choices here as it is impractical to have all choices
            Random rand = new Random();
            int choice = rand.Next(0, 8); //8 choices

            switch (choice)
            {
                case 1: //+-*
                    //code
                    //Display equation
                    equation = n1 + " + " + n2 + " - " + n3 + " * " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 + n2 - n3 * n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 2: //+-/
                    //code
                    //Display equation
                    equation = n1 + " + " + n2 + " - " + n3 + " / " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 + n2 - n3 / n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 3: //-*/
                    //code
                    //Display equation
                    equation = n1 + " - " + n2 + " * " + n3 + " / " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 - n2 * n3 / n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 4: //-*+
                    //code
                    //Display equation
                    equation = n1 + " - " + n2 + " * " + n3 + " + " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 - n2 * n3 + n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 5: //*/+
                    //code
                    //Display equation
                    equation = n1 + " * " + n2 + " / " + n3 + " + " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 * n2 / n3 + n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 6: //*/-
                    //code
                    //Display equation
                    equation = n1 + " * " + n2 + " / " + n3 + " - " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 * n2 / n3 - n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 7: // /+-
                    //code
                    //Display equation
                    equation = n1 + " / " + n2 + " + " + n3 + " - " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 / n2 + n3 - n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;

                case 8: // /+*
                    //code
                    //Display equation
                    equation = n1 + " / " + n2 + " + " + n3 + " * " + n4 + " = ";
                    lblEquation.Content = equation;

                    //Get answer
                    ans = n1 / n2 + n3 * n4;

                    //Test the answer is correct
                    //textBoxUserAnswer.Text = Convert.ToString(ans);
                    break;
            }
        }

        #endregion

        public void countdownTimer(string setting)
        {
            //For a working timer
            //DispatcherTimer timer;
            //TimeSpan time;
            string[] parts = setting.Split(new string[] { " " }, StringSplitOptions.None);
            string DL = parts[3];

            time = TimeSpan.FromMinutes(1);
            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                lblTimer.Content = time.ToString("c");
                if (time == TimeSpan.Zero)
                {
                    timer.Stop();

                    MessageBoxResult result = MessageBox.Show("Your time is up! Congrats you scored " + score + " points!", "Quiz is Over");
                    MathGameBLL Db = new MathGameBLL();
                    List<ScoreModel> Score = new List<ScoreModel>();
                    List<GetCUser> cuserinput = Db.GetCUser();
                   // List<string>currentuser=new List<string>();
                    var currentuser = Db.GetCUser().Select(x => x.user).FirstOrDefault().ToString();
                    Score.Add(new ScoreModel { score = score, lvl = Convert.ToInt16(DL), name=currentuser });
                    Db.InsertScore(Score);
                    if (result == MessageBoxResult.OK)
                    {
                        //returns to main menu / starting page
                        pgStart pg = new pgStart();
                        this .NavigationService.Navigate(pg);
                       
                    }
                }

                //Countdown from time    
                time = time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            //timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Tick += timer_Tick;
            timer.Start();
        }

        //funtion to check answer and move to next question
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            //check for no user input
            try
            {
                //check user answer
                userAns = Convert.ToDouble(textBoxUserAnswer.Text);
                if (userAns == ans)
                {
                    score++;
                    MessageBox.Show("Your answer is correct!");
                }
                else
                {
                    MessageBox.Show("Your answer is wrong!");
                }
            }
            catch
            {
                MessageBox.Show("Your answer is wrong!");
            }

            //reset user input
            userAns = 0;
            textBoxUserAnswer.Text = String.Empty;

            //goto next question
            //just copy and paste the functions at the top
            variableGenerator(input);
            gameMode(input);
        }
    }
}
