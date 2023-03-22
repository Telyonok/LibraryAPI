﻿namespace Library.Domain.Exceptions
{
    [Serializable]
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException()
        {   
        }

        public EntityAlreadyExistsException(string message) : base(message)
        {
        }
    }
}