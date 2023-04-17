namespace Library.DomainLayer.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        { }

        public EntityNotFoundException(string message) : base(message)
        { }
    }
}
