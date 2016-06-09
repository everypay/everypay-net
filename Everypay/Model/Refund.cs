using System;

namespace Everypay
{
	public class Refund : BaseModel
	{
		public string token { get; set;}

		public string date_created { get; set;}

		public string description { get; set; }

		public string status { get; set;}

		public string amount { get; set;}

		public string fee_amount { get; set;}
	}
}

