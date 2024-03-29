﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjælpTilLone
{
    public class Character
    {
        public class Wizard : ICharacter, IGetTeleport, ICanThrow
        {
            public void Die()
            {
                Console.WriteLine("I'm dying");
            }

            public void Fight()
            {
                Console.WriteLine("I'm fighting");
            }

            public void Heal()
            {
                Console.WriteLine("I'm healing");
            }

            public void Teleport(int x, int y)
            {
                Console.WriteLine("I'm teleporting to " + x + " " + y);
            }

            public void ThrowFrostNova()
            {
                Console.WriteLine("I'm throwing my frost nova");
            }

            public void ThrowMagicMisile()
            {
                Console.WriteLine("I'm throwing a magic misile");
            }
        }




        public class Babarian : ICharacter, IGetBash, IGetCleave, IGetSlash
        {
            public void Bash()
            {
                Console.WriteLine("I'm bashing someone");
            }
            public void Cleave()
            {
                Console.WriteLine("I'm cleaving someone");
            }

            public void Die()
            {
                Console.WriteLine("I'm dying");
            }

            public void Fight()
            {
                Console.WriteLine("I'm fighting");
            }

            public void Heal()
            {
                Console.WriteLine("I'm healing");
            }

            public void Slash()
            {
                Console.WriteLine("I'm slashing someone");
            }
        }




        public class Knight : ICharacter, IGetBash, IGetCleave, IGetSlash, IGetShield
        {
            public void Bash()
            {
                Console.WriteLine("I'm bashing someone");
            }

            public void Cleave()
            {
                Console.WriteLine("I'm cleaving someone");
            }

            public void Die()
            {
                Console.WriteLine("I'm dying");
            }

            public void Fight()
            {
                Console.WriteLine("I'm fighting");
            }

            public void Heal()
            {
                Console.WriteLine("I'm healing");
            }

            public void RaiseShield()
            {
                Console.WriteLine("I'm raising my shield");
            }

            public void ShieldGlare()
            {
                Console.WriteLine("I'm throwing shield glare");
           }

            public void Slash()
            {
                Console.WriteLine("I'm slashing someone");
            }
        }



        public class Witch : ICharacter, IGetShield, IGetTeleport
        {

            public void Die()
            {
                Console.WriteLine("I'm dying");
            }

            public void Fight()
            {
                Console.WriteLine("I'm fighting");
            }

            public void Heal()
            {
                Console.WriteLine("I'm healing");
            }

            public void RaiseShield()
            {
                Console.WriteLine("I'm raising my shield");
            }

            public void ShieldGlare()
            {
                Console.WriteLine("I'm throwing shield glare");
            }

            public void Teleport(int x, int y)
            {
                Console.WriteLine("I'm teleporting to " + x + " " + y);
            }
        }
    }
}
