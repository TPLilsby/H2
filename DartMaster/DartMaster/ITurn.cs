using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartMaster
{
    public interface ITurn
    {
        void NextTurn();
        void PlayTurn(Player player, Dartboard dartboard);
    }
}
