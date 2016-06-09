using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Everypay
{
	public class Error
	{
		public string status { get;}

		public string code { get;}

		public string message { get;}

		public Error(JObject data)
		{
			status = data["error"]["status"].Value<string>();
			code = data["error"]["code"].Value<string> ();
			message = data["error"]["message"].Value<string> ();
		}
	}
}