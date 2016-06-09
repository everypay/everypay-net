using System;

namespace Everypay
{
	public class Token : BaseModel
	{
		public string token { get; set;}

		public string date_created { get; set;}

		public string is_used { get; set;}

		public string has_expired { get; set;}

		public string amount { get; set;}		

		public Card card { get; set;}
	}
}