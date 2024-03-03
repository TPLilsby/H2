using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartMaster
{
    public interface IGame
    {
        void StartGame();
        void PlayGame(Dartboard dartboard);
    }
}
