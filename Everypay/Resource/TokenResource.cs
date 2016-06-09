using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;

namespace Everypay
{
	public class TokenResource : Resource
	{
		public Token getObject()
		{
			return JsonConvert.DeserializeObject<Token>(responseContent);
		}

		public new void list(Dictionary<string, string> data = null)
		{
			string message = "Resource `Token` does not support `list` method";
			throw new MethodNotAllowedException (message);
		}

		public new void update(string token, Dictionary<string, string> data = null)
		{
			string message = "Resource `Token` does not support `update` method";
			throw new MethodNotAllowedException (message);
		}

		public new void delete(string token)
		{
			string message = "Resource `Token` does not support `delete` method";
			throw new MethodNotAllowedException (message);
		}

		protected override string getResource()
		{
			return "tokens";
		}
	}
}

