using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAssignment_LiorSaid
{
    public class GameLogic
    {
        public void StartGame(int i_NumberOfSnakes, int i_NumberOfLadders, Player i_FirstPlayer, Player i_SecondPlayer, int i_PlayerTurn)
        {
            BoardFactory boardFactory = new BoardFactory();
            Board board = boardFactory.CreateBoard(i_NumberOfSnakes, i_NumberOfLadders);

            while (i_FirstPlayer.CurrentPlayerPosition < 100 && i_SecondPlayer.CurrentPlayerPosition < 100)
            {
                board.Display(i_FirstPlayer, i_SecondPlayer);
                Console.WriteLine();
                if (i_PlayerTurn % 2 == 1)
                {
                    Console.WriteLine("Its {0} turn! Press any key and than press ENTER to roll a dice!", i_FirstPlayer.PlayerName);
                    string? playerInput = Console.ReadLine();

                    performTurn(board, i_FirstPlayer, i_SecondPlayer);
                    i_PlayerTurn = 0;
                }
                else
                {
                    Console.WriteLine("Its {0} turn! Press any key to roll a dice!", i_SecondPlayer.PlayerName);
                    string? playerPressEnter = Console.ReadLine();

                    performTurn(board, i_SecondPlayer, i_FirstPlayer);
                    i_PlayerTurn++;
                }
            }

            declareWinner(i_FirstPlayer, i_SecondPlayer);
            board.Display(i_FirstPlayer, i_SecondPlayer);
        }
        
        private void performTurn(Board i_Board, Player i_CurrentPlayer, Player i_SecondPlayer)
        {
            Dice dice = new Dice();
            int firstDiceRoll = dice.Roll(6);
            int secondDiceRoll = dice.Roll(6);
            int playerCurrentPosition = i_CurrentPlayer.CurrentPlayerPosition;

            Console.WriteLine("The first roll is: " + firstDiceRoll);
            Console.WriteLine("The second roll is: " + secondDiceRoll);
            Console.WriteLine();
            playerCurrentPosition += (firstDiceRoll + secondDiceRoll);
            i_CurrentPlayer.CurrentPlayerPosition = playerCurrentPosition;
            if (i_CurrentPlayer.CurrentPlayerPosition < 100)
            {
                i_Board.SquaresArray[playerCurrentPosition].SquareEffect?.PerformEffect(i_CurrentPlayer, i_SecondPlayer);
            }
        }

        private void declareWinner(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            if (i_FirstPlayer.CurrentPlayerPosition >= 100)
            {
                i_FirstPlayer.CurrentPlayerPosition = 100;
                Console.WriteLine("{0} is the WINNER!", i_FirstPlayer.PlayerName);
            }
            else
            {
                i_SecondPlayer.CurrentPlayerPosition = 100;
                Console.WriteLine("{0} is the WINNER!", i_SecondPlayer.PlayerName);
            }

            Console.WriteLine();
        }
    }
}
