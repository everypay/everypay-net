using System;

namespace Everypay
{
	public class Customer : BaseModel
	{
		public string token { get; set;}

		public string date_created { get; set;}

		public string date_modified { get; set;}

		public string description { get; set; }

		public string email { get; set;}

		public string full_name { get; set;}

		public string is_active { get; set;}

		public string cvv_required { get; set;}

		public Card card { get; set;}

		public CustomerCards cards { get; set;}
	}
}

