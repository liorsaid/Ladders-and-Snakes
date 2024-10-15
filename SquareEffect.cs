using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAssignment_LiorSaid
{
    public interface SquareEffect : DisplayableObject
    {
        public void PerformEffect(Player i_playerToPerformEffect, Player i_secondPlayer);
    }
}
