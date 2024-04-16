using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _2048
{
    public partial class MainPage : ContentPage
    {
        //define colors
        Xamarin.Forms.Color color0 = Color.FromHex("#EEEEE4");
        Xamarin.Forms.Color color2 = Color.FromHex("#F4C3B2");
        Xamarin.Forms.Color color4 = Color.FromHex("#EED99A");
        Xamarin.Forms.Color color8 = Color.FromHex("#CBDCE3");
        Xamarin.Forms.Color color16 = Color.FromHex("#C06A47");
        Xamarin.Forms.Color color32 = Color.FromHex("#9B8F9D");
        Xamarin.Forms.Color color64 = Color.FromHex("#B7E2AF");
        Xamarin.Forms.Color color128 = Color.FromHex("#71D2E3");
        Xamarin.Forms.Color color256 = Color.FromHex("#646D93");

        //define rules game
        int maxSizeGame = 4;


        public MainPage()
        {
            InitializeComponent();
            //newBoard_Clicked();
            newGame();
        }
 
        private void newGame()
            {
            //Reset Data
            Xamarin.Forms.BoxView resetBox;
            Xamarin.Forms.Label resetText;

            for (int i = 0; i < maxSizeGame; i++)
            {
                for(int j = 0; j < maxSizeGame; j++)
                {
                    resetBox = (Xamarin.Forms.BoxView)FindByName("box" + i + "" + j);
                    resetText = (Xamarin.Forms.Label)FindByName("label" + i + "" + j);
                    resetBox.BackgroundColor = color0;
                    resetText.Text = "";
                }
            }
            

            Random rnd = new Random();
            int row = rnd.Next(0, maxSizeGame);
            int column = rnd.Next(0, maxSizeGame);
            Xamarin.Forms.BoxView first = (Xamarin.Forms.BoxView)FindByName("box" + row + "" + column);
            Xamarin.Forms.Label firsttext = (Xamarin.Forms.Label)FindByName("label" + row + "" + column);
            Xamarin.Forms.BoxView second;
            Xamarin.Forms.Label secondtext;
            do
            {
                row = rnd.Next(0, maxSizeGame);
                column = rnd.Next(0, maxSizeGame);
                second = (Xamarin.Forms.BoxView)FindByName("box" + row + "" + column);
                secondtext = (Xamarin.Forms.Label)FindByName("label" + row + "" + column);
            } while (first == second);
            first.BackgroundColor = color2;
            firsttext.Text = "2";
            second.BackgroundColor = color2;
            secondtext.Text = "2";
        }
        private void restart_Clicked(object sender, EventArgs e)
        {
            newGame();
        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    Console.WriteLine("w lewo");
                    for (int i = maxSizeGame-1; i > 0; i--)
                    {
                        for (int j = 0; j < maxSizeGame; j++)
                        {
                            Xamarin.Forms.Label label = (Xamarin.Forms.Label)FindByName("label" + i + "" + j);
                            Xamarin.Forms.Label labelback = (Xamarin.Forms.Label)FindByName("label" + i + "" + (j - 1));
                            
                            if (label.Text == labelback.Text)
                            {
                                Console.WriteLine("jest taki sam");
                            }
                            else
                            {
                                Console.WriteLine("tekst się różni, po prostu przesuwam");
                                
                            }
                        }
                    }
                    break;
                case SwipeDirection.Right:
                    Console.WriteLine("w prawo");
                    break;
                case SwipeDirection.Up:
                    Console.WriteLine("w górę");
                    break;
                case SwipeDirection.Down:
                    Console.WriteLine("w dół");
                    break;
            }
        }


        //TODO GENEROWANIE PLANSZY! OGARNĘ PÓŹNIEJ - TO JEST PROTOTYP!
        //private void newBoard_Clicked(object sender, EventArgs e)
        //{
        //    Dictionary<string, BoxView> boxViews = new Dictionary<string, BoxView>();

        //    for (int i = 0; i < maxSizeGame; i++)
        //    {
        //        for (int j = 0; j < maxSizeGame; j++)
        //        {
        //            string dynamicName = "box" + i + "" + j;

        //            BoxView temp_nameBoxView = new BoxView
        //            {
        //                BackgroundColor = color8,
        //                CornerRadius = 10
        //            };

        //            boxViews.Add(dynamicName, temp_nameBoxView);

        //            gameView.Children.Add(temp_nameBoxView, j, i);

        //        }
        //    }


        //}
    }
}
