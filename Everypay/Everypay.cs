using System;

namespace Everypay
{
	public static class Everypay
	{
		const string Version = "0.1.0";

		public static bool isTest = false;

		public static string apiKey { get; set; }

		const string apiUrl = "https://api.everypay.gr";

		const string testApiUrl = "https://sandbox-api.everypay.gr";

		public static string getApiUrl()
		{
			return isTest ? testApiUrl : apiUrl;
		}

		public static string getVersion()
		{
			return Version;
		}
	}
}

