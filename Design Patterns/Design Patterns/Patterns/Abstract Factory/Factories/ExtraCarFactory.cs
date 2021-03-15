using Design_Patterns.Patterns.Abstract_Factory.Abstract;
using Design_Patterns.Patterns.Abstract_Factory.Equipment.Engines;
using Design_Patterns.Patterns.Abstract_Factory.Equipment.Suspensions;
using Design_Patterns.Patterns.Abstract_Factory.Equipment.Wheels;

namespace Design_Patterns.Patterns.Abstract_Factory.Factories
{
    public class ExtraCarFactory : ICarFactory
    {
        public Engine CreateEngine()
        {
            return new ExtraEngine();
        }

        public Suspension CreateSuspension()
        {
            return new ExtraSuspension();
        }

        public Wheel CreateWheel()
        {
            return new ExtraWheel();
        }
    }
}
