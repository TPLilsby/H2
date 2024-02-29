using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjælpTilLone
{
    public interface ICharacter
    {
        public void Die();
        public void Fight();
        public void Heal();
    }
}
