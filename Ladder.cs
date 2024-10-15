using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAssignment_LiorSaid
{
    public class Ladder : SquareEffect
    {
        private int m_LadderStartPosition;
        private int m_LadderEndPosition;
        
        public int LadderStartPosition
        {
            get
            {
                return m_LadderStartPosition;
            }
        }

        public int LadderEndPosition
        {
            get
            {
                return m_LadderEndPosition;
            }
        }

        public Ladder(int i_LadderStartPosition, int i_LadderEndPosition)
        {
            m_LadderStartPosition = i_LadderStartPosition;
            m_LadderEndPosition = i_LadderEndPosition;
        }

        public void PerformEffect(Player i_playerToPerformEffect, Player i_secondPlayer)
        {
            i_playerToPerformEffect.CurrentPlayerPosition = LadderEndPosition;
            Console.WriteLine("{0} moved up to square {1}", i_playerToPerformEffect.PlayerName, LadderEndPosition);
        }

        public void Display(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            Console.Write("Ladder -> {0}", LadderEndPosition);
        }
    }
}
