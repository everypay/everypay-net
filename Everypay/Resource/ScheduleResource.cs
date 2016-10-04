using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Everypay
{
	public class ScheduleResource : Resource
	{

		public void create(
			Dictionary<string, string> data, 
			DateTime[] scheduleDates, 
			string[] scheduleRates
		) {
			data ["schedule_dates"] = this.stringifyScheduleDates(scheduleDates);
			data ["schedule_rates"] = string.Join (";", scheduleRates); 
			base.create (data);	
		}

		public void update(
			string token,
			Dictionary<string, string> data = null, 
			DateTime[] scheduleDates = null, 
			string[] scheduleRates = null
		) {
			if (null == data) {
				data = new Dictionary<string, string> ();
			}

			if (scheduleDates != null) {
				data["schedule_dates"] = this.stringifyScheduleDates(scheduleDates);
			}

			if (scheduleRates != null) {
				data ["schedule_rates"] = string.Join (";", scheduleRates);
			}

			base.update (token, data);
		}

		public Schedule getObject()
		{
			return JsonConvert.DeserializeObject<Schedule>(responseContent);
		}

		protected override string getResource()
		{
			return "schedules";
		}

		private string stringifyScheduleDates(DateTime[] scheduleDates)
		{
			string scheduleDatesString = "";
			foreach (DateTime d in scheduleDates) {
				scheduleDatesString = scheduleDatesString + d.ToString ("yyyy-MM-dd'T'HH':'mm':'sszzz") + ";";
			}
			char[] toTrim = { ';' };
			return WebUtility.UrlEncode (scheduleDatesString.Trim (toTrim));
		}
	}
}