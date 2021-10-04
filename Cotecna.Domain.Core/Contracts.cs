using System;
using System.Runtime.Serialization;

namespace Cotecna.Domain.Core
{

    /// <summary>
    /// Defines a contract about an invariant that has to be complied
    /// </summary>
    public static class Contracts
    {
        /// <summary>
        /// Specify the requireness of an invariant condition to be met
        /// </summary>
        /// <param name="precondition">Condition to met</param>
        /// <param name="message">Message to show when the invariant has not been met</param>
        public static void Require(bool precondition, string message = "")
        {
            if (!precondition)
                throw new ContractException(message);
        }

        /// <summary>
        /// Custom exception for a contract invariant that has not been complied
        /// </summary>
        [Serializable]
        public class ContractException : Exception
        {
            /// <summary>
            /// Custom exception constructor to raise for a contract invariant not met
            /// </summary>
            public ContractException() { }

            /// <summary>
            /// Custom exception constructor to raise for a contract invariant not met
            /// </summary>
            /// <param name="message">Message about the invariant not met</param>
            public ContractException(string message)
                : base(message)
            { }

            /// <summary>
            /// Custom exception constructor to raise for a contract invariant not met
            /// </summary>
            /// <param name="message">Message about the invariant not met</param>
            /// <param name="inner">Inner exception</param>
            public ContractException(string message, Exception inner)
                : base(message, inner)
            { }

            protected ContractException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            { }

        }
    }
}
