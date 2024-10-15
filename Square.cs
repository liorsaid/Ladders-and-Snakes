using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAssignment_LiorSaid
{
    public class Square : DisplayableObject
    {
        private readonly int r_SquareNumber;
        private readonly SquareEffect? r_SquareEffect;

        public Square(int i_SquareNumber, SquareEffect? i_SquareEffect)
        {
            r_SquareNumber = i_SquareNumber;
            r_SquareEffect = i_SquareEffect;
        }

        public int SquareNumber
        {
            get
            {
                return r_SquareNumber;
            }
        }
        
        public SquareEffect? SquareEffect
        {
            get
            {
                return r_SquareEffect;
            }
        }

        public void Display(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            Console.Write("({0}", SquareNumber);
            if(SquareEffect != null)
            {
                Console.Write(",");
                SquareEffect?.Display(i_FirstPlayer, i_SecondPlayer);
            }
            if(i_FirstPlayer.CurrentPlayerPosition == SquareNumber)
            {
                Console.Write(",");
                i_FirstPlayer.Display(i_FirstPlayer, i_SecondPlayer);
            }
            if(i_SecondPlayer.CurrentPlayerPosition == SquareNumber)
            {
                Console.Write(",");
                i_SecondPlayer.Display(i_FirstPlayer, i_SecondPlayer);
            }

            Console.Write(")");
        }
    }
}
