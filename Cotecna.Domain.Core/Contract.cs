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
    }
}
