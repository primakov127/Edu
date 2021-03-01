using Design_Patterns.Patterns.Abstract_Factory;
using Design_Patterns.Patterns.Abstract_Factory.Factories;
using System;
using System.Linq;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new EconomyCarFactory());
            var economyCarEquipment = manager.Make();
            Console.WriteLine("Economy car equipment:");
            economyCarEquipment.ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine();

            manager.ChangeCarFacory(new StandardCarFactory());
            var standardCarEquipment = manager.Make();
            Console.WriteLine("Economy car equipment:");
            standardCarEquipment.ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine();

            manager.ChangeCarFacory(new ExtraCarFactory());
            var extraCarEquipment = manager.Make();
            Console.WriteLine("Economy car equipment:");
            extraCarEquipment.ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine();
        }
    }
}
