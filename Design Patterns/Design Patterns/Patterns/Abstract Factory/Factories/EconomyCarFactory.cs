using Design_Patterns.Patterns.Abstract_Factory.Abstract;
using Design_Patterns.Patterns.Abstract_Factory.Equipment.Engines;
using Design_Patterns.Patterns.Abstract_Factory.Equipment.Suspensions;
using Design_Patterns.Patterns.Abstract_Factory.Equipment.Wheels;
using System;

namespace Design_Patterns.Patterns.Abstract_Factory.Factories
{
    public class EconomyCarFactory : ICarFactory
    {
        public Engine CreateEngine()
        {
            return new EconomyEngine();
        }

        public Suspension CreateSuspension()
        {
            return new EconomySuspension();
        }

        public Wheel CreateWheel()
        {
            return new EconomyWheel();
        }
    }
}
