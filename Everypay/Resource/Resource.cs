using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Everypay
{
	public abstract class Resource
	{
		protected JObject responseObject;

		protected string responseContent;

		protected Error errorObject = null;

		protected abstract string getResource ();

		public string getResponse()
		{
			return responseContent;
		}

		public void create(Dictionary<string, string> data = null)
		{
			invoke (HttpMethod.Post, data);
		}

		public void list(Dictionary<string, string> data = null)
		{
			invoke (HttpMethod.Get, data);
		}

		public void update(string token, Dictionary<string, string> data = null)
		{
			if (null == data) {
				data = new Dictionary<string, string> ();
			}
			data.Add ("token", token);

			invoke (HttpMethod.Put, data);
		}

		public void delete(string token)
		{
			Dictionary<string, string> data = new Dictionary<string, string> ();
			data.Add ("token", token);

			invoke (HttpMethod.Delete, data);
		}

		public void retrieve(string token)
		{
			Dictionary<string, string> data = new Dictionary<string, string> ();
			data.Add("token", token);

			invoke (HttpMethod.Get, data);
		}

		public Error getError()
		{
			return errorObject;
		}

		public bool success()
		{
			return null == errorObject;
		}
			
		protected string invoke(HttpMethod method, Dictionary<string, string> data = null)
		{
			reset ();

			string uri = getEndpoint ();

			if (data.ContainsKey ("namespace")) {
				uri = uri + "/" + data ["namespace"];
			}

			if (data.ContainsKey("token") && method == HttpMethod.Get) {
				uri = uri + "/" + data ["token"];
				data.Remove ("token");
			}

			if (method == HttpMethod.Get && data.Count > 0) {
				uri = uri + "?" + getQueryString (data);
			}

			HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create (uri);
			request.Method = method.ToString ();
			request.ContentLength = 0;
			request.UserAgent = "EveryPay .NET Library " + Everypay.getVersion();
			string authorization = Everypay.apiKey + ":";
			string authorizationHeader = "Basic " + Convert.ToBase64String (Encoding.UTF8.GetBytes(authorization));
			request.Headers ["Authorization"] = authorizationHeader;

			if (method == HttpMethod.Post) {
				string postData = getQueryString(data);
				request.ContentType = "application/x-www-form-urlencoded";
				request.ContentLength = postData.Length;

				StreamWriter s = new StreamWriter(request.GetRequestStream ());
				s.Write (postData);
				s.Flush ();
				s.Close ();
			}

			var responseBody = string.Empty;
			HttpWebResponse response = null;

			try
			{
				response = (HttpWebResponse)request.GetResponse();
				responseBody = parseResponse(response);
			} catch (WebException e) {
				response = (HttpWebResponse)e.Response;
				responseBody = parseResponse(response);
			} finally {
				if (response.StatusCode != HttpStatusCode.OK) {
					createErrorObject ();
				}
			}

			return responseBody;
		}

		private void createErrorObject()
		{
			errorObject = new Error(responseObject);
		}

		private string parseResponse(HttpWebResponse response)
		{
			string responseBody = string.Empty;
			using (var responseStream = response.GetResponseStream())
			{
				if (responseStream != null)
					using (var reader = new StreamReader(responseStream))
					{
						responseBody = reader.ReadToEnd();
					}
			}

			responseObject = JObject.Parse (responseBody);
			responseContent = responseBody;

			return responseBody;
		}

		private string getEndpoint()
		{
			return Everypay.getApiUrl () + "/" + getResource ();
		}

		private string getQueryString(IDictionary<string, string> dict)
		{
			var list = new List<string>();
			foreach(var item in dict)
			{
				list.Add(item.Key + "=" + item.Value);
			}

			return string.Join("&", list);
		}

		private void reset()
		{
			errorObject = null;
			responseObject = null;
			responseContent = null;
		}
	}
}