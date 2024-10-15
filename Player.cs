using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAssignment_LiorSaid
{
    public class Player
    {
        private readonly string r_PlayerName;
        private int m_PlayerCurrentPosition;
        
        public string PlayerName
        {
            get
            {
                return r_PlayerName; 
            }
        }

        public int CurrentPlayerPosition
        {
            get
            {
                return m_PlayerCurrentPosition;
            }

            set
            {
                m_PlayerCurrentPosition = value;
            }   
        }
        
        public Player(string playerName)
        {
            r_PlayerName = playerName;
            m_PlayerCurrentPosition = 1;
        }
        
        public void Display(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            Console.Write(PlayerName);
        }
    }
}   
