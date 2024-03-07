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

        public MainPage()
        {
            InitializeComponent();
            newGame();
        }

        private void newGame()
        {
            //Reset Data
            box00.BackgroundColor = color0;
            box01.BackgroundColor = color0;
            box02.BackgroundColor = color0;
            box10.BackgroundColor = color0;
            box11.BackgroundColor = color0;
            box12.BackgroundColor = color0;
            box20.BackgroundColor = color0;
            box21.BackgroundColor = color0;
            box22.BackgroundColor = color0;

            label00.Text = "";
            label01.Text = "";
            label02.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label20.Text = "";
            label21.Text = "";
            label22.Text = "";

            Random rnd = new Random();
            int row = rnd.Next(0, 3);
            int column = rnd.Next(0, 3);
            Xamarin.Forms.BoxView first = (Xamarin.Forms.BoxView)FindByName("box" + row + "" + column);
            Xamarin.Forms.Label firsttext = (Xamarin.Forms.Label)FindByName("label" + row + "" + column);
            Xamarin.Forms.BoxView second;
            Xamarin.Forms.Label secondtext;
            do
            {
                row = rnd.Next(0, 3);
                column = rnd.Next(0, 3);
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
    }
}
