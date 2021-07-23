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

namespace MatchGame
{
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElaspsed;
        int matchesFound;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();

           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElaspsed++;
            timeTextBlock.Text = (tenthsOfSecondsElaspsed / 10F).ToString("0.0s");
            if(matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play Again? ";
            }
        }

        private void SetUpGame()
        {

           
            List<string> animalEmoji = new List<string> // animalEmoji : Create a list of eight pairs of emoji 
            {
                "🐵","🐵",
                "🦁","🦁",
                "🐯","🐯",
                "🐴","🐴",
                "🐻","🐻",
                "🐭","🐭",
                "🐸","🐸",
                "🐉","🐉",

            };
            Random random = new Random(); // Create a new random number generator 
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>()) // Find every TextBlock in main grid and repeat the following statements for each of them 
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count); // Pick an random between 0 and the number of emoji left in the list and call it index 
                    string nextEmoji = animalEmoji[index]; // use the random called "index" to get a random emoji from the list 
                    textBlock.Text = nextEmoji; //Update the TextBlock with the random emoji from the list 
                    animalEmoji.RemoveAt(index); // Remove the random emoji from the list 

                }
            }
            timer.Start();
            tenthsOfSecondsElaspsed = 0;
            matchesFound = 0;
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if(textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}
