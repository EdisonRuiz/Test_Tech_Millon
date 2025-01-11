namespace Test.Millon.Core.Exceptions
{
    public class PropertyNotFoundException : Exception
    {
        public PropertyNotFoundException(int id) : base($"La propiedad con ID {id} no se encontró.") { }
    }
}
