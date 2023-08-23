using System;
using System.Runtime.Serialization;

namespace Zola.MsfClient.Authentication
{
	public class TokenRetrievalException : Exception
	{
        public TokenRetrievalException(int type, string message) : base(message)
        {
            Type = type;
        }

        public TokenRetrievalException(int type, string message, Exception? innerException) : base(message, innerException)
        {
            Type = type;
        }

        public int Type { get; }
    }
}

