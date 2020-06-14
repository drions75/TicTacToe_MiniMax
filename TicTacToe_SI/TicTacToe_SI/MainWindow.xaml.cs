using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace TicTacToe_SI
{
     
    public partial class MainWindow : Window
    {

        int[] iBoard = new int[16];
        int iTurn = -1;
        int iLastMove = -1;
        int iXScores = 0;
        int iOScores = 0;
        bool bEnableBot = false;
        private int iType = 1;
        public int gameType_stat = 2;
        public int field_Count = 15;
        public bool pvpflag = false;
        int movementCounter = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ChangeButtonBackgroundImage(int position)
        {
            Uri resourceUri1 = new Uri("resources/eX.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri1);

            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            var brush1 = new ImageBrush();
            brush1.ImageSource = temp;

            Uri resourceUri2 = new Uri("resources/round.png", UriKind.Relative);
            StreamResourceInfo streamInfo1 = Application.GetResourceStream(resourceUri2);

            BitmapFrame temp2 = BitmapFrame.Create(streamInfo1.Stream);
            var brush2 = new ImageBrush();
            brush2.ImageSource = temp2;


            if (iBoard[position] == -1)
            {
                

                switch (position)
                {
                    //Pierwszy Wiersz [0,1,2,3]
                    case (0): Button0i0.Background = brush1; break;
                    case (1): Button0i1.Background = brush1; break;
                    case (2): Button0i2.Background = brush1; break;
                    case (3): Button0i3.Background = brush1; break;
                    //Drugi Wiersz [4,5,6,7]
                    case (4): Button1i0.Background = brush1; break;
                    case (5): Button1i1.Background = brush1; break;
                    case (6): Button1i2.Background = brush1; break;
                    case (7): Button1i3.Background = brush1; break;
                    //Trzeci Wiersz [8,9,10,11]
                    case (8): Button2i0.Background = brush1; break;
                    case (9): Button2i1.Background = brush1; break;
                    case (10): Button2i2.Background = brush1; break;
                    case (11): Button2i3.Background = brush1; break;
                    //Czwarty Wiersz [12,13,14,15]
                    case (12): Button3i0.Background = brush1; break;
                    case (13): Button3i1.Background = brush1; break;
                    case (14): Button3i2.Background = brush1; break;
                    case (15): Button3i3.Background = brush1; break;

                }
            }
            else if (iBoard[position] == 1)
            {
                switch (position)
                {
                    //Pierwszy Wiersz [0,1,2,3]
                    case (0): Button0i0.Background = brush2; break;
                    case (1): Button0i1.Background = brush2; break;
                    case (2): Button0i2.Background = brush2; break;
                    case (3): Button0i3.Background = brush2; break;
                    //Drugi Wiersz [4,5,6,7]
                    case (4): Button1i0.Background = brush2; break;
                    case (5): Button1i1.Background = brush2; break;
                    case (6): Button1i2.Background = brush2; break;
                    case (7): Button1i3.Background = brush2; break;
                    //Trzeci Wiersz [8,9,10,11]
                    case (8): Button2i0.Background = brush2; break;
                    case (9): Button2i1.Background = brush2; break;
                    case (10): Button2i2.Background = brush2; break;
                    case (11): Button2i3.Background = brush2; break;
                    //Czwarty Wiersz [12,13,14,15]
                    case (12): Button3i0.Background = brush2; break;
                    case (13): Button3i1.Background = brush2; break;
                    case (14): Button3i2.Background = brush2; break;
                    case (15): Button3i3.Background = brush2; break;
                }
                
            }
            else
            {
                switch (position)
                {
                    //Pierwszy Wiersz [0,1,2,3]
                    case (0): Button0i0.Background = null; break;
                    case (1): Button0i1.Background = null; break;
                    case (2): Button0i2.Background = null; break;
                    case (3): Button0i3.Background = null; break;
                    //Drugi Wiersz [4,5,6,7]
                    case (4): Button1i0.Background = null; break;
                    case (5): Button1i1.Background = null; break;
                    case (6): Button1i2.Background = null; break;
                    case (7): Button1i3.Background = null; break;
                    //Trzeci Wiersz [8,9,10,11]
                    case (8): Button2i0.Background = null; break;
                    case (9): Button2i1.Background = null; break;
                    case (10): Button2i2.Background = null; break;
                    case (11): Button2i3.Background = null; break;
                    //Czwarty Wiersz [12,13,14,15]
                    case (12): Button3i0.Background = null; break;
                    case (13): Button3i1.Background = null; break;
                    case (14): Button3i2.Background = null; break;
                    case (15): Button3i3.Background = null; break;
                }
            }
        }              

        void SetNextTurn()
        {
            // This can return: -1 (X win) 1(O win) 0 (Draw) and 2 (Keep Going)
            int GameStatus = CheckGameStatus(gameType_stat);
            
            
            if (GameStatus == 2) //if keep going
            {
                if (iTurn == -1) // if X turn
                {
                    iTurn = 1; // change turn on O
                    StatusLabel.Content = "𐩒 Turn";
                    
                }
                else
                {
                    if (iType != 3 && iLastMove == -1)
                    {
                        iTurn = -1;// change turn on O
                        StatusLabel.Content = "Select Game Mode";
                        
                    }
                    else
                    {
                        iTurn = -1;// change turn on X
                        StatusLabel.Content ="🗙 Turn";
                        
                    }
                }
            }
            else
            {
                if (GameStatus == -1)
                {
                    iXScores++;
                    WynikX.Content = "🗙 - " + iXScores.ToString();
                    StatusLabel.Content = "Game Over - X Win!";
                    TitleLabel.Content = "X win!";
                }
                else if (GameStatus == 1)
                {
                    iOScores++;
                    WynikO.Content = "◯ - " + iOScores.ToString();
                    StatusLabel.Content = "Game Over - O Win!";
                    TitleLabel.Content = "O win!";
                }
                else
                {
                    StatusLabel.Content = "Draw";
                    TitleLabel.Content = "Draw!";
                }
                iTurn = 0;
                //StatusLabel.Content = "Game Over";
            }
        }
         
        //Return -1 = X win, 0 = Draw, 1 = O win, 2 = Keep going
        int CheckGameStatus(int gameType)
        {/*       3x3           
                    [ 0, 1,  2 ]       
                    [ 4, 5,  6 ]  	   
                    [ 8, 9, 10 ]        
                 */

            if (gameType == 1) //3x3
            {   
                // ---
                if (iBoard[0] != 0 && iBoard[0] == iBoard[1] && iBoard[1] == iBoard[2])
                {                    
                    return iBoard[0];
                }
                else if (iBoard[4] != 0 && iBoard[4] == iBoard[5] && iBoard[5] == iBoard[6])
                {                   
                    return iBoard[4];
                }
                else if (iBoard[8] != 0 && iBoard[8] == iBoard[9] && iBoard[8] == iBoard[10])
                {                   
                    return iBoard[8];
                }
                // |
                else if (iBoard[0] != 0 && iBoard[0] == iBoard[4] && iBoard[4] == iBoard[8])
                {
                    return iBoard[0];
                }
                else if (iBoard[1] != 0 && iBoard[1] == iBoard[5] && iBoard[5] == iBoard[9])
                {                    
                    return iBoard[1];
                }
                else if (iBoard[2] != 0 && iBoard[2] == iBoard[6] && iBoard[6] == iBoard[10])
                {
                    return iBoard[2];
                }
                // \
                else if (iBoard[0] != 0 && iBoard[0] == iBoard[5] && iBoard[5] == iBoard[10])
                {
                    return iBoard[0];
                }
                // /
                else if (iBoard[2] != 0 && iBoard[2] == iBoard[5] && iBoard[5] == iBoard[8])
                {
                    return iBoard[2];
                }
                //draw
                else if (iBoard[0] != 0 && iBoard[1] != 0 && iBoard[2] != 0 && iBoard[4] != 0 && iBoard[5] != 0 && iBoard[6] != 0 && iBoard[8] != 0 && iBoard[9] != 0 && iBoard[10] != 0)
                {
                    return 0;
                }


            }
            else if (gameType == 2) //4x4
            {   
                // -
                if (iBoard[0] != 0 && iBoard[0] == iBoard[1] && iBoard[1] == iBoard[2] && iBoard[2] == iBoard[3])
                {                    
                    return iBoard[0];
                }
                else if (iBoard[4] != 0 && iBoard[4] == iBoard[5] && iBoard[5] == iBoard[6] && iBoard[6] == iBoard[7])
                {                    
                    return iBoard[4];
                }
                else if (iBoard[8] != 0 && iBoard[8] == iBoard[9] && iBoard[9] == iBoard[10] && iBoard[10] == iBoard[11])
                {                  
                    return iBoard[8];
                }
                else if (iBoard[12] != 0 && iBoard[12] == iBoard[13] && iBoard[13] == iBoard[14] && iBoard[14] == iBoard[15])
                {
                    return iBoard[12];
                }
                // |
                else if (iBoard[0] != 0 && iBoard[0] == iBoard[4] && iBoard[4] == iBoard[8] && iBoard[8] == iBoard[12])
                {
                    return iBoard[0];
                }
                else if (iBoard[1] != 0 && iBoard[1] == iBoard[5] && iBoard[5] == iBoard[9] && iBoard[9] == iBoard[13])
                {
                    return iBoard[1];
                }
                else if (iBoard[2] != 0 && iBoard[2] == iBoard[6] && iBoard[6] == iBoard[10] && iBoard[10] == iBoard[14])
                {                  
                    return iBoard[2];
                }
                else if (iBoard[3] != 0 && iBoard[3] == iBoard[7] && iBoard[7] == iBoard[11] && iBoard[11] == iBoard[15])
                {
                    return iBoard[3];
                }
                // \
                else if (iBoard[0] != 0 && iBoard[0] == iBoard[5] && iBoard[5] == iBoard[10] && iBoard[10] == iBoard[15])
                {
                    return iBoard[0];
                }
                // /
                else if (iBoard[3] != 0 && iBoard[3] == iBoard[6] && iBoard[6] == iBoard[9] && iBoard[9] == iBoard[12])
                {
                    return iBoard[3];
                }
                //draw
                else if (iBoard[0] != 0 && iBoard[1] != 0 && iBoard[2] != 0 && iBoard[3] != 0 && iBoard[4] != 0 && iBoard[5] != 0 && iBoard[6] != 0 && iBoard[7] != 0 && iBoard[8] != 0 && iBoard[9] != 0 && iBoard[10] != 0 && iBoard[11] != 0 && iBoard[12] != 0 && iBoard[13] != 0 && iBoard[14] != 0 && iBoard[15] != 0)
                {
                    return 0;
                }
            }
            else if (gameType == 7) //3x3 klein
            {/*       3x3           
                    [ 0, 1,  2 ]        x - -      - - x   x - -   - - x //  - - x   x - -    |       x x -   - x x
                    [ 4, 5,  6 ]  	    x - -      - - x   - - -   - - -  // x - -   - - x    |      - - -   - - -
                    [ 8, 9, 10 ]        - - x      x - -   - x x   x x -  // x - -   - - x    |      - - x   x - - 
                 */
                if (iBoard[0] != 0 && iBoard[0] == iBoard[4] && iBoard[4] == iBoard[10])
                {
                    return iBoard[0];
                }
                else if (iBoard[1] != 0 && iBoard[0] == iBoard[1] && iBoard[1] == iBoard[10])
                {
                    return iBoard[1];
                }
                else if (iBoard[1] != 0 && iBoard[2] == iBoard[1] && iBoard[2] == iBoard[8])
                {
                    return iBoard[1];
                }
                else if (iBoard[2] != 0 && iBoard[6] == iBoard[2] && iBoard[6] == iBoard[8])
                {
                    return iBoard[2];
                }
                else if (iBoard[0] != 0 && iBoard[0] == iBoard[9] && iBoard[0] == iBoard[10])
                {
                    return iBoard[0];
                }
                else if (iBoard[2] != 0 && iBoard[2] == iBoard[8] && iBoard[2] == iBoard[9])
                {
                    return iBoard[2];
                }
                else if (iBoard[2] != 0 && iBoard[2] == iBoard[4] && iBoard[2] == iBoard[8])
                {
                    return iBoard[2];
                }
                else if (iBoard[0] != 0 && iBoard[0] == iBoard[6] && iBoard[0] == iBoard[10])
                {
                    return iBoard[0];
                }
                else if (iBoard[0] != 0 && iBoard[1] != 0 && iBoard[2] != 0 && iBoard[4] != 0 && iBoard[5] != 0 && iBoard[6] != 0 && iBoard[8] != 0 && iBoard[9] != 0 && iBoard[10] != 0)
                {
                    return 0;
                }
            }

            return 2;
        }
        
        void RunBot()
        {
            //3 = Play against a friend , 0 = Game over
            if (iType == 3 || iTurn == 0)
                return;

            bEnableBot = true;
            Thread.Sleep(50);            
            
            if (iType == 1)
            {
                RunMediumBot();
            }           
        }
        void RunMediumBot()
        {
            int iOpponent;
            if (iTurn == -1) iOpponent = 1;
            else iOpponent = -1;

            if (iLastMove == -1)
            {
                if(gameType_stat == 2) iLastMove = RandomPosition4x4(); // if gameType  == 2 board = 4x4
                else iLastMove = RandomPosition3x3();
            }
            else 
            { 
                if ( gameType_stat == 2)
                {                   
                    CheckWinAndDontLose(iOpponent, gameType_stat);
                    CheckWinAndDontLose(iTurn, gameType_stat);
                    if (movementCounter == 3)
                    {
                        iLastMove = bestMove4x4(iTurn, iOpponent, iBoard);
                    }
                    else if (iBoard[iLastMove] != 0)
                    {                     
                        
                        iLastMove = RandomPosition4x4();
                    }                     
                 
                }
                else if (iBoard[iLastMove] != 0 && gameType_stat == 1)
                {
                    iLastMove = bestMove3x3(iTurn, iOpponent, iBoard);
                }
                else if(iBoard[iLastMove] != 0 && gameType_stat == 7)
                {
                    iLastMove = bestMove3x3(iTurn, iOpponent, iBoard);
                }
            }
            iBoard[iLastMove] = iTurn;
            ChangeButtonBackgroundImage(iLastMove);
            bEnableBot = false;
            SetNextTurn();
        }
        int minimax4x4(int turn, int opponent, int[] board2, int depth, bool isMaximizing)
        {
            int result = CheckGameStatus(gameType_stat); // return -1, 0, 1, (2 - keep going)
            if (result != 2) return result * 10;
            
            if (isMaximizing)
            {
                int bestScore = int.MinValue + 1;
                for (int i = 0; i <= 15; i++)
                {
                    if (board2[i] == 0)
                    {
                        board2[i] = turn;
                        int score = minimax4x4(turn, opponent, board2, depth + 1, false);
                        board2[i] = 0;
                        if (score > bestScore)
                        {
                            bestScore = score;
                        }

                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue - 1;
                for (int i = 0; i <= 15; i++)
                {
                    if (board2[i] == 0)
                    {
                        board2[i] = opponent;
                        int score = minimax4x4(turn, opponent, board2, depth + 1, true);
                        board2[i] = 0;
                        if (score < bestScore)
                        {
                            bestScore = score;
                        }
                    }
                }
                return bestScore;
            }
        }
        int bestMove4x4(int turn, int opponent, int[] board2)
        {
            int bestScore = int.MinValue;
            int move = -1;
            for (int i = 0; i <= 15; i++)
            {
                if (board2[i] == 0)
                {
                    board2[i] = turn;
                    int score = minimax4x4(turn, opponent, board2, 0, false);
                    board2[i] = 0;
                    if (score > bestScore)
                    {
                        bestScore = score;
                        move = i;
                    }
                }
            }
            return move;
        }
        int minimax3x3(int turn, int opponent, int[] board2, int depth, bool isMaximizing)
        {
            int result = CheckGameStatus(gameType_stat); // return -1, 0, 1, (2 - keep going)
            if (result != 2) return result * 10;            

            if (isMaximizing)
            {
                int bestScore = int.MinValue+1;
                for (int i = 0; i < 15; i++)
                {
                    if (board2[i] == 0 && (i < 3 || i > 3 && i < 7 || i > 7 && i < 11))
                    {
                        board2[i] = turn;
                        int score = minimax3x3(turn, opponent, board2, depth + 1, false);
                        board2[i] = 0;
                        if (score > bestScore)
                        {
                            bestScore = score;
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue-1;
                for (int i = 0; i < 15; i++)
                {
                    if (board2[i] == 0 && (i < 3 || i > 3 && i < 7 || i > 7 && i < 11))
                    {
                        board2[i] = opponent;
                        int score = minimax3x3(turn, opponent, board2, depth + 1, true);
                        board2[i] = 0;
                        if (score < bestScore)
                        {
                            bestScore = score;
                        }

                    }
                }
                return bestScore;
            }

        }
        int bestMove3x3(int turn, int opponent, int[] board2)
        {
            int bestScore = int.MinValue;
            int move = -1;
            for (int i = 0; i < 15; i++)
            {
                if (board2[i] == 0 && (i < 3 || i > 3 && i < 7 || i > 7 && i < 11))
                {
                    board2[i] = turn;
                    int score = minimax3x3(turn, opponent, board2, 0, false);
                    board2[i] = 0;
                    if (score > bestScore)
                    {
                        bestScore = score;
                        move = i;
                    }
                }
            }
            return move;
        }      
        void CheckWinAndDontLose(int XorO, int gameType)
        {
            if(gameType == 1) //3x3 //Pierwszy Wiersz [0,1,2,3] pierwszy w if dla -- drugi w if | opcj. trzeci \ i /
            {     //zrobione                                   
                if (iBoard[0] == 0 && ((iBoard[1] == XorO && iBoard[2] == XorO) || (iBoard[4] == XorO && iBoard[8] == XorO) || (iBoard[5] == XorO && iBoard[10] == XorO)))
                    iLastMove = 0;
                else if (iBoard[1] == 0 && ((iBoard[0] == XorO && iBoard[2] == XorO) || (iBoard[5] == XorO && iBoard[9] == XorO)))
                    iLastMove = 1;
                else if (iBoard[2] == 0 && ((iBoard[0] == XorO && iBoard[1] == XorO) || (iBoard[6] == XorO && iBoard[10] == XorO) || (iBoard[5] == XorO && iBoard[8] == XorO)))
                    iLastMove = 2;
                else if (iBoard[4] == 0 && ((iBoard[0] == XorO && iBoard[8] == XorO) || (iBoard[5] == XorO && iBoard[6] == XorO)))
                    iLastMove = 4;
                else if (iBoard[5] == 0 && ((iBoard[0] == XorO && iBoard[10] == XorO) || (iBoard[2] == XorO && iBoard[8] == XorO) || (iBoard[1] == XorO && iBoard[9] == XorO) || (iBoard[4] == XorO && iBoard[6] == XorO)))
                    iLastMove = 5;
                else if (iBoard[6] == 0 && ((iBoard[2] == XorO && iBoard[10] == XorO) || (iBoard[4] == XorO && iBoard[5] == XorO)))
                    iLastMove = 6;
                else if (iBoard[8] == 0 && ((iBoard[0] == XorO && iBoard[4] == XorO) || (iBoard[9] == XorO && iBoard[10] == XorO) || (iBoard[2] == XorO && iBoard[5] == XorO)))
                    iLastMove = 8;
                else if (iBoard[9] == 0 && ((iBoard[1] == XorO && iBoard[5] == XorO) || (iBoard[8] == XorO && iBoard[10] == XorO)))
                    iLastMove = 9;
                else if (iBoard[10] == 0 && ((iBoard[2] == XorO && iBoard[6] == XorO) || (iBoard[8] == XorO && iBoard[9] == XorO) || (iBoard[0] == XorO && iBoard[5] == XorO)))
                    iLastMove = 10;
            }
            else if(gameType == 2)//4x4
            {   //Sprawdzamy każde pole czy możemy wygrać/zremisować // edytujemy iLastMove miejsce w które wstawimy znak jeśli warunki wygrania będą spełnione
                //Pierwszy Wiersz [0,1,2,3] pierwszy w if dla -- drugi w if | opcj. trzeci \ i /
                if (iBoard[0] == 0 && ((iBoard[1] == XorO && iBoard[2] == XorO && iBoard[3] == XorO) || (iBoard[4] == XorO && iBoard[8] == XorO && iBoard[12] == XorO) || (iBoard[5] == XorO && iBoard[10] == XorO && iBoard[15] == XorO)))
                    iLastMove = 0;
                else if (iBoard[1] == 0 && ((iBoard[0] == XorO && iBoard[2] == XorO && iBoard[3] == XorO) || (iBoard[5] == XorO && iBoard[9] == XorO && iBoard[13] == XorO)))
                    iLastMove = 1;
                else if (iBoard[2] == 0 && ((iBoard[0] == XorO && iBoard[1] == XorO && iBoard[3] == XorO) || (iBoard[6] == XorO && iBoard[10] == XorO && iBoard[14] == XorO)))
                    iLastMove = 2;
                else if (iBoard[3] == 0 && ((iBoard[0] == XorO && iBoard[1] == XorO && iBoard[2] == XorO) || (iBoard[7] == XorO && iBoard[11] == XorO && iBoard[15] == XorO) || (iBoard[6] == XorO && iBoard[9] == XorO && iBoard[12] == XorO)))
                    iLastMove = 3;
                //Drugi Wiersz [4,5,6,7]
                else if (iBoard[4] == 0 && ((iBoard[5] == XorO && iBoard[6] == XorO && iBoard[7] == XorO) || (iBoard[0] == XorO && iBoard[8] == XorO && iBoard[12] == XorO)))
                    iLastMove = 4;
                else if (iBoard[5] == 0 && ((iBoard[4] == XorO && iBoard[6] == XorO && iBoard[7] == XorO) || (iBoard[1] == XorO && iBoard[9] == XorO && iBoard[13] == XorO)))
                    iLastMove = 5;
                else if (iBoard[6] == 0 && ((iBoard[4] == XorO && iBoard[5] == XorO && iBoard[7] == XorO) || (iBoard[2] == XorO && iBoard[10] == XorO && iBoard[14] == XorO)))
                    iLastMove = 6;
                else if (iBoard[7] == 0 && ((iBoard[4] == XorO && iBoard[5] == XorO && iBoard[6] == XorO) || (iBoard[3] == XorO && iBoard[11] == XorO && iBoard[15] == XorO)))
                    iLastMove = 7;
                //Trzeci Wiersz [8,9,10,11]
                else if (iBoard[8] == 0 && ((iBoard[9] == XorO && iBoard[10] == XorO && iBoard[11] == XorO) || (iBoard[0] == XorO && iBoard[4] == XorO && iBoard[12] == XorO)))
                    iLastMove = 8;
                else if (iBoard[9] == 0 && ((iBoard[8] == XorO && iBoard[10] == XorO && iBoard[11] == XorO) || (iBoard[1] == XorO && iBoard[5] == XorO && iBoard[13] == XorO)))
                    iLastMove = 9;
                else if (iBoard[10] == 0 && ((iBoard[8] == XorO && iBoard[9] == XorO && iBoard[11] == XorO) || (iBoard[2] == XorO && iBoard[6] == XorO && iBoard[14] == XorO)))
                    iLastMove = 10;
                else if (iBoard[11] == 0 && ((iBoard[8] == XorO && iBoard[9] == XorO && iBoard[10] == XorO) || (iBoard[3] == XorO && iBoard[7] == XorO && iBoard[15] == XorO)))
                    iLastMove = 11;
                //Czwarty Wiersz [12,13,14,15]
                else if (iBoard[12] == 0 && ((iBoard[13] == XorO && iBoard[14] == XorO && iBoard[15] == XorO) || (iBoard[0] == XorO && iBoard[4] == XorO && iBoard[8] == XorO) || (iBoard[9] == XorO && iBoard[6] == XorO && iBoard[3] == XorO)))
                    iLastMove = 12;
                else if (iBoard[13] == 0 && ((iBoard[12] == XorO && iBoard[14] == XorO && iBoard[15] == XorO) || (iBoard[1] == XorO && iBoard[5] == XorO && iBoard[9] == XorO)))
                    iLastMove = 13;
                else if (iBoard[14] == 0 && ((iBoard[12] == XorO && iBoard[13] == XorO && iBoard[15] == XorO) || (iBoard[6] == XorO && iBoard[10] == XorO && iBoard[2] == XorO)))
                    iLastMove = 14;
                else if (iBoard[15] == 0 && ((iBoard[12] == XorO && iBoard[13] == XorO && iBoard[14] == XorO) || (iBoard[7] == XorO && iBoard[11] == XorO && iBoard[3] == XorO) || (iBoard[10] == XorO && iBoard[5] == XorO && iBoard[0] == XorO)))
                    iLastMove = 15;
            }
            else if(gameType == 7) // klein 3x3
            {
                /*       3x3           
                    [ 0, 1,  2 ]        x - -   - - x   x - -   - - x   - - x   x - -   x x -   - x x
                    [ 4, 5,  6 ]  	    x - -   - - x   - - -   - - -   x - -   - - x   - - -   - - -
                    [ 8, 9, 10 ]        - - x   x - -   - x x   x x -   x - -   - - x   - - x   x - - 
                 */
                //czy pusta [ 0, 1,  2 ]
                if (iBoard[0] == 0 && ((iBoard[4] == XorO && iBoard[10] == XorO) || (iBoard[9] == XorO && iBoard[10] == XorO) || (iBoard[6] == XorO && iBoard[10] == XorO)))
                    iLastMove = 0;
                if (iBoard[1] == 0 && ((iBoard[0] == XorO && iBoard[10] == XorO) || (iBoard[2] == XorO && iBoard[8] == XorO)))
                    iLastMove = 1;
                if (iBoard[2] == 0 && ((iBoard[6] == XorO && iBoard[8] == XorO) || (iBoard[8] == XorO && iBoard[9] == XorO) || (iBoard[1] == XorO && iBoard[8] == XorO)))
                    iLastMove = 2;
                //[ 4, 5,  6 ]
                if (iBoard[4] == 0 && ((iBoard[0] == XorO && iBoard[10] == XorO) || (iBoard[2] == XorO && iBoard[8] == XorO)))
                    iLastMove = 4;
                if (iBoard[6] == 0 && ((iBoard[2] == XorO && iBoard[8] == XorO) || (iBoard[0] == XorO && iBoard[10] == XorO)))
                    iLastMove = 6;
                //[ 8, 9, 10 ]
                if (iBoard[8] == 0 && ((iBoard[2] == XorO && iBoard[6] == XorO) || (iBoard[9] == XorO && iBoard[2] == XorO) || (iBoard[4] == XorO && iBoard[2] == XorO)))
                    iLastMove = 8;
                if (iBoard[9] == 0 && ((iBoard[0] == XorO && iBoard[10] == XorO) || (iBoard[8] == XorO && iBoard[2] == XorO)))
                    iLastMove = 9;
                if (iBoard[10] == 0 && ((iBoard[0] == XorO && iBoard[4] == XorO) || (iBoard[9] == XorO && iBoard[0] == XorO) || (iBoard[6] == XorO && iBoard[0] == XorO) || (iBoard[0] == XorO && iBoard[1] == XorO)))
                    iLastMove = 10;
            }
        }
        int RandomPosition4x4()
        {
            int Count = 0;
            for (int i = 0; i <= 15; i++)
            {
                if (iBoard[i] == 0)
                {
                    Count++;
                }
            }
            Random rnd = new Random();
            int iRandom = rnd.Next(1, Count);

            Count = 0;
            for (int i = 0; i <= 15; i++)
            {
                if (iBoard[i] == 0)
                {
                    Count++;
                    if (Count == iRandom)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        int RandomPosition3x3()
        {
            int Count = 0;
            for (int i = 0; i <= 15; i++)
            { 
                if ((i < 3 || i > 3 && i < 7 || i > 7 && i < 11) && iBoard[i] == 0)
                {
                    Count++;
                }
            }
            Random rnd = new Random();
            int iRandom = rnd.Next(1, Count);

            Count = 0;
            for (int i = 0; i <= 15; i++)
            {
                if ((i < 3 || i > 3 && i < 7 || i > 7 && i < 11) && iBoard[i] == 0)
                {
                    Count++;
                    if (Count == iRandom)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
               

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        #region Plansza
        private void Button0i0_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[0] == 0)
            {
                iLastMove = 0;
                iBoard[0] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }
        }

        private void Button0i1_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[1] == 0)
            {
                iLastMove = 1;
                iBoard[1] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }
        }

        private void Button0i2_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[2] == 0)
            {
                iLastMove = 2;
                iBoard[2] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }
        }

        private void Button0i3_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[3] == 0 && field_Count == 15)
            {
                iLastMove = 3;
                iBoard[3] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }

        }

        private void Button1i0_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[4] == 0)
            {
                iLastMove = 4;
                iBoard[4] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }
        }

        private void Button1i1_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[5] == 0)
            {
                iLastMove = 5;
                iBoard[5] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }
        }

        private void Button1i2_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[6] == 0)
            {
                iLastMove = 6;
                iBoard[6] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }
        }

        private void Button1i3_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[7] == 0 && field_Count == 15)
            {
                iLastMove = 7;
                iBoard[7] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }
        }

        private void Button2i0_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[8] == 0)
            {
                iLastMove = 8;
                iBoard[8] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }
        }
        private void Button2i1_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[9] == 0)
            {
                iLastMove = 9;
                iBoard[9] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }
        }

        private void Button2i2_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[10] == 0)
            {
                iLastMove = 10;
                iBoard[10] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }
        }
        private void Button2i3_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[11] == 0 && field_Count == 15)
            {
                iLastMove = 11;
                iBoard[11] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }
        }
        private void Button3i0_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[12] == 0 && field_Count == 15)
            {
                iLastMove = 12;
                iBoard[12] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }
        }
        private void Button3i1_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[13] == 0 && field_Count == 15)
            {
                iLastMove = 13;
                iBoard[13] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }
        }
        private void Button3i2_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[14] == 0 && field_Count == 15)
            {
                iLastMove = 14;
                iBoard[14] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }
        }
        private void Button3i3_Click(object sender, RoutedEventArgs e)
        {
            if (iTurn == 0 || bEnableBot)
                return;

            if (iBoard[15] == 0 && field_Count == 15)
            {
                iLastMove = 15;
                iBoard[15] = iTurn;
                ChangeButtonBackgroundImage(iLastMove);
                SetNextTurn();
                RunBot();
            }
        }
        #endregion
                
        void Restart(int fieldCount )
        {
            movementCounter = 0;
            SolidColorBrush color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF92BAF7"));

            if (fieldCount == 15)
            {
                for (int i = 0; i <= 15; i++)
                {
                    iBoard[i] = 0;
                }
                Button0i3.Background = color;
                Button1i3.Background = color;
                Button2i3.Background = color;
                Button3i0.Background = color;
                Button3i1.Background = color;
                Button3i2.Background = color;
                Button3i3.Background = color;
            }
            else if(fieldCount == 8)
            {
                for (int i = 0; i <= 15; i++)
                {
                    if(i < 3) iBoard[i] = 0;
                    if (i > 3 && i < 7) iBoard[i] = 0;
                    if (i > 7 && i < 11) iBoard[i] = 0;
                }
            }
            StatusLabel.Content = "Game Status";
            iLastMove = -1;
            
            bEnableBot = false;            
            
            //X first
            iTurn = 1;
            SetNextTurn();           
           
            Button0i0.Background = color;
            Button0i1.Background = color;
            Button0i2.Background = color;            
            Button1i0.Background = color;
            Button1i1.Background = color;
            Button1i2.Background = color;            
            Button2i0.Background = color;
            Button2i1.Background = color;
            Button2i2.Background = color;            
           
        }        
             
        private void KleinButton(object sender, RoutedEventArgs e)
        {
            TitleLabel.Content = "Klein Bottle";
            field_Count = 8;
            Restart(field_Count);
            gameType_stat = 7;

            SolidColorBrush color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b50e0e"));

            Button0i3.Background = color;
            Button1i3.Background = color;
            Button2i3.Background = color;
            Button3i0.Background = color;
            Button3i1.Background = color;
            Button3i2.Background = color;
            Button3i3.Background = color;
        }

        private void game3x3(object sender, RoutedEventArgs e)
        {
            TitleLabel.Content = "3x3";
            field_Count = 8;
            gameType_stat = 1;
            Restart(field_Count);
            
            SolidColorBrush color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b50e0e"));

            Button0i3.Background = color;
            Button1i3.Background = color;
            Button2i3.Background = color;
            Button3i0.Background = color;
            Button3i1.Background = color;
            Button3i2.Background = color;
            Button3i3.Background = color;                      
            
        }

        private void game4x4(object sender, RoutedEventArgs e)
        {
            TitleLabel.Content = "4x4";
            field_Count = 15;
            gameType_stat = 2;
            Restart(field_Count);
        }

        private void pvpEnbale(object sender, RoutedEventArgs e)
        {
            iType = 3;
            pvpflag = true;
            Restart(field_Count);
        }

        private void pvpdisable(object sender, RoutedEventArgs e)
        {            
            iType = 1;
            pvpflag = false;
            Restart(field_Count);
        }

        
    }
}
