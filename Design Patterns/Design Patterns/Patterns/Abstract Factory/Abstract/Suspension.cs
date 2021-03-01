namespace Design_Patterns.Patterns.Abstract_Factory.Abstract
{
    public abstract class Suspension
    {
        private readonly string _suspensionType;

        protected Suspension(string suspensionType)
        {
            _suspensionType = suspensionType;
        }

        public override string ToString()
        {
            return $"Suspension type: {_suspensionType}";
        }
    }
}
