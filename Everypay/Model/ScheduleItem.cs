using System;

namespace Everypay
{
	public class ScheduleItem
	{
		public string token { get; set;}

		public string schedule_date { get; set;}

		public string amount { get; set;}

		public string currency { get; set;}

		public string percentage { get; set;}

		public Payment payment { get; set;}
	}
}

