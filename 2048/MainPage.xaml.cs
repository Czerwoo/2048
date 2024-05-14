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
        //defines
        Random random = new Random();

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
        static int maxSizeGame = 4;
        bool added = false;
        int[,] board = new int[maxSizeGame, maxSizeGame];


        public MainPage()
        {
            InitializeComponent();
            newGame();
        }

        private void fillTable(int[,] board)
        {
            //Reset Data On Screen
            Xamarin.Forms.BoxView resetBox;
            Xamarin.Forms.Label resetText;



            Xamarin.Forms.Label DataText;
            Xamarin.Forms.BoxView DataBox;

            //Update Data On Screen
            Console.WriteLine("Rzut aktualnego stanu tablicy");
            for (int i = 0; i < maxSizeGame; i++)
            {
                for (int j = 0; j < maxSizeGame; j++)
                {

                    DataText = (Xamarin.Forms.Label)FindByName("label" + i + "" + j);
                    string tempData = board[i, j].ToString();
                    if (tempData != "0")
                    {
                        DataText.Text = tempData;

                    } else
                    {
                        DataText.Text = "";
                    }

                    DataBox = (Xamarin.Forms.BoxView)FindByName("box" + i + "" + j);
                    switch (board[i, j])
                    {
                        case 0: DataBox.BackgroundColor = color0; break;
                        case 2: DataBox.BackgroundColor = color2; break;
                        case 4: DataBox.BackgroundColor = color4; break;
                        case 8: DataBox.BackgroundColor = color8; break;
                        case 16: DataBox.BackgroundColor = color16; break;
                        case 32: DataBox.BackgroundColor = color32; break;
                        case 64: DataBox.BackgroundColor = color64; break;
                        case 128: DataBox.BackgroundColor = color128; break;
                        case 256: DataBox.BackgroundColor = color256; break;

                    }


                    
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();

            }

        }

        private object generateTile(int[,] board, int quantityTile, int amount) 
        {
            int i = 0;
            while (i < amount)
            {
                int row = random.Next(0, maxSizeGame);
                int column = random.Next(0, maxSizeGame);
                if (board[column, row] == 0)
                {
                    board[column, row] = quantityTile;
                    i++;
                }

            }
            fillTable(board);
            return board;
        }
 
            
        private void newGame()
            {
            for (int i = 0; i < maxSizeGame; i++)
            {
                for (int j = 0; j < maxSizeGame; j++)
                {
                    board[i, j] = 0;
                }
            }
                    generateTile(board, 2, 2);


            
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
                    MoveLeft();
                    generateTile(board, 2, 1);
                    break;
                case SwipeDirection.Right:
                    MoveRight();
                    generateTile(board, 2, 1);
                    break;
                case SwipeDirection.Up:
                    MoveUp();
                    generateTile(board, 2, 1);
                    break;
                case SwipeDirection.Down:
                    MoveDown();
                    generateTile(board, 2, 1);
                    break;
            }
        }

        void MoveLeft()
        {
            for (int i = 0; i < maxSizeGame; i++)
            {
                for (int j = 0; j < maxSizeGame; j++)
                {
                    if (board[i, j] != 0)
                    {
                        if (j - 1 >= 0)
                        {
                            if (board[i, j - 1] == 0)
                            {
                                board[i, j - 1] = board[i, j];
                                board[i, j] = 0;
                                Console.WriteLine("w lewo");
                                Console.WriteLine("Plansza:");
                                fillTable(board);
                            }
                            else if (board[i, j - 1] == board[i, j])
                            {
                                board[i, j - 1] = board[i, j] * 2;
                                board[i, j] = 0;
                                Console.WriteLine("w lewo");
                                Console.WriteLine("Plansza:");
                                fillTable(board);
                            }
                        }
                    }
                }
            }
        }

        void MoveRight()
        {
            for (int i = 0; i < maxSizeGame; i++)
            {
                for (int j = maxSizeGame - 1; j >= 0; j--)
                {
                    if (board[i, j] != 0)
                    {
                        if (j + 1 < maxSizeGame)
                        {
                            if (board[i, j + 1] == 0)
                            {
                                board[i, j + 1] = board[i, j];
                                board[i, j] = 0;
                                Console.WriteLine("w prawo");
                                Console.WriteLine("Plansza:");
                                fillTable(board);
                            }
                            else if (board[i, j + 1] == board[i, j])
                            {
                                board[i, j + 1] = board[i, j] * 2;
                                board[i, j] = 0;
                                Console.WriteLine("w prawo");
                                Console.WriteLine("Plansza:");
                                fillTable(board);
                            }
                        }
                    }
                }
            }
        }

        void MoveUp()
        {
            for (int j = 0; j < maxSizeGame; j++)
            {
                for (int i = 0; i < maxSizeGame; i++)
                {
                    if (board[i, j] != 0)
                    {
                        if (i - 1 >= 0)
                        {
                            if (board[i - 1, j] == 0)
                            {
                                board[i - 1, j] = board[i, j];
                                board[i, j] = 0;
                                Console.WriteLine("w górę");
                                Console.WriteLine("Plansza:");
                                fillTable(board);
                            }
                            else if (board[i - 1, j] == board[i, j])
                            {
                                board[i - 1, j] = board[i, j] * 2;
                                board[i, j] = 0;
                                Console.WriteLine("w górę");
                                Console.WriteLine("Plansza:");
                                fillTable(board);
                            }
                        }
                    }
                }
            }
        }

        void MoveDown()
        {
            for (int j = 0; j < maxSizeGame; j++)
            {
                for (int i = maxSizeGame - 1; i >= 0; i--)
                {
                    if (board[i, j] != 0)
                    {
                        if (i + 1 < maxSizeGame)
                        {
                            if (board[i + 1, j] == 0)
                            {
                                board[i + 1, j] = board[i, j];
                                board[i, j] = 0;
                                Console.WriteLine("w dół");
                                Console.WriteLine("Plansza:");
                                fillTable(board);
                            }
                            else if (board[i + 1, j] == board[i, j])
                            {
                                board[i + 1, j] = board[i, j] * 2;
                                board[i, j] = 0;
                                Console.WriteLine("w dół");
                                Console.WriteLine("Plansza:");
                                fillTable(board);
                            }
                        }
                    }
                }
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
