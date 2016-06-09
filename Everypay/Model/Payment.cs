using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Everypay
{
	public class Payment : BaseModel
	{
		public string token { get; set;}

		public string date_created { get; set;}

		public string description { get; set; }

		public string currency { get; set;}

		public string status { get; set;}

		public string amount { get; set;}

		public string refund_amount { get; set;}

		public string fee_amount { get; set;}

		public string payee_email { get; set;}

		public string payee_phone { get; set;}

		public string refunded { get; set;}

		public Card card { get; set; }

		public List<Refund> refunds { get; set;}

		public string installments_count { get; set;}

		public List<Payment> installments { get; set;}
	}
}