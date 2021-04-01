namespace Design_Patterns.Patterns.Abstract_Factory.Abstract
{
    public interface ICarFactory
    {
        Engine CreateEngine();
        Wheel CreateWheel();
        Suspension CreateSuspension();
    }
}
