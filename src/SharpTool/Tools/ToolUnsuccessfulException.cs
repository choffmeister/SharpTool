using System;
using System.Runtime.Serialization;

namespace SharpTool.Tools
{
    /// <summary>
    /// Exception that indicates that a <see cref="ITool"/> implementation could
    /// not finish successfully.
    /// </summary>
    [Serializable]
    public class ToolUnsuccessfulException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolUnsuccessfulException"/> class
        /// </summary>
        public ToolUnsuccessfulException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolUnsuccessfulException"/> class
        /// </summary>
        /// <param name="message">A <see cref="System.String"/> that describes the exception. </param>
        public ToolUnsuccessfulException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolUnsuccessfulException"/> class
        /// </summary>
        /// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
        /// <param name="inner">The exception that is the cause of the current exception. </param>
        public ToolUnsuccessfulException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolUnsuccessfulException"/> class
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected ToolUnsuccessfulException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
