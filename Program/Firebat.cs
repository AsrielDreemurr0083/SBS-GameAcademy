using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Firebat : Unit
    {
        public Firebat() 
        {
            health = 50;
            attack = 7;
            defense = 1;
        }

        new public void Skill()
        {
            Console.WriteLine("StimPack");
        }

        override public void Show()
        {
            Console.WriteLine("health 변수의 값 : " + health);
            Console.WriteLine("health 변수의 값 : " + attack);
            Console.WriteLine("health 변수의 값 : " + defense);
        }

    }
}
