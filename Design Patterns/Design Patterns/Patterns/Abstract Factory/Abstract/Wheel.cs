namespace Design_Patterns.Patterns.Abstract_Factory.Abstract
{
    public abstract class Wheel
    {
        private readonly int _wheelDiameter;

        protected Wheel(int wheelDiameter)
        {
            _wheelDiameter = wheelDiameter;
        }

        public override string ToString()
        {
            return $"Wheel diameter: {_wheelDiameter}";
        }
    }
}
