using System;

namespace Application.Client.Core.AppCacheStorage.Exceptions
{
    public class CacheItemNotExistException : Exception
    {
        public CacheItemNotExistException()
        { }

        public CacheItemNotExistException(string message) : base(message)
        { }

        public CacheItemNotExistException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
