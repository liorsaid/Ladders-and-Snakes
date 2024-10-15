using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAssignment_LiorSaid
{
    public class GoldSquare : SquareEffect
    {
        public GoldSquare()
        {

        }
        
        public void PerformEffect(Player i_playerToPerformEffect, Player i_secondPlayer)
        {
            if(i_playerToPerformEffect.CurrentPlayerPosition < i_secondPlayer.CurrentPlayerPosition)
            {
                int playerToEffectPosition = i_playerToPerformEffect.CurrentPlayerPosition;

                i_playerToPerformEffect.CurrentPlayerPosition = i_secondPlayer.CurrentPlayerPosition;
                i_secondPlayer.CurrentPlayerPosition = playerToEffectPosition;
                Console.WriteLine("{0} reached a gold square ,Change positions!", i_playerToPerformEffect.PlayerName);
            }
        }
        
        public void Display(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            Console.Write("Gold Square");
        }
    }
}
