﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class8th__Polymorphism_
{
    internal class Ghost : Unit
    {
        public Ghost() 
        {
            health = 45;
            attack = 8;
            defense = 0;
        }

        new public void Skill()
        {
            Console.WriteLine("Lock Down");
        }

        override public void Show()
        {
            Console.WriteLine("health 변수의 값 : " + health);
            Console.WriteLine("health 변수의 값 : " + attack);
            Console.WriteLine("health 변수의 값 : " + defense);
        }
    }
}
