namespace Design_Patterns.Patterns.Abstract_Factory.Abstract
{
    public abstract class Engine
    {
        private readonly string _engineType;

        protected Engine(string engineType)
        {
            _engineType = engineType;
        }

        public override string ToString()
        {
            return $"Engine type: {_engineType}";
        }
    }
}
