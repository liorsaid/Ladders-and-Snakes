using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAssignment_LiorSaid
{
    public class Board : DisplayableObject
    {
        private readonly Square[] r_SquaresArray;
        
        public Square[] SquaresArray
        {
            get
            {
                return r_SquaresArray;
            }
        }
        
        public Board(Square[] i_SquaresArray)
        {
            r_SquaresArray = i_SquaresArray;
        }
        
        public void Display(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            int currentSquareNumber = SquaresArray.Length - 1;
            int rowNumber = 1;
            
            while (currentSquareNumber > 0)
            {
                for (int rowCounter = 0; rowCounter < 10; rowCounter++)
                {
                    SquaresArray[currentSquareNumber].Display(i_FirstPlayer, i_SecondPlayer);
                    Console.Write("|");
                    if (rowCounter != 9)
                    {
                        if (rowNumber % 2 == 1)
                        {
                            currentSquareNumber--;
                        }
                        else
                        {
                            currentSquareNumber++;
                        }
                    }
                }
                
                Console.WriteLine();
                currentSquareNumber -= 10;
                rowNumber++;
            }

            Console.Write("");
        }
    }
}
