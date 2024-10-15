using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAssignment_LiorSaid
{
    public class Dice
    {
        private Random m_Random;

        public Dice() 
        {
            m_Random = new Random();
        }

        public int Roll(int x)
        {
            return m_Random.Next(1, x + 1);
        }
    }
}
