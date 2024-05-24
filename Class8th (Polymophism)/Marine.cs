using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Class8th__Polymorphism_
{
    internal class Marine : Unit
    {
        private int stimPack;

        public Marine() 
        {
            health = 40;
            attack = 5;
            defense = 0;

            stimPack = 5;

            Console.WriteLine("Create Marine");
        } 

        new public void Skill()
        {
            Console.WriteLine("Stimpack");
        }

        override public void Show()
        {
            Console.WriteLine("health 변수의 값 : " + health);
            Console.WriteLine("health 변수의 값 : " + attack);
            Console.WriteLine("health 변수의 값 : " + defense);
        }
    }
}
