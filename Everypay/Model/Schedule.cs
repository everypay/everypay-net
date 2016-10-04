using System;
using System.Collections.Generic;

namespace Everypay
{
	public class Schedule
	{
		public string token { get; set;}

		public string status { get; set;}

		public string amount { get; set;}

		public string currency { get; set;}

		public string description { get; set;}

		public string date_created { get; set;}

		public string schedule_type { get; set;}

		public Customer customer { get; set; }

		public List<ScheduleItem> items { get; set;}
	}
}

