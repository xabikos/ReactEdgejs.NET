using System;
using System.Runtime.Serialization;

namespace ReactEdge.Exceptions
{
	/// <summary>
	/// Thrown when the React npm package is not installed
	/// </summary>
	[Serializable]
	public class ReactNotInstalledException : ReactEdgeException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ReactNotInstalledException"/> class.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public ReactNotInstalledException(string message) : base(message) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ReactNotInstalledException"/> class.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
		public ReactNotInstalledException(string message, Exception innerException)
			: base(message, innerException) { }

		/// <summary>
		/// Initializes a new instance of the System.Exception class with serialized data.
		/// </summary>
		/// <param name="info">The System.Runtime.Serialization.SerializationInfo that holds the serialized
		/// object data about the exception being thrown.</param>
		/// <param name="context">The System.Runtime.Serialization.StreamingContext that contains contextual information
		/// about the source or destination.</param>
		protected ReactNotInstalledException(SerializationInfo info, StreamingContext context)
			: base(info, context) { }
	}
}
