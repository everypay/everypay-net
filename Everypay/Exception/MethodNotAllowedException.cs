using System;

namespace Everypay
{
	public class MethodNotAllowedException : Exception
	{
		public MethodNotAllowedException ()
		{
		}

		public MethodNotAllowedException (string message) : base(message)
		{
		}
	}
}

