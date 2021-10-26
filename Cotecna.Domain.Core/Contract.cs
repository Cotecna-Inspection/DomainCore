
using System;
using System.Runtime.Serialization;

namespace Cotecna.Domain.Core
{
    /// <summary>
    /// Represents a <see cref="Contract"/> about an invariant that has to be complied
    /// </summary>
    public static class Contract
    {
        /// <summary>
        /// Specify the requireness of an invariant condition to be met. Throws <see cref="ContractException"/>
        /// </summary>
        /// <param name="precondition">Pre-Condition to met</param>
        /// <param name="message">Message to show when the invariant has not been met. Optional. Default as Empty</param>
        public static void Require(bool precondition, string message = "")
        {
            if (!precondition)
                throw new ContractException(message);
        }

        /// <summary>
        /// Represents a Serializable <see cref="ContractException"/> for a contract invariant that has not been complied. Inherirts from <see cref="Exception"/>
        /// </summary>
        [Serializable]
        public class ContractException : Exception
        {

            /// <summary>
            /// Initializes a <see cref="ContractException"/> to raise for a contract invariant not met
            /// </summary>
            public ContractException() { }

            /// <summary>
            ///Initializes a <see cref="ContractException"/> to raise for a contract invariant not met
            /// </summary>
            /// <param name="message">Message about the invariant not met</param>
            public ContractException(string message)
                : base(message)
            { }

            /// <summary>
            /// Initializes a <see cref="ContractException"/> to raise for a contract invariant not met
            /// </summary>
            /// <param name="message">Message about the invariant not met</param>
            /// <param name="inner">Inner <see cref="Exception"/></param>
            public ContractException(string message,
                                     Exception inner)
                : base(message, inner)
            { }

            /// <summary>
            /// Initializes a <see cref="ContractException"/> to raise for a contract invariant not met
            /// </summary>
            /// <param name="info"><see cref="SerializationInfo"/> of the contract invariant not met</param>
            /// <param name="context"><see cref="StreamingContext"/> of the contract invariant not met</param>
            protected ContractException(SerializationInfo info,
                                        StreamingContext context)
                : base(info, context)
            { }

        }

    }
}
