using System;

namespace RESTFulExample.BLL.Infrastructure
{
    public class BusinessLogicException : ApplicationException
    {
        public string Property { get; protected set; }
        public BusinessLogicException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
