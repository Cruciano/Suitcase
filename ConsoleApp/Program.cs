﻿using System;
using System.Collections.Generic;
using Suitcase;
using Suitcase.Implementation.ChainOfResponsibility;
using Suitcase.Interfaces;
using Suitcase.Implementation.Composite;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ISuitcase suitcase = new Pocket("Suitcase", AnimalType.AnyType, null);
            suitcase.DayTime = DayTime.Day;
            
            IComponent comufloraPocket = new Pocket("comufloraPocket", AnimalType.Comuflora, suitcase);
            suitcase.Add(comufloraPocket);
            
            IRandomFactory comufloraFactory = new ComufloraFactory();
            IRandomFactory occamFactory = new OccamFactory();
            IRandomFactory lichurkaFactory = new LichurkaFactory();

            comufloraFactory.Factory = occamFactory;
            occamFactory.Factory = lichurkaFactory;

            for (int i = 0; i < 10;  i++) 
            {
                var random = new Random().Next(100);
                var randomAnimal = comufloraFactory.Create(random, suitcase);

                suitcase.Add(randomAnimal);
            }

            Console.WriteLine(suitcase.Scream(null));
        }
    }
}