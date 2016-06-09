using System;

namespace Everypay
{
	public class Card : BaseModel
	{
		public string token { get; set;}

		public string expiration_month { get; set;}

		public string expiration_year { get; set;}

		public string last_four { get; set;}

		public string type { get; set;}

		public string holder_name { get; set;}

		public string supports_installments { get; set;}

		public string max_installments { get; set;}

		public string status { get; set;}

		public string friendly_name { get; set;}

		public string cvv_required { get; set;}
	}
}