using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeAssignment_LiorSaid
{
    public class Snake : SquareEffect
    {
        private int m_SnakeHeadPosition;
        private int m_SnakeTailPosition;

        public int SnakeHeadPosition
        {
            get
            {
                return m_SnakeHeadPosition;
            }
        }

        public int SnakeTailPosition
        {
            get 
            {
                return m_SnakeTailPosition; 
            }
        }

        public Snake(int i_SnakeHeadPosition, int i_SnakeTailPosition)
        {
            m_SnakeHeadPosition = i_SnakeHeadPosition;
            m_SnakeTailPosition = i_SnakeTailPosition;
        }
        public void PerformEffect(Player i_playerToPerformEffect, Player i_secondPlayer)
        {
            i_playerToPerformEffect.CurrentPlayerPosition = SnakeTailPosition;
            Console.WriteLine("{0} moved down to square {1}", i_playerToPerformEffect.PlayerName, SnakeTailPosition);
        }
        
        public void Display(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            Console.Write("Snake -> {0}", SnakeTailPosition);
        }
    }
}


