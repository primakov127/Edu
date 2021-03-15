using Design_Patterns.Patterns.Abstract_Factory.Abstract;
using System.Collections;
using System.Collections.Generic;

namespace Design_Patterns.Patterns.Abstract_Factory
{
    public class Manager
    {
        private ICarFactory _carFactory;

        public Manager(ICarFactory carFactory)
        {
            _carFactory = carFactory;
        }

        public void ChangeCarFacory(ICarFactory carFactory)
        {
            _carFactory = carFactory;
        }

        public List<object> Make()
        {
            Engine engine = _carFactory.CreateEngine();
            Wheel wheel = _carFactory.CreateWheel();
            Suspension suspension = _carFactory.CreateSuspension();

           return new List<object> {engine, wheel, suspension};
        }
    }
}
